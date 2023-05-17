using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TaxPayersApplication.API.Infraestructure.Base;
using TaxPayersApplication.Application.Services.Base;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;
using TaxPayersApplication.Application.DTOs;
using AutoMapper;
using TaxPayersApplication.Application.Services.Contract;
using TaxPayersApplication.Common.Filters;

namespace TaxPayersApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxPayersController : BaseApiController<TaxPayers, TaxPayersDto, IServicesBase<TaxPayers>>
    {
        readonly ITaxPayersServices _service;
        public TaxPayersController(IServicesBase<TaxPayers> manager, ITaxPayersServices service, IMapper Mapper) : base(manager, Mapper)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetPagedtaxPayers")]
        public async Task<ActionResult> GetPagedtaxPayersAsync([FromQuery] TaxPayersFilter filter)
        {
            try
            {
                return Ok(await _service.GetPagedtaxPayers(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] TaxPayersDto data)
        {
            try
            {
                return Ok(await _service.Create(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("InactiveTaxPayers/{id}")]
        public async Task<ActionResult> InactiveTaxPayers(int id)
        {
            try
            {
                return Ok(await _service.InactiveTaxPayers(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
