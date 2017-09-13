using System;
using System.Linq;
using iOps.Core.Model;

namespace iOps.Core.Security
{
    public interface IFormsAuthentication
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
    }
}
