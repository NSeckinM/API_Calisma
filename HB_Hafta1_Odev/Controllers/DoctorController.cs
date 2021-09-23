using HB_Hafta1_Odev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB_Hafta1_Odev.Controllers
{
    [Route("api/V1/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        static List<DoctorDto> drList = new List<DoctorDto>()
                {
                    new DoctorDto() {Id = 1 ,FirstName = "Ali", LastName="Yılmaz", Gender="M", Clinic="Genel Cerrahi",HospitalName="A Hastahanesi"},
                    new DoctorDto() {Id = 2 ,FirstName = "Can", LastName="Kalkan", Gender="M", Clinic="Kardiyoloji",HospitalName="A Hastahanesi"},
                    new DoctorDto() {Id = 3 ,FirstName = "Cem", LastName="Çelik", Gender="M", Clinic="Kulak Burun Boğaz",HospitalName="B Hastahanesi"},
                    new DoctorDto() {Id = 4 ,FirstName = "Ece", LastName="Bulut", Gender="F", Clinic="Pediatri",HospitalName="B Hastahanesi"},
                    new DoctorDto() {Id = 5 ,FirstName = "Veli", LastName="Durmaz", Gender="N", Clinic="Dahiliye",HospitalName="C Hastahanesi"},
                };

        [HttpGet]//localHost4458/api/V1/doctors/<fieldName>
        public IActionResult Get(string search)
        {
            string keyword = search.ToLower();
            List<string> filteredList = new List<string>();

            switch (keyword)
            {
                case "firstname":
                    foreach (var dr in drList)
                    {
                        filteredList.Add(dr.FirstName.ToString());
                    }
                    return Ok(filteredList);

                case "lastname":
                    foreach (var dr in drList)
                    {
                        filteredList.Add(dr.LastName.ToString());
                    }
                    return Ok(filteredList);

                case "gender":
                    foreach (var dr in drList)
                    {
                        filteredList.Add(dr.Gender.ToString());
                    }
                    return Ok(filteredList);
                case "clinic":
                    foreach (var dr in drList)
                    {
                        filteredList.Add(dr.Clinic.ToString());
                    }
                    return Ok(filteredList);
                case "hospitalname":
                    foreach (var dr in drList)
                    {
                        filteredList.Add(dr.HospitalName.ToString());
                    }
                    return Ok(filteredList);

                default:
                    return Ok(drList);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getdoctor(int id)
        {
            //DoctorDto dr = _drlist.FirstOrDefault(x => x.Id == id); better and short code.
            foreach (var dr in drList)
            {
                if (dr.Id == id)
                {
                    return await Task.FromResult(Ok(dr));
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateDr([FromBody] DoctorDto dr)
        {
            if (ModelState.IsValid)
            {
                dr.Id = drList.Count + 1;
                drList.Add(dr);
                return CreatedAtAction("GetDoctor", new { Id = dr.Id }, dr); // ===>
            };
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDr([FromRoute] int id, [FromBody] DoctorDto dr)
        {
            if (ModelState.IsValid)
            {
                if (id != dr.Id)
                {
                    return BadRequest("Id information is not confirmed");
                }
                if (!drList.Any(x => x.Id == id))
                {
                    return NotFound();
                }

                foreach (DoctorDto doctor in drList)
                {
                    if (id == doctor.Id)
                    {
                        doctor.FirstName = dr.FirstName;
                        doctor.LastName = dr.LastName;
                        doctor.Clinic = dr.Clinic;
                        doctor.HospitalName = dr.HospitalName;
                        return Ok();
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDr(int id)
        {
            if (!drList.Any(x => x.Id == id))
            {
                return NotFound();
            }
            else
            {
                drList.Remove(drList[id - 1]);
                return NoContent();
            }

        }

        [HttpPatch("{id}")]
        public IActionResult UpdateHospitalName([FromRoute] int id, [FromBody] UpdateHospitalNameDto HospitalName)
        {
            if (ModelState.IsValid)
            {
                if (!drList.Any(x => x.Id == id))
                {
                    return NotFound();
                }
                foreach (DoctorDto doctor in drList)
                {
                    if (id == doctor.Id)
                    {
                        doctor.HospitalName = HospitalName.HospitalName;
                        return Ok();
                    }
                }
            }
            return BadRequest(ModelState);
        }

    }


}

