using SheepShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SheepShop.Context
{
    public class HerdContext : DbContext
    {
        public DbSet<Herd>herd { get; set; }

    }
}