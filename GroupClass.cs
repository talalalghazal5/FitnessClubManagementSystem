namespace FitnessClubManagementSystem
{
    public class GroupClass : Activity
    {
        public string InstructorName { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;

        public GroupClass(int activityId, string name, int durationMinutes, int capacity, string instructorName, string difficultyLevel)
            : base(activityId, name, durationMinutes, capacity)
        {
            InstructorName = instructorName;
            DifficultyLevel = difficultyLevel;
        }

        public override double CalculateSessionCost()
        {
            return 0;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Type: GROUP");
            Console.WriteLine("Activity ID: " + ActivityId);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Duration (minutes): " + DurationMinutes);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Instructor: " + InstructorName);
            Console.WriteLine("Difficulty: " + DifficultyLevel);
            Console.WriteLine("Session Cost: " + CalculateSessionCost().ToString("F2"));
        }
    }
}
