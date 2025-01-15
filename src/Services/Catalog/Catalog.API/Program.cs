var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    // This is an experimental function
    //opts.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;

}).UseLightweightSessions();


var app = builder.Build();

// Configure the HTTP request pipeline

// It deals with all the ICarter Implementation
app.MapCarter();

app.Run();
