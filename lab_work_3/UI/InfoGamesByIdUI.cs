
namespace lab_work_3
{
        public class InfoGamesByIdUI : IUserInterface
        {
            IGameService gameService;
            public InfoGamesByIdUI(DbContext context)
            {
                gameService = new GameService(context);
            }
            public string Action()
            {
                Console.WriteLine("Enter User id:");
                var validId = int.TryParse(Console.ReadLine(), out int userid);
                if (!validId)
                    return "Non valid ID, can`t find user.";
                var games = gameService.ReadUsersGamesByUserId(userid); ;
                string result = "";
                foreach (var gameItem in games)
                {
                    result += gameItem.GetInfo() + "\n";
                }
                return result;
            }
            public string Show()
            {
                return $"Show User games by Id";
            }
        }
}
