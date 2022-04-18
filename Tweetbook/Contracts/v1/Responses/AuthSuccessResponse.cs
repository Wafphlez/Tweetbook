using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweetbook.Contracts.v1.Responses
{
    public class AuthSuccessResponse
    {
        // TODO: Email verification before returning a token

        public string Token { get; set; }
    }
}
