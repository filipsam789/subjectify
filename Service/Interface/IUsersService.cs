using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IdentityModels;

namespace Service.Interface
{
    public interface IUsersService
    {
        public List<SubjectifyUser> GetUsers();
        public SubjectifyUser GetPlatformUserById(string id);
        public SubjectifyUser CreateNewUser(SubjectifyUser user);
        public SubjectifyUser UpdateUser(SubjectifyUser user);
        public SubjectifyUser DeleteUser(SubjectifyUser user);
    }
}
