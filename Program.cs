#pragma warning disable CS8600

using System;

namespace FitnessClubManagementSystem
{
    public class Program
    {
        static void DisplayMenu()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
            }

            Console.WriteLine("===========================================");
            Console.WriteLine("Fitness Club Management System");
            Console.WriteLine("===========================================");
            Console.WriteLine("1) Show All Members");
            Console.WriteLine("2) Show All Activities");
            Console.WriteLine("3) Show All Trainers");
            Console.WriteLine("4) Show All Bookings");
            Console.WriteLine("5) Find Member by ID");
            Console.WriteLine("6) Find Activity by ID");
            Console.WriteLine("7) Add New Member");
            Console.WriteLine("8) Add New Activity");
            Console.WriteLine("9) Add New Trainer");
            Console.WriteLine("10) Add New Booking");
            Console.WriteLine("11) Show Projected Monthly Revenue");
            Console.WriteLine("0) Exit");
            Console.WriteLine("===========================================");
            Console.Write("Select an option: ");
        }

        static string ReadText(string prompt)
        {
            Console.Write(prompt);
            string text = Console.ReadLine();
            if (text == null)
            {
                return string.Empty;
            }

            return text.Trim();
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                string input = ReadText(prompt);
                int result;
                if (int.TryParse(input, out result))
                {
                    return result;
                }

                Console.WriteLine("Invalid integer. Please try again.");
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                string input = ReadText(prompt);
                double result;
                if (double.TryParse(input, out result))
                {
                    return result;
                }

                Console.WriteLine("Invalid number. Please try again.");
            }
        }

        static bool ReadYesNo(string prompt)
        {
            while (true)
            {
                string input = ReadText(prompt).ToUpper();
                if (input == "Y" || input == "YES")
                {
                    return true;
                }

                if (input == "N" || input == "NO")
                {
                    return false;
                }

                Console.WriteLine("Please enter Y or N.");
            }
        }

        static void Pause()
        {
            try
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            catch
            {
            }
        }

        static void Main()
        {
            FitnessClubSystem system = new FitnessClubSystem();
            ClubStaff staff = new ClubStaff(1, "Sara Manager", "Operations");
            FileManager fileManager = new FileManager();

            fileManager.LoadMembers(system);
            fileManager.LoadActivities(system);
            fileManager.LoadTrainers(system);
            fileManager.LoadBookings(system);
            system.LinkTrainerSessions();

            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();
                int option = ReadInt(string.Empty);

                switch (option)
                {
                    case 1:
                        system.ShowAllMembers();
                        Pause();
                        break;

                    case 2:
                        system.ShowAllActivities();
                        Pause();
                        break;

                    case 3:
                        system.ShowAllTrainers();
                        Pause();
                        break;

                    case 4:
                        system.ShowAllBookings();
                        Pause();
                        break;

                    case 5:
                        {
                            int memberId = ReadInt("Enter Member ID: ");
                            Member foundMember = system.FindMemberById(memberId);
                            if (foundMember != null)
                            {
                                foundMember.PrintInfo();
                            }
                            else
                            {
                                Console.WriteLine("Member not found.");
                            }

                            Pause();
                            break;
                        }

                    case 6:
                        {
                            int activityId = ReadInt("Enter Activity ID: ");
                            Activity foundActivity = system.FindActivityById(activityId);
                            if (foundActivity != null)
                            {
                                foundActivity.PrintInfo();
                            }
                            else
                            {
                                Console.WriteLine("Activity not found.");
                            }

                            Pause();
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("Add New Member");
                            string memberType = ReadText("Type (STANDARD/PREMIUM): ").ToUpper();
                            string memberName = ReadText("Name: ");
                            string memberEmail = ReadText("Email: ");
                            string memberJoinDate = ReadText("Join Date (YYYY-MM-DD): ");

                            int nextMemberId = system.MemberCount + 1;

                            if (memberType == "STANDARD")
                            {
                                int freezeDays = ReadInt("Freeze Days Used: ");
                                StandardMember member = new StandardMember(nextMemberId, memberName, memberEmail, memberJoinDate, freezeDays);
                                system.AddMember(member);
                                fileManager.SaveMember(member);
                                Console.WriteLine("Standard member added successfully.");
                            }
                            else if (memberType == "PREMIUM")
                            {
                                bool hasTrainer = ReadYesNo("Has Personal Trainer? (Y/N): ");
                                int guestPasses = ReadInt("Guest Passes: ");
                                PremiumMember member = new PremiumMember(nextMemberId, memberName, memberEmail, memberJoinDate, hasTrainer, guestPasses);
                                system.AddMember(member);
                                fileManager.SaveMember(member);
                                Console.WriteLine("Premium member added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid member type. Please use STANDARD or PREMIUM.");
                            }

                            Pause();
                            break;
                        }

                    case 8:
                        {
                            Console.WriteLine("Add New Activity");
                            string activityType = ReadText("Type (GROUP/PT): ").ToUpper();
                            string activityName = ReadText("Name: ");
                            int activityDuration = ReadInt("Duration (minutes): ");
                            int activityCapacity = ReadInt("Capacity: ");
                            int nextActivityId = system.ActivityCount + 1;

                            if (activityType == "GROUP")
                            {
                                string instructorName = ReadText("Instructor Name: ");
                                string difficulty = ReadText("Difficulty Level: ");
                                GroupClass activity = new GroupClass(nextActivityId, activityName, activityDuration, activityCapacity, instructorName, difficulty);
                                system.AddActivity(activity);
                                fileManager.SaveActivity(activity);
                                Console.WriteLine("Group class added successfully.");
                            }
                            else if (activityType == "PT")
                            {
                                int trainerId = ReadInt("Trainer ID: ");
                                double hourlyRate = ReadDouble("Hourly Rate: ");
                                PersonalTrainingSession activity = new PersonalTrainingSession(nextActivityId, activityName, activityDuration, activityCapacity, trainerId, hourlyRate);
                                system.AddActivity(activity);
                                fileManager.SaveActivity(activity);
                                Console.WriteLine("Personal training session added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid activity type. Please use GROUP or PT.");
                            }

                            Pause();
                            break;
                        }

                    case 9:
                        {
                            Console.WriteLine("Add New Trainer");
                            int nextTrainerId = system.TrainerCount + 1;
                            string trainerName = ReadText("Name: ");
                            string trainerSpecialty = ReadText("Specialty: ");
                            double trainerSalary = ReadDouble("Salary: ");
                            Trainer trainer = new Trainer(nextTrainerId, trainerName, trainerSpecialty, trainerSalary);
                            system.AddTrainer(trainer);
                            fileManager.SaveTrainer(trainer);
                            Console.WriteLine("Trainer added successfully.");
                            Pause();
                            break;
                        }

                    case 10:
                        {
                            Console.WriteLine("Add New Booking");
                            int nextBookingId = system.BookingCount + 1;
                            int memberId = ReadInt("Member ID: ");
                            int activityId = ReadInt("Activity ID: ");
                            string bookingDate = ReadText("Date (YYYY-MM-DD): ");
                            string bookingStatus = ReadText("Status: ");
                            Booking booking = new Booking(nextBookingId, memberId, activityId, bookingDate, bookingStatus);
                            system.AddBooking(booking);
                            fileManager.SaveBooking(booking);
                            Console.WriteLine("Booking added successfully.");
                            Pause();
                            break;
                        }

                    case 11:
                        {
                            double revenue = system.GetProjectedMonthlyRevenue();
                            Console.WriteLine("Projected monthly revenue: " + revenue.ToString("F2"));
                            Pause();
                            break;
                        }

                    case 0:
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Pause();
                        break;
                }
            }
        }
    }
}
