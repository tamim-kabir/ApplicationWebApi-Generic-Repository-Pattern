using ApplicationEntitiesLib;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


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
        public async Task<ActionResult<IEnumerable<TDto>>> GetAll()
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

        [HttpPost]
        public async Task<ActionResult<TDto>> Create(TDto DtoEnbtity)
        {
            var Entitry = _mapper.Map<T>(DtoEnbtity);
            await _repo.CreateNewRecord(Entitry);
            var createDto = _mapper.Map<TDto>(Entitry);
            return NoContent();//CreatedAtRoute(nameof(GetById), new { Id = createDto.ID }, createDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEntitry(int id, TDto dto)
        {
            var Entitry = await _repo.GetRecordById(id);
            if(Entitry == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, Entitry);
            await _repo.UpdateRecord(Entitry);
            return NoContent();
        }
    }
}
