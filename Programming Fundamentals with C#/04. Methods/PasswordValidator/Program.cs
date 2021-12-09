using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isTrue = ValidateLenght(password) &&
                          ValidateLetersAndDigits(password) &&
                          PasswordHasTwoDigits(password);

            if (isTrue)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!ValidateLenght(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!ValidateLetersAndDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!PasswordHasTwoDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        private static bool PasswordHasTwoDigits(string password)
        {
            int counter = 0;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                return true;
            }

            return false;
        }

        private static bool ValidateLetersAndDigits(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateLenght(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                bool isTrue = true;
                return isTrue;
            }
            else
            {
                return false;
            }
        }
    }
}
