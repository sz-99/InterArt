using InterArt_Backend.DBContext;
using InterArt_Backend.Models.DTOs;
using InterArt.Models;

namespace InterArt_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private ArtworkDbContext _db;

        public UserRepository(ArtworkDbContext db)
        {
            _db = db;
        }
        public User SignUpUser(UserSignUpDTO userSignUpDTO)
        {
            var newUser = new User()
            {
                UserName = userSignUpDTO.UserName,
                Name = userSignUpDTO.Name,
                Email = userSignUpDTO.Email,
                Password = userSignUpDTO.Password,
                Level = 1,
                XP = 0,
            };
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public bool LoginUser(UserLoginDTO userLoginDTO)
        {
            User user = _db.Users.FirstOrDefault(u=>u.Email == userLoginDTO.Email);
            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, user.Password);
        }
    }

    public interface IUserRepository
    {
        bool LoginUser(UserLoginDTO userLoginDTO);
        User SignUpUser(UserSignUpDTO userSignUpDTO);
    }
}
