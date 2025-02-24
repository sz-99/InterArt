using InterArt_Backend.Models.DTOs;
using InterArt_Backend.Repository;
using InterArt.Models;

namespace InterArt_Backend.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User SignUpUser(UserSignUpDTO userSignUpDTO)
        {
            return _userRepository.SignUpUser(userSignUpDTO);
        }
    }

    public interface IUserService
    {
        User SignUpUser(UserSignUpDTO userSignUpDTO);
    }
}
