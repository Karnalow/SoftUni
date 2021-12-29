using System;

namespace P06.ValidPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Peter", "Johnson", 24);

            try
            {
                Person personWithoutFirstName = new Person(string.Empty, "Peterson", 31);
                Person personWithoutLastName = new Person("Ivan", string.Empty, 25);
                Person personWithNegativeAge = new Person("Kiro", "Stamatov", -1);
                Person personWithTooBigAge = new Person("Kiro", "Stamatov", 122);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException aoutOfRange)
            {
                Console.WriteLine(aoutOfRange.Message);
            }

            Console.WriteLine(person);
        }
    }
}
