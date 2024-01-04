
namespace lab_work_3
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext dbcontext;
        public GameRepository(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public void Create(GameEntity game)
        {
            dbcontext.Games.Add(game);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameEntity> Read()
        {
            return dbcontext.Games;
        }

        public void Update(GameEntity game)
        {
            throw new NotImplementedException();
        }
    }
}
