using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetbook.Contracts;
using Tweetbook.Contracts.v1;
using Tweetbook.Contracts.v1.Requests;
using Tweetbook.Contracts.v1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Controllers.v1
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAllPosts)]
        public IActionResult GetAllPosts()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.GetPost)]
        public IActionResult GetPost([FromRoute] Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if(post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.CreatePost)]
        public IActionResult CreatePost([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { Id = postRequest.Id };
            if (post.Id == Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }

            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var endpoint = baseUrl + "/" + ApiRoutes.Posts.GetPost.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };

            return Created(endpoint, response);
        }
    }
}
