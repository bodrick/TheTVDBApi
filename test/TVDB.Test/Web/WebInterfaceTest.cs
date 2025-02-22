using System;
using System.Linq;
using System.Threading.Tasks;
using TVDB.Model;
using TVDB.Web;
using Xunit;

namespace TVDB.Test.Web
{
    public class WebInterfaceTest
    {
        /// <summary>
        /// Api key for testing.
        /// </summary>
        private const string ApiKey = "CE1AECDA14314FD5";

        /// <summary>
        /// Mirror for testing.
        /// </summary>
        private readonly Mirror _testMirror = new()
        {
            Address = "http://thetvdb.com",
            ContainsBannerFile = true,
            ContainsXmlFile = true,
            ContainsZipFile = true,
            Id = 1
        };

        #region GetMirrors tests

        [Fact]
        public async Task GetMirrorsTestSuccessfulAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetMirrorsAsync();

            Assert.True(result.Count > 0);
        }

        #endregion GetMirrors tests

        #region GetLanguagestests

        [Fact]
        public async Task GetLanguagesTestFailedNoMirrorAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetLanguagesAsync(null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetLanguagesTestSuccessfulAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetLanguagesAsync();

            Assert.NotNull(result);
            Assert.True(result!.Count > 0);
        }

        [Fact]
        public async Task GetLanguagesTestSuccessfulWithMirrorAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetLanguagesAsync(_testMirror);

