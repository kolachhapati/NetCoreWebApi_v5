using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi_v5.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NetCoreWebApi_v5.Models;
using Microsoft.AspNetCore.Authorization;

namespace NetCoreWebApi_v5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitofWork unitofWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitofWork.Countries.GetAll();
                var result = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the  {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var countries = await _unitofWork.Countries.Get(x => x.Id == id, new List<string> { "Hotels" });
                var result = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the  {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
