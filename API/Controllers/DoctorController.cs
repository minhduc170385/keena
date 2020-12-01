using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
       // private IDoctorRepository _doctorRepository;
        private IUnitOfWork _repo;

        public DoctorController(IUnitOfWork repo)
        {            
            this._repo = repo;
        }
        // GET: api/doctor
        [HttpGet]
        [ActionName(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAll()
        {
            return Ok(await _repo.Doctor.GetAllAsync());
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctorAndPatient()
        {
            return Ok(await _repo.Doctor.GetAllDoctorAndPatientAsync());
        }


        // GET: api/doctor/1
        [HttpGet("{id}")]
        [ActionName(nameof(GetDoctorById))]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            return await _repo.Doctor.GetByIdAsync(id);
        }
        
        //POST: api/doctor
        [HttpPost]
        public async Task<ActionResult<Doctor>> Insert([FromBody] Doctor doctor)
        {           
            await _repo.Doctor.InsertAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        //Delete: api/members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> Delete(int id)
        {
            Doctor doctor = await _repo.Doctor.DeleteAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            
            return doctor;
        }
        //Put: api/members
        [HttpPut]
        public async Task<ActionResult<Doctor>> Update([FromBody] Doctor doctor)
        {
            await _repo.Doctor.UpdateAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }
    }
}
