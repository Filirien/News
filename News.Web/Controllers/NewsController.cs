using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Services.Interfaces;
using News.Web.Models;

namespace News.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }
     
        public async Task<IActionResult> All([FromQuery]int page = 1)
            => View(await this.news.AllAsync(page));

        [HttpGet]
        public async Task<IActionResult> AllAsync([FromQuery]int page = 1)
            => Json(await this.news.AllAsync(page));
        
    }
}