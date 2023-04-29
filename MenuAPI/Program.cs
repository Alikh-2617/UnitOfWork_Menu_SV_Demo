using DAL.AppDbContext;
using DAL.Doman.Contracts;
using DAL.Implementation.Categorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);    // Automapper config and paket måste install

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
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
