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
        [Display(Name = "If you have any previous medical conditions, select this option")]
        public bool MedicalConditions { get; set; }

        [Required]
        [Display(Name = "Which type of sports do you prefer?")]
        public String Sports { get; set; }

        [Required]
        [Display(Name = "For each exericse, how much minimum calories you wish to burn (per hour)?")]
        public int MinCalory { get; set; }

        [Required]
        [Display(Name = "For each exericse, how much maximum calories you wish to burn (per hour)?")]
        public int MaxCalory { get; set; }
    }
}