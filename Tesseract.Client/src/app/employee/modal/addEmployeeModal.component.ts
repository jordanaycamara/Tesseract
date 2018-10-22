import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Component, Input, Output} from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../employee.service';
import { EventEmitter } from '@angular/core';


@Component({
  selector: 'add-employee-modal',
  templateUrl: './addEmployeeModal.component.html',
  styleUrls: ['./addEmployeeModal.component.scss']
})

export class AddEmployeeModalComponent {
  employee: Employee;
  @Output() onClose = new EventEmitter();
  @Input() isNew = true;

  constructor(private modalService: NgbModal, private employeeService: EmployeeService) {
  }

  open(content) {
    if (this.isNew) {
      this.employee = new Employee();
    }
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        this.employeeService.saveEmployee(result).then( (response: [Employee]) => {
          this.onClose.emit();
        });
    });
  }
}