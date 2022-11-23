using Dapr;
using Dapr.Client;
using HotelBooking.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers;

[ApiController][Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly DaprClient _daprClient;

    public BookingController(ILogger<BookingController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpPost]
    [Topic("pubsub", "placedBooking")]
    public async Task PlaceBooking(Booking booking)
    {
        _logger.LogInformation($"Received new booking");
        
        // Check room availability
        var isAvailable = await _daprClient.InvokeMethodAsync<bool>(HttpMethod.Get, "roomservice", $"/api/check-availability");
        _logger.LogInformation(isAvailable ? "Room is available" : "Room is not available");
        if (!isAvailable)
        {
            return;
        }

        // Update user profile
        await _daprClient.InvokeMethodAsync(HttpMethod.Post, "userservice", "/api/users", booking.User);
        
        // Process payment
        await _daprClient.InvokeMethodAsync(HttpMethod.Post, "paymentservice", "/api/make-payment",
            new { booking.User.PaymentInfo, booking.Price });
        
        booking.Id = Guid.NewGuid();
        
        // Get state from store
        var bookingNumberState = await _daprClient.GetStateEntryAsync<int>("statestore", "bookingNumber");
        var bookingNumber = bookingNumberState.Value;
        booking.Number = $"{++bookingNumber:000000}";
        await _daprClient.SaveStateAsync("statestore", "bookingNumber", bookingNumber);
        _logger.LogInformation("[Booking Service]: Booking saved");

        // Send email
        var emailMetadata = new Dictionary<string, string>(){{"emailTo", booking.User.Email}};
        await _daprClient.InvokeBindingAsync("smtp", "create", $"Your booking <b>{booking.Number}</b> has been confirmed.", emailMetadata);
    }
}

public record Person(string FirstName, string LastName);