#pragma warning disable CS8603

namespace FitnessClubManagementSystem
{
    public class ClubStaff
    {
        public const int MAX_MEMBERS = 50;
        public const int MAX_ACTIVITIES = 50;
        public const int MAX_TRAINERS = 50;
        public const int MAX_BOOKINGS = 50;

        public int StaffId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        public Member[] Members { get; set; }
        public Activity[] Activities { get; set; }
        public Trainer[] Trainers { get; set; }
        public Booking[] Bookings { get; set; }
        public int MemberCount { get; set; }
        public int ActivityCount { get; set; }
        public int TrainerCount { get; set; }
        public int BookingCount { get; set; }

        public ClubStaff(int staffId, string name, string position)
        {
            StaffId = staffId;
            Name = name;
            Position = position;
            Members = new Member[MAX_MEMBERS];
            Activities = new Activity[MAX_ACTIVITIES];
            Trainers = new Trainer[MAX_TRAINERS];
            Bookings = new Booking[MAX_BOOKINGS];
        }

        public void AddMember(Member member)
        {
            if (MemberCount < MAX_MEMBERS)
            {
                Members[MemberCount] = member;
                MemberCount = MemberCount + 1;
            }
        }

        public void AddActivity(Activity activity)
        {
            if (ActivityCount < MAX_ACTIVITIES)
            {
                Activities[ActivityCount] = activity;
                ActivityCount = ActivityCount + 1;
            }
        }

        public void AddTrainer(Trainer trainer)
        {
            if (TrainerCount < MAX_TRAINERS)
            {
                Trainers[TrainerCount] = trainer;
                TrainerCount = TrainerCount + 1;
            }
        }

        public void AddBooking(Booking booking)
        {
            if (BookingCount < MAX_BOOKINGS)
            {
                Bookings[BookingCount] = booking;
                BookingCount = BookingCount + 1;
            }
        }

        public void ShowAllMembers()
        {
            Console.WriteLine("\n--- Members ---");
            if (MemberCount == 0)
            {
                Console.WriteLine("No members available.");
                return;
            }

            for (int i = 0; i < MemberCount; i = i + 1)
            {
                Members[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public void ShowAllActivities()
        {
            Console.WriteLine("\n--- Activities ---");
            if (ActivityCount == 0)
            {
                Console.WriteLine("No activities available.");
                return;
            }

            for (int i = 0; i < ActivityCount; i = i + 1)
            {
                Activities[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public void ShowAllTrainers()
        {
            Console.WriteLine("\n--- Trainers ---");
            if (TrainerCount == 0)
            {
                Console.WriteLine("No trainers available.");
                return;
            }

            for (int i = 0; i < TrainerCount; i = i + 1)
            {
                Trainers[i].PrintInfo();
                Console.WriteLine();
            }
        }

        public void ShowAllBookings()
        {
            Console.WriteLine("\n--- Bookings ---");
            if (BookingCount == 0)
            {
                Console.WriteLine("No bookings available.");
                return;
            }

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
    }
}
