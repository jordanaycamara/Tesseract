import { NgModule } from '@angular/core';
import { CostReportComponent } from './costReport.component';
import { CostReportService } from './costReport.service';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
      CostReportComponent
  ],
  imports: [
      CommonModule
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
