using HotelBooking.Shared.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/check-card", ([FromBody]PaymentInfo paymentInfo) => Console.WriteLine("[Payment service]: Credit card is valid"));
app.MapPost("/api/make-payment", ([FromBody]object paymentInfo) => Console.WriteLine("[Payment service]: Payment processed successfully"));

app.Run();