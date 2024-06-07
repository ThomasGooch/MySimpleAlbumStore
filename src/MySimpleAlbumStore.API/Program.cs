


var builder = WebApplication.CreateBuilder(args);

// configure services

builder.Services.AddDbContext<AlbumStoreContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
        .LogTo(Console.WriteLine, LogLevel.Warning);

});
builder.Services.AddScoped<IArtistsRepository, ArtistsRepository>();
builder.Services.AddScoped<IAlbumsRepository, AlbumsRepository>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCarter();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();


app.MapCarter();

app.UseExceptionHandler(opt => { });


app.Run();
