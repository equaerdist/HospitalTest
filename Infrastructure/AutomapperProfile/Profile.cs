using AutoMapper;

namespace HospitalTest.Infrastructure;

public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<Doctor, GetSingleDoctorDto>();
    }
}
