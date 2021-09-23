using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HB_Hafta1_Odev.Models
{
    public class UpdateHospitalNameDto
    {
        [Required]
        public string HospitalName { get; set; }
    }
}
