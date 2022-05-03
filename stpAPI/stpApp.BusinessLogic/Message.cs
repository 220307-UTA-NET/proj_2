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


        public Message()
        {
            this.Id = 0;
            this.UserId = 0;
            this.CreatedAt = null;
            this.UpdatedAt = null;
        }

        public Message(int id, string msgContents, int usrId, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id;
            this.messageContents = msgContents;
            this.UserId = usrId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}