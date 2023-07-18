using api.Models;
using api.ViewModels;

namespace api.Interfaces {
    public interface IUserRepository
    {
        void Register(User user);
        UserValidation CheckIfUserIsValidOnRegister(UserViewModel userViewModel);
        UserValidation CheckIfUserIsValidOnLogin(LoginViewModel loginViewModel);
        User Login();
        string EncryptPassword(string password);
        string DecryptPassword(string cypher);
        User GetUserByEmail(string Email);
    }
}