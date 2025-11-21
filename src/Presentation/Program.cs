using ECommerce.Persistence;
//clean-up
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddOpenApi()
    .AddPersistenceServices(builder.Configuration)
    .AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment()) 
    app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();