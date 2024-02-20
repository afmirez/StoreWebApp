import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrls: ['./products.page.css']
})
export class ProductsPage {
  @ViewChild("modal") modal: ElementRef

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
}
