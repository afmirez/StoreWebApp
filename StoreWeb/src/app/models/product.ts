export interface ProductData {
    data: Product[];
  }
  
export interface Product {
    id: number;
    name: string;
    description: string;
    productStock: number;
    price: number;
    categoryId: number;
    productStateId: number;
  }