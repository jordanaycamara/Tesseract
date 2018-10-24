import { NgModule } from '@angular/core';
import { CostReportComponent } from './costReport.component';
import { CostReportService } from './costReport.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
      CostReportComponent
  ],
  imports: [
      CommonModule,
      FormsModule
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
