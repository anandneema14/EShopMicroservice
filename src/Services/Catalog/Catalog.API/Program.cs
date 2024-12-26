using JasperFx.Core;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the container
//Register Carter
builder.Services.AddCarter();

//Register MediatR
builder.Services.AddMediatR(configuration =>
{
    //it tells to MedialtR where to find our Command and query handler classes
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DefaultConnection"));
    //below line will create DB objects automatically. Not suitable for PROD environments
    //options.AutoCreateSchemaObjects = true;
}).UseLightweightSessions();

var app = builder.Build();

//Configure HTTP request pipeline
app.MapCarter();
app.Run();