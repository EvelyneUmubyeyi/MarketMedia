using MarketMedia.src.EF;
using MarketMedia.src.Entities;
using MarketMedia.src.Models;
using MarketMedia.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketMedia.src.Controllers
{
    [Route("Address")]
    public class AddressController : Controller
    {
        private readonly IRepository _iRepository;
        private MMDbContext _dbContext;

        public AddressController(IRepository Repository, MMDbContext mmDbContext)
        {
            _iRepository = Repository;
            _dbContext = mmDbContext;   
        }

        #region GetAddress(id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var address = await _iRepository.GetAddress(id);
            return Ok(address);
        }
        #endregion

        #region GetAllAddressesInVillage
        [HttpGet("InVillage{villageId}")]
        public async Task<IActionResult> GetAddressInVillage(int villageId)
        {
            if ((_dbContext.Addresses.Where(t => t.VillageId.Equals(villageId)).ToList().Count == 0))
            {
                return NotFound("No address in that village found");
            }
            var addresses = await _iRepository.GetAddressesByVillage(villageId);
            return Ok(addresses);
        }
        #endregion

        #region GetAllAddresses
        [HttpGet]
        public async Task<IActionResult> GetAlladdress()
        {
            var address = await _iRepository.GetAllAddresses();
            return Ok(address);
        }
        #endregion

        #region PostAddress
        [HttpPost]
        public async Task<IActionResult> PostAddress([FromBody] AddressInputDto inputDto)
        {

            if (string.IsNullOrWhiteSpace(inputDto.Details) && string.IsNullOrWhiteSpace(inputDto.VillageId.ToString())) return BadRequest("Invalid input data.");
            if((_dbContext.Addresses.Where(t=>t.Details.Equals(inputDto.Details) && t.VillageId.Equals(inputDto.VillageId)).ToList()).Count > 0)
            {
                return BadRequest("Address already exists");
            }
                //AsEnumerable().Any(row => inputDto.VillageId == row.Field<int>("VillageId"));

            var address = new Address();

            if (inputDto.Details != null)
            {
                address.Details = inputDto.Details;
            }

            if (inputDto.VillageId != null)
            {
                address.VillageId = inputDto.VillageId;
            }

            _iRepository.Add(address);
            await _iRepository.Save();
            return Ok();
        }
        #endregion

        #region UpdateAddress
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, [FromBody] AddressInputDto inputDto)
        {
            var address = await _iRepository.GetAddress(id);
            if (string.IsNullOrWhiteSpace(inputDto.Details) && string.IsNullOrWhiteSpace(inputDto.VillageId.ToString())) return BadRequest("Invalid input data.");

            if (inputDto.Details != null)
            {
                address.Details = inputDto.Details;
            }

            if (inputDto.VillageId != null)
            {
                address.VillageId = inputDto.VillageId;
            }
            await _iRepository.Save();

            return Ok();
        }
        #endregion

        #region DeleteAddress
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _iRepository.GetAddress(id);
            _iRepository.Delete(address);
            await _iRepository.Save();
            return Ok();
        }
        #endregion
    }
}

