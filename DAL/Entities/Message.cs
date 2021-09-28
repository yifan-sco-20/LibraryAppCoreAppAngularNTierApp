using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Message
    {

        public Int64 MessageID { get; set; } //PK
        public String Message_Content { get; set; }

    }
}
