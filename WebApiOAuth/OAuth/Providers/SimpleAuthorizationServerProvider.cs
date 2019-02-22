using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using WebApiOAuth.Models;

namespace WebApiOAuth.OAuth.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili 
        //ValidateClientAuthentication metotunu override ediyoruz.
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili 
        //GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var db = new User2Context())
            {
                var dbUser = db.Users.Single(p => p.UserName == context.UserName);
                if (dbUser.UserName == context.UserName && dbUser.Password == context.Password)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", context.UserName));
                    identity.AddClaim(new Claim("role", "user"));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
                }
            }

            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            //if (context.UserName == "fatih" && context.Password == "12345")
            //{
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    identity.AddClaim(new Claim("sub", context.UserName));
            //    identity.AddClaim(new Claim("role", "user"));
            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            //}
        }
    }
}

/*
 
                //newUser.FirstName = user.FirstName;
                //newUser.LastName = user.LastName;
                //newUser.Email = user.Email;
                //newUser.Password = user.Password;
                //newUser.CreatedDate = user.CreatedDate;
                //newUser.BirthDay = user.BirthDay;

                //var result1 = (from emp in Db.TblEmployees where emp.EmailId == LoginVar.UserName select emp.Password).FirstOrDefault();
                //string DPassword = Decrypt(result1);
                //// Db.TblEmployees.Where(m=>m.EmailId==LoginVar.UserName && m.Password==LoginVar.Password).FirstOrDefault()
                //if (DPassword == LoginVar.Password)
                //{
                //    return RedirectToAction("EmployeeDetails", "Employee", new { area = "Admin" });
                //}
                //else
                //{
                //    ViewBag.Message = string.Format("UserName and Password is incorrect");
                //    return View();
                //}


                //var data = (from post in db.Posts.AsEnumerable()
                //            where post.Id == postId
                //            select post).FirstOrDefault();

                //data.Name = newName;
                //data.Description = newDescription;
                //data.Validate();
                //db.SaveChanges();
     */
