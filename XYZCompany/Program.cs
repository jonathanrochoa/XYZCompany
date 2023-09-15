using Microsoft.EntityFrameworkCore;
using XYZCompany.Repositories;
using XYZCompany.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("XYZCompany");
builder.Services.AddDbContext<XYZCompanyContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<TitleRepository>();
builder.Services.AddScoped<EmployeeRepository>();

builder.Services.AddScoped<TitleService>();
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<XYZCompanyContext>();
context.Database.EnsureCreated();

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
