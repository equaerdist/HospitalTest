namespace HospitalTest.Infrastructure;

public class Specialization
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
