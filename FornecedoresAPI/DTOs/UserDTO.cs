using Microsoft.AspNetCore.Identity;

namespace FornecedoresAPI.DTOs
{
    public class UserDTO 
    {
        public string? Email { get; set; }
        public string? Password { get; set; }           
        public string? ConfirmPassword { get; set; }
    }
}
