

namespace lab_work_3
{
    public class InfoUserByIdUI : IUserInterface
    {
        IUserService userService;
        UserEntity userEntity = new();
        public InfoUserByIdUI(DbContext context)
        {
            userService = new UserService(context);
        }
        public string Action()
        {
            Console.WriteLine("Enter User id:");
            var validId = int.TryParse(Console.ReadLine(), out int userid);
            if (!validId)
                return "Invalid ID, can`t find user. Please enter valid ID";
            var user = userService.ReadAccountbyId(userid); ;
            string result = "";
            result += user.GetInfo();
            return result;
        }
        public string Show()
        {
            return $"Show User info by Id";
        }
    }
}
