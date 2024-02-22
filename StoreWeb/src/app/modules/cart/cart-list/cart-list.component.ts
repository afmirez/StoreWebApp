import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { FullPurchase } from 'src/app/models/order';
import { ToastrService } from 'ngx-toastr';
import { ProductCartService } from '../../../shared/product-cart.service';
import { CartService } from '../cart.service';
import Swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-cart-list',
  templateUrl: './cart-list.component.html',
  styleUrls: ['./cart-list.component.css']
})
export class CartListComponent implements OnInit, OnDestroy {

  private subscription!: Subscription;
  purchaseForm!: FormGroup;
  fullPurchase: FullPurchase = {
    PurchaseData: {
      Date: new Date(new Date().getTime() - 24 * 60 * 60 * 1000), 
      Total: 0,
      CustomerName: '',
      CustomerDocumentId: '',
      CustomerPhone: '',
      CustomerEmail: '',
      CustomerAddress: ''
    },
    PurchaseProductData: []
  };

  isPurchaseCompleted: boolean = false;

  constructor(
    private productCartService: ProductCartService,
    private cdr: ChangeDetectorRef,
    private cartService : CartService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.purchaseForm = this.formBuilder.group({
      customerName: ['', Validators.required],
      customerDocumentId: ['', Validators.required],
      customerPhone: ['', Validators.required],
      customerEmail: ['', [Validators.required, Validators.email]],
      customerAddress: ['', Validators.required]
    });

    this.subscription = this.productCartService.selectedProducts$.subscribe((selectedProducts) => {
      this.fullPurchase.PurchaseProductData = selectedProducts;
      this.calculateTotalPrice(); 
      this.cdr.detectChanges();
    });
  }
  
  createPurchase(): void {
    if (this.purchaseForm.valid) {
      this.fullPurchase.PurchaseData.CustomerName = this.purchaseForm.value.customerName;
      this.fullPurchase.PurchaseData.CustomerDocumentId = this.purchaseForm.value.customerDocumentId;
      this.fullPurchase.PurchaseData.CustomerPhone = this.purchaseForm.value.customerPhone;
      this.fullPurchase.PurchaseData.CustomerEmail = this.purchaseForm.value.customerEmail;
      this.fullPurchase.PurchaseData.CustomerAddress = this.purchaseForm.value.customerAddress;
    
      this.cartService.createPurchase(this.fullPurchase).subscribe(
        response => {
          console.log('Compra fue agregada con exito: ', response);
          this.purchaseForm.reset();
        },
        error => {
          console.error('La compra no pudo ser agregada: ', error);
        }
      );
      this.clearCart();
      this.toastr.success('La compra fue realizada', 'Confirmacion:', {
        timeOut: 2500,
        closeButton: true,
        toastClass: 'custom-toast custom-toast-success',
        positionClass: 'toast-top-center'
      });
    } else {
      console.error('El formulario no es valido....');
    }
  }

  calculateTotalPrice(): void {
    this.fullPurchase.PurchaseData.Total = this.fullPurchase.PurchaseProductData.reduce(
      (total, product) => total + product.TotalPrice,
      0
    );
  }

  resetPurchaseData(): void {
    this.fullPurchase.PurchaseData = {
      // Tuve un problema con date.now() ya que el API respondia que la fecha no podia ser mayor a la actual. Decidi hacerlo asi para poder avanzar.
      Date: new Date(new Date().getTime() - 24 * 60 * 60 * 1000),
      Total: 0,
      CustomerName: '',
      CustomerDocumentId: '',
      CustomerPhone: '',
      CustomerEmail: '',
      CustomerAddress: ''
    };
  }

  removeItemFromCart(productId: number): void {
    this.productCartService.removeCartItem(productId);
  }

  clearCart(): void {
    this.productCartService.clearCart();
    this.resetPurchaseData();
  }

  confirmEmptyCart() : void {
    Swal.fire({
      title: 'Estas seguro?',
      text: 'Esto vaciara tu carrito. Estas seguro que deseas continuar?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#785ce9',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si',
      cancelButtonText: 'No',
      customClass: 'my-swal-container'
    }).then((result) => {
      if (result.isConfirmed) {
        this.productCartService.clearCart();
        this.resetPurchaseData();
        Swal.fire('Listo!', 'Tu carrito se ha vaciado.', 'success');
      }
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}