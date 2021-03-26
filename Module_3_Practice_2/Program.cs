using System;
using System.Linq;
using Module_3_Practice_2.Models;

namespace Module_3_Practice_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };
            var result = numbers.Where(item => item == 5).ToArray();

            var contacts = new Contacts<Contact>
            {
                new Contact { FirstName = "Victor", LastName = "Zdanov", BirthDay = new DateTime(1982, 03, 21) },
                new Contact { FirstName = "Sergey", LastName = "Ivanov", BirthDay = new DateTime(1978, 03, 27) },
                new Contact { FirstName = "Taras", LastName = "Protsenko", BirthDay = new DateTime(1999, 03, 13) },
                new Contact { FirstName = "Sergey", LastName = "Ivanov", BirthDay = new DateTime(1978, 11, 22) },
                new Contact { FirstName = "Sergey", LastName = "Ivanov", BirthDay = new DateTime(1978, 11, 22) },
                new Contact { FirstName = "Sergey", LastName = "Ivanov", BirthDay = new DateTime(1978, 11, 22) },
                new Contact { FirstName = "Sergey", LastName = "Ivanov", BirthDay = new DateTime(1978, 11, 22) },
            };

            var currentMonthBirthdays = contacts.GetNearestBirthday();
            Console.WriteLine($"{currentMonthBirthdays.FullName} {currentMonthBirthdays.BirthDay}");
        }
    }
}
