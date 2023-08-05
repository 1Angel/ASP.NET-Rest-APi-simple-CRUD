using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleCrudAsp.models;
using SimpleCrudAsp.Services;

namespace SimpleCrudAsp.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController: ControllerBase
    {
        private readonly PostServices _postServices;
        public PostController(PostServices postServices) 
        {
                _postServices= postServices;   
        }

        [HttpGet("")]
        public async Task<IEnumerable<Post>> GetAll()
        {
            var posts = await _postServices.GetAll();
            return posts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetByID(int id)
        {
            var postsid = await _postServices.GetByID(id);
            if(postsid is null)
            {
                return NotFound();
            }
            return Ok(postsid);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
        {

            var createPost = await _postServices.CreatePost(post);
            return CreatedAtAction(nameof(GetByID), new {id = post.Id}, post);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            if(id != post.Id)
            {
                return BadRequest();
            }
            var posts = await _postServices.UpdatePost(id, post);
            if(posts == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public void DeletePost(int id)
        {
            _postServices.DeletePost(id);
        }
    }
}
