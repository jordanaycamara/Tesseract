import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { RoutesModule } from './routes.module';
import { EmployeeModule } from './employee/employee.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RoutesModule,
    EmployeeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
