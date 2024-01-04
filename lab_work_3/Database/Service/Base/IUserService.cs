
namespace lab_work_3
{
    public interface IUserService
    {
        public bool CreateAccount(GameAccount user, UserType userType);
        public List<GameAccount> ReadAccounts();
        public GameAccount ReadAccountbyId(int searchId);
    }
}
