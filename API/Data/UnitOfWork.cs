using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Entities;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        
        public IDoctorRepository Doctor { get; private set; }

        public IPatientRepository Patient { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Doctor = new DoctorRepository(_context);
            Patient = new PatientRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
