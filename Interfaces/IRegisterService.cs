using CanamRegister.Models;

namespace CanamRegister.Interfaces
{
    public interface IRegisterService
    {
        Task<CreditAccountFormRequestModel> SaveCustomer(CreditAccountFormRequestModel requestModel);
    }
}
