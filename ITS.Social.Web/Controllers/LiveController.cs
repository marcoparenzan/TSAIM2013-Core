using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Social.Web.Models;

namespace Social.Web.Controllers
{
    public class LiveController : SocialController
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override string SocialApplicationConfiguration
        {
            get
            {
                return ConfigurationManager
                          .AppSettings["LiveApplication"];
            }
        }
        
        public ActionResult LogOn()
        {
            var url_referrer = Request.UrlReferrer.ToString();

            var url =
                string.Format(
                    "https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={3}&response_type=code&redirect_uri={1}"
                    , SocialApplication.AppId
                    , Url.Encode(url_referrer)
                    , string.Empty
                    , SocialApplication.DefaultScope
                );

            return Redirect(url);
        }

        public ActionResult LogOff()
        {
            var url_referrer = Request.UrlReferrer.ToString();

            var url =
                string.Format(
                    "https://graph.facebook.com/me/permissions?method=delete&{0}"
                    , SocialState.AccessTokenQuery
                );
            try
            {
                var result =
                    WebClient.DownloadString(url);
            }
            catch
            {
            }
            finally
            {
                Response.Cookies["social_state"].Expires = DateTime.Now.AddDays(-1);
            }

            return Redirect(url_referrer);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Request.Cookies.AllKeys.Contains("social_state"))
            {
                if (Request.HttpMethod == "GET")
                {
                    ViewBag.social_state = SocialState;
                    ViewBag.is_authenticated = true;
                }
                else
                {
                    ViewBag.is_authenticated = false;
                }
            }
            else if (Request.QueryString.AllKeys.Contains("code"))
            {
                var request_url = Request.Url.ToString().Replace("localhost", SocialApplication.Localhost);
                request_url =
                    request_url
                    .Substring(0, request_url.LastIndexOf("code=") - 1);

                var url =
                    string.Format(
                        "https://login.live.com/oauth20_token.srf"
                        + "?client_id={0}"
                        + "&redirect_uri={1}"
                        + "&client_secret={2}"
                        + "&code={3}"
                        + "&grant_type=authorization_code"
                        , SocialApplication.AppId
                        , Url.Encode(request_url)
                        , SocialApplication.AppSecret
                        , Request.QueryString["code"]
                    );

                var social_state =
                    new SocialState
                    {
                        AppId = SocialApplication.AppId
                    };

                var tokens_json = WebClient.DownloadString(url);
                var tokens = DeserializeJson(tokens_json);
                social_state.AccessTokenQuery =
                    WebClient.DownloadString(url);
                social_state.AccessTokenQuery = string.Format("access_token={0}", tokens.access_token);
                var me_json =
                    WebClient.DownloadString(
                        string.Format(
                            "https://apis.live.net/v5.0/me?{0}"
                            , social_state.AccessTokenQuery
                        )
                    );
                social_state.Me =
                    DeserializeJson<SocialUser>(me_json);

                SocialState = social_state;
                ViewBag.social_state = SocialState;
                ViewBag.is_authenticated = true;

                Response.Redirect(request_url);
            }
            else
            {
                ViewBag.is_authenticated = false;
            }
        }
    }
}
