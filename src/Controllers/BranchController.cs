using Microsoft.AspNetCore.Mvc;
using MarketMedia.src.EF;
using MarketMedia.src.Entities;
using MarketMedia.src.Models;
using MarketMedia.src.Services;

namespace MarketMedia.src.Controllers
{
    [Route("Branch")]
    public class BranchController : Controller
    {
        private readonly IRepository _iRepository;
        private MMDbContext _dbContext;

        public BranchController(IRepository Repository, MMDbContext mmDbContext)
        {
            _iRepository = Repository;
            _dbContext = mmDbContext;
        }

        #region GetBranch(id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranch(int id)
        {
            if ((_dbContext.Branches.Where(t => t.Id.Equals(id)).ToList().Count == 0))
            {
                return NotFound("Branch not found");
            }
            var branch = await _iRepository.GetBranch(id);
            return Ok(branch);
        }
        #endregion

        #region GetBranch(VillageId)
        [HttpGet("InVillage/{villageId}")]
        public async Task<IActionResult> GetBranchesInVillage(int villageId)
        {
            if ((_dbContext.Branches.Where(t => t.villageId.Equals(villageId)).ToList().Count == 0))
            {
                return NotFound("No branches in that village found");
            }
            var branches = await _iRepository.GetBranchesByVillage(villageId);
            return Ok(branches);
        }
        #endregion

        #region GetBranch(SellerId)
        [HttpGet("BySeller/{sellerId}")]
        public async Task<IActionResult> GetBranchesBySeller(int sellerId)
        {
            if ((_dbContext.Branches.Where(t => t.sellerId.Equals(sellerId)).ToList().Count == 0))
            {
                return NotFound("No branches by that seller found");
            }
            var branches = await _iRepository.GetBranchesBySeller(sellerId);
            return Ok(branches);
        }
        #endregion

        #region GetBranch(streetNumber)
        [HttpGet("OnStreet/{streetNumber}")]
        public async Task<IActionResult> GetBranchesOnStreet(string streetNumber)
        {
            if ((_dbContext.Branches.Where(t => t.Street_number.Equals(streetNumber)).ToList().Count == 0))
            {
                return NotFound("No branches on that street found");
            }
            var branches = await _iRepository.GetBranchesByStreet(streetNumber);
            return Ok(branches);
        }
        #endregion

        #region GetAllBranches
        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _iRepository.GetAllBranches();
            return Ok(branches);
        }
        #endregion

        #region PostBranch
        [HttpPost]
        public async Task<IActionResult> PostBranch([FromBody] BranchInputDto inputDto)
        {

            if (string.IsNullOrWhiteSpace(inputDto.Name) || string.IsNullOrWhiteSpace(inputDto.villageId.ToString()) || string.IsNullOrWhiteSpace(inputDto.sellerId.ToString())) return BadRequest("Invalid input data.");
            if ((_dbContext.Branches.Where(t => t.Name.Equals(inputDto.Name)
                                        && t.Street_number.Equals(inputDto.Street_number)
                                        && t.Contact.Equals(inputDto.Contact)
                                        && t.sellerId.Equals(inputDto.sellerId)
                                        && t.villageId.Equals(inputDto.villageId))
                                        .ToList()).Count > 0)
            {
                return BadRequest("Branch already exists");
            }

            var branch = new Branch();

            branch.Name = inputDto.Name;
            branch.Street_number = inputDto.Street_number;
            branch.Contact = inputDto.Contact;
            branch.sellerId = inputDto.sellerId;
            branch.villageId = inputDto.villageId;

            _iRepository.Add(branch);
            await _iRepository.Save();
            return Ok();
        }
        #endregion

        #region UpdateBranch
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, [FromBody] BranchInputDto inputDto)
        {
            if (string.IsNullOrWhiteSpace(inputDto.Name) || string.IsNullOrWhiteSpace(inputDto.villageId.ToString()) || string.IsNullOrWhiteSpace(inputDto.sellerId.ToString()))
            return BadRequest("Invalid input data.");
            
            var branch = await _iRepository.GetBranch(id);
            branch.Name = inputDto.Name;
            branch.Street_number = inputDto.Street_number;
            branch.Contact = inputDto.Contact;
            branch.sellerId = inputDto.sellerId;
            branch.villageId = inputDto.villageId;

            await _iRepository.Save();

            return Ok();
        }
        #endregion

        #region DeleteBranch
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _iRepository.GetBranch(id);
            _iRepository.Delete(branch);
            await _iRepository.Save();
            return Ok();
        }
        #endregion
    }
}
