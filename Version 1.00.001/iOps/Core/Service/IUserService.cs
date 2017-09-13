using iOps.Core.Model;
using System;

namespace iOps.Core.Service
{
    public interface IUserService : ICrudService<User>
    {
        bool IsUnique(string username);
        void ChangePassword(Guid id, string password);
        User Get(string Organization, string username, string password);

    }
}