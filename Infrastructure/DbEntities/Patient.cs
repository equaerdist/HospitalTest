namespace HospitalTest.Infrastructure;

public class Patient
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime BirthDateInUtc { get; set; }
    public string Sex { get; set; } = null!;
    public long AreaId { get; set; }
    public Area? Area { get; set; }
}
