namespace TE29_HeartHealth_GCardiac.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyMember")]
    public partial class FamilyMember
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression("[0-9a-zA-Z]{4,10}", ErrorMessage = "Please only enter the numbers & characters and the length should be 4-10 characters.")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        [Range(0, 100, ErrorMessage = "Please enter a number between 0 and 100.")]
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

        [Display(Name = "Secret Reward")]
        public string SecretReward { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}
