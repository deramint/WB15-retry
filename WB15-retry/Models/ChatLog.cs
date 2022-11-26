namespace WB15_retry.Models
{
    public class ChatLog
    {
        public int Id { get; set; }
        public DateTime PostAt { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}
