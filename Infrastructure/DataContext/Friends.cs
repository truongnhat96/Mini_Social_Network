using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataContext
{
    [Table("Friend")]
    public class Friends
    {
        [Key]
        [StringLength(200)]
        public required string FullName { get; set; }
        [StringLength(10)]
        public string Status { get; set; } = "None";

        public virtual Accounts? Account { get; set; }
    }
}
