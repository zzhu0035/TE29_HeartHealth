using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TE29_HeartHealth_GCardiac.Models
{
    public partial class UserDetailsModels : DbContext
    {

        static UserDetailsModels()
        {
            Database.SetInitializer<UserDetailsModels>(null);
        }

        public UserDetailsModels()
            : base("name=Plans")
        {
        }

        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<FamilyMember> FamilyMember { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
