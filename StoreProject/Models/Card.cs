using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreProject.Models
{
    public class Card
    {
        public int id { get; set; }
        public int prise { get; set; }
        public string code_mahsoul { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string img_src { get; set; }
    }
}