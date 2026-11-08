#pragma warning disable CS8603

namespace FitnessClubManagementSystem
{
    public class FitnessClubSystem
    {
        public const int MAX_SIZE = 50;

        public Member[] Members { get; set; }
        public Activity[] Activities { get; set; }
        public Trainer[] Trainers { get; set; }
        public Booking[] Bookings { get; set; }
        public int MemberCount { get; set; }
        public int ActivityCount { get; set; }
        public int TrainerCount { get; set; }
        public int BookingCount { get; set; }

        public FitnessClubSystem()
        {
            Members = new Member[MAX_SIZE];
            Activities = new Activity[MAX_SIZE];
            Trainers = new Trainer[MAX_SIZE];
            Bookings = new Booking[MAX_SIZE];
        }

        public void AddMember(Member member)
        {
            if (MemberCount < MAX_SIZE)
            {
                Members[MemberCount] = member;
                MemberCount = MemberCount + 1;
            }
        }

        public void AddActivity(Activity activity)
        {
            if (ActivityCount < MAX_SIZE)
            {
                Activities[ActivityCount] = activity;
                ActivityCount = ActivityCount + 1;
            }
        }

        public void AddTrainer(Trainer trainer)
        {
            if (TrainerCount < MAX_SIZE)
            {
                Trainers[TrainerCount] = trainer;
                TrainerCount = TrainerCount + 1;
            }
        }

        public void AddBooking(Booking booking)
        {
            if (BookingCount < MAX_SIZE)
            {
                Bookings[BookingCount] = booking;
                BookingCount = BookingCount + 1;
            }
        }

        public void ShowAllMembers()
        {
            Console.WriteLine("\n--- Members ---");
            for (int i = 0; i < MemberCount; i = i + 1)
            {
                Members[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public void ShowAllActivities()
        {
            Console.WriteLine("\n--- Activities ---");
            for (int i = 0; i < ActivityCount; i = i + 1)
            {
                Activities[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public void ShowAllTrainers()
        {
            Console.WriteLine("\n--- Trainers ---");
            for (int i = 0; i < TrainerCount; i = i + 1)
            {
                Trainers[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public void ShowAllBookings()
        {
            Console.WriteLine("\n--- Bookings ---");
            for (int i = 0; i < BookingCount; i = i + 1)
            {
                Bookings[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public Member FindMemberById(int id)
        {
            for (int i = 0; i < MemberCount; i = i + 1)
            {
                if (Members[i] != null && Members[i].Id == id)
                {
                    return Members[i];
                }
            }

            return null;
        }

        public Activity FindActivityById(int id)
        {
            for (int i = 0; i < ActivityCount; i = i + 1)
            {
                if (Activities[i] != null && Activities[i].ActivityId == id)
                {
                    return Activities[i];
                }
            }

            return null;
        }

        public void LinkTrainerSessions()
        {
            for (int i = 0; i < TrainerCount; i = i + 1)
            {
                Trainers[i].SessionCount = 0;
            }

            for (int i = 0; i < ActivityCount; i = i + 1)
            {
                if (Activities[i] is PersonalTrainingSession)
                {
                    PersonalTrainingSession session = (PersonalTrainingSession)Activities[i];
                    for (int j = 0; j < TrainerCount; j = j + 1)
                    {
                        if (Trainers[j] != null && Trainers[j].TrainerId == session.TrainerId)
                        {
                            Trainers[j].AssignSession(session);
                            break;
                        }
                    }
                }
            }
        }

        public double GetProjectedMonthlyRevenue()
        {
            double total = 0.0;
            for (int i = 0; i < MemberCount; i = i + 1)
            {
                if (Members[i] != null)
                {
                    total = total + Members[i].CalculateMonthlyFee();
                }
            }

            return total;
        }
    }
}
