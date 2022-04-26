using System.ComponentModel.DataAnnotations;


namespace stpApp.BusinessLogic
{
    public partial class UserAcc
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? LastPlace { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }


}