using Domain.IdentityModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public SubjectifyUser CreateNewUser(SubjectifyUser user)
        {
            var insertedUser = _userRepository.Insert(user); 
            return insertedUser;
        }

        public SubjectifyUser DeleteUser(SubjectifyUser user)
        {
            return _userRepository.Delete(user); 
        }

        public SubjectifyUser GetPlatformUserById(string id)
        {
            return _userRepository.Get(id);
        }

        public List<SubjectifyUser> GetUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public SubjectifyUser UpdateUser(SubjectifyUser user)
        {
            return _userRepository.Update(user);
        }
    }
}
