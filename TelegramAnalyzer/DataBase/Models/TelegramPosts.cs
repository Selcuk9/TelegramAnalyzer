using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class TelegramPosts
    {
        public long Id { get; set; }
        public string ChannelUsername { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime WriteTime { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public long ChannelTelegramId { get; set; }
        public long TelegramId { get; set; }
    }
}
