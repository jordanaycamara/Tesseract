import { Discount } from "./Discount";

export class Cost {
    name: string;
    amount: number;
    dependents: Cost[] = [];
    discounts: Discount[] = [];
}