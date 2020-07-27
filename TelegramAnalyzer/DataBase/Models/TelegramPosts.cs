using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class TelegramPosts
    {
        public TelegramPosts()
        {
            StatisticsPosts = new HashSet<StatisticsPosts>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime WriteTime { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public long ChatId { get; set; }

        public virtual TelegramChannels Chat { get; set; }
        public virtual ICollection<StatisticsPosts> StatisticsPosts { get; set; }
    }
}
