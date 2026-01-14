using Microsoft.EntityFrameworkCore;
using OpsAnalytics.Infrastructure.Repositories.Interface;
using OpsAnalytics.Infrastructure.Repositories.Implement;
using OpsAnalytics.Infrastructure.Services.Interface;
using OpsAnalytics.Infrastructure.Services.Implement;
using OpsAnalytics.Infrastructure.Data.Models;


var builder = WebApplication.CreateBuilder(args);

//DbContext
builder.Services.AddDbContext<OpsanalyticsContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//Repositories & Services
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Need to have this line when manually add MVC structure (manually add Controllers)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//add middleware for MVC support
app.MapControllers();
app.Run();

