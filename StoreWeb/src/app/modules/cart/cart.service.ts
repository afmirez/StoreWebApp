import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FullPurchase } from '../../models/order';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private apiUrlPurchase = environment.apiUrl + '/api/purchases';

  constructor(private http: HttpClient) { }

  createPurchase(fullPurchase: FullPurchase): Observable<any> {
    return this.http.post<any>(`${this.apiUrlPurchase}`, fullPurchase);
  }
  
}
