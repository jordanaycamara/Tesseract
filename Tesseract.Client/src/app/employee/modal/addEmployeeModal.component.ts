import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Component, Input, Output} from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../employee.service';
import { EventEmitter } from '@angular/core';
import { Dependent } from '../../models/Dependent';
import { ResourcesService } from '../../resources/resources.services';


@Component({
  selector: 'add-employee-modal',
  templateUrl: './addEmployeeModal.component.html',
  styleUrls: ['./addEmployeeModal.component.scss']
})

export class AddEmployeeModalComponent {
  employee: Employee;
  @Output() onClose = new EventEmitter();
  @Input() isNew = true;

  constructor(private modalService: NgbModal, private employeeService: EmployeeService, private resourcesService: ResourcesService) {
  }

  open(content) {
    if (this.isNew) {
      this.employee = new Employee();
      var ethan = new Dependent();
      ethan.firstName = "Ethan";
      ethan.lastName = "Camara";
      this.employee.dependents = [ethan];
    }
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        this.employeeService.saveEmployee(result).then( (response: [Employee]) => {
          this.onClose.emit();
        });
    });
  }

  onDelete(dependent) {
    this.resourcesService._.remove(this.employee.dependents, {
      id: dependent.id
    });
  }
}