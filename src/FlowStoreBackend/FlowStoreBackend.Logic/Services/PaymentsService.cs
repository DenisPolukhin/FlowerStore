using FlowStoreBackend.Common.Exceptions;
using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Database.Models.Enums;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Order;
using Yandex.Checkout.V3;
using Payment = FlowStoreBackend.Database.Models.Entities.Payment;


namespace FlowStoreBackend.Logic.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly AsyncClient _client;
        public PaymentsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _client = new Client("", "").MakeAsync();
        }

        public async Task<string> CreatePaidOrderUrl(PaidOrderUrlModel createPaidOrderUrlModel)
        {
            var order = await _databaseContext.Orders.FindAsync(createPaidOrderUrlModel.Id);
            if (order == null)
            {
                throw new EntityFindException();
            }

            var newPayment = new NewPayment
            {
                Amount = new Amount
                {
                    Currency = "RUB",
                    Value = createPaidOrderUrlModel.Products.Sum(x => x.TotalPrice)
                },
                Capture = true,
                Description = $"Payment for the order {createPaidOrderUrlModel.Id} in the store",
                Confirmation = new Confirmation
                {
                    Type = ConfirmationType.Redirect,
                    ReturnUrl = "https://www.google.com/"
                },

                Receipt = new Receipt
                {
                    Email = createPaidOrderUrlModel.UserEmail,
                    Phone = createPaidOrderUrlModel.UserPhoneNumber,
                    Items = createPaidOrderUrlModel.Products.Select(x => new ReceiptItem
                    {
                        Description = x.Name,
                        Quantity = x.Quantity,
                        VatCode = VatCode.NoVat,
                        ProductCode = x.Id.ToString(),
                        PaymentSubject = PaymentSubject.Commodity,
                        PaymentMode = PaymentMode.FullPrepayment,
                        Amount = new Amount
                        {
                            Currency = "RUB",
                            Value = x.UnitPrice
                        }
                    }).ToList()
                }
            };

            var yookassaPayment = await _client.CreatePaymentAsync(newPayment);
            var payment = new Payment
            {
                YookassaPaymentId = yookassaPayment.Id,
                Amount = yookassaPayment.Amount.Value,
                State = PaymentState.Pending
            };

            await _databaseContext.Payments.AddAsync(payment);
            order.PaymentId = payment.Id;
            await _databaseContext.SaveChangesAsync();

            return yookassaPayment.Confirmation.ConfirmationUrl;
        }
    }
}
