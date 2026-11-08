namespace FitnessClubManagementSystem
{
    public class PremiumMember : Member
    {
        public bool HasPersonalTrainer { get; set; }
        public int GuestPasses { get; set; }

        public PremiumMember(int id, string name, string email, string joinDate, bool hasPersonalTrainer, int guestPasses)
            : base(id, name, email, joinDate)
        {
            HasPersonalTrainer = hasPersonalTrainer;
            GuestPasses = guestPasses;
        }

        public override double CalculateMonthlyFee()
        {
            double fee = 100.0;
            fee = fee + (10.0 * GuestPasses);

            if (HasPersonalTrainer == true)
            {
                fee = fee + 40.0;
            }

            return fee;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Type: PREMIUM");
            Console.WriteLine("Member ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Join Date: " + JoinDate);
            Console.WriteLine("Has Personal Trainer: " + HasPersonalTrainer);
            Console.WriteLine("Guest Passes: " + GuestPasses);
            Console.WriteLine("Monthly Fee: " + CalculateMonthlyFee().ToString("F2"));
        }
    }
}
