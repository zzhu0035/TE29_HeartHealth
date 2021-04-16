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
        [Display(Name = "Which type of exericses do you prefer?")]
        public String Sports { get; set; }

        [Required]
        [Display(Name = "Which exericses strength do you want?")]
        public String Strength { get; set; }

        public List<ExerciseModel> exercise { get; set; }
    }
}