using System.ComponentModel.DataAnnotations;

namespace stpApp.BusinessLogic
{
    public class Guest
    {
        // Fields
        [Key]
        public int id { get; set; }
        public DateTime lastPlace { get; set; }
        public string ipAddress { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        // Constructor

        // w/ created_at
        public Guest(int id, DateTime lastPlace, string ipAddress, DateTime created_at, DateTime updated_at)
        {
            this.id = id;
            this.lastPlace = lastPlace;
            this.ipAddress = ipAddress;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }
        // w/o created_at
        public Guest(int id, DateTime lastPlace, string ipAddress, DateTime updated_at)
        {
            this.id = id;
            this.lastPlace = lastPlace;
            this.ipAddress = ipAddress;
            this.updated_at = updated_at;
        }
    }


}