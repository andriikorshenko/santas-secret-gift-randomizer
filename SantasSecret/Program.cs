using SantasSecret;

List<Person> list = new()
{
    new Person { Id = 1, Name = "Андрей", Nickname = "korshenko", FamilyGroup = 1 },
    new Person { Id = 2, Name = "Ольга З.", Nickname = "olga_zaika", FamilyGroup = 1 },
    new Person { Id = 3, Name = "Илюша", Nickname = "Azovtsev", FamilyGroup = 2 },
    new Person { Id = 4, Name = "Ольга А.", Nickname = "olgaazovtseva", FamilyGroup = 2 },
    new Person { Id = 5, Name = "Алинка", Nickname = "Alinka_Aleks", FamilyGroup = 3 },
    new Person { Id = 6, Name = "Димка", Nickname = "dmytroho", FamilyGroup = 3 },
    new Person { Id = 7, Name = "Богдан", Nickname = "karasyov", FamilyGroup = 4 },
    new Person { Id = 8, Name = "Виктория", Nickname = "Fedoryachenko", FamilyGroup = 4 }
};

var shaffler = new Shaffler();
var pairs = shaffler.Shaffle(list);

var bot = new Sender();

if (bot.GetOpenChatsQty().Result >= list.Count && 
    pairs >= list.Count)
{
    Console.WriteLine("It's high time! Push to continue...");
    Console.ReadKey();

    foreach (var person in list)
    {
        await bot.Send(person, list.Count);
    }
}
else
{
    Console.WriteLine("It's not time yet...");
}
