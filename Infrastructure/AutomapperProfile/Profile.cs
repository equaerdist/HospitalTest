using AutoMapper;

namespace HospitalTest.Infrastructure;

public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<Doctor, GetSingleDoctorDto>();
        CreateMap<AddDoctorDto, Doctor>();
        CreateMap<UpdateDoctorDto, Doctor>()
            .ForMember(x => x.Id, cfg => cfg.Ignore());
    }
}
