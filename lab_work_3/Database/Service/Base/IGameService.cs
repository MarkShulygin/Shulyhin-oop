
namespace lab_work_3
{
    public interface IGameService
    {
        public bool CreateGame(AbstractGame game, GameType gameType);
        public List<AbstractGame> ReadGame();
        public List<AbstractGame> ReadUsersGamesByUserId(int searchId);
    }
}
