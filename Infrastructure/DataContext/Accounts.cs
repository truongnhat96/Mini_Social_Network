using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataContext
{
    [Table("Account")]
    public class Accounts
    {
        [Key]
        [StringLength(100)]
        public required string Username { get; set; }

        [StringLength(50)]
        public required string Password { get; set; }

        [StringLength(200)]
        public required string DisplayName { get; set; }

        public virtual List<Friends>? Friends { get; set; }
    }
}
