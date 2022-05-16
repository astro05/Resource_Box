using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    public class UserChat
    {
        public int messageId { get; set; }
        public int senderId { get; set; }
        public string senderName { get; set; }
        public string senderImage { get; set; }
        public int recieverId { get; set; }
        public string recieverName { get; set; }
        public string recieverImage { get; set; }
        public string message { get; set; }
        public string date_time { get; set; }

        public string seen { get; set; }
        public string seen_time { get; set; }
    }
}