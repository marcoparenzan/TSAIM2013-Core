using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.Web.Models
{
    public class SocialApplication
    {
        public static SocialApplication Parse(string value)
        {
            var parts = value.Split(';');
            var info = new SocialApplication
            {
                Localhost = parts[0].Trim()
                ,
                AppId = parts[1].Trim()
                ,
                AppSecret = parts[2].Trim()
                ,
                DefaultScope = parts[3].Trim()
            };
            return info;
        }

        public string Localhost { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string DefaultScope { get; set; }
    }
}