using ApplicatinoDataAccess.DTOs;
using ApplicatinoDataAccess.Repository;
using ApplicationEntitiesLib.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeModel, EmployeeRepo, EmployeeModelDto>
    {
        public EmployeeController(EmployeeRepo employeeRepo, IMapper mapper) : base(employeeRepo, mapper)
        {

        }
    }
}
