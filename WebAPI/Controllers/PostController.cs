using Business.Abstracts;
using Business.Dtos.Requests.Post;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePostRequest createPostRequest)
        {
            var result = await _postService.AddAsync(createPostRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePostRequest updatePostRequest)
        {
            var result = await _postService.UpdateAsync(updatePostRequest);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _postService.GetListPosts(pageRequest);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _postService.DeleteById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeletePostRequest deletePostRequest)
        {
            var result = await _postService.DeleteAsync(deletePostRequest);
            return Ok(result);
        }

        [HttpDelete("deletebymail/{email}")]
        public async Task<IActionResult> DeleteByMailAsync(string email)
        {
            var result = await _postService.DeleteByMailAsync(email);
            return Ok(result);
        }
    }
}