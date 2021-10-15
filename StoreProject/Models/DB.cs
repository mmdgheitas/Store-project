using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreProject.Models
{
    public class DB : DbContext
    {
        public DB() : base("st") { }
        public DbSet<item> items { get; set; }
        public DbSet<human> humen { get; set; }
        public DbSet<DATA> data { get; set; }
        public DbSet<Card> card { get; set; }

    }
}