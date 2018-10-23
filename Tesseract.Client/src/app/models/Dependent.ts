import { Person } from "./base/Person";
import { ResourcesService } from "../resources/resources.services";

export class Dependent extends Person {
    constructor(resourcesService: ResourcesService) {
        super(resourcesService);
    }
}