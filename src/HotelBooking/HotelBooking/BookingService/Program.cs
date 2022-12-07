using BookingService.Monitoring;
using Microsoft.ApplicationInsights.Extensibility;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddDapr();
builder.Services.AddDaprClient();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.Configure<TelemetryConfiguration>(o => o.TelemetryInitializers.Add(new AppInsightsInitializer()));
var app = builder.Build();


app.UseCloudEvents();
app.MapControllers();
app.MapSubscribeHandler();

app.Run();