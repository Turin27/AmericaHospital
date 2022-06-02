using AmericaHospital.API.Models;
using AmericaHospital.Models.Entities;
using AutoMapper;

namespace AmericaHospital.API.Mappings
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, UpsertEmployeeDto>();
            CreateMap<UpsertEmployeeDto, Employee>();
        }
    }
}
