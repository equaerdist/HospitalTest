using Microsoft.EntityFrameworkCore;

namespace HospitalTest.Infrastructure;

public class HospitalContext(AppConfig config) : DbContext
{
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(config.SqlKey)
            .UseSnakeCaseNamingConvention();
    }
}
