using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    public class Post
    {
        public int postId { get; set; }
      
        public string post { get; set; }
        public string postImage { get; set; }
       
        public string file { get; set; }
        public string postType { get; set; }
        public string privacy { get; set; }
        public int userId { get; set; }
        public string date_time { get; set; }
    }
}