using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
  public class Post : BaseEntity 
    { 
        
        public string ShortDescription { get; set; }       
        public string Category { get; set; }   
        public bool IsPosted { get; set; }        

    }
}
