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
            // Create a new Customer entity from the provided model
            var customer = new Customer
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
                TermsAcknowledgement = model.TermsAcknowledgement,
                CCFirstName = model.CCFirstName,
                CCLastName = model.CCLastName,
                CCNumber = model.CCNumber,
                CCExpiryMonth = model.CCExpiryMonth,
                CCExpiryYear = model.CCExpiryYear,
                CVV = model.CVV,
            };

            // Add the customer to the context
            _context.Add(customer);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Now you can get the ID of the saved customer
            var customerId = customer.Id; // Assuming Id is the primary key

            // Save suppliers based on the model's properties
            await SaveSuppliers(customerId, model);
            return model;
        }

        // Method to save suppliers based on model fields
        private async Task SaveSuppliers(int customerId, CreditAccountFormRequestModel model)
        {
            var suppliers = new Suppliers
            {
                CustomerId = customerId,
                SupplierName1 = model.SupplierName1,
                SupplierCity1 = model.SupplierCity1,
                SupplierPhone1 = model.SupplierPhone1,
                SupplierName2 = model.SupplierName2,
                SupplierCity2 = model.SupplierCity2,
                SupplierPhone2 = model.SupplierPhone2,
                SupplierName3 = model.SupplierName3,
                SupplierCity3 = model.SupplierCity3,
                SupplierPhone3 = model.SupplierPhone3
            };
            _context.Suppliers.Add(suppliers);
            await _context.SaveChangesAsync();
        }


    }
}
