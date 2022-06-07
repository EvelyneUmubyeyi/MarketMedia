using Microsoft.AspNetCore.Mvc;
using MarketMedia.src.EF;
using MarketMedia.src.Entities;
using MarketMedia.src.Models;
using MarketMedia.src.Services;

namespace MarketMedia.src.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IRepository _iRepository;
        private MMDbContext _dbContext;

        public ContactController(IRepository Repository, MMDbContext mmDbContext)
        {
            _iRepository = Repository;
            _dbContext = mmDbContext;
        }

        #region GetContact(id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            if ((_dbContext.Contacts.Where(t => t.Id.Equals(id)).ToList().Count == 0))
            {
                return NotFound("Contact not found");
            }
            var contact = await _iRepository.GetContact(id);
            return Ok(contact);
        }
        #endregion

        #region GetAllContacts
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _iRepository.GetAllContacts();
            return Ok(contacts);
        }
        #endregion

        #region PostContact
        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody] ContactInputDto inputDto)
        {

            if (string.IsNullOrWhiteSpace(inputDto.Email)) return BadRequest("Invalid input data.");
            if ((_dbContext.Contacts.Where(t => t.Email.Contains(inputDto.Email)
                                        && t.phone.Contains(inputDto.phone))
                                        .ToList()).Count > 0)
            {
                return BadRequest("Contact is already recorded");
            }

            var contact = new Contact();
            if(inputDto.Email)
            contact.Email = inputDto.Name;
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

