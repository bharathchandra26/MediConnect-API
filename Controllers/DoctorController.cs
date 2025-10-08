using MediConnect.API.Data;
using MediConnect.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediConnect.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly MediConnectDbContext _context;
        public DoctorController(MediConnectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("doctors")]
        public ActionResult<IEnumerable<Doctor>> GetAll()
        {
            try
            {
                var doctors = _context.Doctors.ToList();
                return Ok(doctors);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("doctors/{id}")]

        public ActionResult<Doctor> GetDoctor(int id)
        {
            try
            {
                var doctor = _context.Doctors.Find(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("doctors")]
        [Authorize(Roles = "Admin")]

        public ActionResult<Doctor> Add(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return Ok(doctor);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }


        [HttpPut]
        [Route("doctors/{id}")]
        public ActionResult<Doctor> Update(int id,Doctor doctor)
        
        {
            try
            {
                if (id != doctor.DoctorId)
                {
                    return BadRequest();
                }
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return Ok(doctor);  
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("doctors/{id}")]

        public ActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return BadRequest();
            }
            return Ok(doctor);
        }





    }
}
