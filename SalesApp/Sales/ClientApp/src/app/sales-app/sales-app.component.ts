import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { IDropdownSettings } from 'ng-multiselect-dropdown';


@Component({
  selector: 'app-sales-app',
  templateUrl: './sales-app.component.html'
})
export class SalesAppComponent implements OnInit {

  public sales: Sales[];
  public baseUrl: string;
  public states: Array<any> = [];
  public years: Array<any> = [];
  public cols: Array<String> = [];
  public countries: Array<any> = [];
  public groupedByMonth: Map<string, any[]>;
  public show: boolean;

  profileForm = new FormGroup({
    country: new FormControl(''),
    state: new FormControl(''),
    year: new FormControl(''),
    selectedStates: new FormControl('')
  });

  dropdownList: Array<any> = [];
  selectedItems: Array<any> = [];
  dropdownSettings: IDropdownSettings = {
    singleSelection: false,
    textField: 'state',
    itemsShowLimit: 3
  };


  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getAllCountries();
  }

  async onCountryChange() {
    await this.getSalesData();
    console.log(this.sales);
    this.years = [...new Set(this.sales.map(item => item.year))];
    console.log("years" + this.years);
    this.dropdownList = [...new Set(this.sales.map(item => item.state))];
    console.log("dropdown" + this.dropdownList);
  }

  getSalesData() {
    let promise = new Promise((resolve, reject) => {
      this.http.get<Sales[]>("/api/sales/" + this.profileForm.get("country").value)
        .toPromise()
        .then(
          res => {
            this.sales = res;
            resolve();
          }
        );
    });
    return promise;
  }

  getAllCountries() {
    this.http.get<Countries[]>("/api/countries").subscribe(result => {
      result.forEach(r => this.countries.push(r.country));
    }, error => console.error(error));
  }

  fetchSalesData() {
    console.log(this.profileForm.value.selectedStates);
    for (var i = 0; i < this.profileForm.value.selectedStates.length; i++) {
      console.log(this.profileForm.value.selectedStates);
      if (this.cols.indexOf(this.profileForm.value.selectedStates[i]) == -1) {
        this.cols.push(this.profileForm.value.selectedStates[i]);
      }
    }
    this.groupedByMonth = this.groupBy(this.sales, s => s.month);
    this.getRows();
    this.getTotal();
  }

  getRows() {
    var tableRef = <HTMLTableElement>document.getElementById("myTable");
    for (let key of this.groupedByMonth.keys()) {
      console.log(this.groupedByMonth.get(key));
      var newRow = tableRef.insertRow(-1);
      var i = 0;
      var newCell = newRow.insertCell(i);
      var newText = document.createTextNode(key);
      newCell.appendChild(newText);
      let found = false;
      for (let col of this.cols) {
        for (let record of this.groupedByMonth.get(key)) {
          if (record.state == col) {
            found = true;
            i++;
            var newCell = newRow.insertCell(i);
            var newText = document.createTextNode(record.salesData);
            newCell.appendChild(newText);
          }
        }
        if (!found) {
          i++;
          var newCell = newRow.insertCell(i);
          var newText = document.createTextNode("00");
          newCell.appendChild(newText);
        }
        found = false;
      }
      i = 0;
    }

  }


  getTotal() {
    var tableRef = <HTMLTableElement>document.getElementById("myTable");
    var newRow = tableRef.insertRow(-1);
    var i = 0;
    var newCell = newRow.insertCell(i);
    var newText = document.createTextNode("Total");
    newCell.appendChild(newText);
    for (let col of this.cols) {
      let sum = 0;
      for (let key of this.groupedByMonth.keys()) {
        for (let record of this.groupedByMonth.get(key)) {
          if (record.state == col) {
            sum = sum + Number(record.salesData);
          }
        }
      }
      i++;
      var newCell = newRow.insertCell(i);
      var newText = document.createTextNode(sum.toString());
      newCell.appendChild(newText);
      sum = 0;

    }
  }


  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }


  groupBy(list, keyGetter) {
    const map = new Map();
    list.forEach((item) => {
      const key = keyGetter(item);
      const collection = map.get(key);
      if (!collection) {
        map.set(key, [item]);
      } else {
        collection.push(item);
      }
    });
    return map;
  }


}

interface Sales {
  state: string;
  country: string;
  month: string;
  year: string;
  salesData: string;
}

interface Countries {
  country: string;
}

interface years {
  Id: number;
}
