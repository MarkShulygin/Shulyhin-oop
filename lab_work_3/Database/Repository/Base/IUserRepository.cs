
namespace lab_work_3
{
    public interface IUserRepository
    {
        public void Create(UserEntity user);
        public IEnumerable<UserEntity> Read();
        public void Update(UserEntity user);
        public void Delete(int Id);
    }
}
