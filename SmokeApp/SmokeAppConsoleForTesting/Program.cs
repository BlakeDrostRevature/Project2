using System;
using Microsoft.EntityFrameworkCore;
using SmokeApp_Storage.Models;
using System.Linq;

namespace SmokeAppConsoleForTesting
{
    class Program
    {
        static void Main(string[] args)
        {



            using (SmokeDBContext context = new SmokeDBContext())
            {
                var users = context.Users.FromSqlRaw<User>("SELECT * FROM Users").ToList();

                foreach (var x in users)
                {
                    Console.WriteLine($"The Users in the Database are FirstName: {x.FirstName} LastName: {x.LastName} Email: {x.Email} DOB: {x.Dob}");
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
