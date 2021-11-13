using Microsoft.AspNetCore.Mvc;
using CRUD;
using ApplicationEntitiesLib.Employee;
using ApplicatinoDataAccess.Repository;
using ApplicatinoDataAccess.DTOs;
using AutoMapper;

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
