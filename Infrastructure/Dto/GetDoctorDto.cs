namespace HospitalTest.Infrastructure;

public class GetDoctorDto
{
    public long Id { get; set; }
    public string FullName { get; set; } = null!;
    public string CabinetNumber { get; set; } = null!;
    public string SpecializationName { get; set; } = null!;
    public string? AreaName { get; set; }
}
