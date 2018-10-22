import { AbstractHttpService } from "../common/abstractHttp.service";
import { ResourcesService } from "../resources/resources.services";
import { Injectable } from "@angular/core";

@Injectable()
export class EmployeeService {

    constructor(private resourcesService: ResourcesService, private abstractService: AbstractHttpService) {

    }

    getEmployees() {
        return this.abstractService.get(this.resourcesService.serviceUrls.employee);
    }
}