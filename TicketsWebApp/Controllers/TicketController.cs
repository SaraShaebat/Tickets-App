using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketManager con_ticketManager;

        public TicketController(ITicketManager ticketManager)
        {
            con_ticketManager = ticketManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await con_ticketManager.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TicketDTO ticketDto)
        {
            await con_ticketManager.AddAsync(ticketDto);
            return CreatedAtAction(nameof(GetById), new { id = ticketDto.Id }, ticketDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketDTO ticketDto)
        {
            await con_ticketManager.UpdateAsync(ticketDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_ticketManager.DeleteAsync(id);
            return NoContent();
        }
    }
}
