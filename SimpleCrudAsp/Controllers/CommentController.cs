using Microsoft.AspNetCore.Mvc;
using SimpleCrudAsp.models;
using SimpleCrudAsp.Services;

namespace SimpleCrudAsp.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController: ControllerBase
    {

        private readonly CommentService _commentService;
        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Comment>> CommentList()
        {
            return await _commentService.CommentsList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> FindByID(int id)
        {
            var commentid = await _commentService.CommentById(id);
            if(commentid == null)
            {
                return NotFound();
            }
            return Ok(commentid);
        }


        [HttpPost("create")]
        public async Task<ActionResult<Comment>> CreateComment(Comment comments)
        {
            var create = await _commentService.CreateComment(comments);
            return CreatedAtAction(nameof(FindByID), new { id = comments.Id }, create);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            _commentService.DeleteComment(id);
        }
    }
}
