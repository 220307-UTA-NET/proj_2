using System.ComponentModel.DataAnnotations;


namespace stpApp.BusinessLogic
{
    public class User
    {
        // Fields
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime lastPlace { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        
        // Constructor

        // w/ created_at
        public User(int id, string username, string password, DateTime lastPlace, DateTime created_at, DateTime updated_at)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.lastPlace = lastPlace;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
        // w/o created_at
        public User(int id, string username, string password, DateTime lastPlace, DateTime updated_at)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.lastPlace = lastPlace;
            this.updated_at = updated_at;
        }
    }
    
    
}