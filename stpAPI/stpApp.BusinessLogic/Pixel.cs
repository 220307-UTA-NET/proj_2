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

        public void testPixel(int id, short row, short col, string color, DateTime createdAt, DateTime updatedAt, string updatedBy)
        {
            this.Id = id;
            this.Row = row;
            this.Col = col;
            this.Color = color;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.UpdatedBy = updatedBy;
        }
    }
}