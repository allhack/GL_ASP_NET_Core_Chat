using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChatApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
