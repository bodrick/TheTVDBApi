using System;
using TVDB.Model;
using Xunit;

namespace TVDB.Test.Model
{
    public class SeriesTest
    {
        #region Initialize tests

        [Fact]
        public void InitializeTestSuccessfulNoEpisodes()
        {
            var target = new Series();
            var targetType = typeof(Series);
            var method = targetType.GetMethod("Initialize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method?.Invoke(target, Array.Empty<object>());

            Assert.False(target.HasEpisodes);
        }

        [Fact]
        public void InitializeTestSuccessfulWithEpisodes()
        {
            var target = new Series();
            target.Episodes.Add(new Episode());
            var targetType = typeof(Series);
            var method = targetType.GetMethod("Initialize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method?.Invoke(target, Array.Empty<object>());

            Assert.True(target.HasEpisodes);
        }

        #endregion Initialize tests

        #region Deserialize tests

        [Fact]
        public void DeserializeTestFailedNoNode()
        {
            var target = new Series();

            var expected = new ArgumentNullException("node", "Provided node must not be null.");
            var actual = Assert.Throws<ArgumentNullException>(() => target.Deserialize(null));

            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void DeserializeTestSuccessful()
        {
            const string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Data><Series><id>83462</id><Actors>|Nathan Fillion|Stana Katic|Molly C. Quinn|Jon Huertas|Seamus Dever|Tamala Jones|Susan Sullivan|Ruben Santiago-Hudson|Penny Johnson|</Actors><Airs_DayOfWeek>Monday</Airs_DayOfWeek><Airs_Time>10:00 PM</Airs_Time><ContentRating>TV-PG</ContentRating><FirstAired>2009-03-09</FirstAired><Genre>|Comedy|Crime|Drama|</Genre><IMDB_ID>tt1219024</IMDB_ID><Language>en</Language><Network>ABC</Network><NetworkID></NetworkID><Overview>Rick Castle is one of the world's most successful crime authors. But when his rock star lifestyle isn't enough, this bad boy goes looking for new trouble and finds it working with smart, beautiful Detective Kate Beckett. Inspired by her professional record and intrigued by her buttoned-up personality, Castle's found the model for his bold new character whether she likes it or not. Now with the mayor's permission, Castle is helping solve crime with his own twist.</Overview><Rating>8.8</Rating><RatingCount>346</RatingCount><Runtime>60</Runtime><SeriesID>75394</SeriesID><SeriesName>Castle (2009)</SeriesName><Status>Continuing</Status><added>2008-10-17 15:05:50</added><addedBy>3071</addedBy><banner>graphical/83462-g10.jpg</banner><fanart>fanart/original/83462-33.jpg</fanart><lastupdated>1378896827</lastupdated><poster>posters/83462-6.jpg</poster><tms_wanted>1</tms_wanted><zap2it_id>EP01085588</zap2it_id></Series></Data>";
            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xmlContent);

            var dataNode = doc.ChildNodes[1];
            Assert.NotNull(dataNode);
            var seriesNode = dataNode.ChildNodes[0];
            var target = new Series();

            target.Deserialize(seriesNode);

            const int expectedId = 83462;
            const string expectedLanguage = "en";
            const string expectedName = "Castle (2009)";
            const string expectedBannerPath = "graphical/83462-g10.jpg";
            const string expectedOverview = "Rick Castle is one of the world's most successful crime authors. But when his rock star lifestyle isn't enough, this bad boy goes looking for new trouble and finds it working with smart, beautiful Detective Kate Beckett. Inspired by her professional record and intrigued by her buttoned-up personality, Castle's found the model for his bold new character whether she likes it or not. Now with the mayor's permission, Castle is helping solve crime with his own twist.";
            var expectedFirstAired = new DateTime(2009, 3, 9, 0, 0, 0);
            const string expectedIMDBId = "tt1219024";
            const string expectedZap2itId = "EP01085588";
            const string expectedActors = "Nathan Fillion, Stana Katic, Molly C. Quinn, Jon Huertas, Seamus Dever, Tamala Jones, Susan Sullivan, Ruben Santiago-Hudson, Penny Johnson";
            const string expectedGenre = "Comedy, Crime, Drama";
            const string expectedDayAired = "Monday";
            const string expectedTimeAired = "10:00 PM";
            const string expectedContentRating = "TV-PG";
            const string expectedNetwork = "ABC";
            const int expectedNetworkID = 0;
            const double expectedRating = 8.8;
            const int expectedRatingCount = 346;
            const double expectedRunTime = 60.0;
            const int expectedSeriesID = 75394;
            const string expectedStatus = "Continuing";
            var expectedAddedDate = new DateTime(2008, 10, 17, 15, 05, 50);
            const int expectedAddedByUserId = 3071;
            const string expectedBanner = "graphical/83462-g10.jpg";
            const string expectedFanArt = "fanart/original/83462-33.jpg";
            const string expectedPoster = "posters/83462-6.jpg";
            const bool expectedTMSWanted = true;

            Assert.Equal(expectedId, target.Id);
            Assert.Equal(expectedLanguage, target.Language);
            Assert.Equal(expectedName, target.Name);
            Assert.Equal(expectedBannerPath, target.Banner);
            Assert.Equal(expectedOverview, target.Overview);
            Assert.Equal(expectedFirstAired, target.FirstAired);
            Assert.Equal(expectedIMDBId, target.ImdbId);
            Assert.Equal(expectedZap2itId, target.Zap2ItId);
            Assert.False(target.HasEpisodes);
            Assert.Equal(expectedActors, target.Actors);
            Assert.Equal(expectedGenre, target.Genre);
            Assert.Equal(expectedDayAired, target.AirsDayOfWeek);
            Assert.Equal(expectedTimeAired, target.AirsTime);
            Assert.Equal(expectedContentRating, target.ContentRating);
            Assert.Equal(expectedNetwork, target.Network);
            Assert.Equal(expectedNetworkID, target.NetworkId);
            Assert.Equal(expectedRating, target.Rating);
            Assert.Equal(expectedRatingCount, target.RatingCount);
            Assert.Equal(expectedRunTime, target.Runtime);
            Assert.Equal(expectedSeriesID, target.SeriesId);
            Assert.Equal(expectedStatus, target.Status);
            Assert.Equal(expectedAddedDate, target.AddedDate);
            Assert.Equal(expectedAddedByUserId, target.AddedByUserId);
            Assert.Equal(expectedBanner, target.Banner);
            Assert.Equal(expectedFanArt, target.FanArt);
            Assert.Equal(expectedPoster, target.Poster);
            Assert.Equal(expectedTMSWanted, target.TmsWanted);
        }

        #endregion Deserialize tests
    }
}
