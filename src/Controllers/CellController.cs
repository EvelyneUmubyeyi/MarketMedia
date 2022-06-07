using MarketMedia.src.EF;
using MarketMedia.src.Entities;
using MarketMedia.src.Models;
using MarketMedia.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketMedia.src.Controllers
{
    [Route("Cell")]
    public class CellController : Controller
    {
        private readonly IRepository _iRepository;
        private MMDbContext _dbContext;

        public CellController(IRepository Repository, MMDbContext mmDbContext)
        {
            _iRepository = Repository;
            _dbContext = mmDbContext;
        }

        #region GetCell(id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCell(int id)
        {
            var cell = await _iRepository.GetCell(id);
            return Ok(cell);
        }
        #endregion

        #region GetAllCellsInSector
        [HttpGet("InSector{sectorId}")]
        public async Task<IActionResult> GetCellsInVillage(int sectorId)
        {
            if ((_dbContext.Cells.Where(t => t.sectorId.Equals(sectorId)).ToList().Count == 0))
            {
                return NotFound("No cells in that sector found");
            }
            var cells = await _iRepository.GetCellsBySector(sectorId);
            return Ok(cells);
        }
        #endregion

        #region GetAllCells
        [HttpGet]
        public async Task<IActionResult> GetAllCells()
        {
            var cells = await _iRepository.GetAllCells();
            return Ok(cells);
        }
        #endregion

        #region PostCell
        [HttpPost]
        public async Task<IActionResult> PostCell([FromBody] CellInputDto inputDto)
        {

            if (string.IsNullOrWhiteSpace(inputDto.Name) && string.IsNullOrWhiteSpace(inputDto.sectorId.ToString())) return BadRequest("Invalid input data.");
            if ((_dbContext.Cells.Where(t => t.Name.Equals(inputDto.Name) && t.sectorId.Equals(inputDto.sectorId)).ToList()).Count > 0)
            {
                return BadRequest("Cell already exists");
            }
            //AsEnumerable().Any(row => inputDto.VillageId == row.Field<int>("VillageId"));

            var cell = new Cell();

            cell.Name = inputDto.Name;
            cell.sectorId = inputDto.sectorId;

            _iRepository.Add(cell);
            await _iRepository.Save();
            return Ok();
        }
        #endregion

        #region UpdateCell
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCell(int id, [FromBody] CellInputDto inputDto)
        {
            var cell = await _iRepository.GetCell(id);
            if (string.IsNullOrWhiteSpace(inputDto.Name) && string.IsNullOrWhiteSpace(inputDto.sectorId.ToString())) return BadRequest("Invalid input data.");

            cell.Name = inputDto.Name;
            cell.sectorId = inputDto.sectorId;

            await _iRepository.Save();

            return Ok();
        }
        #endregion

        #region DeleteCell
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCell(int id)
        {
            var cell = await _iRepository.GetCell(id);
            _iRepository.Delete(cell);
            await _iRepository.Save();
            return Ok();
        }
        #endregion
    }
}
