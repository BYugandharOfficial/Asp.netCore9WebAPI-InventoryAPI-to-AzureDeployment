using InventoryAPI;
using InventoryAPI.Models;
using InventoryAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

//DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("*******") ?? throw new InvalidOperationException("Connection string '********' not found.")));  // Azure SQL Connection String
    
//options.UseSqlServer(builder.Configuration.GetConnectionString("*******") ?? throw new InvalidOperationException("Connection string '******(' not found."))); // LocalDB Connection String

//Repository DI
builder.Services.AddScoped<IProductsRepository, productsRepository>();
builder.Services.AddScoped<ICategoriesRepository, categoriesRepository>();



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//CORS Configuration //Don't use AllowAnyOrigin in Production
//--------------------------------------------------------------------

//var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");

//builder.Services.AddCors(options =>
//{
    //options.AddPolicy("AllowAll", policy => 
        
//        {
//            policy.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//        });
//});



var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
