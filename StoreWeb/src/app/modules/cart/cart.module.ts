import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartListComponent } from './cart-list/cart-list.component';
import { FormsModule } from '@angular/forms';
import { ProductCartService } from '../../shared/product-cart.service';
import { CartService } from './cart.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CartListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ProductCartService,
    CartService,
  ]
})

export class CartModule { }