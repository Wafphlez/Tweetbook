﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts = new List<Post>();

        public PostService()
        {
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post {i}"
                });
            }
        }

        public Post GetPostById(Guid postId)
        {
            return _posts.SingleOrDefault(x => x.Id == postId);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public bool UpdatePost(Post post)
        {
            if (GetPostById(post.Id) == null)
            {
                return false;
            }

            var index = _posts.FindIndex(x => x.Id == post.Id);
            _posts[index] = post;

            return true;
        }

        public bool DeletePost(Guid postId)
        {
            var post = GetPostById(postId);

            if (post == null)
            {
                return false;
            }

            _posts.Remove(post);
            return true;
        }
    }
}
