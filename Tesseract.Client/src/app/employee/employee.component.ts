import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';
import {GridOptions, Grid} from "ag-grid-community";
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { Employee } from '../models/Employee';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  entryComponents: [AddEmployeeModalComponent]
})
export class EmployeeComponent {
    employees: [Employee];

    gridOptions = <GridOptions>{
        columnDefs: [
            {headerName: 'First Name', field: 'firstName' },
            {headerName: 'Last Name', field: 'lastName' }
        ],
        enableColResize: false,
        enableSorting: true,
        rowSelection: 'single',
    };

    constructor(private service: EmployeeService) {

    }

    ngOnInit() {
        this.service.getEmployees().then((response: [Employee]) => {
            this.employees = response;
            this.gridOptions.api.setRowData(response);
            this.gridOptions.api.sizeColumnsToFit();
        });
    }
}