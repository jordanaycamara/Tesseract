import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { ThirdPartyModule } from '../thirdparty/thirdparty.module';



@NgModule({
  declarations: [
    EmployeeComponent,
    AddEmployeeModalComponent
  ],
  imports: [
      ThirdPartyModule
  ],
  exports:[
      EmployeeComponent,
      AddEmployeeModalComponent
  ],
  providers: [
      EmployeeService
  ],
  bootstrap: [EmployeeComponent, AddEmployeeModalComponent]
})
export class EmployeeModule { }
