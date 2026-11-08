namespace FitnessClubManagementSystem
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string JoinDate { get; set; } = string.Empty;

        public Member(int id, string name, string email, string joinDate)
        {
            Id = id;
            Name = name;
            Email = email;
            JoinDate = joinDate;
        }

        public virtual double CalculateMonthlyFee()
        {
            return 0;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Member ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Join Date: " + JoinDate);
            Console.WriteLine("Monthly Fee: " + CalculateMonthlyFee().ToString("F2"));
        }
    }
}
