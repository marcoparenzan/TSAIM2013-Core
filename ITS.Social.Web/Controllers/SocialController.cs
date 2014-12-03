using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Social.Web.Models;

namespace Social.Web.Controllers
{
    public abstract class SocialController : Controller
    {
        private SocialState _socialState;

        protected SocialState SocialState
        {
            get
            {
                if (_socialState == null)
                {
                    if (Request.Cookies.AllKeys.Contains("social_state"))
                    {
                        var social_state_json =
                            Request.Cookies["social_state"].Value;
                        _socialState =
                            DeserializeJson<SocialState>(social_state_json);
                    }
                }
                return _socialState;
            }

            set
            {
                _socialState = value;
                var social_state_json =
                    SerializeJson(_socialState);
                Response.AppendCookie(
                    new HttpCookie("social_state", social_state_json)
                    {
                        Expires = DateTime.Now.AddDays(7)
                    }
                );
            }
        }

        protected abstract string SocialApplicationConfiguration { get; }

        private SocialApplication _socialApplication;

        protected SocialApplication SocialApplication
        {
            get
            {
                if (_socialApplication == null)
                {
                    _socialApplication =
                        SocialApplication.Parse(
                            SocialApplicationConfiguration
                        );
                }
                return _socialApplication;
            }
        }

        private WebClient _webClient;

        protected WebClient WebClient
        {
            get
            {
                if (_webClient == null)
                {
                    _webClient = new WebClient();
                }
                return _webClient;
            }
        }

        private JsonSerializer _jsonSerializer;

        protected JsonSerializer JsonSerializer
        {
            get
            {
                if (_jsonSerializer == null)
                {
                    _jsonSerializer = new JsonSerializer();
                }
                return _jsonSerializer;
            }
        }

        protected T DeserializeJson<T>(string json)
        {
            var reader = new JsonTextReader(
                new System.IO.StringReader(json));
            var target = JsonSerializer.Deserialize<T>(reader);
            return target;
        }

        protected dynamic DeserializeJson(string json)
        {
            var reader = new JsonTextReader(
                new System.IO.StringReader(json));
            var target = JsonSerializer.Deserialize(reader);
            return target;
        }

        protected string SerializeJson<T>(T target)
        {
            var string_writer = new System.IO.StringWriter();
            var writer =
                new JsonTextWriter(string_writer);
            JsonSerializer.Serialize(writer, target);
            return string_writer.ToString();
        }
    }
}
