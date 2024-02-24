import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from 'src/app/api/order/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderApi {
  API: string='https://localhost:7217/api/purchases'

  constructor(private clienteHttp:HttpClient) { };

  GetOrders(): Observable<any> {
    return this.clienteHttp.get(this.API);
  }

  CreateOrder(order: Order): Observable<any> {
    let data = new Order(order);
    console.log (data);
    return this.clienteHttp.post(this.API, data);
  }

}