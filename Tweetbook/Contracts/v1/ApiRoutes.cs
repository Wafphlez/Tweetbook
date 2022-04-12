﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweetbook.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/"+ Version;

        public static class Posts
        {
            public const string GetAllPosts = Base + "/posts";
        }
    }
}
