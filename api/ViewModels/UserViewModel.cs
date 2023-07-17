using api.Enums;

namespace api.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string UserProfile { get; set; } = "";
        public AccessLevelEnum AccessLevel { get; set; }
    }
}