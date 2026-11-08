using System.Globalization;

namespace FitnessClubManagementSystem
{
    public class FileManager
    {
        public void LoadMembers(FitnessClubSystem system)
        {
            if (File.Exists("MEMBERS.TXT") == false)
            {
                return;
            }

            string[] lines = File.ReadAllLines("MEMBERS.TXT");
            for (int i = 0; i < lines.Length; i = i + 1)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');
                if (parts.Length < 7)
                {
                    continue;
                }

                int id = int.Parse(parts[0], CultureInfo.InvariantCulture);
                string name = parts[1];
                string email = parts[2];
                string joinDate = parts[3];
                string type = parts[4].Trim();

                if (type == "STANDARD")
                {
                    int freezeDays = 0;
                    int.TryParse(parts[5], out freezeDays);
                    StandardMember member = new StandardMember(id, name, email, joinDate, freezeDays);
                    system.AddMember(member);
                }
                else if (type == "PREMIUM")
                {
                    bool hasTrainer = false;
                    bool.TryParse(parts[5], out hasTrainer);
                    int guestPasses = 0;
                    int.TryParse(parts[6], out guestPasses);
                    PremiumMember member = new PremiumMember(id, name, email, joinDate, hasTrainer, guestPasses);
                    system.AddMember(member);
                }
            }
        }

        public void LoadActivities(FitnessClubSystem system)
        {
            if (File.Exists("ACTIVITIES.TXT") == false)
            {
                return;
            }

            string[] lines = File.ReadAllLines("ACTIVITIES.TXT");
            for (int i = 0; i < lines.Length; i = i + 1)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');
                if (parts.Length < 7)
                {
                    continue;
                }

                int activityId = int.Parse(parts[0], CultureInfo.InvariantCulture);
                string name = parts[1];
                int duration = int.Parse(parts[2], CultureInfo.InvariantCulture);
                int capacity = int.Parse(parts[3], CultureInfo.InvariantCulture);
                string type = parts[4].Trim();

                if (type == "GROUP")
                {
                    string instructorName = parts[5];
                    string difficultyLevel = parts[6];
                    GroupClass activity = new GroupClass(activityId, name, duration, capacity, instructorName, difficultyLevel);
                    system.AddActivity(activity);
                }
                else if (type == "PT")
                {
                    int trainerId = int.Parse(parts[5], CultureInfo.InvariantCulture);
                    double hourlyRate = double.Parse(parts[6], CultureInfo.InvariantCulture);
                    PersonalTrainingSession activity = new PersonalTrainingSession(activityId, name, duration, capacity, trainerId, hourlyRate);
                    system.AddActivity(activity);
                }
            }
        }

        public void LoadTrainers(FitnessClubSystem system)
        {
            if (File.Exists("TRAINERS.TXT") == false)
            {
                return;
            }

            string[] lines = File.ReadAllLines("TRAINERS.TXT");
            for (int i = 0; i < lines.Length; i = i + 1)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');
                if (parts.Length < 4)
                {
                    continue;
                }

                int trainerId = int.Parse(parts[0], CultureInfo.InvariantCulture);
                string name = parts[1];
                string specialty = parts[2];
                double salary = double.Parse(parts[3], CultureInfo.InvariantCulture);
                Trainer trainer = new Trainer(trainerId, name, specialty, salary);
                system.AddTrainer(trainer);
            }

            system.LinkTrainerSessions();
        }

        public void LoadBookings(FitnessClubSystem system)
        {
            if (File.Exists("BOOKINGS.TXT") == false)
            {
                return;
            }

            string[] lines = File.ReadAllLines("BOOKINGS.TXT");
            for (int i = 0; i < lines.Length; i = i + 1)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(';');
                if (parts.Length < 5)
                {
                    continue;
                }

                int bookingId = int.Parse(parts[0], CultureInfo.InvariantCulture);
                int memberId = int.Parse(parts[1], CultureInfo.InvariantCulture);
                int activityId = int.Parse(parts[2], CultureInfo.InvariantCulture);
                string date = parts[3];
                string status = parts[4];
                Booking booking = new Booking(bookingId, memberId, activityId, date, status);
                system.AddBooking(booking);
            }
        }

        public void SaveMember(Member member)
        {
            using (StreamWriter writer = new StreamWriter("MEMBERS.TXT", true))
            {
                if (member is StandardMember)
                {
                    StandardMember standard = (StandardMember)member;
                    writer.WriteLine(standard.Id + ";" + standard.Name + ";" + standard.Email + ";" + standard.JoinDate + ";STANDARD;" + standard.FreezeDaysUsed + ";0");
                }
                else if (member is PremiumMember)
                {
                    PremiumMember premium = (PremiumMember)member;
                    string personalTrainerText = premium.HasPersonalTrainer ? "TRUE" : "FALSE";
                    writer.WriteLine(premium.Id + ";" + premium.Name + ";" + premium.Email + ";" + premium.JoinDate + ";PREMIUM;" + personalTrainerText + ";" + premium.GuestPasses);
                }
            }
        }

        public void SaveActivity(Activity activity)
        {
            using (StreamWriter writer = new StreamWriter("ACTIVITIES.TXT", true))
            {
                if (activity is GroupClass)
                {
                    GroupClass group = (GroupClass)activity;
                    writer.WriteLine(group.ActivityId + ";" + group.Name + ";" + group.DurationMinutes + ";" + group.Capacity + ";GROUP;" + group.InstructorName + ";" + group.DifficultyLevel);
                }
                else if (activity is PersonalTrainingSession)
                {
                    PersonalTrainingSession session = (PersonalTrainingSession)activity;
                    writer.WriteLine(session.ActivityId + ";" + session.Name + ";" + session.DurationMinutes + ";" + session.Capacity + ";PT;" + session.TrainerId + ";" + session.HourlyRate.ToString("F2", CultureInfo.InvariantCulture));
                }
            }
        }

        public void SaveTrainer(Trainer trainer)
        {
            using (StreamWriter writer = new StreamWriter("TRAINERS.TXT", true))
            {
                writer.WriteLine(trainer.TrainerId + ";" + trainer.Name + ";" + trainer.Specialty + ";" + trainer.Salary.ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        public void SaveBooking(Booking booking)
        {
            using (StreamWriter writer = new StreamWriter("BOOKINGS.TXT", true))
            {
                writer.WriteLine(booking.BookingId + ";" + booking.MemberId + ";" + booking.ActivityId + ";" + booking.Date + ";" + booking.Status);
            }
        }
    }
}
