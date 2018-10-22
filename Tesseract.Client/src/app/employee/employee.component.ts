import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
    employees: any;

    constructor(private employeeService: EmployeeService) {

    }

    ngOnInit() {
        this.employeeService.getEmployees().then((response: any) => {
             this.employees = response;
        });
    }
}