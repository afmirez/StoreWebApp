using API.DataTransferObjects;
namespace API.Validators
{
    public interface IPurchaseValidator
    {
        bool ValidateInsert(PurchaseRequest data, List<string> messges);
    }
}
