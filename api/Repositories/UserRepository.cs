using System.Security.Cryptography;
using api.Interfaces;
using api.Models;
using api.Db;
using System.Text;

namespace api.Repositories {
    public class UserRepository : IUserRepository 
    {
        private readonly MariaDbContext _context = new MariaDbContext();
        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public UserValidation CheckIfUserIsValid(string Name, string Email)
        {

            if(Name == "" || Email == "") { 
                return new UserValidation("Preencha todos os campos", false);
            }

            var checkIfUserExist = _context.Users.Any(u => u.Name == Name || u.Email == Email);

            if(checkIfUserExist) return new UserValidation("Usuario já cadastrado", false);
            
            return new UserValidation("Usuario cadastrado com sucesso!", true);
        }
        public User Login()
        {
            return _context.Users.First();
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
    }
}