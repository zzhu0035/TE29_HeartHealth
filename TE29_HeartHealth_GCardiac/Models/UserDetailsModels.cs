using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TE29_HeartHealth_GCardiac.Models
{
    public partial class UserDetailsModels : DbContext
    {
        public UserDetailsModels()
            : base("name=UserDetailsModels")
        {
        }

        public virtual DbSet<user_details> user_details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
