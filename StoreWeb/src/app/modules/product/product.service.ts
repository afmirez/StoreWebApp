import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductData } from '../../models/product';
import { CategoryData } from '../../models/category';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrlProducts = environment.apiUrl + '/api/products';
  private apiUrlCategories = environment.apiUrl + '/api/categories';

  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<ProductData> { 
    return this.http.get<ProductData>(this.apiUrlProducts);
  }

  getAllCategories(): Observable<CategoryData> { 
    return this.http.get<CategoryData>(this.apiUrlCategories);
  }

  getFilteredProducts(
    categoryId: string,
    productName: string = '',
    priceFrom?: number,
    priceTo?: number
  ): Observable<ProductData> {
    let params = new HttpParams();
  
    if (categoryId && categoryId !== '0') {
      params = params.set('CategoryId', categoryId);
    }
    if (productName) {
      params = params.set('Name', productName);
    }
    if (priceFrom !== undefined) {
      params = params.set('PriceFrom', priceFrom.toString());
    }
    if (priceTo !== undefined) {
      params = params.set('PriceTo', priceTo.toString());
    }
  
    console.log('Sending params:', params.toString());
  
    return this.http.get<ProductData>(this.apiUrlProducts, { params });

    
  }
}