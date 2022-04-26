using System.ComponentModel.DataAnnotations;

namespace stpApp.BusinessLogic
{
    public partial class Pixel
    {
        public int Id { get; set; }
        public short Row { get; set; }
        public short Col { get; set; }
        public string Color { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }


}