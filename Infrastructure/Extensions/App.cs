using Microsoft.EntityFrameworkCore;

namespace HospitalTest.Infrastructure;

public static class AppExtensions
{
    public static Specialization[] GetSpecializations() =>
        Enumerable
        .Range(0, 20)
        .Select(t => new Specialization() { Name = $"Specialization {t}"})
        .ToArray();
    public static Area[] GetAreas() =>
        Enumerable
        .Range(0, 20)
        .Select(t => new Area() {AreaNumber = $"Area #{t}" })
        .ToArray();
    public static Cabinet[] GetCabinets() =>
        Enumerable
        .Range(0, 25)
        .Select(t => new Cabinet() { CabinetNumber = $"CABINET #{t}" })
        .ToArray();
    public static async Task AddFakeDataIfNeeded(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<HospitalContext>();
        var specz = ctx.Set<Specialization>();
        var cabs = ctx.Set<Cabinet>();
        var areas = ctx.Set<Area>();
        var cabsCount = await cabs.CountAsync();
        var speczCount = await specz.CountAsync();
        var areaCount = await areas.CountAsync();
        if (cabsCount == 0)
        {
            await cabs.AddRangeAsync(GetCabinets());
        }
        if (areaCount == 0)
        {
            await areas.AddRangeAsync(GetAreas());
        }
        if (speczCount == 0)
        {
            await specz.AddRangeAsync(GetSpecializations());
        }
        await ctx.SaveChangesAsync();
    }
}
