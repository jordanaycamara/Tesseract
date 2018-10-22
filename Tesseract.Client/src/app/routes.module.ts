import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { CostReportComponent } from './cost/costReport.component';

const routes: Routes = [
  { path: '',
    redirectTo: 'Employees',
    pathMatch: 'full'
  },
  { path: 'Employees', component: EmployeeComponent },
  { path: 'Cost', component: CostReportComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class RoutesModule { }
