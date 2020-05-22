using Cwiczenia11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.DAL
{
    public interface IDbService
    {
        public IEnumerable<Models.Doctor> GetDoctors();
        public IActionResult AddDoctor(Models.Doctor doctor);
        public IActionResult DeleteDoctor(int id);
        public IActionResult ModifyDoctor(Doctor doctor);
    }
}
