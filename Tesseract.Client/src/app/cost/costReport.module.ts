import { NgModule } from '@angular/core';
import { CostReportComponent } from './costReport.component';
import { CostReportService } from './costReport.service';

@NgModule({
  declarations: [
      CostReportComponent
  ],
  imports: [
  ],
  exports:[
      CostReportComponent
  ],
  providers: [
      CostReportService
  ],
  bootstrap: [CostReportComponent]
})
export class CostReportModule { }
