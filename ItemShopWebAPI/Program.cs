using _20231220_EntityFrameworkCore_ItemShop_WebApi.Cotext;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Middlewares;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Repositories;
using _20231220_EntityFrameworkCore_ItemShop_WebApi.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

/*
 * Add services to the container. 
 */

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string _postgreconnection = builder.Configuration.GetConnectionString("PostgreConnection");
//EntityFramework CORE POSTGRESql
builder.Services.AddDbContext<ItemEntityContext>(options => options.UseNpgsql(_postgreconnection));
// Postgre adding to DI contianer string for Dapper:
//builder.Services.AddScoped<IDbConnection>((sp) => new NpgsqlConnection(_postgreconnection));

//builder.Services.AddDbContext<ItemEntityContext>(opt => opt.UseInMemoryDatabase("InMemoryDB"));

builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<IItemRepository,  ItemRepository>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

/* 
 * Configure the HTTP request pipeline.
 */

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
