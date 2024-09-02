namespace HospitalTest.Infrastructure;

public static class ServicesExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddDbContext<HospitalContext>();
        services.AddAutoMapper(typeof(HospitalProfile));    
    }
}
