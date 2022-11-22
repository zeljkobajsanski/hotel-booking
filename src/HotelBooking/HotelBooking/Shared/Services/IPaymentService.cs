using HotelBooking.Shared.Models;

namespace HotelBooking.Shared.Services;

public interface IPaymentService
{
    Task CheckCreditCard(PaymentInfo paymentInfo);
    Task MakePayment(PaymentInfo userPaymentInfo, double bookingPrice);
}