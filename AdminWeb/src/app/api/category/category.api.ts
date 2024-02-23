import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateUpdateCategoryDTO } from './category.dto'; 
import { Category } from 'src/app/api/category/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryApi {
  API: string='https://localhost:7217/api/categories'

  constructor(private clienteHttp:HttpClient) { };
  GetCategories(): Observable<any> {
    return this.clienteHttp.get(this.API);
  }

  CreateCategory(category: Category): Observable<any> {
    let data = new CreateUpdateCategoryDTO(category);
    console.log (data);
    return this.clienteHttp.post(this.API, data);
  }

  UpdateCategory(CategoryToUpdate: Category, categoryId: string, name: string) : Observable<any> {
    let data = new CreateUpdateCategoryDTO(CategoryToUpdate)
    return this.clienteHttp.put(`${this.API}/category/`, data);
}
}