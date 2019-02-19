using System;
using System.Linq;
using RunescapeConsole.Enums;
using RunescapeConsole.Models;


namespace RunescapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string username;
            AccountType accountType;

            username = AskForUsername();

            accountType = AskForAccountType();

            Player player = new HighscoreLookup(username, accountType).Player;

            DisplayPlayerInformation(player);

            Console.ReadLine();
        }

        private static void DisplayPlayerInformation(Player player)
        {
            Console.WriteLine($"Welcome, { player.Username }, you're an { player.AccountType }");
        }


        private static string AskForUsername()
        {
            string username;

            Console.Write("Please enter your OSRS username: ");
            username = Console.ReadLine();

            return Player.CleanUsername(username);
        }

        private static AccountType AskForAccountType()
        {
            int accountTypeInt;

            Console.WriteLine("Please enter your Account type: ");

            foreach(AccountType as AccountTypes)
            Console.WriteLine("Normal = 0");
            Console.WriteLine("Ironman = 0");
            Console.WriteLine("Ultimate Ironman = 0");
            Console.WriteLine("Normal = 0");
            Console.WriteLine("Normal = 0");
            accountTypeInt = int.Parse(Console.ReadLine());
            

            AccountType accountType = (AccountType)accountTypeInt;

            Console.ReadLine();

            return accountType;
        }
    }
}
