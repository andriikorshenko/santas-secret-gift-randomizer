namespace SantasSecret
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string Nickname { get; set; }

        public int FamilyGroup { get; set; }

        public Person Target { get; set; }
    }
}
