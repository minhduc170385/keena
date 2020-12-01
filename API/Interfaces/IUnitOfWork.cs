using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        int Complete();
    }
}
