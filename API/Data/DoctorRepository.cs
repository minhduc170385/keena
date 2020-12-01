using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DoctorRepository : Repositories<Doctor>, IDoctorRepository
    {
        private readonly DataContext _context;
        public DoctorRepository(DataContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorAndPatientAsync()
        {
            return await _context.Doctors
                                .Include(p => p.Patients)
                                .ToListAsync();

        }
    }
}
