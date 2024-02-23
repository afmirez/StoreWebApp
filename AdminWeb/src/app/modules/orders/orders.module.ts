import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersPage } from './pages/orders/orders.page';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    OrdersPage
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    FormsModule
  ]
})
export class OrdersModule { }
