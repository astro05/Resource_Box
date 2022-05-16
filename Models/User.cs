using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    [Table("Users")]
    public class User
    {
       [Key]
       public int userId { get; set; }
       
       public string userName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string hashCode { get; set; }
        public string image { get; set; }


    }
    
}