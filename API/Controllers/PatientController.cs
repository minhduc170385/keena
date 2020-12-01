using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IUnitOfWork _repo;
        public PatientController(IUnitOfWork repo)
        {
            this._repo = repo;
        }
        
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return Ok(await _repo.Patient.GetAllAsync());
        }
        //Get: api/Patient/5
        [HttpGet("GetPatients/{doctorId}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientsByDoctorId(int doctorId)
        {
            return Ok(await _repo.Patient.GetAllPatientByDoctorId(doctorId));
        }
        //Get: api/Patient/5
        [HttpGet("{id}")]
        [ActionName(nameof(GetPatientById))]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            return await _repo.Patient.GetByIdAsync(id);
        }

        //Put: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> Delete(int id)
        {            
            Patient patient = await _repo.Patient.DeleteAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }

        //POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> Insert([FromBody] Patient patient)
        {
            await _repo.Patient.InsertAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }


    }
}
