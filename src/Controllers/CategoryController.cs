using MarketMedia.src.EF;
using MarketMedia.src.Entities;
using MarketMedia.src.Models;
using MarketMedia.src.Services;
using Microsoft.AspNetCore.Mvc;
namespace MarketMedia.src.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        private readonly IRepository _iRepository;
        private MMDbContext _dbContext;

        public CategoryController(IRepository Repository, MMDbContext mmDbContext)
        {
            _iRepository = Repository;
            _dbContext = mmDbContext;
        }

        #region GetCategory(id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _iRepository.GetCategory(id);
            return Ok(category);
        }
        #endregion

        #region GetAllCategories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await _iRepository.GetAllCategories();
            return Ok(category);
        }
        #endregion

        #region PostCategory
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryInputDto inputDto)
        {

            if (string.IsNullOrWhiteSpace(inputDto.Name)) return BadRequest("Invalid input data.");
            if (_dbContext.Categories.Where(t => t.Name.Equals(inputDto.Name)).ToList().Count > 0)
            {
                return BadRequest("Category already exists");
            }

            var category = new Category();
            category.Name = inputDto.Name;
          
            _iRepository.Add(category);
            await _iRepository.Save();
            return Ok();
        }
        #endregion

        #region UpdateCategory
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] CategoryInputDto inputDto)
        {
            var category = await _iRepository.GetCategory(id);
            if (string.IsNullOrWhiteSpace(inputDto.Name)) return BadRequest("Invalid input data.");

            category.Name = inputDto.Name;
            await _iRepository.Save();

            return Ok();
        }
        #endregion

        #region DeleteCategory
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _iRepository.GetCategory(id);
            _iRepository.Delete(category);
            await _iRepository.Save();
            return Ok();
        }
        #endregion
    }
}