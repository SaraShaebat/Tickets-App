using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusManager con_statusManager;

        public StatusController(IStatusManager statusManager)
        {
            con_statusManager = statusManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await con_statusManager.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StatusDTO statusDto)
        {
            await con_statusManager.AddAsync(statusDto);
            return CreatedAtAction(nameof(GetById), new { id = statusDto.Id }, statusDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StatusDTO statusDto)
        {
            await con_statusManager.UpdateAsync(statusDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_statusManager.DeleteAsync(id);
            return NoContent();
        }
    }
}
