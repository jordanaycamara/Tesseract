import { NgModule } from '@angular/core';
import { AgGridModule } from 'ag-grid-angular';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
    ],
    exports: [
        NgbModule,
        AgGridModule
    ],
    imports: [
      AgGridModule.withComponents([]),
      NgbModule.forRoot()
    ],
    providers: [],
    bootstrap: []
  })
  export class ThirdPartyModule { }
