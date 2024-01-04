
namespace lab_work_3
{
    internal class UserRepository : IUserRepository
    {
        private readonly DbContext dbcontext;
        public UserRepository(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void Create(UserEntity user)
        {
            dbcontext.Users.Add(user);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> Read()
        {
            return dbcontext.Users;
        }

        public void Update(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
