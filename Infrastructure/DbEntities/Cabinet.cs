namespace HospitalTest.Infrastructure;

public class Cabinet
{
    public long Id { get; set; }
    public string CabinetNumber { get; set; } = null!;
    public Doctor? Doctor { get; set; }
}
