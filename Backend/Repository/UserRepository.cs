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
    }

    public interface IUserRepository
    {
        User SignUpUser(UserSignUpDTO userSignUpDTO);
    }
}
