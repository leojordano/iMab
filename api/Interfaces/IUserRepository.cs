using api.Models;

namespace api.Interfaces {
    public interface IUserRepository
    {
        void Register(User user);
        bool CheckIfUserIsValid(string Name, string Email);
        User Login();
        string EncryptPassword(string password);
        string DecryptPassword(string cypher);
    }
}