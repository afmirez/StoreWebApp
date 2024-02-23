import { Component, ElementRef, ViewChild } from '@angular/core';
import { OrderApi } from 'src/app/api/order/order.api';
import { Order } from 'src/app/api/order/order.model'; 

@Component({
  selector: 'app-orders',
  templateUrl: './orders.page.html',
  styleUrls: ['./orders.page.css']
})
export class OrdersPage {
@ViewChild("modal") modal: ElementRef

public orders: Order[] =[];

public orderVariable: Order = new Order();


constructor(
  private orderAPI: OrderApi) { 
}

public ngOnInit(): void {
  this.orderAPI.GetOrders().subscribe(result=>{
  this.orders= result.data.map((order: any)=>new Order(order));
  console.log(this.orders);
  })
}

public openModal(){
  this.modal.nativeElement.classList.add("open")
}

public closeModal(){
  this.modal.nativeElement.classList.remove("open")
}
@ViewChild("edit") edit: ElementRef

public openEdit(){
  this.edit.nativeElement.classList.add("open")
}

public closeEdit(){
  this.edit.nativeElement.classList.remove("open")
}

public createOrder(): void {
  this.orderAPI.CreateOrder(this.orderVariable).subscribe({
    next: (response) => {
      console.log('Response:', response);
      if(!response.success){
        alert(response.messages.join('\n'));
      }
      else{
      }      
    }
  });
}

}
