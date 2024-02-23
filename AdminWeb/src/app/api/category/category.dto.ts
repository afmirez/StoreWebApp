import { Category } from "./category.model"; 
import { CategoryState } from "./categoryState/categoryState.model";

export class CreateUpdateCategoryDTO {
    public readonly id: number;
    public readonly name: string;
    public readonly CategoryStateId: number;
  
  constructor(data: Category) {
        this.id = parseInt(data.id);
        this.name = data.name;
        this.CategoryStateId = 1;
  }
}