import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';
import {GridOptions, Grid} from "ag-grid-community";

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
    gridOptions = <GridOptions>{
        columnDefs: [
            {headerName: 'First Name', field: 'firstName' },
            {headerName: 'Last Name', field: 'lastName' }
        ],

        enableColResize: true,
        enableSorting: true,
        rowSelection: 'single',
    };

    constructor(private service: EmployeeService) {

    }

    ngOnInit() {
        this.service.getEmployees().then((response: any) => {
             this.gridOptions.api.setRowData(response);
        });
    }
}