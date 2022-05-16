using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public string releaseDate { get; set; }
        public string bookCategory { get; set; }
        public string department { get; set; }
        public string bookImage { get; set; }
        public int bookPrice { get; set; }
        public int userIdFK { get; set; }
        public int locationIdFK { get; set; }
    }
}