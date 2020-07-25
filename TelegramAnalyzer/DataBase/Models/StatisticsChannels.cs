using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class StatisticsChannels
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public int SubscribersCount { get; set; }
        public DateTime CreateTime { get; set; }
        public long TelegramId { get; set; }
    }
}
