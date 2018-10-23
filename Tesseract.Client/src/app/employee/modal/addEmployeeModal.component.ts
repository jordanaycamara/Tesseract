import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {Component, Input, Output, ViewChild, ElementRef} from '@angular/core';
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
  @Output() onClose = new EventEmitter();
  isNew: boolean;
  employee: Employee;
  dependent: Dependent;

  @ViewChild('content')
  content: ElementRef;

  constructor(private modalService: NgbModal, private employeeService: EmployeeService, private resourcesService: ResourcesService) {
  }

  open(employee: Employee = null) {
    this.dependent = new Dependent(this.resourcesService);

    var isNew = !employee;
    this.employee = !isNew ? employee : new Employee(this.resourcesService);
    this.isNew = isNew;

    this.modalService.open(this.content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
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