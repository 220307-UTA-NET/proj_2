using System.ComponentModel.DataAnnotations;

namespace stpApp.BusinessLogic
{
    public partial class Guest
    {
        [Key]
        public int Id { get; set; }
        public DateTime? LastPlace { get; set; }
        public string IpAddress { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public Guest()
        {
            this.Id = 0;
            this.LastPlace = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }

        public Guest(int id, DateTime lastPlace, string ipAdress, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id;
            this.LastPlace = lastPlace;
            this.IpAddress = ipAdress;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }


}