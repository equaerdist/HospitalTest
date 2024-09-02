namespace HospitalTest.Infrastructure;

public class Doctor
{
    public long Id { get; set; }
    public string FullName { get; set; } = null!;
    public long CabinetId { get; set; }
    public Cabinet? Cabinet { get; set; }
    public long SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
    public long? AreaId { get; set; }
    public Area? Area { get; set; }
}
