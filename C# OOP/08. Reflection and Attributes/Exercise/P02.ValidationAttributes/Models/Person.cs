namespace ValidationAttributes
{
    internal class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [Required]
        public string FullName { get; set; }


        [Range(12, 90)]
        public int Age { get; set; }
    }
}