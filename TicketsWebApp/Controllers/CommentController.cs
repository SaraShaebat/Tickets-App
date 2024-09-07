using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TicketsWebAppPresentationLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager con_commentManager;

        public CommentController(ICommentManager commentManager)
        {
            con_commentManager = commentManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await con_commentManager.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentDTO commentDto)
        {
            await con_commentManager.AddAsync(commentDto);
            return CreatedAtAction(nameof(GetById), new { id = commentDto.Id }, commentDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentDTO commentDto)
        {
            await con_commentManager.UpdateAsync(commentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await con_commentManager.DeleteAsync(id);
            return NoContent();
        }
    }
}
