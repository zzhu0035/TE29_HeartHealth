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
        [Range(20, 100, ErrorMessage = "Please enter a number between 20 and 100.")]
        public int Age { get; set; }

        [Display(Name = "Height(cm)")]
        [Range(100, 250, ErrorMessage = "Please enter a number between 100 and 250.")]
        public int Height { get; set; }

        [Display(Name = "Weight(kg)")]
        [Range(30, 200, ErrorMessage = "Please enter a number between 30 and 200.")]
        public int Weight { get; set; }

        [Display(Name = "HeartRate\n(times/min)")]
        [Range(50, 150, ErrorMessage = "Please enter a number between 50 and 150.")]
        public int? HeartRate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Create by")]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
