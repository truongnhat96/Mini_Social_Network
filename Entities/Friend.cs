using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Friend
    {
        public required string FullName { get; set; }
        public string Status { get; set; } = "None";
    }
}
