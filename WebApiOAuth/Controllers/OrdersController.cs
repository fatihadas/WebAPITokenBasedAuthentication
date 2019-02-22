using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApiOAuth.Models;

namespace WebApiOAuth.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private User2Context db = new User2Context();

        [HttpGet]
        [Route("list")]
        [Authorize]
        public HttpResponseMessage listele()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.Users.ToList()));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("find/{username}")]
        public HttpResponseMessage find(string username)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.Users.Single(p => p.UserName == username)));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Authorize]
        public List<string> List()
        {
            //using (var db = new User2Context())
            //{
            //    var dbUser = db.Users.Single(p => p.UserName == context.UserName);
            //    if (dbUser.UserName == context.UserName && dbUser.Password == context.Password)
            //    {
            //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //        identity.AddClaim(new Claim("sub", context.UserName));
            //        identity.AddClaim(new Claim("role", "user"));
            //        context.Validated(identity);
            //    }
            //    else
            //    {
            //        context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            //    }
            //}

            List<string> orders = new List<string>();

            orders.Add("Elma");
            orders.Add("Armut");
            orders.Add("Erik");

            return orders;
        }
    }

}
