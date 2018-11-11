using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using News.Common.News.BindingModels;
using News.Data;
using News.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Services
{
    public class NewsService : INewsService
    {
        private readonly NewsDbContext db;
        private readonly IMapper mapper;
        private readonly int NewsPageSize = 6;
        private readonly int FirstPageSize = 9;

        public NewsService(NewsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<NewsListingViewModel>> AllAsync(int page = 1)
        {
            int pageToSkip = (page <= 1) ? 0 : (page - 2) * NewsPageSize + FirstPageSize;
            int pageToTake = (page <= 1) ? FirstPageSize : NewsPageSize;

            return await this.db
                 .News
                 .OrderByDescending(n => n.CreatedOn)
                 .Skip(pageToSkip)
                 .Take(pageToTake)
                 .ProjectTo<NewsListingViewModel>(mapper.ConfigurationProvider)
                 .ToListAsync();
        }
    }
}
