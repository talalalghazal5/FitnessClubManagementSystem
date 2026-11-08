namespace FitnessClubManagementSystem
{
    public class StandardMember : Member
    {
        public int FreezeDaysUsed { get; set; }

        public StandardMember(int id, string name, string email, string joinDate, int freezeDaysUsed)
            : base(id, name, email, joinDate)
        {
            FreezeDaysUsed = freezeDaysUsed;
        }

        public override double CalculateMonthlyFee()
        {
            double fee = 50.0;
            if (FreezeDaysUsed == 0)
            {
                fee = fee - 5.0;
            }

            return fee;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Type: STANDARD");
            Console.WriteLine("Member ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Join Date: " + JoinDate);
            Console.WriteLine("Freeze Days Used: " + FreezeDaysUsed);
            Console.WriteLine("Monthly Fee: " + CalculateMonthlyFee().ToString("F2"));
        }
    }
}
