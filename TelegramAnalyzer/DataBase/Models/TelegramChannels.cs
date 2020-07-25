using System;
using System.Collections.Generic;

namespace TelegramAnalyzer.DataBase.Models
{
    public partial class TelegramChannels
    {
        public long Id { get; set; }
        public long TelegramId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
