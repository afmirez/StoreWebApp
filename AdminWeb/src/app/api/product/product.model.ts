import { Category } from "../category/category.model";
import { ProductState } from "./productState/productState.model";

export class Product{
    id!:string;
    name!: string;
    description!: string;
    productStock: number;
    price!: number;

    category!:Category;

    productState!: ProductState;

    constructor(data: any = null) {
        //Técnica de deep copy para eliminar referencias de memoria
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.id = data.id ? data.id : null;
        this.name = data.name ? data.name : null;
        this.description = data.description ? data.description : null;
        this.productStock = data.productStock;
        this.price = data.price ? data.price : null;
        this.category = new Category (data.category);
        this.productState = new ProductState (data.productState);
    }
}