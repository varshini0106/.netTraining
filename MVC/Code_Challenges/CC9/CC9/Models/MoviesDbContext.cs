﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CC9.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("connectstr") { }

        public DbSet<Movie> Movies { get; set; }
    }
}
