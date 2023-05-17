using TaxPayersApplication.API.Extensions;
using TaxPayersApplication.Application.DependencyInjection;
using TaxPayersApplication.DataAccess.DependencyInection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers(o =>
{
    o.AllowEmptyInputInBodyModelBinding = true;
});

builder.Services.AddContextInfrastructure(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddRepositoriesCollections();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("CorsPolicy");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
