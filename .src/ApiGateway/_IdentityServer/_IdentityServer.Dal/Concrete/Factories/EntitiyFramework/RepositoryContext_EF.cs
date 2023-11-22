using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IdentityServer.Dal.Concrete.Factories.EntitiyFramework
{
    public class RepositoryContext_EF : DbContext
    {
        void Configuration()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;


            if (this.Database.IsNpgsql())
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            }
            else if (this.Database.IsSqlServer())
            {

            }
        }
        public RepositoryContext_EF(DbContextOptions<RepositoryContext_EF> options) : base(options)
        {
            Configuration();
        }
        public RepositoryContext_EF()
        {
            Configuration();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                throw new Exception("Kullanılacak Veri Tabanı Ayarları yapılmamış.");
        }

    }
}
