using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();


var ShipStationIntegration = new DirtLegalAssignment.ShipStation.ShipStationIntegration();

app.MapGet("/GetOrdersAsync", async ([FromQuery]  string? query = null) =>
{
    return await ShipStationIntegration.GetOrdersAsync(query);
});

app.MapPost("/CreateOrUpdateOrderAsync", async ([FromBody] object payload) =>
{
    return await ShipStationIntegration.CreateOrUpdateOrderAsync(payload);
});



app.Run();
