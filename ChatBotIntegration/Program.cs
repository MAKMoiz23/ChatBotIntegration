using ChatBotIntegration.Services.IService;
using ChatBotIntegration.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IOrderStatusService, OrderStatusService>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri("https://orderstatusapi-dot-organization-project-311520.uc.r.appspot.com");
});
builder.Services.AddScoped<IDialogService, DialogService>();

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
