using Product.Manager.Data.Context;
using Product.Manager.Data.Interfaces;
using Product.Manager.Logic.Interfaces;
using Product.Manager.Logic.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductRepostory>(s =>
				new ProductRepository(builder.Configuration["ProductManagerDb"]));
builder.Services.AddTransient<IProductManager, ProductManager>();
//builder.Services.AddTransient<IProductRepostory, ProductRepository>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }