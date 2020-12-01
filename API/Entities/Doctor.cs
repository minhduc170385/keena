using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Doctor
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(8,MinimumLength = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public Doctor() { }
        public Doctor(string firstName,string lastname, bool gender, string address =null, string email=null, string phone =null, ICollection<Patient> patient =null)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Gender = gender;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Patients = patient;
            
        }

    }
}
