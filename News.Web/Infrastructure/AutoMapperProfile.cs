using AutoMapper;
using News.Common.News.BindingModels;

namespace News.Web.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.Models.News, NewsListingViewModel>();
        }
    }
}
