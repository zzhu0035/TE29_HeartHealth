namespace TE29_HeartHealth_GCardiac.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Height(cm)")]
        public int Height { get; set; }

        [Display(Name = "Weight(kg)")]
        public int Weight { get; set; }

        [Display(Name = "HeartRate(times/min)")]
        public int? HeartRate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Create by")]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
