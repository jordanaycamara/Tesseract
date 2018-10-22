import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';

// third-party modules
import { AgGridModule } from 'ag-grid-angular';
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    EmployeeComponent,
    AddEmployeeModalComponent
  ],
  imports: [
      AgGridModule.withComponents([]),
      NgbModule
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
