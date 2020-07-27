using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class StatisticsChannel
    {
        public long Id { get; set; }
        public long CountSubscribers { get; set; }
        public DateTime CreateTime { get; set; }
        public long ChannelId { get; set; }
    }
}
