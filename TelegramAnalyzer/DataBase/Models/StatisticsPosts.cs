using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class StatisticsPosts
    {
        public long Id { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateTime { get; set; }
        public long? PostId { get; set; }

        public virtual TelegramPosts Post { get; set; }
    }
}
