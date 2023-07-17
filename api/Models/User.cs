using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Enums;

namespace api.Models {

    [Table("user")]
    public class User
    {
        [Key]
        public int _id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserProfile { get; set; }
        public AccessLevelEnum Roles { get; set; }

        public User(string name, string Email, string Password, AccessLevelEnum roles, string UserProfile)
        {
            this.Name = name;
            this.Email = Email;
            this.Password = Password;
            this.Roles = roles;
            this.UserProfile = UserProfile;
        }
    }
}