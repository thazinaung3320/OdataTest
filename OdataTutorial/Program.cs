using Microsoft.EntityFrameworkCore;
using ODataTutorial.Models;
using ODataTutorial.Data;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Sentry;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Todo>("Todos");
    builder.EntitySet<Note>("Notes");
    return builder.GetEdmModel();
}

SentrySdk.Init(options =>
{
    options.Dsn = "https://3ba5e205db034cd5867b45a18b0d2b69@o4505051667562496.ingest.sentry.io/4505170225201152";
    options.Debug = true;
    options.AutoSessionTracking = true;
    options.IsGlobalModeEnabled = true;
    options.EnableTracing = true;
});

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);
string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Add services to the container.
builder.Services.AddDbContext<DataContext>(
     // options => options.UseNpgsql(connectionString)
     options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Count().OrderBy().Select().Expand());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
