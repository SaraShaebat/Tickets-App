using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceManager con_serviceManager;

        public ServiceController(IServiceManager serviceManager)
        {
            con_serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await con_serviceManager.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceDTO serviceDto)
        {
            await con_serviceManager.AddAsync(serviceDto);
            return CreatedAtAction(nameof(GetById), new { id = serviceDto.Id }, serviceDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServiceDTO serviceDto)
        {
            await con_serviceManager.UpdateAsync(serviceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_serviceManager.DeleteAsync(id);
            return NoContent();
        }
    }

}