            Assert.NotNull(result);
            Assert.True(result!.Count > 0);
        }

        #endregion GetLanguagestests

        #region GetSeriesByName tests

        [Fact]
        public async Task GetSeriesByNameTestFailedNoMirrorAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByNameAsync("Hugo", null);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByNameTestFailedNoSeriesNameAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByNameAsync(string.Empty, _testMirror);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByNameTestFailedSeriesNameLanguageNoMirrorAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByNameAsync("Hugo", "en", null);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByNameTestFailedSeriesNameNoLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByNameAsync("Hugo", string.Empty, _testMirror);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByNameTestSuccessfulAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByNameAsync("Chuck", _testMirror);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);

            var firstElement = result[0];
            Assert.Equal("en", firstElement.Language);
            Assert.Equal("Chuck", firstElement.Name);
            Assert.Equal("/banners/graphical/80348-g.jpg", firstElement.Banner);
            Assert.Equal(new DateTime(2007, 09, 24), firstElement.FirstAired);
            Assert.Equal("NBC", firstElement.Network);
            Assert.Equal("tt0934814", firstElement.ImdbId);
            Assert.Equal("EP00930779", firstElement.Zap2ItId);
            Assert.Equal(80348, firstElement.Id);
        }

        [Fact]
        public async Task GetSeriesByNameTestSuccessfulWithNameAndLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByNameAsync("Chuck", "en", _testMirror);

            Assert.NotNull(result);

            var firstElement = result[0];
            Assert.Equal("en", firstElement.Language);
            Assert.Equal("Chuck", firstElement.Name);
            Assert.Equal("/banners/graphical/80348-g.jpg", firstElement.Banner);
            Assert.Equal(new DateTime(2007, 09, 24), firstElement.FirstAired);
            Assert.Equal("NBC", firstElement.Network);
            Assert.Equal("tt0934814", firstElement.ImdbId);
            Assert.Equal("EP00930779", firstElement.Zap2ItId);
            Assert.Equal(80348, firstElement.Id);
        }

        #endregion GetSeriesByName tests

        #region GetSeriesByRemoteId tests

        [Fact]
        public async Task GetSeriesByRemoteIdTestFailedBothIdsAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync("tt0934814", "EP00930779", string.Empty, null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestFailedNoIdAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync(string.Empty, string.Empty, _testMirror);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestFailedNoLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync("tt0934814", string.Empty, string.Empty, _testMirror);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestFailedNoMirrorAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync("tt0934814", string.Empty, string.Empty, null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestSuccessfulImdbIdAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync("tt0934814", string.Empty, _testMirror);

            Assert.NotNull(result);
            Assert.True(result.Count == 1);

            var firstElement = result[0];
            Assert.Equal("en", firstElement.Language);
            Assert.Equal("Chuck", firstElement.Name);
            Assert.Equal("graphical/80348-g.jpg", firstElement.Banner);
            Assert.Equal(new DateTime(2007, 09, 24), firstElement.FirstAired);
            Assert.Equal("tt0934814", firstElement.ImdbId);
            Assert.Equal("EP00930779", firstElement.Zap2ItId);
            Assert.Equal(80348, firstElement.Id);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestSuccessfulImdbIdWithLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync("tt0934814", string.Empty, "en", _testMirror);

            Assert.NotNull(result);
            Assert.True(result.Count == 1);

            var firstElement = result[0];
            Assert.Equal("en", firstElement.Language);
            Assert.Equal("Chuck", firstElement.Name);
            Assert.Equal("graphical/80348-g.jpg", firstElement.Banner);
            Assert.Equal(new DateTime(2007, 09, 24), firstElement.FirstAired);
            Assert.Equal("tt0934814", firstElement.ImdbId);
            Assert.Equal("EP00930779", firstElement.Zap2ItId);
            Assert.Equal(80348, firstElement.Id);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestSuccessfulZap2ItIdAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync(string.Empty, "EP00930779", _testMirror);

            Assert.NotNull(result);
            Assert.True(result.Count == 1);

            var firstElement = result[0];
            Assert.Equal("en", firstElement.Language);
            Assert.Equal("Chuck", firstElement.Name);
            Assert.Equal("graphical/80348-g.jpg", firstElement.Banner);
            Assert.Equal(new DateTime(2007, 09, 24), firstElement.FirstAired);
            Assert.Equal("tt0934814", firstElement.ImdbId);
            Assert.Equal("EP00930779", firstElement.Zap2ItId);
            Assert.Equal(80348, firstElement.Id);
        }

        [Fact]
        public async Task GetSeriesByRemoteIdTestSuccessfulZap2ItIdWithLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetSeriesByRemoteIdAsync(string.Empty, "EP00930779", "en", _testMirror);

            Assert.NotNull(result);
            Assert.True(result.Count == 1);

            var firstElement = result[0];
            Assert.Equal("en", firstElement.Language);
            Assert.Equal("Chuck", firstElement.Name);
            Assert.Equal("graphical/80348-g.jpg", firstElement.Banner);
            Assert.Equal(new DateTime(2007, 09, 24), firstElement.FirstAired);
            Assert.Equal("tt0934814", firstElement.ImdbId);
            Assert.Equal("EP00930779", firstElement.Zap2ItId);
            Assert.Equal(80348, firstElement.Id);
        }

        #endregion GetSeriesByRemoteId tests

        #region GetFullSeriesById tests

        [Fact]
        public async Task GetFullSeriesByIdFailedNoIdAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetFullSeriesByIdAsync(0, _testMirror);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetFullSeriesByIdFailedNoLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetFullSeriesByIdAsync(83462, string.Empty, _testMirror);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetFullSeriesByIdFailedNoMirrorAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetFullSeriesByIdAsync(83462, null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetFullSeriesByIdTestSuccessfulWithDefaultLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetFullSeriesByIdAsync(83462, _testMirror);

            Assert.NotNull(result);
            Assert.NotNull(result.Series);

            var firstEpisode = result.Series.Episodes.First(x => x.SeasonNumber == 1 && x.Number == 1);

            // check details
            Assert.Equal("en", result.Language);

            Assert.NotNull(result.Actors);
            Assert.Equal(11, result.Actors.Count);

            Assert.NotNull(result.Banners);
            Assert.True(result.Banners.Count > 10);

            // check series
            Assert.Equal(83462, result.Series.Id);
            Assert.Equal("Castle (2009)", result.Series.Name);
            Assert.Equal("en", result.Series.Language);

            // check episodes
            Assert.Equal(1, firstEpisode.SeasonNumber);
            Assert.Equal(1, firstEpisode.Number);
            Assert.Equal(398671, firstEpisode.Id);
            Assert.Equal("Flowers for Your Grave", firstEpisode.Name);
        }

        [Fact]
        public async Task GetFullSeriesByIdTestSuccessfulWithLanguageAsync()
        {
            var target = new WebInterface(ApiKey);
            var result = await target.GetFullSeriesByIdAsync(83462, "de", _testMirror);

            Assert.NotNull(result);
            Assert.NotNull(result.Series);

            Assert.Equal("de", result.Language);

            var firstEpisode = result.Series.Episodes.First(x => x.SeasonNumber == 1 && x.Number == 1);

            // check series
            Assert.Equal(83462, result.Series.Id);
            Assert.Equal("Castle", result.Series.Name);
            Assert.Equal("de", result.Series.Language);

            // check episodes
            Assert.Equal(1, firstEpisode.SeasonNumber);
            Assert.Equal(1, firstEpisode.Number);
            Assert.Equal(398671, firstEpisode.Id);
            Assert.Equal("Blumen für Dein Grab", firstEpisode.Name);
        }

        #endregion GetFullSeriesById tests
    }
}
