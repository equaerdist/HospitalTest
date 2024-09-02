
using HospitalTest.Infrastructure;

namespace HospitalTest;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration.Get<AppConfig>(o => o.BindNonPublicProperties = true) ??
            throw new InvalidDataException("Cant resolve config");
        builder.Services.AddControllers();
        builder.Services.AddSingleton(config);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAppServices();

        var app = builder.Build();

       
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        await app.AddFakeDataIfNeeded();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
