using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketTypeManager con_ticketTypeManager;

        public TicketTypeController(ITicketTypeManager ticketTypeManager)
        {
            con_ticketTypeManager = ticketTypeManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticketType = await con_ticketTypeManager.GetByIdAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }
            return Ok(ticketType);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TicketTypeDTO ticketTypeDto)
        {
            await con_ticketTypeManager.AddAsync(ticketTypeDto);
            return CreatedAtAction(nameof(GetById), new { id = ticketTypeDto.Id }, ticketTypeDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketTypeDTO ticketTypeDto)
        {
            await con_ticketTypeManager.UpdateAsync(ticketTypeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_ticketTypeManager.DeleteAsync(id);
            return NoContent();
        }
    }

}
