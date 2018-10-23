import { AgRendererComponent, ICellRendererAngularComp } from "ag-grid-angular";
import { Component, Input, Output } from "@angular/core";
import { IAfterGuiAttachedParams, ICellRendererComp } from "ag-grid-community";

// create your cellRenderer as a Angular component
@Component({
    selector: 'delete-cell',
    templateUrl: './deleteCellRenderer.component.html'
})

export class DeleteCellRendererComponent implements ICellRendererAngularComp {
    private params: any;
    buttonId: string;

    refresh(params: any) {
        return true;
    }

    afterGuiAttached?(params?: IAfterGuiAttachedParams) {

    }

    agInit(params: any) {
        this.params = params;
        this.buttonId = 'deleteButton' + this.params.rowIndex;
    }
}