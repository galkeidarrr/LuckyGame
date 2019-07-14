using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LuckyFishExercise.Models
{
    public class gameDBContext : DbContext
    {
        public gameDBContext() : base() { }
        public DbSet<Conf> _Configuration { get; set; }
        public DbSet<Sign> _Signs { get; set; }


    }
}