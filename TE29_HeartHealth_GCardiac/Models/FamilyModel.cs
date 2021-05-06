using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TE29_HeartHealth_GCardiac.Models
{
    public partial class FamilyModel : DbContext
    {
        public FamilyModel()
            : base("name=FamilyModel")
        {
        }

        public virtual DbSet<FamilyMember> FamilyMember { get; set; }
        public IEnumerable<object> UserDetails { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
