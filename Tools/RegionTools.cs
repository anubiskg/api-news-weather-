using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_news_weather.Tools
{
    public class RegionTools
    {
        public static string GetRegionName(string countryCode)
        {
            try
            {
                RegionInfo regionInfo = new RegionInfo(countryCode);
                return regionInfo.DisplayName;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        } 
    }
}
