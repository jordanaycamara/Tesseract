import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';

// third-party modules
import { AgGridModule } from 'ag-grid-angular';

@NgModule({
  declarations: [
    EmployeeComponent
  ],
  imports: [
      AgGridModule.withComponents([])
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
