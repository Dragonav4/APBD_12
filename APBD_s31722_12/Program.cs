using APBD_s31722_12.Data;
using APBD_s31722_12.Exceptions;
using APBD_s31722_12.Interfaces;
using APBD_s31722_12.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MasterContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ));
builder.Services.AddControllers();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IClientService,ClientService>();
var app = builder.Build();

app.UseMiddleware<ApiExceptionMiddleware>();
app.MapControllers();
app.Run();