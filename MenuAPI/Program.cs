using DAL.AppDbContext;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using DAL.Implementation.Categorys;
using MenuAPI.FilterConfiguration.AttributFilters;
using MenuAPI.FilterConfiguration.GlobalFilters;
using MenuAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalFilter()); // Add Global Filter !
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();  // Add Cors to Access other app request to the host
builder.Services.AddAutoMapper(typeof(Program).Assembly);    // Automapper config and paket måste install
builder.Services.AddScoped(typeof(ValidationActionFilterAttribut<>));
builder.Services.AddScoped(typeof(ValidationModelAttribut<>));
builder.Services.AddScoped(typeof(FileValidationAttribut));
builder.Services.AddScoped(typeof(UploadService));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
});
builder.Services.AddTransient<IUnitOfWork , UnitOfWorkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseExceptionHandler("/error");


//app.UseCors(options => options.WithOrigins("http://localhost:3000//").AllowAnyMethod().AllowAnyHeader()); // use Cors
app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()); // use Cors
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
