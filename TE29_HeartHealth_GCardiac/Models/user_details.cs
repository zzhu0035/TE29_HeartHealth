namespace TE29_HeartHealth_GCardiac.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int age { get; set; }

        public int height { get; set; }

        public int? weight { get; set; }

        public int? heart_rate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
