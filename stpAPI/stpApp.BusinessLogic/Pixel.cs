using System.ComponentModel.DataAnnotations;

namespace stpApp.BusinessLogic
{
    public partial class Pixel
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }


}