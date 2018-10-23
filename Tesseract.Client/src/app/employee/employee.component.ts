import { Component, ViewChild } from '@angular/core';
import { EmployeeService } from './employee.service';
import {GridOptions, Grid} from "ag-grid-community";
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { Employee } from '../models/Employee';
import { EditCellRendererComponent } from '../common/cellRenderer/editCellRenderer.component';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  entryComponents: [AddEmployeeModalComponent, EditCellRendererComponent]
})
export class EmployeeComponent {
    employees: [Employee];
    @ViewChild(AddEmployeeModalComponent)
    modalComponent: AddEmployeeModalComponent;

    gridOptions = <GridOptions>{
        context: {
            componentParent: this
        },
        columnDefs: [
            { headerName: 'First Name', field: 'firstName' },
            { headerName: 'Last Name', field: 'lastName' },
            { headerName: '', width: 20, cellRendererFramework: EditCellRendererComponent, onCellClicked: this.editEmployee }
        ],
        enableColResize: false,
        enableSorting: true,
        rowSelection: 'single',
    };

    constructor(private service: EmployeeService) {

    }

    ngOnInit() {
        this.getEmployees();
    }

    onClose($event: any) {
        this.getEmployees();
    }

    private getEmployees() {
        this.service.getEmployees().then((response: [Employee]) => {
            this.employees = response;
            this.gridOptions.api.setRowData(response);
            this.gridOptions.api.sizeColumnsToFit();
        });
    }

    editEmployee(gridData) {
        gridData.context.componentParent.modalComponent.open(gridData.data);
    }
}