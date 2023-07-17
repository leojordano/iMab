using api.Enums;

namespace api.Models
{
    public class AuthorizeRole
    {
        public string Route { get; set; } = "";
        public List<AccessLevelEnum> AccessLevel { get; set; } = new List<AccessLevelEnum>();
    }
}