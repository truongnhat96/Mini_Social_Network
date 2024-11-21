using System.ComponentModel.DataAnnotations;

namespace GUI.Models
{
    public class AccountModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string DisplayName { get; set; }
    }
}
