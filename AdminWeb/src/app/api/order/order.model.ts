export class Order{
    id!:string;
    date!: Date;
    total!: number;
    customerName!: string;
    customerDocumentId!: string;
    customerPhone!: number;
    customerEmail!: string;
    customerAddress!: string;

    constructor(data: any = null) {
        //Técnica de deep copy para eliminar referencias de memoria
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.id = data.id ? data.id : null;
        this.date = data.date ? data.date : null;
        this.total = data.total ? data.total : null;
        this.customerName = data.customerName ? data.customerName : null;
        this.customerDocumentId = data.customerDocumentId ? data.customerDocumentId : null;
        this.customerPhone = data.customerPhone ? data.customerPhone : null;
        this.customerEmail = data.customerEmail ? data.customerEmail : null;
        this.customerAddress = data.customerAddress ? data.customerAddress : null;
    }
}