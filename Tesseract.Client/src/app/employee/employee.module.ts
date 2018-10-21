import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';

@NgModule({
  declarations: [
    EmployeeComponent
  ],
  imports: [
  ],
  exports:[
      EmployeeComponent
  ],
  providers: [],
  bootstrap: [EmployeeComponent]
})
export class EmployeeModule { }
