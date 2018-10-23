import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Tesseract';
  tabs = [
    { link : '/Employees', title : 'Employees' },
    { link : '/Cost', title : 'Report' }
  ];

  selectedTab = this.tabs[0];

  constructor(private router: Router) {

  }

  getTabClass(tab) {
    var classes = ['btn', 'btn-outline-primary', 'navButton'];
    if (this.selectedTab === tab) {
      classes.push('active');
    }
    return classes;
  }

  onClick(tab) {
    this.selectedTab = tab;
    this.router.navigate([tab.link]);
  }
}
