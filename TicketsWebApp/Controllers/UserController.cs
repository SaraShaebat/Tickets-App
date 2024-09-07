using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager con_userManager;

        public UserController(IUserManager userManager)
        {
            con_userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await con_userManager.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDTO userDto)
        {
            await con_userManager.AddAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDTO userDto)
        {
            await con_userManager.UpdateAsync(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_userManager.DeleteAsync(id);
            return NoContent();
        }
    }

}
