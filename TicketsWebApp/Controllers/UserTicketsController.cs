using DataAccessLayer.Entities;
using DataAccessLayerSchool.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{

    namespace YourNamespace.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserTicketsController : ControllerBase
        {
            private readonly IUserTicketService con_userTicketService;

            public UserTicketsController(IUserTicketService userTicketService)
            {
                con_userTicketService = userTicketService;
            }

            [HttpGet("{ticketId}/{userId}")]
            public async Task<IActionResult> Get(int ticketId, int userId)
            {
                var userTicket = await con_userTicketService.GetByIdAsync(ticketId, userId);
                if (userTicket == null)
                {
                    return NotFound();
                }

                return Ok(userTicket);
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] UserTicket userTicket)
            {
                await con_userTicketService.AddAsync(userTicket);
                return CreatedAtAction(nameof(Get), new { ticketId = userTicket.TicketId, userId = userTicket.UserId }, userTicket);
            }

            [HttpPut("{ticketId}/{userId}")]
            public async Task<IActionResult> Put(int ticketId, int userId, [FromBody] UserTicket userTicket)
            {
                if (ticketId != userTicket.TicketId || userId != userTicket.UserId)
                {
                    return BadRequest();
                }

                await con_userTicketService.UpdateAsync(userTicket);
                return NoContent();
            }

            [HttpDelete("{ticketId}/{userId}")]
            public async Task<IActionResult> Delete(int ticketId, int userId)
            {
                var userTicket = await con_userTicketService.GetByIdAsync(ticketId, userId);
                if (userTicket == null)
                {
                    return NotFound();
                }

                await con_userTicketService.DeleteAsync(ticketId, userId);
                return NoContent();
            }
        }
    }

}
