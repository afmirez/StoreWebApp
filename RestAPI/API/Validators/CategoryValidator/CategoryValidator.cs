using API.Data;
using API.DataTransferObjects;

namespace API.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        private readonly StoreDB _database;
        public CategoryValidator(StoreDB database)
        {
            _database = database;
        }

        public bool ValidateInsertUpdate(InsertUpdateCategoryDTO data, List<string> messages)
        {
            List<string> innerMessages = new();
            // Name
            if (string.IsNullOrWhiteSpace(data.Name))
            {
                innerMessages.Add("El nombre de la categoria es requerida");
            }
            else if (data.Name.Length > 50)
            {
                innerMessages.Add("El nombre de la categoria no puede contener mas de 50 caracteres");
            }

            // Product State
            if (!data.CategoryStateId.HasValue)
            {
                innerMessages.Add("El estado de la categoria es requerido");
            }
            else if (!this._database.Category.Any(c => c.Id == data.CategoryStateId))
            {
                innerMessages.Add("Debe seleccionar un estado de la categoria que este registrada en el sistema");
            }
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}