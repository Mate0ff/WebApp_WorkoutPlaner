using Kucharz_Liberacki_Kopanko.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kucharz_Liberacki_Kopanko.Models.DbModels;

namespace Kucharz_Liberacki_Kopanko.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Kucharz_Liberacki_KopankoConnectionString") { }
        public DbSet<User> User { get; set;}
        public DbSet<Exercise> Exercise { get; set;}
        public DbSet<Plan> Plan { get; set;}
        public DbSet<ExDetails> ExDetails { get; set;}
        public DbSet<Plan_Ex> Plan_Ex { get; set; }
    }
}