import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductApi {
  API: string='https://localhost:7217/api/products'

  constructor(private clienteHttp:HttpClient) { };
  GetProducts(): Observable<any> {
    return this.clienteHttp.get(this.API);
  }
}