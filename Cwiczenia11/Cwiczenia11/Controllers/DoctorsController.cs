using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : Controller
    {
        private readonly DAL.IDbService _dbService;
        public DoctorsController(DAL.IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_dbService.GetDoctors());
        }
        [HttpPost]
        public IActionResult AddDoctor(Models.Doctor doctor)
        {
            return _dbService.AddDoctor(doctor);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            return _dbService.DeleteDoctor(id);
        }
        [HttpPatch]
        public IActionResult ModifyDoctor(Models.Doctor doctor)
        {
            return _dbService.ModifyDoctor(doctor);
        }
    }
}