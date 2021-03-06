﻿using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 一个获取所有天气数据的API
        /// </summary>
        /// <returns></returns>
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        //[Authorize(Roles ="Admin")]
        //[Authorize(Roles ="User")]

        //与下面两个实例意思都不一样，就是一个字符串。
        //[Authorize(Roles = "Admin,User")]
        //[Authorize(Roles = "AdminOrUser")]
        //[Authorize(Roles = "AdminAndUser")]

        //[Authorize(Policy = "AdminOrUser")]
        [Authorize(Policy = "AdminAndUser")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Model注释展示测试
        /// </summary>
        /// <param name="love">model实体类参数</param>
        [HttpPost]
        public void Post(Love love)
        {
        }
    }
}
