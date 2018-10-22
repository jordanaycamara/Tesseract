import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Tesseract';
  tabs = [
    { link : '/Employees', title : 'Employees' },
    { link : '/Cost', title : 'Cost Report' }
  ];

  selectedTab = this.tabs[0];

  getTabClass(tab) {
    return this.selectedTab === tab ? "active" : "";
  }

  setSelectedTab(tab) {
    this.selectedTab = tab;
  }
}
