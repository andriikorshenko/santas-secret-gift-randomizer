namespace SantasSecret
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Nickname { get; set; } = string.Empty;

        public int FamilyGroup { get; set; }

        public Person? Target { get; set; }
    }
}
