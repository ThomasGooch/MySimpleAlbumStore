var builder = WebApplication.CreateBuilder(args);

// configure services
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    // behaviors go here
});

var app = builder.Build();

// configure pipeline



app.Run();
