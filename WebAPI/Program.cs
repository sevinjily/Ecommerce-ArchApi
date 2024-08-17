using Business.DependencyResolver;
using Core.DependencyResolver;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessService();
builder.Services.AddCoreService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region FluentValidation
FluentValidationMvcExtensions.AddFluentValidation(builder.Services.AddControllersWithViews(), x =>
{
    x.RegisterValidatorsFromAssemblyContaining<Program>();
    x.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("ru-RU");
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
