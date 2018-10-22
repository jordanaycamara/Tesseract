import { Person } from "./base/Person";
import { Dependent } from "./Dependent";

export class Employee extends Person {
    dependents: [Dependent];

    constructor() {
        super()
    }
}