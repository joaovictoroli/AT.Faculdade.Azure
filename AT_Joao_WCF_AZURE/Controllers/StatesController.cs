using AT_Joao.BLL.Models.DTO;
using AT_Joao.BLL.Models.Entities;
using AT_Joao.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace AT_Joao_WCF_AZURE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatesController : Controller
    {
        private readonly IStateRepository stateRepository;
        private readonly IMapper mapper;
        private readonly ICountryRepository countryRepository; 

        public StatesController(IStateRepository stateRepository, ICountryRepository countryRepository , IMapper mapper)
        {
            this.stateRepository = stateRepository;
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesAsync()
        {
            var states = (await stateRepository.GetAllAsync());

            var statesDTO = mapper.Map<List<StateDTO>>(states);
            return Ok(statesDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetStateAsync")]
        public async Task<ActionResult<Country>> GetStateAsync(int id)
        {
            var state = await stateRepository.GetAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            var stateDTO = mapper.Map<StateDTO>(state);

            return Ok(stateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStateAsync([FromRoute] int id, UpdateStateRequest updateStateRequest)
        {
            if (!(await ValidateUpdateStateAsync(updateStateRequest)))
            {
                return BadRequest(ModelState);
            }

            var state = new State()
            {
                Name = updateStateRequest.Name,
                ImageUrl = updateStateRequest.ImageUrl,
                CountryId = updateStateRequest.CountryId
            };

            var response = await stateRepository.UpdateAsync(id, state);

            if (response == null)
            {
                return NotFound();
            }

            var stateDTO = mapper.Map<StateDTO>(state);

            return Ok(stateDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddStateAsync(AddStateRequest addStateRequest)
        {
            if (!await ValidadeAddStateAsync(addStateRequest))
            {
                return BadRequest(ModelState);
            }

            var state = new State()
            {
                Name = addStateRequest.Name,
                ImageUrl = addStateRequest.ImageUrl,
                CountryId = addStateRequest.CountryId
            };

            var response = await stateRepository.AddAsync(state);

            var stateDTO = mapper.Map<StateDTO>(state);

            return CreatedAtAction(nameof(GetStateAsync), new { id = state.Id }, state);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            var state = await stateRepository.DeleteAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            var stateDTO = mapper.Map<StateDTO>(state);

            return Ok(stateDTO);
        }
        #region

        private async Task<bool> ValidadeAddStateAsync(AddStateRequest addStateRequest)
        {
            var country = await countryRepository.GetAsync(addStateRequest.CountryId);
            if (country == null)
            {
                ModelState.AddModelError(nameof(addStateRequest.CountryId),
                  $"{nameof(addStateRequest.CountryId)} is invalid.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateUpdateStateAsync(UpdateStateRequest updateStateRequest)
        {
            var country = await countryRepository.GetAsync(updateStateRequest.CountryId);
            if (country == null)
            {
                ModelState.AddModelError(nameof(updateStateRequest.CountryId),
                  $"{nameof(updateStateRequest.CountryId)} is invalid.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
        #endregion


    }
}
