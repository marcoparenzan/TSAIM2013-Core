using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.Web.Models
{
    public class SocialState
    {
        public string AppId { get; set; }
        public string AccessTokenQuery { get; set; }
        public SocialUser Me { get; set; }
    }
}