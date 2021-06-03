using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_news_weather.Models;
using webapi_news_weather.Tools;

namespace webapi_news_weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsWeatherController : ControllerBase
    {
        private readonly pruebaContext context;

        public NewsWeatherController(pruebaContext context)
        {
            this.context = context;
        }

        //Get /history
        [Route("history")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Histories.ToList());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Get api/<controller>/city
        [HttpGet("{countryCode}")]
        public ActionResult Get(string countryCode)
        {
            try
            {
                var articles = New.New.FromJson(ExternalRequest.GetNews(countryCode));
                var nameCountry = RegionTools.GetRegionName(countryCode);
                var weather = Weather.Weather.FromJson(ExternalRequest.GetWeather(nameCountry));
                var arrayOfObjects = JsonConvert.SerializeObject(new Object[] { articles, weather });
                SaveHistory(nameCountry, arrayOfObjects);
                return Ok(arrayOfObjects);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private void SaveHistory(string nameCountry, string arrayOfObjects)
        {
            History history = new History();
            history.City = nameCountry;
            history.Info = arrayOfObjects;
            context.Histories.Add(history);
            context.SaveChanges();
        }
    }
}
