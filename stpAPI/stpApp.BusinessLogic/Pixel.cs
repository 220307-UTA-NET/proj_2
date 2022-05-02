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



        public Pixel()
        {
            this.Id = 0;
            //this.Color = null;
            this.CreatedAt = null;
            this.UpdatedAt = null;
            this.UpdatedBy = null;
        }

        public Pixel(int id, string color, DateTime createdAt, DateTime updatedAt, string updatedBy)
        {
            this.Id = id;
            this.Color = color;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.UpdatedBy = updatedBy;
        }
    }
}