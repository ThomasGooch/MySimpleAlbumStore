using Microsoft.EntityFrameworkCore;
using MySimpleAlbumStore.API.Data;

var builder = WebApplication.CreateBuilder(args);

// configure services

builder.Services.AddDbContext<AlbumStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    // behaviors go here
});

builder.Services.AddCarter();

var app = builder.Build();

// configure pipeline

app.MapCarter();


app.Run();
