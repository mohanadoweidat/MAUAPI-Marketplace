using MAUAPI.Data;
using MAUAPI.IConfiguration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//SQL database service.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

//Adding the unit of work to the DI contain
builder.Services.AddScoped<IUnitOfWork, UnitOfwork>();

var app = builder.Build();
app.Environment.IsProduction();

// Configure the HTTP request pipeline.

/*
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}*/
if (app.Environment.IsProduction())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "/swagger/{documentname}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketplace API V1");
        c.RoutePrefix = String.Empty;
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
