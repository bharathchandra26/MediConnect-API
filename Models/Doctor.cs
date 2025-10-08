namespace MediConnect.API.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string ? Name { get; set; }
        
        public string ? Specialization { get; set; }
        public int Fees { get; set; }
        public int Experience { get; set; }
        public int UserId { get; set; }
    }
}
