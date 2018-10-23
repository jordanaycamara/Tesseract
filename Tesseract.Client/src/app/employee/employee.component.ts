import { Component, ViewChild } from '@angular/core';
import { EmployeeService } from './employee.service';
import {GridOptions, Grid} from "ag-grid-community";
import { AddEmployeeModalComponent } from './modal/addEmployeeModal.component';
import { Employee } from '../models/Employee';
import { EditCellRendererComponent } from '../common/cellRenderer/editCell/editCellRenderer.component';
import { DeleteCellRendererComponent } from '../common/cellRenderer/deleteCell/deleteCellRenderer.component';

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
            { headerName: '', width: 20, cellRendererFramework: EditCellRendererComponent, onCellClicked: this.editEmployee },
            { headerName: '', width: 20, cellRendererFramework: DeleteCellRendererComponent, onCellClicked: this.deleteEmployee }
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

    private deleteEmployee(gridData) {
        gridData.context.componentParent.service.deleteEmployee(gridData.data.id).then((response: any) => {
            this.getEmployees();
        });
    }

    private editEmployee(gridData) {
        gridData.context.componentParent.modalComponent.open(gridData.data);
    }
}