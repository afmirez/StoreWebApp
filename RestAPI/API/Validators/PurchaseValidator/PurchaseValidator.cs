using API.Data;
using API.Data.Models;
using API.DataTransferObjects;

namespace API.Validators
{
    public class PurchaseValidator : IPurchaseValidator
    {
        private readonly StoreDB _database;
        public PurchaseValidator(StoreDB database)
        {
            _database = database;
        }

        public bool ValidateInsert(PurchaseRequest data, List<string> messages)
        {

            List<string> innerMessages = new();

            // Extraer Purchase
            InsertPurchaseDTO? purchase = data.PurchaseData;

            // Extraer la lista que contiene los elementos 
            List<InsertPurchaseProductDTO>? purchaseProductsList = data.PurchaseProductData;

            //PURCHASE VALIDATORS:
            // purchase.Date
            if (!purchase.Date.HasValue)
            {
                innerMessages.Add("La fecha de la compra es requerida");
            }
            else if (purchase.Date > DateTime.Now)
            {
                innerMessages.Add("La fecha de compra no puede ser mayor a la fecha actual");
            }

            // purchase.Total
            if (!purchase.Total.HasValue)
            {
                innerMessages.Add("Total de la compra es requerido");
            }
            else if (purchase.Total <= 0)
            {
                innerMessages.Add("Total de la compra debe ser mayor a 0");
            }

            // Purchase.CustomerName 
            if (string.IsNullOrWhiteSpace(purchase?.CustomerName))
            {
                innerMessages.Add("Nombre del cliente es requerido");
            }
            else if (purchase.CustomerName.Length > 50)
            {
                innerMessages.Add("Nombre del cliente no puede contener mas de 50 caracteres");
            }

            // purchase.DocumentId
            if (string.IsNullOrWhiteSpace(purchase?.CustomerDocumentId))
            {
                innerMessages.Add("Documento del cliente es requerido");
            }
            else if (purchase.CustomerDocumentId.Trim().Length != 9)
            {
                innerMessages.Add("Documento del cliente debe tener nueve digitos solamente. ");
            }
            else if (purchase.CustomerDocumentId.StartsWith("0"))
            {
                innerMessages.Add("Documento del cliente no puede comenzar por 0");
            }
            else if (!int.TryParse(purchase.CustomerDocumentId, out int num) || num < 0)
            {
                innerMessages.Add("Documento del cliente debe tener numeros solamente. ");
            }

            // purchase.CustomerPhone
            if (string.IsNullOrWhiteSpace(purchase?.CustomerPhone))
            {
                innerMessages.Add("Teléfono del cliente es requerido");
            }
            else if (purchase.CustomerPhone.Length > 8)
            {
                innerMessages.Add("Teléfono del cliente no puede contener más de 8 caracteres");
            }
            else if (purchase.CustomerPhone.StartsWith("0"))
            {
                innerMessages.Add("Teléfono del cliente no puede empezar con 0");
            }

            // purchase.CustomerEmail
            if (string.IsNullOrWhiteSpace(purchase?.CustomerEmail))
            {
                innerMessages.Add("Correo electrónico del cliente es requerido");
            }
            else if (purchase.CustomerEmail.Length > 250)
            {
                innerMessages.Add("Correo electrónico del cliente no puede contener más de 250 caracteres");
            }

            // purchase.CustomerAddress
            if (string.IsNullOrWhiteSpace(purchase?.CustomerAddress))
            {
                innerMessages.Add("La dirección del cliente es requerida");
            }
            else if (purchase.CustomerAddress.Length > 250)
            {
                innerMessages.Add("La dirección del cliente no puede contener más de 250 caracteres");
            }


            //PURCHASEPRODUCT VALIDATORS:
            //La lista no puede ser = null o estar sin elementos. 
            if (purchaseProductsList == null || !purchaseProductsList.Any())
            {
                innerMessages.Add("La lista de productos de compra está vacía. Debe contener al menos un producto.");
            }
            else
            {
                foreach (var purchaseProductElement in purchaseProductsList)
                {
                    // purchaseProduct.Quantity
                    if (!purchaseProductElement.Quantity.HasValue)
                    {
                        innerMessages.Add("La cantidad del producto es requerida");
                    }
                    else if (purchaseProductElement.Quantity <= 0)
                    {
                        innerMessages.Add("La cantidad del producto debe ser mayor a 0");
                    }

                    //purchaseProduct.TotalPrice
                    if (!purchaseProductElement.TotalPrice.HasValue)
                    {
                        innerMessages.Add("El precio total de la transaccion es requerido");
                    }
                    else if (purchaseProductElement.TotalPrice <= 0)
                    {
                        innerMessages.Add("El precio total del producto debe ser mayor a 0");
                    }

                    // purchaseProduct.ProductId
                    if (!purchaseProductElement.ProductId.HasValue)
                    {
                        innerMessages.Add("El ID del producto es requerido");
                    } else if (!this._database.Product.Any(P => P.Id == purchaseProductElement.ProductId))
                    {
                        innerMessages.Add("Debe seleccionar un producto que este registrado en el sistema");
                    }
                }
            };
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}