namespace News.Web.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using News.Data;
    using News.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;


    public static class ApplicationBuilderExtensions
    {
        private const string firstNewsTitle = "Pariplay Brings to Life Tutankhamun Legend with New Luxor Slot";
        private const string firstNewsDescription = "22nd October 2018 – Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has released Luxor, an original video slot that combines cutting-edge 21st century technology with the timeless mystery of the land of the pharaohs. The Tutankhamun-themed slot features highly innovative in-game features such as expanding reels that increase the pay ways to an exceptional 1,944.";
        private const string firstNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/10/355x152.png";
        private const string firstNewsCreatedOn = "10/22/2018";

        private const string secondNewsTitle = "Pariplay Launches Enchantingly Epic ‘Bai She Zhuan’ Video Slot";
        private const string secondNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has launched Bai She Zhuan, a delightfully original online video slot. Developed by Pariplay’s in-house studio, the slot will inspire repeat visits through its unique gameplay, a collection of enticing rewards and the two captivating characters at the centre of its mythical tale.";
        private const string secondNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/08/355x152.jpg";
        private const string secondNewsCreatedOn = "08/23/2018";

        private const string thirdNewsTitle = "The Carnival Heats Up as Pariplay Launches New ‘Rio Fever’ Video Slot";
        private const string thirdNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has launched Rio Fever, an original online video slot. Developed by Pariplay’s in-house studio, the game combines appealing aesthetics, tantalising bonuses and innovative features to encourage strong player acquisition and retention.";
        private const string thirdNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/07/355x152.png";
        private const string thirdNewsCreatedOn = "07/05/2018";

        private const string fourthNewsTitle = "Pariplay Enters Italian iGaming Market with StarCasinó.it";
        private const string fourthNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has announced its entry into the Italian iGaming market. This development will see the global gaming software provider supply casino games to leading Italian online casino brand StarCasino.it, which is part of Betsson Group’s brand portfolio.";
        private const string fourthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/07/Starcasino-Logo_0-3.png";
        private const string fourthNewsCreatedOn = "07/01/2018";

        private const string fifthNewsTitle = "Pariplay Wins Prestigious ‘Mobile Gaming Software’ 2018 EGR B2B Award";
        private const string fifthNewsDescription = "Pariplay Ltd., a gaming technology company serving online and land-based casinos, iLotteries and iGaming brands, has won the prestigious ‘Mobile Gaming Software’ Award at the 2018 EGR B2B Awards, held in London on 20th June 2018. The award recognises the company’s major contribution to evolving the mobile gaming space with its innovative interactive gaming system eyeON® for global land-based casinos, including Foxwoods Resort Casino.";
        private const string fifthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/06/EGR-B2B-Awards-2018-Winner-Logo-AltSize_300dpi-2.jpg";
        private const string fifthNewsCreatedOn = "06/24/2018";

        private const string sixthNewsTitle = "Pariplay Launches Explosive New ‘Chitty Bang’ Video Slot	";
        private const string sixthNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has launched Chitty Bang, an original online video slot. Developed by Pariplay’s in-house studio, the game combines the best of classic slots with cutting-edge features for 2018 to ensure strong player engagement and retention, including a wide range of bonuses and wilds.";
        private const string sixthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/05/ChittyBang_355x152.png";
        private const string sixthNewsCreatedOn = "04/25/2018";

        private const string seventhNewsTitle = "Pariplay Inks Strategic Content Partnership with AMATIC’s AMANET";
        private const string seventhNewsDescription = "Pariplay Ltd., a gaming technology company serving online and land-based casinos, iLotteries and iGaming brands, has announced a strategic partnership with AMANET, the online subsidiary of the Austrian land-based casino games manufacturer AMATIC Industries. Under the agreement, AMANET’s portfolio of online casino and slots games will integrate with Pariplay’s FUSION content network.";
        private const string seventhNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/03/Amatic-Industries-Logo-300dpi-1-450x169-2-e1532097290805.jpg";
        private const string seventhNewsCreatedOn = "03/08/2018";

        private const string eighthNewsTitle = "Pariplay’s Online Casino Portfolio Blossoms with New Wild Cherry Slot";
        private const string eighthNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has launched Wild Cherry, an original online video slot game. Released to coincide with spring, the game is a flavoursome twist on classic land-based fruit machine games and was developed by Pariplay’s in-house studio with a strong emphasis on player engagement and retention, including an unprecedented number of bonus features.";
        private const string eighthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/05/Wild_Cherry_355x152.png";
        private const string eighthNewsCreatedOn = "03/22/2018";

        private const string ninthNewsTitle = "Casino Players Will be Over the Moon with Pariplay’s New Chang’e Slot";
        private const string ninthNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and lotteries, has launched Chang’e – Goddess of the Moon, an original online video slot game. Paying spectacular homage to the ancient Chinese lunar goddess Chang’e, the new Pariplay-developed game allows online casino players across to world to shoot for the moon on their device of choice.";
        private const string ninthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/05/Change_355x152.png";
        private const string ninthNewsCreatedOn = "03/01/2018";

        private const string tenthNewsTitle = "Pariplay & Foxwoods Resort Casino Enter Landmark Interactive Gaming Technology Partnership";
        private const string tenthNewsDescription = "Pariplay Ltd., a gaming technology company serving online and land-based casinos, iLotteries and iGaming brands, has announced a major technology partnership with Foxwoods Resort Casino, the Connecticut resort and casino complex owned by the Mashantucket Pequot Tribal Nation. Foxwoods has adopted Pariplay’s ground-breaking interactive gaming platform eyeON, allowing guests at North America’s largest resort casino to enjoy digital gaming on-property, subject to any necessary legislation and regulatory review and approval.";
        private const string tenthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/02/FoxwoodsLogo_Horizontal_Black-1-705x172-1-e1532097469680.jpg";
        private const string tenthNewsCreatedOn = "02/05/2018";

        private const string eleventhNewsTitle = "The Legend Lives On as Pariplay & Atari Launch Atari® Pong Online Slot";
        private const string eleventhNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and iLotteries, and Atari, a leading publisher of video games, have announced the launch of the real-money online slot Pong®, based on the iconic Atari Interactive arcade game. Having recently celebrated its 45th Anniversary, this legendary table tennis simulator has been enjoyed by countless players since its original 1972 release and is often credited with establishing the video game industry as it is known today.";
        private const string eleventhNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/01/pong-web-300x128-1.jpg";
        private const string eleventhNewsCreatedOn = "01/24/2018";

        private const string twelfthNewsTitle = "Pariplay Ltd. Launches Content Partnership with Betclic Everest Group";
        private const string twelfthNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and iLotteries, has announced a content partnership with Betclic Group, the France-based operator of the Betclic portfolio of online sports-betting, horse-racing, casino and poker brands. Under the partnership, Pariplay’s online casino games have gone live on the operator’s online sportsbook and casino brands, Betclic.com and Expekt.com, along with their stand-alone casino MonteCarloCasino.com.";
        private const string twelfthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2018/01/logo-betclic-group-g-300x128-1.jpg";
        private const string twelfthNewsCreatedOn = "01/16/2018";

        private const string thirteenthNewsTitle = "Pariplay Springs Jack in the Box Casino Slot on iGaming Industry";
        private const string thirteenthNewsDescription = "Pariplay Ltd., a gaming technology company serving iGaming operators, land-based casinos and iLotteries, has launched Jack in the Box, a real-money online video slot. An original title developed in HTML5 for cross-device play, the new casino slot conjures up the fun and surprises of the golden age of big-top circuses yet features state-of-the-art UX and cutting-edge graphical design and soundtrack.";
        private const string thirteenthNewsImageUrl = "https://www.pariplayltd.com/wp-content/uploads/2017/11/235X141.png";
        private const string thirteenthNewsCreatedOn = "11/16/2017";

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<NewsDbContext>();
                dbContext.Database.Migrate();

                bool isNewsTableEmpty = !dbContext.News.Any();

                if (isNewsTableEmpty)
                {
                    var news = new List<News>
                    {
                        new News
                        {
                            Title = firstNewsTitle,
                            Description = firstNewsDescription,
                            CreatedOn = DateTime.ParseExact(firstNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = firstNewsImageUrl
                        },
                        new News
                        {
                            Title = secondNewsTitle,
                            Description = secondNewsDescription,
                            CreatedOn = DateTime.ParseExact(secondNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = secondNewsImageUrl
                        },
                        new News
                        {
                            Title = thirdNewsTitle,
                            Description = thirdNewsDescription,
                            CreatedOn = DateTime.ParseExact(thirdNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = thirdNewsImageUrl
                        },
                        new News
                        {
                            Title = fourthNewsTitle,
                            Description = fourthNewsDescription,
                            CreatedOn = DateTime.ParseExact(fourthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = fourthNewsImageUrl
                        },
                        new News
                        {
                            Title = fifthNewsTitle,
                            Description = fifthNewsDescription,
                            CreatedOn = DateTime.ParseExact(fifthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = fifthNewsImageUrl
                        },
                        new News
                        {
                            Title = sixthNewsTitle,
                            Description = sixthNewsDescription,
                            CreatedOn = DateTime.ParseExact(sixthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = sixthNewsImageUrl
                        },
                        new News
                        {
                            Title = seventhNewsTitle,
                            Description = seventhNewsDescription,
                            CreatedOn = DateTime.ParseExact(seventhNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = seventhNewsImageUrl
                        },
                        new News
                        {
                            Title = eighthNewsTitle,
                            Description = eighthNewsDescription,
                            CreatedOn = DateTime.ParseExact(eighthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = eighthNewsImageUrl
                        },
                        new News
                        {
                            Title = ninthNewsTitle,
                            Description = ninthNewsDescription,
                            CreatedOn = DateTime.ParseExact(ninthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = ninthNewsImageUrl
                        },
                        new News
                        {
                            Title = tenthNewsTitle,
                            Description = tenthNewsDescription,
                            CreatedOn = DateTime.ParseExact(tenthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = tenthNewsImageUrl
                        },
                        new News
                        {
                            Title = eleventhNewsTitle,
                            Description = eleventhNewsDescription,
                            CreatedOn = DateTime.ParseExact(eleventhNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = eleventhNewsImageUrl
                        },
                        new News
                        {
                            Title = twelfthNewsTitle,
                            Description = twelfthNewsDescription,
                            CreatedOn = DateTime.ParseExact(twelfthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = twelfthNewsImageUrl
                        },
                        new News
                        {
                            Title = thirteenthNewsTitle,
                            Description = thirteenthNewsDescription,
                            CreatedOn = DateTime.ParseExact(thirteenthNewsCreatedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ImageUrl = thirteenthNewsImageUrl
                        }
                    };

                    dbContext.AddRange(news);
                    dbContext.SaveChanges();
                }
            }

            return app;
        }
    }
}
