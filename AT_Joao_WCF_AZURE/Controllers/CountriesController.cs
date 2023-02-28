using AT_Joao.BLL.Models.DTO;
using AT_Joao.BLL.Models.Entities;
using AT_Joao.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using System.Drawing;

namespace AT_Joao_WCF_AZURE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = (await countryRepository.GetAllAsync());

            var countriesDTO = mapper.Map<List<CountryDTO>>(countries);
            return Ok(countriesDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetCountryAsync")]
        public async Task<ActionResult> GetCountryAsync(int id)
        {
            var country = await countryRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDTO = mapper.Map<CountryDTO>(country);

            return Ok(countryDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountryAsync([FromRoute] int id, UpdateCountryRequest updateCountryRequest)
        {
            var country = new Country()
            {
                Name = updateCountryRequest.Name,
                ImageUrl = updateCountryRequest.ImageUrl
            };

            var response = await countryRepository.UpdateAsync(id, country);

            if (response == null)
            {
                return NotFound();
            }

            var countryDTO = mapper.Map<CountryDTO>(country);

            return Ok(countryDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> AddCountryAsync(AddCountryRequest addCountryRequest)
        {
            var country = new Country()
            {
                Name = addCountryRequest.Name,
                ImageUrl = addCountryRequest.ImageUrl
            };

            var response = await countryRepository.AddAsync(country);

            var countryDTO = mapper.Map<CountryDTO>(country);

            return CreatedAtAction(nameof(GetCountryAsync), new { id = country.Id }, country);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            var country = await countryRepository.DeleteAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            var countryDTO = mapper.Map<CountryDTO>(country);

            return Ok(countryDTO);
        }
    }
}
