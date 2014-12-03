using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Social.Web.Models;

namespace Social.Web.Controllers
{
    public class FacebookController : SocialController
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
                          .AppSettings["FacebookApplication"];
            }
        }

        public ActionResult LogOn()
        {
            var url_referrer = Request.UrlReferrer.ToString();

            var url =
                string.Format(
                    "https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope={3}"
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
                        "https://graph.facebook.com/oauth/access_token"
                        + "?client_id={0}"
                        + "&redirect_uri={1}"
                        + "&client_secret={2}"
                        + "&code={3}"
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
                social_state.AccessTokenQuery =
                    WebClient.DownloadString(url);
                var me_json =
                    WebClient.DownloadString(
                        string.Format(
                            "https://graph.facebook.com/me?{0}"
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
