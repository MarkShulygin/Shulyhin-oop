
namespace lab_work_3
{
    public class AddUserUI : IUserInterface
    {
        IUserService userService;
        public AddUserUI(DbContext context)
        {
            userService = new UserService(context);
        }
        public string Action()
        {
            // Username
            string userName;
            Console.WriteLine("Enter new username:");
            userName = Console.ReadLine();

            // Usertype
            GameAccount userEntity;
            Console.WriteLine("Choose type of User:\r\n\t\tGame Account[0],\r\n\t\tDouble Deduction Points Game Account[1],\r\n\t\tDouble Points Game Account[2]");
            UserType userTypeEnum;
            string usertype = Console.ReadLine();
            if (usertype[0] != '0' && usertype[0] != '1' && usertype[0] != '2')
                return "Unknown command, non possible to create a user";
            if (usertype[0] == '1')
            {
                userEntity = new DoubleDeductionPointsGameAccount(userName);
                userTypeEnum = UserType.DoubleDeductionPointsGameAccount;
            }
            else
            {
                if(usertype[0] == '2')
                {
                    userEntity = new DoublePointsGameAccount(userName);
                    userTypeEnum = UserType.DoublePointsGameAccount;
                }
                else
                {
                    userEntity = new GameAccount(userName);
                    userTypeEnum = UserType.GameAccount;
                }
            }
            
            //userid
            Console.WriteLine("Enter User id:");
            var validId = int.TryParse(Console.ReadLine(), out int id);
            if (!validId)
                return "Can`t create user. Invalid ID.";
            userEntity.Id = id;
            try
            {
                var result = userService.CreateAccount(userEntity, userTypeEnum);
                return "User added";
            }
            catch (Exception e)
            {
                return $"Non possible to add a user. {e.Message}";
            }
        }
        public string Show()
        {
            return "Add User.";
        }
    }
}
