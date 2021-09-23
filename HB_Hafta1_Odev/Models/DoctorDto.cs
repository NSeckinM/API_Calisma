using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HB_Hafta1_Odev.Models
{

    //Model And Validation for Entity

    public class DoctorDto
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("(M|F|N)(1)",ErrorMessage ="you can enter only one character that is 'M'(Male) or 'F'(Female) or 'N'(Not Defined)")]
        public string Gender { get; set; }

        [Required,MaxLength(50,ErrorMessage ="Clinic name can not be longer than 50 Characters")]
        public string Clinic { get; set; }
        public string HospitalName { get; set; }



    }
}
