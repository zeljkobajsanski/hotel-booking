using Dapr.Client;
using HotelBooking.Server.Monitoring;
using HotelBooking.Shared.Models;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDaprClient();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.Configure<TelemetryConfiguration>(o => o.TelemetryInitializers.Add(new AppInsightsInitializer()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapGet("/api/rooms",
    (DaprClient daprClient) =>
        daprClient.InvokeMethodAsync<IEnumerable<Room>>(HttpMethod.Get, "roomservice", "/api/rooms"));
app.MapPost("/api/rooms",
    (DaprClient daprClient, object _) =>
        daprClient.InvokeMethodAsync<IEnumerable<Room>>(HttpMethod.Post, "roomservice", "/api/rooms"));
app.MapPost("/api/bookings",
   async (DaprClient daprClient, Booking booking) => await daprClient.PublishEventAsync("pubsub", "placedBooking", booking));
app.MapFallbackToFile("index.html");

app.Run();
