using MediConnect.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MediConnect.API.Data
{
    public class MediConnectDbContext:DbContext
    {
        public MediConnectDbContext(DbContextOptions<MediConnectDbContext> options)
       : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


    }
}
