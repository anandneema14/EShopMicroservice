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
var app = builder.Build();

//Configure HTTP request pipeline
app.MapCarter();
app.Run();