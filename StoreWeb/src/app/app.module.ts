import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './modules/shared/shared.module';
import { ProductsModule } from '@products/products.module';
import { OrdersModule } from '@orders/orders.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    OrdersModule,
    ProductsModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
