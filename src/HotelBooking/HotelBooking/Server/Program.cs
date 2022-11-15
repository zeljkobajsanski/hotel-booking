using HotelBooking.Server.Services;
using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<INotificationsService, NotificationsService>();

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

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapGet("/api/users/{id}", (IUserService userService, Guid id) => userService.GetUser(id));
app.MapGet("/api/rooms", (IRoomService roomService) => roomService.GetPopularRooms());
app.MapPost("/api/rooms", (IRoomService roomService) => roomService.FindRooms(DateTime.Now, DateTime.Now, 1, 0));
app.MapPost("/api/bookings", (IBookingService bookingService, Booking booking) => bookingService.BookRoom(booking));

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
