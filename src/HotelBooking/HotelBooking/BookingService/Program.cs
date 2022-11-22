using BookingService;
using HotelBooking.Shared.Models;
using HotelBooking.Shared.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<INotificationsService, NotificationsService>(client => client.BaseAddress = builder.Configuration.GetValue<Uri>("Endpoints:NotificationService"));
builder.Services.AddHttpClient<IPaymentService, PaymentService>(client => client.BaseAddress = builder.Configuration.GetValue<Uri>("Endpoints:PaymentService"));
builder.Services.AddHttpClient<IRoomService, RoomService>(client => client.BaseAddress = builder.Configuration.GetValue<Uri>("Endpoints:RoomService"));
builder.Services.AddHttpClient<IUserService, UserService>(client => client.BaseAddress = builder.Configuration.GetValue<Uri>("Endpoints:UserService"));
builder.Services.AddScoped<IBookingService, BookingService.BookingService>();

var app = builder.Build();

app.MapPost("/api/bookings", (Booking booking, IBookingService bookingService) => bookingService.BookRoom(booking));

app.Run();