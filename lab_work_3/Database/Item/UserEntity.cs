
namespace lab_work_3
{
	public enum UserType
	{
		GameAccount,
		DoubleDeductionPointsGameAccount,
		DoublePointsGameAccount
	};
	public class UserEntity
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public int CurrentRating { get; set; }
		public UserType Type { get; set; }
    }   
}

