import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Component} from '@angular/core';


@Component({
  selector: 'add-employee-modal',
  templateUrl: './addEmployeeModal.component.html',
  styleUrls: ['./addEmployeeModal.component.scss']
})

export class AddEmployeeModalComponent {
  closeResult: string;

  constructor(private modalService: NgbModal) {}

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
}