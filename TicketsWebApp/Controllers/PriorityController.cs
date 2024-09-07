using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityManager con_priorityManager;

        public PriorityController(IPriorityManager priorityManager)
        {
            con_priorityManager = priorityManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var priority = await con_priorityManager.GetByIdAsync(id);
            if (priority == null)
            {
                return NotFound();
            }
            return Ok(priority);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PriorityDTO priorityDto)
        {
            await con_priorityManager.AddAsync(priorityDto);
            return CreatedAtAction(nameof(GetById), new { id = priorityDto.Id }, priorityDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PriorityDTO priorityDto)
        {
            await con_priorityManager.UpdateAsync(priorityDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_priorityManager.DeleteAsync(id);
            return NoContent();
        }
    }

}
