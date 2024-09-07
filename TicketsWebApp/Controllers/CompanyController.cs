using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager con_companyManager;

        public CompanyController(ICompanyManager companyManager)
        {
            con_companyManager = companyManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await con_companyManager.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyDTO companyDto)
        {
            await con_companyManager.AddAsync(companyDto);
            return CreatedAtAction(nameof(Get), new { id = companyDto.Id }, companyDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CompanyDTO companyDto)
        {
            await con_companyManager.UpdateAsync(companyDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_companyManager.DeleteAsync(id);
            return NoContent();
        }
    }
}
