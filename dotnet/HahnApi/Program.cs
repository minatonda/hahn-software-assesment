using System.Text.Json.Serialization;
using DataAccess.Repository;
using HahnDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.ConfigureHttpJsonOptions((options) =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var dbPath = System.IO.Path.Join("../hahn.db");
    options.UseSqlite($"Data Source={dbPath}", b => b.MigrationsAssembly("HahnWorkerService"));
    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
});

builder.Services.AddTransient<BreedRepository, BreedRepository>();
builder.Services.AddTransient<BreedAttributeBooleanRepository, BreedAttributeBooleanRepository>();
builder.Services.AddTransient<BreedAttributeRangeRepository, BreedAttributeRangeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}/{id?}"
);
app.Run();