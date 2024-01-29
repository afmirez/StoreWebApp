using API.DataTransferObjects;
namespace API.Validators
{
    public interface IProductValidator
    {
        bool ValidateInsertUpdate(InsertUpdateProductDTO data, List<string> messges);
    }
}
