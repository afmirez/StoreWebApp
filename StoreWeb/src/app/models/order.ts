export interface FullPurchase {
    PurchaseData: PurchaseData;
    PurchaseProductData: PurchaseProductData[];
  }

export interface PurchaseData {
    Date: Date;
    Total: number;
    CustomerName: string;
    CustomerDocumentId: string;
    CustomerPhone: string;
    CustomerEmail: string;
    CustomerAddress: string;
  }
  
  export interface PurchaseProductData {
    Quantity: number;
    TotalPrice: number;
    ProductId: number;
  }