using System;
using System.Collections.Generic;
using System.Data.Entity;
using MvcNormal.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcNormal.Data
{
    public class MockDB : DbContext
    {

        public DbSet<Adresse> Adressen { get; set; }
        public DbSet<Beleg> Belege { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Position> Positionen { get; set; }


    }
}
