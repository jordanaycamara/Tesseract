import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { ResourcesService } from './resources/resources.services';

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

  constructor(private router: Router, private resourcesService: ResourcesService) {
  }

  getTabClass(tab) {
    var classes = ['btn', 'btn-outline-primary', 'navButton'];
    if (this.selectedTab === tab) {
      classes.push('active');
    }
    return classes;
  }

  ngOnInit() {
    this.router.events.subscribe((event) => {
      this.getInitialTab(event);
    });
  }

  getInitialTab(event) {
    if (event instanceof NavigationEnd && event.url) {
      var selectedTab = this.resourcesService._.find(this.tabs, function(element) {
        return element.link == event.url;
      });

      if (selectedTab) {
        this.selectedTab = selectedTab;
      }
      return;
    }
  }

  onClick(tab) {
    this.selectedTab = tab;
    this.router.navigate([tab.link]);
  }
}
