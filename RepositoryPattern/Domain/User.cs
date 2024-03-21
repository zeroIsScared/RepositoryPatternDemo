using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
    public class User : BaseEntity
    {
       
        public string Email { get; set; }
        public int Points { get; set; }
        public int PostedItems { get; set; }
    }
}
