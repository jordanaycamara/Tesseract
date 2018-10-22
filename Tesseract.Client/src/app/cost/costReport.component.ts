import { Component } from '@angular/core';
import { CostReportService } from './costReport.service';

@Component({
  selector: 'cost-report',
  templateUrl: './costReport.component.html'
})
export class CostReportComponent {
    costReport: any = new Object();

    constructor(private service: CostReportService) {

    }

    ngOnInit() {
        this.service.getCostReport().then((response: any) => {
             this.costReport = response;
        });
    }
}