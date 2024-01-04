
namespace lab_work_3
{
    public interface IGameRepository
    {
        public void Create(GameEntity game);
        public IEnumerable<GameEntity> Read();
        public void Update(GameEntity game);
        public void Delete(int Id);
        
    }
}
