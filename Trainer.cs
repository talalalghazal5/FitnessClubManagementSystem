namespace FitnessClubManagementSystem
{
    public class Trainer
    {
        public const int MAX_SESSIONS = 20;

        public int TrainerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public double Salary { get; set; }
        public PersonalTrainingSession[] SessionsAssigned { get; set; }
        public int SessionCount { get; set; }

        public Trainer(int trainerId, string name, string specialty, double salary)
        {
            TrainerId = trainerId;
            Name = name;
            Specialty = specialty;
            Salary = salary;
            SessionsAssigned = new PersonalTrainingSession[MAX_SESSIONS];
            SessionCount = 0;
        }

        public void AssignSession(PersonalTrainingSession session)
        {
            if (SessionCount < MAX_SESSIONS)
            {
                SessionsAssigned[SessionCount] = session;
                SessionCount = SessionCount + 1;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Trainer ID: " + TrainerId);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Specialty: " + Specialty);
            Console.WriteLine("Salary: " + Salary.ToString("F2"));
            Console.WriteLine("Assigned PT Sessions: " + SessionCount);
            for (int i = 0; i < SessionCount; i = i + 1)
            {
                if (SessionsAssigned[i] != null)
                {
                    Console.WriteLine("   Session " + (i + 1) + ": " + SessionsAssigned[i].Name + " (Activity ID: " + SessionsAssigned[i].ActivityId + ")");
                }
            }
        }
    }
}
