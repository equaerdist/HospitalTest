namespace HospitalTest.Infrastructure;

public class Area
{
    public long Id { get; set; }
    public string AreaNumber { get; set; } = null!;
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
