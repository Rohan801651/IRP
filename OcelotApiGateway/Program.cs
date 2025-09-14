using Ocelot.DependencyInjection;
using Ocelot.Middleware;




var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();


await app.UseOcelot();


app.Run();
