using HotelBooking.Shared.Models;

namespace HotelBooking.Server.Services
{
    public interface IPaymentService
    {
        void CheckCreditCard(PaymentInfo paymentInfo);
        void MakePayment(PaymentInfo userPaymentInfo, double bookingPrice);
    }

    public class PaymentService : IPaymentService
    {
        public void CheckCreditCard(PaymentInfo paymentInfo)
        {
            Console.WriteLine("[Payment service]: Credit card is valid");
        }

        public void MakePayment(PaymentInfo userPaymentInfo, double bookingPrice)
        {
            Console.WriteLine("[Payment service]: Payment processed successfully");
        }
    }
}
