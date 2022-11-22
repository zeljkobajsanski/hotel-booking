using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

namespace BookingService;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;

    public PaymentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task CheckCreditCard(PaymentInfo paymentInfo)
    {
        return _httpClient.PostAsJsonAsync("/api/check-card", paymentInfo);
    }

    public Task MakePayment(PaymentInfo paymentInfo, double bookingPrice)
    {
        return _httpClient.PostAsJsonAsync("/api/make-payment", new{paymentInfo, bookingPrice});
    }
}