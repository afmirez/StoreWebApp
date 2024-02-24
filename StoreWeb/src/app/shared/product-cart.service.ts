import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Product } from 'src/app/models/product';
import { PurchaseProductData } from '../models/order';


@Injectable({
  providedIn: 'root',
})
export class ProductCartService {
  private selectedProductsSubject = new BehaviorSubject<PurchaseProductData[]>([]);
  selectedProducts$: Observable<PurchaseProductData[]> = this.selectedProductsSubject.asObservable();

  constructor() {}

  addProductToCart(product: Product): void {
    const existingProducts = this.selectedProductsSubject.getValue();
    const existingProductIndex = existingProducts.findIndex(p => p.ProductId === product.id);

    if (existingProductIndex !== -1) {
      existingProducts[existingProductIndex].Quantity += 1;
      existingProducts[existingProductIndex].TotalPrice += product.price;
    } else {
      const newProduct: PurchaseProductData = {
        Quantity: 1,
        TotalPrice: product.price,
        // Por falta de tiempo use esta prpiedad y no trabaje en traer el nombre del producto en si. 
        ProductId: product.id,
      };
      existingProducts.push(newProduct);
      this.selectedProductsSubject.next([...existingProducts]);
    }
    this.selectedProductsSubject.next([...existingProducts]);
  }

  removeCartItem(productId: number): void {
    const existingProducts = this.selectedProductsSubject.getValue();
    const updatedProducts = existingProducts.filter(p => p.ProductId !== productId);
    this.selectedProductsSubject.next([...updatedProducts]);
  }

  clearCart(): void {
    this.selectedProductsSubject.next([]);
  }
}