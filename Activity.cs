namespace FitnessClubManagementSystem
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public int Capacity { get; set; }

        public Activity(int activityId, string name, int durationMinutes, int capacity)
        {
            ActivityId = activityId;
            Name = name;
            DurationMinutes = durationMinutes;
            Capacity = capacity;
        }

        public virtual double CalculateSessionCost()
        {
            return 0;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Activity ID: " + ActivityId);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Duration (minutes): " + DurationMinutes);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Session Cost: " + CalculateSessionCost().ToString("F2"));
        }
    }
}
