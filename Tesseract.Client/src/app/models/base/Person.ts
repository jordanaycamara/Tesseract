import { ResourcesService } from "../../resources/resources.services";

export class Person {
    id: string;
    firstName: string;
    lastName: string;

    constructor(resourcesService: ResourcesService) {
        this.id = resourcesService.constants.emptyGuid;
    }
}