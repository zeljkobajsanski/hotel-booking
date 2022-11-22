using HotelBooking.Shared.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/users", (User user) => Console.WriteLine("[User service]: Saving user"));

app.Run();