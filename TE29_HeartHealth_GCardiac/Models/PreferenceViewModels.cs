using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TE29_HeartHealth_GCardiac.Models
{
    public class PreferenceViewModels
    {
        [Required]
        [Display(Name = "Do you have any previous medical conditions?")]
        public bool MedicalConditions { get; set; }

        [Required]
        [Display(Name = "Which type of sports do you prefer?")]
        public String Sports { get; set; }

        [Required]
        [Display(Name = "Which sport strength do you want?")]
        public String Strength { get; set; }
    }
}