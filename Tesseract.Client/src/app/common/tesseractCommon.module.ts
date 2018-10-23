import { EditCellRendererComponent } from "./cellRenderer/editCellRenderer.component";
import { AgGridModule } from "ag-grid-angular";
import { ThirdPartyModule } from "../thirdparty/thirdparty.module";
import { NgModule } from "@angular/core";


@NgModule({
    declarations: [
        EditCellRendererComponent
    ],
    exports: [
        EditCellRendererComponent,
        AgGridModule
    ],
    imports: [
        ThirdPartyModule
    ],
    providers: [],
    bootstrap: [EditCellRendererComponent]
  })
  export class TesseractCommonModule { }
