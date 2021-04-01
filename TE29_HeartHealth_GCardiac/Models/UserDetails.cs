namespace TE29_HeartHealth_GCardiac.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int? HeartRate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
