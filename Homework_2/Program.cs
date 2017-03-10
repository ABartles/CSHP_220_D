using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of list 
            var users = new List<Models.User>();

            // Add items to the newly created list
            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            Console.WriteLine("---- Complete List ----");

            foreach (var n in users)
            {
                Console.WriteLine("{0}", n);
            }

            // Display all users with the password of hello
            Console.WriteLine("\n---- Passwords == hello ----");

            var QueryHello =
                from Name in users
                where Name.Password == "hello"
                select Name;
            
            // print to console
            foreach (var n in QueryHello)
            {
                Console.WriteLine("{0}", n);
            }


            // Delete user/passwords where the password is lower(name)
            Console.WriteLine("\n---- Name.ToLower() != Password ----");

            users.RemoveAll(x => x.Password == x.Name.ToLower());

            // print to console
            foreach (var n in users)
            {
                Console.WriteLine("{0}", n);
            }

            // Delete the first user with the password == hello

            users.RemoveAt(0);

            // Display the remaining names
            Console.WriteLine("\n---- Remaining users/password ----");

            // print to console
            foreach (var n in users)
            {
                Console.WriteLine("{0}", n);
            }
            
            // Hold open console
            Console.ReadLine();

        }
    }
}
