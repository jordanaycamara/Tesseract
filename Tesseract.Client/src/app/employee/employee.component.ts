import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
    employees: any = new Object();

    constructor(private service: EmployeeService) {

    }

    ngOnInit() {
        this.service.getEmployees().then((response: any) => {
             this.employees = response;
        });
    }
}