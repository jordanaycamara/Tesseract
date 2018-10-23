// angular modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

// shared modules
import { RoutesModule } from './routes.module';
import { AppComponent } from './app.component';

import { EmployeeModule } from './employee/employee.module';
import { CostReportModule } from './cost/costReport.module';
import { AgGridModule } from 'ag-grid-angular';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RoutesModule,
    EmployeeModule,
    CostReportModule,
    NgbModule,
    AgGridModule.withComponents([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
