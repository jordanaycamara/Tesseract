import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { RoutesModule } from './routes.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

import { EmployeeModule } from './employee/employee.module';
import { CostReportModule } from './cost/costReport.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RoutesModule,
    EmployeeModule,
    CostReportModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
