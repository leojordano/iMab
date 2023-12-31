using System.Security.Cryptography;
using System.Text; 
using api.Interfaces;
using api.Models;
using api.Db;
using api.ViewModels;

namespace api.Repositories {
    public class UserRepository : IUserRepository 
    {
        private readonly MariaDbContext _context = new MariaDbContext();
        
        #region Routes
        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User Login()
        {
            return _context.Users.First();
        }
        #endregion

        #region Manipulations
        public User GetUserByEmail(string email)
        {   
            return _context.Users.First(u => u.Email == email);
;
        }
        #endregion

        #region Utils
        public UserValidation CheckIfUserIsValidOnRegister(UserViewModel userViewModel)
        {

            if(userViewModel.Name == "" || userViewModel.Email == "" || userViewModel.Password == "") { 
                return new UserValidation("Preencha todos os campos", false);
            }

            var checkIfUserExist = _context.Users.Any(u => u.Name == userViewModel.Name || u.Email == userViewModel.Email);

            if(checkIfUserExist) return new UserValidation("Usuario já cadastrado", false);
            
            return new UserValidation("Usuario cadastrado com sucesso!", true);
        }
        public UserValidation CheckIfUserIsValidOnLogin(LoginViewModel loginViewModel)
        {

            if(loginViewModel.Email == "" || loginViewModel.Password == "") { 
                return new UserValidation("Preencha todos os campos", false);
            }

            var checkIfUserExist = _context.Users.Any(u => u.Email == loginViewModel.Email);

            if(!checkIfUserExist) return new UserValidation("Usuario não encontrado!", false);
            
            return new UserValidation("Usuario encontrado!", true);
        }
        public string EncryptPassword(string password)
        {
            if(password == null) throw new ArgumentNullException("password");

            try
            {
                var data = Encoding.Unicode.GetBytes(password);
                byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

                return Convert.ToBase64String(encrypted);
            } catch(CryptographicException e)
            {
                throw new Exception("", e);
            }
        }
        public string DecryptPassword(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
        #endregion
    }
}