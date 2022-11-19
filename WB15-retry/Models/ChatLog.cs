namespace WB15_retry.Models
{
    public class ChatLog
    {
        public int Id { get; set; }
        public DateTime PostAt { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }

    }

    /*
    public class ChatLogService: IChatLogService
    {
        private IChatLogRepository _repository;
        public ChatLogService():this(new ChatLogRepositry()) { }

        public ChatLogService(IChatLogRepository repositry)
        {
            _repository = repositry;
        }

        public List<ChatLog> GetChatLogs()
        {
            var model = new List<ChatLog>();
            var data = _repository.GetChatLogs();

            foreach(var item in data)
            {
                var log = new ChatLog();
                log.Id = item.Id;
                log.PostAt = item.PostAt;
                log.Message = item.Message;
                log.UserId = item.UserId;
                model.Add(log);
            }
            return model;
        }
    }

    public interface IChatLogService
    {
        List<ChatLog> GetChatLogs();
    }

    public class ChatLogRepositry: IChatLogRepository
    {
        DevEntities dbcontext = new DevEntities();

        public List<ChatLog> GetChatLogs()
        {
            var query = from x in dbcontext.ChatLogs
                        orderby x.Id
                        select x;

            return query.ToList();
        }
    }

    public interface IChatLogRepository
    {
        List<ChatLog> GetChatLogs();
    }
    */
}
