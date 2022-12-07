using HotelBooking.Shared.Models;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Monitoring;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.Configure<TelemetryConfiguration>(o => o.TelemetryInitializers.Add(new AppInsightsInitializer()));
var app = builder.Build();

app.MapPost("/api/check-card", ([FromBody]PaymentInfo paymentInfo) => Console.WriteLine("[Payment service]: Credit card is valid"));
app.MapPost("/api/make-payment", ([FromBody]object paymentInfo) => Console.WriteLine("[Payment service]: Payment processed successfully"));

app.Run();