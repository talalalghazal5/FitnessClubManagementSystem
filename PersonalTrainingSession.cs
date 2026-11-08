namespace FitnessClubManagementSystem
{
    public class PersonalTrainingSession : Activity
    {
        public int TrainerId { get; set; }
        public double HourlyRate { get; set; }

        public PersonalTrainingSession(int activityId, string name, int durationMinutes, int capacity, int trainerId, double hourlyRate)
            : base(activityId, name, durationMinutes, capacity)
        {
            TrainerId = trainerId;
            HourlyRate = hourlyRate;
        }

        public override double CalculateSessionCost()
        {
            double hours = DurationMinutes / 60.0;
            return HourlyRate * hours;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Type: PT");
            Console.WriteLine("Activity ID: " + ActivityId);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Duration (minutes): " + DurationMinutes);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Trainer ID: " + TrainerId);
            Console.WriteLine("Hourly Rate: " + HourlyRate.ToString("F2"));
            Console.WriteLine("Session Cost: " + CalculateSessionCost().ToString("F2"));
        }
    }
}
