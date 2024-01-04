using lab_work_3;

namespace Game
{
    public class Main
    {
        public List<IUserInterface> Setup()
        {
            DbContext context = new();
            return new List<IUserInterface>
            {
                new AddGameUI(context),
                new AddUserUI(context),
                new GamesInfoUI(context),
                new InfoGamesByIdUI(context),
                new InfoUserByIdUI(context),
                new UsersInfoUI(context)
            };
        }
    }
    public class Program
    {
        static void Main()
        {
            var uis = new Main().Setup();
            while (true)
            {
                Console.WriteLine("Choose:\n");
                for (int i = 0; i < uis.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {uis[i].Show()}");
                }
                var key = Console.ReadLine();
                if (key == "quit")
                    return;
                var isInt = int.TryParse(key, out int actionIndex);
                if (isInt == true && actionIndex <= uis.Count && actionIndex > 0)
                    Console.WriteLine(uis[actionIndex - 1].Action());
                else
                    Console.WriteLine($"Invalid value. Can`t parse {key}. Values must be in range [1:{uis.Count}].");
            }
        }
    }
}




