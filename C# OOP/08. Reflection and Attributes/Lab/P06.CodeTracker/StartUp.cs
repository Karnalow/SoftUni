using System;

namespace AuthorProblem
{
    [Author("Karnalow")]
    public class StartUp
    {
        [Author("Karnalow")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
