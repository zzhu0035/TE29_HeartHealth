using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TE29_HeartHealth_GCardiac.Models
{
    public class Prediction
    {
        //sex (1 = male; 0 = female)
        [Required]
        [Display(Name = "sex                ")]
        public int sex { get; set; }

        //chest pain type(4 values)
        [Required]
        [Display(Name = "chest pain type             ")]
        public int cp { get; set; }

        //resting blood pressure 94-200
        [Required]
        [Display(Name = "resting blood pressure (94-200)")]
        [Range(94, 200, ErrorMessage = "Please enter number between 94 and 200")]
        public int trestbps { get; set; }

        //serum cholestoral in mg/dl 126-564
        [Required]
        [Display(Name = "serum cholestoral in mg/dl (126-564)")]
        [Range(126, 564, ErrorMessage = "Please enter number between 126 and 564")]
        public int chol { get; set; }

        //fasting blood sugar > 120 mg/dl (1 = true; 0 = false)
        [Required]
        [Display(Name = "fasting blood sugar")]
        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int fbs { get; set; }

        //resting electrocardiographic results(values 0,1,2)
        [Required]
        [Display(Name = "resting electrocardiographic")]
        public int restecg { get; set; }

        //maximum heart rate achieved 71-202
        [Required]
        [Display(Name = "maximum heart rate achieved (71-202)")]
        [Range(71, 202, ErrorMessage = "Please enter number between 71 and 202")]
        public int thalach { get; set; }

        //exercise induced angina (1 = yes; 0 = no)
        [Required]
        [Display(Name = "exercise induced angina")]
        public int exang { get; set; }

        //oldpeak = ST depression induced by exercise relative to rest 0-6.2
        [Required]
        [Display(Name = "ST depression induced by exercise relative to rest (0-6.2)")]
        [Range(0, 6.2, ErrorMessage = "Please enter number between 0 and 6.2")]
        public float oldpeak { get; set; }

        //the slope of the peak exercise ST segment 0 1 2
        [Required]
        [Display(Name = "slope of the peak exercise ST segment")]
        public int slope { get; set; }

        [Required]
        [Display(Name = "number of major vessels(0-3) colored by flourosopy")]
        //number of major vessels(0-3) colored by flourosopy 0-4
        public int ca { get; set; }

        //thal: 0 = normal; 1 = fixed defect; 2 = reversable defect
        [Required]
        [Display(Name = "thal")]
        public int thal { get; set; }

    }
}