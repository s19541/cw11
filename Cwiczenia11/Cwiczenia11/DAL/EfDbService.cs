using Cwiczenia11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.DAL
{
    public class EfDbService : IDbService
    {
        public DoctorsDbContext Context { get; set; }
        public EfDbService(DoctorsDbContext dbContext)
        {
            Context = dbContext;
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            return Context.Doctors.ToList();
        }

        public IActionResult AddDoctor(Doctor doctor)
        {
            Context.Doctors.Add(doctor);
            Context.SaveChanges();
            return new OkObjectResult(doctor);
        }

        public IActionResult DeleteDoctor(int id)
        {
            var doctorToDelete = Context.Doctors.Where(doc => doc.IdDoctor == id);
            if (doctorToDelete.Count() == 0)
                return new BadRequestResult();
            Context.Doctors.Remove(doctorToDelete.First());
            Context.SaveChanges();
            return new OkResult();
        }

        public IActionResult ModifyDoctor(Doctor doctor)
        {
            var doctorToModify = Context.Doctors.FirstOrDefault(doc => doc.IdDoctor == doctor.IdDoctor);
            if (doctorToModify != null)
            {
                if (doctor.FirstName != null)
                    doctorToModify.FirstName = doctor.FirstName;
                if (doctor.LastName != null)
                    doctorToModify.LastName = doctor.LastName;
                if (doctor.Email != null)
                    doctorToModify.Email = doctor.Email;

            }
            else
            {
                return new BadRequestResult();
            }
            Context.SaveChanges();
            return new OkObjectResult(doctorToModify);
        }
    }
}
