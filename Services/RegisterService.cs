using CanamRegister.Data;
using CanamRegister.Entity;
using CanamRegister.Interfaces;
using CanamRegister.Models;

namespace CanamRegister.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly ApplicationDbContext _context;
        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreditAccountFormRequestModel> SaveCustomer(CreditAccountFormRequestModel model)
        {
            var request = new Customer
            {
                LegalName = model.LegalName,
                TradeName = model.TradeName,
                BusinessType = model.BusinessType,
                PhoneNumber = model.PhoneNumber,
                TaxID = model.TaxID,
                IsRegisteredBusiness = model.IsRegisteredBusiness,
                PSTNumber = model.PSTNumber,
                BillingAddress = model.BillingAddress,
                BillingAddress2 = model.BillingAddress2,
                BillingCity = model.BillingCity,
                BillingState = model.BillingState,
                BillingCountry = model.BillingCountry,
                BillingZip = model.BillingZip,
                ShippingAddress = model.ShippingAddress,
                ShippingAddress2 = model.ShippingAddress2,
                ShippingCity = model.ShippingCity,
                ShippingState = model.ShippingState,
                ShippingCountry = model.ShippingCountry,
                ShippingZipcode = model.ShippingZipcode,
                BankName = model.BankName,
                BankContactName = model.BankContactName,
                BankAddress = model.BankAddress,
                BankPhoneNumber = model.BankPhoneNumber,
                TransitNo = model.TransitNo,
                InstNo = model.InstNo,
                AccountNo = model.AccountNo,
                SupplierName = model.SupplierName,
                SupplierCity = model.SupplierCity,
                SupplierPhone = model.SupplierPhone,
                IsContactAuthorized = model.IsContactAuthorized,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                MobilePhone = model.MobilePhone,
                EmailAddress = model.EmailAddress,
                Fax = model.Fax,
                IsTwoFactorAuthEnabled = model.IsTwoFactorAuthEnabled,
                MobileNumber = model.MobileNumber,
                IsAuthorizedToViewInvoices = model.IsAuthorizedToViewInvoices,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                IsAuthorizedForPurchases = model.IsAuthorizedForPurchases,
                AgreesToTerms = model.AgreesToTerms,
                ReceiveEmails = model.ReceiveEmails,
                Guarantee = model.Guarantee,
                AuthorizationForVerification = model.AuthorizationForVerification,
                AccuracyConfirmation = model.AccuracyConfirmation,
                TermsAcknowledgement = model.TermsAcknowledgement
            };
            _context.Add(request);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
