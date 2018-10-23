import { Person } from "./base/Person";
import { Dependent } from "./Dependent";
import { ResourcesService } from "../resources/resources.services";

export class Employee extends Person {
    dependents: Dependent[] = [];

    constructor(resourcesService: ResourcesService) {
        super(resourcesService)
    }
}