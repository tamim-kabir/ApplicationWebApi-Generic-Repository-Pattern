using ApplicationEntitiesLib;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TRepo, TDto> : ControllerBase where T : class where TRepo : IBaseRepo<T>
    {
        private readonly TRepo _repo;
        private readonly IMapper _mapper;

        public BaseController(TRepo baseRepo, IMapper mapper)
        {
            this._repo = baseRepo;
            this._mapper = mapper;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var emp = await _repo.GetAllRecords();

            return Ok(_mapper.Map<IEnumerable<TDto>>(emp));
        }

        [HttpGet("{id}")]//, Name = "GetEmployeeById"
        public async Task<ActionResult<TDto>> GetById(int id)
        {
            var emp = await _repo.GetRecordById(id);
            if (emp != null)
                return Ok(_mapper.Map<TDto>(emp));

            return NotFound();
        }

    }
}
