import { CategoryState } from "./categoryState/categoryState.model";

export class Category{
    id!:string;
    name!: string;

    categoryState!: CategoryState;

    constructor(data: any = null) {
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.id = data.id ? data.id : null;
        this.name = data.name ? data.name : null;
        this.categoryState = new CategoryState (data.categoryState);
    }
}