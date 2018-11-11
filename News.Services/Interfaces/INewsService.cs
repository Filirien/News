using News.Common.News.BindingModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Services.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsListingViewModel>> AllAsync(int page = 1);
    }
}
