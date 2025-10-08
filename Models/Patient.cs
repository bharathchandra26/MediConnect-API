namespace MediConnect.API.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string ? Name { get; set; }
        public string ? Email { get; set; }
        public int Phone { get; set; }
        public int UserId { get; set; }
    }
}
