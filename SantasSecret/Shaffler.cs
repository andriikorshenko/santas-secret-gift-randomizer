namespace SantasSecret
{
    public class Shaffler
    {
        private readonly List<Person> outsiders = new();
        private readonly Random random = new();
        private int num = default;
        private bool result = true;
        private int pairs = default;

        public int Shaffle(IEnumerable<Person> list)
        {
            foreach (var person in list)
            {
                result = true;

                do
                {
                    num = random.Next(1, 9);
                    var target = list.FirstOrDefault(x => x.Id == num);

                    if (person.FamilyGroup == target!.FamilyGroup ||
                        person.Id == target.Id ||
                        outsiders.Contains(target))
                    {
                        continue;
                    }
                    else
                    {
                        person.Target = target;
                        outsiders.Add(target);
                        result = false;
                        pairs++;
                    }
                } while (result);
            }
            return pairs;
        }
    }
}
