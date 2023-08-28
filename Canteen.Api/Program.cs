using Canteen.Application;
using Canteen.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddCors();
}

var app = builder.Build();
{
    app.UseCors(x => x
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
    );

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();