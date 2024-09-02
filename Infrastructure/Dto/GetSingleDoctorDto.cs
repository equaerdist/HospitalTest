namespace HospitalTest.Infrastructure;

public class GetSingleDoctorDto
{
    public long Id { get; set; }
    public string FullName { get; set; } = null!;
    public long CabinetId { get; set; }
    public long SpecializationId { get; set; }
    public long? AreaId { get; set; }
}
