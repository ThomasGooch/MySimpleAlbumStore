var builder = WebApplication.CreateBuilder(args);

// configure services

builder.Services.AddDbContext<AlbumStoreContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging();
});
builder.Services.AddScoped<IArtistsRepository, ArtistsRepository>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    // behaviors go here
});

builder.Services.AddCarter();

var app = builder.Build();


app.MapCarter();


app.Run();
