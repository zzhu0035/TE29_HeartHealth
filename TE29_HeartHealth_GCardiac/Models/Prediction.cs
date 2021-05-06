using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TE29_HeartHealth_GCardiac.Models
{
    public class Prediction
    {
        //sex
        public int sex { get; set; }

        //chest pain type(4 values)
        public int cp { get; set; }

        //resting blood pressure 94-200
        public int trestbps { get; set; }

        //serum cholestoral in mg/dl 126-564
        public int chol { get; set; }

        //fasting blood sugar > 120 mg/dl
        public Boolean fbs { get; set; }

        //resting electrocardiographic results(values 0,1,2)
        public int restecg { get; set; }

        //maximum heart rate achieved 71-202
        public int thalach { get; set; }

        //exercise induced angina
        public Boolean exang { get; set; }

        //oldpeak = ST depression induced by exercise relative to rest 0-6.2
        public float oldpeak { get; set; }

        //the slope of the peak exercise ST segment 0 1 2
        public int slope { get; set; }

        //number of major vessels(0-3) colored by flourosopy 0-4
        public int ca { get; set; }

        //thal: 0 = normal; 1 = fixed defect; 2 = reversable defect
        public int thal { get; set; }

    }
}