using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public Int64 UserID { get; set; } //PK
        public String Username { get; set; }
        public String User_Email { get; set; }
    }
}
