using InterArt_Backend.Models.DTOs;
using InterArt_Backend.Repository;
using InterArt.Models;
using BCrypt.Net;

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
            UserSignUpDTO newUser = new UserSignUpDTO()
            {
                UserName = userSignUpDTO.UserName,
                Name = userSignUpDTO.Name,
                Email = userSignUpDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userSignUpDTO.Password)
            };
            return _userRepository.SignUpUser(newUser);
        }

        public bool LoginUser(UserLoginDTO userLoginDTO)
        {
            return _userRepository.LoginUser(userLoginDTO);
        }
    }

    public interface IUserService
    {
        bool LoginUser(UserLoginDTO userLoginDTO);
        User SignUpUser(UserSignUpDTO userSignUpDTO);
    }
}
