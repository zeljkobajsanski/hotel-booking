using HotelBooking.RoomService;
using HotelBooking.Shared.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRoomService, RoomService>();

var app = builder.Build();

app.MapGet("/api/rooms", (IRoomService roomService) => roomService.GetPopularRooms());
app.MapPost("/api/rooms", (IRoomService roomService) => roomService.FindRooms(DateTime.Now, DateTime.Now, 1, 0));
app.MapGet("/api/rooms/{id:guid}", (IRoomService roomService, Guid id) => roomService.GetRoom(id));
app.MapPost("/api/room-availability", (IRoomService roomService) => roomService.IsRoomAvailable(DateTime.Now, DateTime.Now));

app.Run();