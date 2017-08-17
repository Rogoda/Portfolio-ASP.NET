using Portfolio1.Infrastructure.Abstract;
using Portfolio1.PasswordHash;
using Portfolio1Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Portfolio1.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {

        public bool Authenticate(string username, string password)
        {
            bool result = false;

            Portfolio1DB model = new Portfolio1DB();
            Users user = model.Users.ToList().Where(u => u.LoginName.Equals(username)).FirstOrDefault();

            if (user != null)
            {
                result = Helper.VerifyHash(password, "SHA512", user.PasswordHash);
                if (result == true)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                }
            }

            return result;
        }
    }
}