using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_AspNetIdentity.Models;

namespace WebApi_AspNetIdentity.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            // Par defaut le minimum pour le mot de passe est de 6 caracteres donc pour changer ce caractere par defaut.

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };

            IdentityResult result = manager.Create(user, model.Password);
            return result;
        }
    }
}
