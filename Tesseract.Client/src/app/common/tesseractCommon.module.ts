import { EditCellRendererComponent } from "./cellRenderer/editCell/editCellRenderer.component";
import { AgGridModule } from "ag-grid-angular";
import { ThirdPartyModule } from "../thirdparty/thirdparty.module";
import { NgModule } from "@angular/core";
import { DeleteCellRendererComponent } from "./cellRenderer/deleteCell/deleteCellRenderer.component";


@NgModule({
    declarations: [
        EditCellRendererComponent,
        DeleteCellRendererComponent
    ],
    exports: [
        EditCellRendererComponent,
        DeleteCellRendererComponent,
        AgGridModule
    ],
    imports: [
        ThirdPartyModule
    ],
    providers: [],
    bootstrap: [EditCellRendererComponent, DeleteCellRendererComponent]
  })
  export class TesseractCommonModule { }
