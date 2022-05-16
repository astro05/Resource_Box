using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    public class ViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<UserChat> UserChats { get; set; }
        public IEnumerable<UserNotification> UserNotifications { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<AboutUs> AboutUs { get; set; }
        public IEnumerable<TermsAndCondition> TermsAndCondition { get; set; }

    }
}