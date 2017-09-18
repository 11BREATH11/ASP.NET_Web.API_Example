using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class OwnersPetsContext : DbContext
    {
        public OwnersPetsContext() : base("name=OwnersPetsContext")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Pets>().ToTable("Pets");
            modelBuilder.Entity<UsersPets>().ToTable("UsersPets");

            base.OnModelCreating(modelBuilder);
        }

    }

}