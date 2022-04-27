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
    }


}