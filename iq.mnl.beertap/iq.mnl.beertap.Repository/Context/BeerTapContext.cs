using System.Data.Entity;
using iq.mnl.beertap.Repository.Mapping;
using iq.mnl.beertap.Repository.ModelDto;

namespace iq.mnl.beertap.Repository.Context
{
    public class BeerTapContext : DbContext, IBeerTapContext 
    {
        public BeerTapContext() : base("name=BeerTapDatabase") { }

        public virtual DbSet<OfficeDto> Offices { get; set; }
        public virtual DbSet<BeerTapDto> BeerTaps { get; set; }

        public void SaveDbChanges()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OfficeMap());
            modelBuilder.Configurations.Add(new BeerTapMap());
        }
    }
}
