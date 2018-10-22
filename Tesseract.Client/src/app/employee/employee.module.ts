import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';

@NgModule({
  declarations: [
    EmployeeComponent
  ],
  imports: [
  ],
  exports:[
      EmployeeComponent
  ],
  providers: [
      EmployeeService
  ],
  bootstrap: [EmployeeComponent]
})
export class EmployeeModule { }
