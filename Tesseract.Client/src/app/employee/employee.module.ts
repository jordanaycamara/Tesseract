import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { ThirdPartyModule } from '../thirdparty/thirdparty.module';
import { FormsModule } from '@angular/forms';
import {CommonModule} from '@angular/common';


@NgModule({
  declarations: [
    EmployeeComponent,
    AddEmployeeModalComponent
  ],
  imports: [
      FormsModule,
      ThirdPartyModule,
      CommonModule
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
