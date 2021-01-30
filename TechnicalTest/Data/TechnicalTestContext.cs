using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TechnicalTest.Data
{
    public class TechnicalTestContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TechnicalTestContext() : base("name=TechnicalTestContext")
        {
        }

        public System.Data.Entity.DbSet<Genoma.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<Genoma.Models.Analysis> Analyses { get; set; }

        public System.Data.Entity.DbSet<Genoma.Models.PersonalityTraitsResults> PersonalityTraitsResults { get; set; }

        public System.Data.Entity.DbSet<Genoma.Models.Candidate> Candidates { get; set; }

        public System.Data.Entity.DbSet<Job.Models.Advertisement> Advertisements { get; set; }

        public System.Data.Entity.DbSet<Job.Models.PrefilledStatus> PrefilledStatus { get; set; }
    }
}
