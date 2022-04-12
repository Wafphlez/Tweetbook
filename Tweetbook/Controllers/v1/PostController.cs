using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetbook.Contracts;
using Tweetbook.Contracts.v1;
using Tweetbook.Domain;

namespace Tweetbook.Controllers.v1
{
    public class PostController : Controller
    {
        [HttpGet(ApiRoutes.Posts.GetAllPosts)]
        public IActionResult GetAllPosts()
        {
            List<Post> posts = new List<Post>();

            for (int i = 0; i < 5; i++)
            {
                posts.Add(new Post { Id = Guid.NewGuid() });
            }

            return Ok(posts);
        }
    }
}
