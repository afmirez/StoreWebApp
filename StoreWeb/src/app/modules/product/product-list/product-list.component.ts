import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductData, Product } from '../../../models/product';
import { CategoryData } from '../../../models/category';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from '../product.service';
import { ProductCartService } from 'src/app/shared/product-cart.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit {

  products: ProductData = { data: [] };
  filteredProducts: ProductData = { data: [] };
  categories: CategoryData = { data: [] };

  //Propiedades del filtro. 
  categoryId: string = '';
  productName: string = '';
  priceFrom: number | undefined ;
  priceTo: number | undefined ;

  constructor(private _productService: ProductService, private toastr: ToastrService, private productCartService : ProductCartService) { }

  ngOnInit(): void {
    this.loadAllProducts();
    this.loadAllCategories();
  }

  loadAllProducts() {
    const priceFromNumber = this.priceFrom != null ? +this.priceFrom : undefined;
    const priceToNumber = this.priceTo != null ? +this.priceTo : undefined;
    this._productService.getFilteredProducts(
      this.categoryId,
      this.productName,
      priceFromNumber,
      priceToNumber
    ).subscribe(data => {
      this.filteredProducts.data = data.data;
    });
  }

  loadAllCategories() {
    this._productService.getAllCategories().subscribe(data => {
      this.categories.data = data.data;
    });
  }

  applyFilter() {
    this.loadAllProducts();
  }

  addProductToCart(product: Product): void {
    this.productCartService.addProductToCart(product);
    this.toastr.success('Producto añadido al carrito!', 'Confirmacion:', {
      timeOut: 2500,
      closeButton: true,
      toastClass: 'custom-toast',
      positionClass: 'toast-top-center'
    });
  }
}