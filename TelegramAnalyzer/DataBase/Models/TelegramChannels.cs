using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class TelegramChannels
    {
        public TelegramChannels()
        {
            TelegramPosts = new HashSet<TelegramPosts>();
        }

        public long TelegramId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public int? SubscribersCount { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<TelegramPosts> TelegramPosts { get; set; }
    }
}
