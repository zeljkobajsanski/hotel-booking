var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/send-email", () => Console.WriteLine("[Notification service]: Email has been sent successfully"));

app.Run();