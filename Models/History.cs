using System;
using System.Collections.Generic;

#nullable disable

namespace webapi_news_weather.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Info { get; set; }
    }
}
