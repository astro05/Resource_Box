using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Models
{
    public class Location
    {
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public string lattitude { get; set; }

        public string longitude { get; set; }
    }
}