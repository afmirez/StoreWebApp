using API.Data;
using API.DataTransferObjects;
namespace API.Validators
{
    public class ProductValidator : IProductValidator
    {
        private readonly StoreDB _database;

        public ProductValidator(StoreDB database)
        {
            _database = database;
        }

        public bool ValidateInsertUpdate(InsertUpdateProductDTO data, List<string> messages)
        {
            List<string> innerMessages = new();

            // Name
            if (string.IsNullOrWhiteSpace(data.Name))
            {
                innerMessages.Add("El nombre del producto es requerido");
            }
            else if (data.Name.Length > 50)
            {
                innerMessages.Add("El nombre del producto no puede contener mas de 50 caracteres");
            }
            // Description
            if (string.IsNullOrWhiteSpace(data.Description))
            {
                innerMessages.Add("La descripcion del producto es requerida");
            }
            else if (data.Description.Length > 250)
            {
                innerMessages.Add("La descripcion del producto no puede contener mas de 50 caracteres");
            }
            // Stock
            if (!data.ProductStock.HasValue)
            {
                innerMessages.Add("Cantidad del producto es requerida");
            }
            else if (data.ProductStock < 0)
            {
                innerMessages.Add("Cantidad del producto debe ser mayor o igual a 0");
            }
            // Price
            if (!data.Price.HasValue)
            {
                innerMessages.Add("Precio del producto es requerido");
            }
            else if (data.Price < 0)
            {
                innerMessages.Add("Precio del producto debe ser mayor o igual a 0");
            }
            // Category
            if (!data.CategoryId.HasValue)
            {
                innerMessages.Add("Categoria es requerida");
            }
            else if (!this._database.Product.Any(c => c.Id == data.CategoryId))
            {
                innerMessages.Add("Debe seleccionar una categoria que este registrada en el sistema");
            }
            // Product State
            if (!data.ProductStateId.HasValue)
            {
                innerMessages.Add("Estado del producto es requerido");
            }
            else if (!this._database.Product.Any(p => p.Id == data.ProductStateId))
            {
                innerMessages.Add("Debe seleccionar un estado del producto que este registrado en el sistema");
            }
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}
