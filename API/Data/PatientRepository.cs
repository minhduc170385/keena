using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PatientRepository : Repositories<Patient>, IPatientRepository
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context):base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientByDoctorId(int Id)
        {            
            var query = _context.Patients.Where(x => x.Doctor.Id == Id).ToList();
            return query;            
        }
        public async Task RemoveRangeAsync(IEnumerable<Patient> patients)
        {
            _context.RemoveRange(patients);
            await _context.SaveChangesAsync();
        }
    }
}
