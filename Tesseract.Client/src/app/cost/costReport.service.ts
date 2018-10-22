import { AbstractHttpService } from "../common/abstractHttp.service";
import { ResourcesService } from "../resources/resources.services";
import { Injectable } from "@angular/core";

@Injectable()
export class CostReportService {

    constructor(private resourcesService: ResourcesService, private abstractService: AbstractHttpService) {

    }

    getCostReport() {
        return this.abstractService.get(this.resourcesService.serviceUrls.cost);
    }
}