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
        CreateMap<Doctor, GetDoctorDto>()
            .ForMember(x => x.CabinetNumber, cfg => cfg.MapFrom(x => x.Cabinet!.CabinetNumber))
            .ForMember(x => x.SpecializationName, cfg => cfg.MapFrom(x => x.Specialization!.Name))
            .ForMember(x => x.AreaName, cfg => cfg.MapFrom(x => x.Area != null ? x.Area.AreaNumber : null));
    }
}
