using System.ComponentModel.DataAnnotations;


namespace stpApp.BusinessLogic
{
    public partial class Message
    {
        [Key]
        public int Id { get; set; }
        public string messageContents { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}