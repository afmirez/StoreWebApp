import { Component, ElementRef, ViewChild } from '@angular/core';
import { ProductApi } from 'src/app/api/product/product.api';
import { Product } from 'src/app/api/product/product.model'; 


@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrls: ['./products.page.css']
})
export class ProductsPage {
  @ViewChild("modal") modal: ElementRef

  public products: Product[] =[];

  constructor(
    private productAPI: ProductApi) { 
  
  }

  public ngOnInit(): void {
    this.productAPI.GetProducts().subscribe(result=>{
    this.products= result.data.map((order: any)=>new Product(order));
    console.log(this.products);
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
}
