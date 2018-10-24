import { AbstractHttpService } from "../common/abstractHttp.service";
import { ResourcesService } from "../resources/resources.services";
import { Injectable } from "@angular/core";

@Injectable()
export class CostReportService {

    constructor(private resourcesService: ResourcesService, private abstractService: AbstractHttpService) {

    }

    getCostReport(type: number) {
        var url = this.resourcesService.serviceUrls.cost + "/" + type;
        return this.abstractService.get(url);
    }
}