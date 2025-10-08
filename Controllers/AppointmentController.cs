using MediConnect.API.Data;
using MediConnect.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediConnect.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly MediConnectDbContext _context;
        public AppointmentController(MediConnectDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("appointments")]
        public ActionResult<Appointment> Add(Appointment appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return Ok(appointment);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("appointments/patient/{id}")]
        public ActionResult<IEnumerable<Appointment>> GetAll(int id)
        {
            try
            {
                var appointments = _context.Appointments.Where(a => a.PatientId == id).ToList();
                return Ok(appointments);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("appointments/doctor/{id}")]

        public ActionResult<IEnumerable<Appointment>> GetSome(int id)
        {
            try
            {
                var appointments = _context.Appointments.Where(a => a.DoctorId == id).ToList();
                return Ok(appointments);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("appointments")]
        public IActionResult GetAllAppointments()
        {
            var appointments = (from a in _context.Appointments
                                join d in _context.Doctors on a.DoctorId equals d.DoctorId
                                join p in _context.Patients on a.PatientId equals p.PatientId
                                select new
                                {
                                    a.AppointmentId,
                                    a.Date,
                                    a.TimeSlot,
                                    a.Status,
                                    DoctorName = d.Name,
                                    PatientName = p.Name
                                }).ToList();

            return Ok(appointments);
        }


        [HttpPut]
        [Route("appointments/{id}")]
        public ActionResult<Appointment> UpdateApp(int id, Appointment appointment)
        {
            try
            {
                if (id != appointment.AppointmentId)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Appointments.Update(appointment);
                    _context.SaveChanges();
                    return Ok(appointment);
                }
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpDelete]
        [Route("appointments/{id}")]

        public ActionResult<Appointment> Delete(int id)
        {
            try
            {
                var appointment = _context.Appointments.Find(id);
                if (appointment == null)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Appointments.Remove(appointment);
                    _context.SaveChanges();
                    return Ok(appointment);
                }
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}
