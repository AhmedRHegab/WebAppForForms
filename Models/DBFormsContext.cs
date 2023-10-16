using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewFormsProject.Models;

namespace ApplicantsFromProject.Models
{
    public class DBFormsContext : DbContext
    {
        public DBFormsContext(DbContextOptions<DBFormsContext> options) : base(options)
        {

        }

        public DbSet<ApplicantsFrom> ApplicantsFroms { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Speciality> Specialities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicantsFrom>().Property(x => x.Github_Link).IsRequired(false);
            builder.Entity<ApplicantsFrom>().Property(x => x.LinkedIn_Link).IsRequired(false);
            builder.Entity<ApplicantsFrom>().Property(x => x.year_Of_Graduation).IsRequired(false);
            builder.Entity<ApplicantsFrom>().Property(x => x.Current_Company).IsRequired(false);
            builder.Entity<ApplicantsFrom>().Property(x => x.Current_Salary).IsRequired(false);




        }

    }
}
