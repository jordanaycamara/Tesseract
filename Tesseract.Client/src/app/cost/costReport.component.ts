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

    constructor(private service: CostReportService) {

    }

    ngOnInit() {
        this.service.getCostReport().then((response: any) => {
             this.costReport = response;
        });
    }
}