using api.Models;
using api.Db;

namespace api.Seeds
{
    public class UsersSeeds
    {
        private List<User> Users = new List<User>()
        {
        };

        public UsersSeeds(MariaDbContext _context)
        {
            foreach(var user in Users)
            {
                var CheckIfUserExist = _context.Users
                    .Any(u => u.Email == user.Email || u.Name == user.Name);

                if(!CheckIfUserExist) {
                    _context.Users.Add(user);
                }
            }

            _context.SaveChanges();
        }
    }
}