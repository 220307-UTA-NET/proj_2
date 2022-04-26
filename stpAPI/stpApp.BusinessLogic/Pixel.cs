using System.ComponentModel.DataAnnotations;

namespace stpApp.BusinessLogic
{
    public class Pixel
    {
        // Fields
        [Key]
        public int id { get; set; }
        public byte row { get; set; }
        public byte col { get; set; }
        public string color { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string updatedBy { get; set; }

        // Constructor

        // w/ created_at
        public Pixel(int id, byte row, byte col, string color, DateTime created_at, DateTime updated_at, string updatedBy)
        {
            this.id = id;
            this.row = row;
            this.col = col;
            this.color = color;
            this.created_at = created_at;
            this.updated_at = updated_at;
            this.updatedBy = updatedBy;
        }
        // w/o created_at
        public Pixel(int id, byte row, byte col, string color, DateTime updated_at, string updatedBy)
        {
            this.id = id;
            this.row = row;
            this.col = col;
            this.color = color;
            this.updated_at = updated_at;
            this.updatedBy = updatedBy;
        }
    }


}