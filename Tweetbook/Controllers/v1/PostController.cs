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

namespace Tweetbook.Controllers.v1
{
    public class PostController : Controller
    {
        List<Post> _posts = new List<Post>();

        [HttpGet(ApiRoutes.Posts.GetAllPosts)]
        public IActionResult GetAllPosts()
        {

            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }

            return Ok(_posts);
        }

        [HttpPost(ApiRoutes.Posts.CreatePost)]
        public IActionResult CreatePost([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { Id = postRequest.Id };
            if (string.IsNullOrEmpty(post.Id))
            {
                post.Id = Guid.NewGuid().ToString();
            }

            _posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var endpoint = baseUrl + "/" + ApiRoutes.Posts.GetPost.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };

            return Created(endpoint, response);
        }
    }
}
