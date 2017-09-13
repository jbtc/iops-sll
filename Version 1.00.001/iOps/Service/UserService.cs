using System;
using System.Linq;
using System.Web;
using Omu.Encrypto;
using iOps.Core.Model;
using iOps.Core.Repository;
using iOps.Core.Service;

namespace iOps.Service
{
    public class UserService : CrudService<User>, IUserService
    {
        private readonly IHasher hasher;
        private readonly User currentUser;

        public UserService(IRepo<User> repo, IHasher hasher)
            : base(repo)
        {
            
            this.hasher = hasher;
            hasher.SaltSize = 128;
            currentUser = repo.Where(o => o.Username == HttpContext.Current.User.Identity.Name).SingleOrDefault();
        }

        public override Guid Create(User user)
        {
            user.Password = hasher.Encrypt(user.Password);
            return base.Create(user);
        }

        public bool IsUnique(string username)
        {
            return repo.Where(o => o.Username == username).Count() == 0;
        }

        public User Get(string Organization, string username, string password)
        {
            User[] users = repo.Where(o => o.Username == username && o.IsDeleted == false).ToArray();
            foreach(User user in users)
            {
                string PasswordHash = user.Password.ToString();
                
                if ((user.Organizations.Where(o => o.Designator == Organization).Count()) > 0 && hasher.CompareStringToHash(password.ToString(), PasswordHash)) return user;
            }
            return null;
        }

        public void ChangePassword(Guid id, string password)
        {
            hasher.SaltSize = 128;
            DateTime updateTimeStamp = DateTime.Now;

            repo.Get(id).Password = hasher.Encrypt(password);
            repo.Get(id).PasswordDateTime = updateTimeStamp;
            ControlData updateCD = repo.Get(id).ControlFields;
            updateCD.Updated.UserGUID = currentUser.ID;
            updateCD.Updated.TimeStamp = updateTimeStamp;
            repo.Get(id).ControlFields = updateCD;
            repo.Save();
        }

        public static void ChangeUserPassword(ref User user, string password)
        {
            Hasher hasher = new Hasher();
            hasher.SaltSize = 128;
            DateTime updateTimeStamp = DateTime.Now;
            user.Password = hasher.Encrypt(password);
            user.PasswordDateTime = updateTimeStamp;
            ControlData updateCD = new ControlData(user.ControlField);
            updateCD.Updated.UserGUID = Guid.Empty;
            updateCD.Updated.TimeStamp = updateTimeStamp;
            user.ControlField = updateCD.ExportToXMLString();
            
        }
    }
}