using System.ComponentModel.DataAnnotations;


namespace stpApp.BusinessLogic
{
    public partial class UserAcc
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? LastPlace { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public UserAcc()
        {
            this.Id = 0;
            //this.Username = null!;
            this.LastPlace = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }

        public UserAcc(int id, string username, string password, DateTime lastPlace, DateTime createdAt, DateTime updateAt)
        {
            this.Id = id;
            this.Username = username;   
            this.Password = password;
            this.LastPlace = lastPlace;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updateAt;
        }
    }


}