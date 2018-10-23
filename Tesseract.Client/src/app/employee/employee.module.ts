import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { ThirdPartyModule } from '../thirdparty/thirdparty.module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TesseractCommonModule } from '../common/tesseractCommon.module';


@NgModule({
  declarations: [
    EmployeeComponent,
    AddEmployeeModalComponent
  ],
  imports: [
      CommonModule,
      FormsModule,
      ThirdPartyModule,
      TesseractCommonModule
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
