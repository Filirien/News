using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using News.Common.News.BindingModels;
using News.Data;
using News.Services;
using News.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace News.Tests.Services
{
    [TestClass]
    public class NewsServiceTests
    {

        private IMapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        private NewsDbContext GetDbContext()
            => new NewsDbContext(
                new DbContextOptionsBuilder<NewsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

        private readonly IEnumerable<Data.Models.News> testData = new List<Data.Models.News>
        {
            new Data.Models.News{ Id = 4, Title = "Title1",Description="Description1", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2018-11-11") }, 
            new Data.Models.News{ Id = 2, Title = "Title2",Description="Description2", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2017-08-03")},
            new Data.Models.News{ Id = 5, Title = "Title3",Description="Description3", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2016-08-03")},
            new Data.Models.News{ Id = 1, Title = "Title4",Description="Description4", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2015-08-03")},
            new Data.Models.News{ Id = 3, Title = "Title5",Description="Description5", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2014-08-03")},
            new Data.Models.News{ Id = 6, Title = "Title6",Description="Description1", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2013-08-03")},
            new Data.Models.News{ Id = 7, Title = "Title7",Description="Description2", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2012-08-03")},
            new Data.Models.News{ Id = 8, Title = "Title8",Description="Description3", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2011-08-03")},
            new Data.Models.News{ Id = 9, Title = "Title9",Description="Description4", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png",   CreatedOn = DateTime.Parse("2010-08-03")},
            new Data.Models.News{ Id = 10, Title = "Title10",Description="Description5", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2009-08-03")},
            new Data.Models.News{ Id = 11, Title = "Title11",Description="Description1", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2008-08-03")},
            new Data.Models.News{ Id = 12, Title = "Title12",Description="Description2", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2007-08-03")},
            new Data.Models.News{ Id = 15, Title = "Title13",Description="Description3", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2006-08-03")},
            new Data.Models.News{ Id = 16, Title = "Title14",Description="Description4", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2005-08-03")},
            new Data.Models.News{ Id = 13, Title = "Title15",Description="Description5", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2004-08-03")},
            new Data.Models.News{ Id = 14, Title = "Title16",Description="Description1", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2003-08-03")},
            new Data.Models.News{ Id = 17, Title = "Title17",Description="Description2", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2002-08-03")},
            new Data.Models.News{ Id = 18, Title = "Title18",Description="Description3", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2001-08-03")},
            new Data.Models.News{ Id = 19, Title = "Title19",Description="Description4", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("2000-08-03")},
            new Data.Models.News{ Id = 20, Title = "Title20",Description="Description5", ImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png", CreatedOn = DateTime.Parse("1999-08-03")},
        };

        private void PopulateData(NewsDbContext db)
        {
            db.AddRange(this.testData);
            db.SaveChanges();
        }

        [TestMethod]
        public async Task AllAsync_ShouldReturnNineRecordsForFirstPage_WhenPageIsNotPassed()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync();

            // Assert
            Assert.AreEqual(returnedData.Count(), 9);
        }

        [TestMethod]
        public async Task AllAsync_ShouldReturnNineRecords_WhenPageIsOne()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(1);

            // Assert
            Assert.AreEqual(returnedData.Count(), 9);
        }

        [TestMethod]
        public async Task AllAsync_ShouldReturnSixRecordsForFirstPage_WhenPageIsSecond()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(2);

            // Assert
            Assert.AreEqual(returnedData.Count(), 6);
        }

        [TestMethod]
        public async Task AllAsync_ShouldReturnLeftRecordsForFirstPage_WhenPageIsThird()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(3);

            // Assert
            Assert.AreEqual(returnedData.Count(), 5);
        }

        [TestMethod]
        public async Task AllAsync_ShouldBeEqualTitles_WhenTakeFirstNewsFromFirstPage()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(1);

            // Assert
            Assert.AreEqual("Title1", returnedData.ToList().FirstOrDefault().Title);
        }

        [TestMethod]
        public async Task AllAsync_ShouldBeEqualTitles_WhenTakeLasttNewsFromFirstPage()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(1);

            // Assert
            Assert.AreEqual("Title9", returnedData.ToList().Last().Title);
        }

        [TestMethod]
        public async Task AllAsync_ShouldBeEqualTitles_WhenTakeFirstNewsFromSecondPage()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(2);

            // Assert
            Assert.AreEqual("Title10", returnedData.ToList().FirstOrDefault().Title);
        }

        [TestMethod]
        public async Task AllAsync_ShouldBeEqualTitles_WhenTakeLastNewsFromSecondPage()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(2);

            // Assert
            Assert.AreEqual("Title15", returnedData.ToList().Last().Title);
        }

        [TestMethod]
        public async Task AllAsync_ShouldBeEqualTitles_WhenTakeLastNewsFromLastPage()
        {
            // Arrange
            var context = this.GetDbContext();

            this.PopulateData(context);

            var newsService = new NewsService(context, mapper);
            // Act
            var returnedData = await newsService.AllAsync(3);

            // Assert
            Assert.AreEqual("Title20", returnedData.ToList().Last().Title);
        }
    }
}
