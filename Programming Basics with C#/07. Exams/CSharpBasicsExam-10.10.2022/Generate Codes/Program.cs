using System;

namespace Generate_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            bool stop = false;
            var count = 1;

            for (int s1 = 0; s1 <= 9; s1++)
            {
                for (int s2 = 0; s2 <= 9; s2++)
                {
                    for (int s3 = 0; s3 <= 9; s3++)
                    {
                        for (char s4 = 'a'; s4 <= 'z'; s4++)
                        {
                            for (char s5 = 'a'; s5 <= 'z'; s5++)
                            {
                                for (int s6 = 0; s6 <= 9; s6++)
                                {
                                    if (s1 + s2 + s3 + (int)s4 + (int)s5 + s6 == m)
                                    {
                                        if (count > n)
                                        {
                                            stop = true;
                                            break;
                                        }
                                        Console.Write($"{s1}{s2}{s3}{s4}{s5}{s6} ");
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }
}
