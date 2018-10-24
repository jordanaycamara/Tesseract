import { Component } from '@angular/core';
import { CostReportService } from './costReport.service';
import { CostReport } from '../models/CostReport';

@Component({
  selector: 'cost-report',
  templateUrl: './costReport.component.html',
  styleUrls: ['./costReport.component.scss']
})
export class CostReportComponent {
    costReport: CostReport = new CostReport();
    selectedReport: number;

    constructor(private service: CostReportService) {

    }

    ngOnInit() {
        this.getCostReport(1);
    }

    onClick(type) {
        this.selectedReport = type;
        this.getCostReport(type);
    }

    getRadioButtonClass(type) {
        var classes = ['btn', 'btn-outline-primary'];
        if (this.selectedReport == type) {
          classes.push('active');
        }
        return classes;
      }

    private getCostReport(type: number) {
        this.service.getCostReport(type).then((response: any) => {
            this.costReport = response;
       });
    }
}