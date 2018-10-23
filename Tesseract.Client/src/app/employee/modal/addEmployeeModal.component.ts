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
  dependent: Dependent;

  constructor(private modalService: NgbModal, private employeeService: EmployeeService, private resourcesService: ResourcesService) {
  }

  open(content) {
    this.dependent = new Dependent(this.resourcesService);

    if (this.isNew) {
      this.employee = new Employee(this.resourcesService);
    }
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        this.employeeService.saveEmployee(result).then( (response: [Employee]) => {
          this.onClose.emit();
        });
    }, (reason) => {

    });
  }

  validateEmployee() {
    return this.employee.firstName && this.employee.lastName;
  }

  validateDependent() {
    return this.dependent.firstName && this.dependent.lastName;
  }

  onAdd() {
    if (this.dependent.id) {

    } else {
    }
    this.employee.dependents.push(this.dependent);
    this.dependent = new Dependent(this.resourcesService);
  }

  onEdit(dependent) {
    this.removeFromDependents(dependent);
    this.dependent = dependent;
  }

  onDelete(dependent) {
    this.removeFromDependents(dependent);
  }

  private removeFromDependents(dependent) {
    this.resourcesService._.remove(this.employee.dependents, function(object) {
      return object === dependent;
    });
  }
}