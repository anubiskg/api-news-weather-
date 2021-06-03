using System;
using System.IO;
using System.Net;

namespace webapi_news_weather.Tools
{
    public class ExternalRequest
    {
        private const string apiKeyNews = "82fa869ce388461e87474bb3fc31f4f7";
        private const string apiKeyWeather = "302dee572be7b4351c6b895ea6dba910";
        public static string GetNews(string countryCode)
        {
            var url = $"https://newsapi.org/v2/top-headlines?country={countryCode}&apiKey={apiKeyNews}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("NEWS " + ex.Message);
                return null;
            }
        }

        public static string GetWeather(string country)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={country}&appid={apiKeyWeather}&units=metric";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine("WEATHER " + responseBody);
                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("weather " + ex.Message);
                return null;
            }
        }
    }
}
