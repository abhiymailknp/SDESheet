using System;
using Abhishek.SDESheetDataAccess;

namespace Abhishek.SdeSheet.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            SdeDBRepository repository = new SdeDBRepository();
            var users = repository.GetAllUsers();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("CategoryId\tCategoryName");
            Console.WriteLine("----------------------------------");
            foreach (var user in users)
            {
                Console.WriteLine("{0}\t\t{1}", user.EmailId, user.UserPassword);
            }
        }
    }
}
