using ChatBotIntegration.Models.OrderStatus.Settings;
using ChatBotIntegration.Services.IService;
using ChatBotIntegration.Services.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IOrderStatusService, OrderStatusService>((serviceProvider, client) =>
{
    var settings = serviceProvider
        .GetRequiredService<IOptions<OrderStatusSettings>>().Value;
    client.BaseAddress = new Uri(settings.Url);
});
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.Configure<OrderStatusSettings>(
        builder.Configuration.GetSection("OrderApiUrl")
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
