using ApplicationEntitiesLib.DTOs;
using ApplicationEntitiesLib.Employee;
using AutoMapper;

namespace ApplicatinoDataAccess.ModelMapingProfile
{
    public class ModelMapingProfile : Profile
    {
        public ModelMapingProfile()
        {
            ///<summary>From orginal Databse Model to Dto</summary>
            //Source -> Terget to Get employee
            CreateMap<EmployeeModel, EmployeeModelDto>();

            CreateMap<EmployeeModelDto, EmployeeModel>();

            CreateMap<EmployeeImagesModel, EmployeeImageDto>();
        }
    }
}
