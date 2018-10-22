import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Component} from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../employee.service';


@Component({
  selector: 'add-employee-modal',
  templateUrl: './addEmployeeModal.component.html',
  styleUrls: ['./addEmployeeModal.component.scss']
})

export class AddEmployeeModalComponent {
  employee = new Employee();

  constructor(private modalService: NgbModal, private employeeService: EmployeeService) {}

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        this.employeeService.saveEmployee(result);
    });
  }
}