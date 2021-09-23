namespace ForbExpress.Models
{
    public class Correspondence
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public LetterStatus Status { get; set; }
        public string ReceivingAddress { get; set; }
    }

    public enum LetterStatus
    {
        Sent,
        Received
    }
}