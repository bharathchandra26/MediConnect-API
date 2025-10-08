namespace MediConnect.API.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
