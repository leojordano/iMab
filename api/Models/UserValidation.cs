namespace api.Models {
    public class UserValidation
    {
        public string Message { get; set; } = "";
        public bool IsValid { get; set; } = false;

        public UserValidation(string Message, bool isValid = false)
        {
            this.Message = Message;
            this.IsValid = isValid;
        }
    }
}