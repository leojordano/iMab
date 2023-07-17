using api.Models;
using api.ViewModels;

namespace api.Interfaces {
    public interface IUserRepository
    {
        void Register(User user);
        UserValidation CheckIfUserIsValid(UserViewModel userViewModel);
        User Login();
        string EncryptPassword(string password);
        string DecryptPassword(string cypher);
    }
}