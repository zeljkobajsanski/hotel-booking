var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddDapr();
builder.Services.AddDaprClient();
var app = builder.Build();


app.UseCloudEvents();
app.MapControllers();
app.MapSubscribeHandler();

app.Run();