namespace FitnessClubManagementSystem
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int MemberId { get; set; }
        public int ActivityId { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public Booking(int bookingId, int memberId, int activityId, string date, string status)
        {
            BookingId = bookingId;
            MemberId = memberId;
            ActivityId = activityId;
            Date = date;
            Status = status;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Booking ID: " + BookingId);
            Console.WriteLine("Member ID: " + MemberId);
            Console.WriteLine("Activity ID: " + ActivityId);
            Console.WriteLine("Date: " + Date);
            Console.WriteLine("Status: " + Status);
        }
    }
}
