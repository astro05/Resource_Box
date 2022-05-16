using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    public class UserNotification
    {
        public int userId { get; set; }
        public int messageUnread { get; set; }
        public int newNotification { get; set; }
       
    }
}