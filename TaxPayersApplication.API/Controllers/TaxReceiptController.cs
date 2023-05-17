using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxPayersApplication.Application.DTOs;
using TaxPayersApplication.Application.Services.Base;
using TaxPayersApplication.Application.Services.Contract;
using TaxPayersApplication.Common.Filters;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxReceiptController : ControllerBase
    {
        readonly ITaxReceiptServices _service;
        public TaxReceiptController(ITaxReceiptServices service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("GetReceiptByPayers")]
        public async Task<ActionResult> GetReceiptByPayers([FromQuery] string id)
        {
            try
            {
                return Ok(await _service.GetReceiptByPayers(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetNFC")]
        public async Task<ActionResult> GetNFC()
        {
            try
            {
                return Ok(await _service.GetNFC());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateReceiptPayers")]
        public async Task<ActionResult> CreateReceiptPayers([FromBody] TaxReceiptDto data)
        {
            try
            {
                return Ok(await _service.CreateReceiptPayers(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
