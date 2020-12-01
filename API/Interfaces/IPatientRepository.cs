using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task RemoveRangeAsync(IEnumerable<Patient> patients);
        Task<IEnumerable<Patient>> GetAllPatientByDoctorId(int Id);

    }
}
