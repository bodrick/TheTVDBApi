using System;
using TVDB.Model;
using Xunit;

namespace TVDB.Test.Model
{
    public class SeriesDetailsTest
    {
        /// <summary>
        /// Path of the extracted test data.
        /// </summary>
        private const string TestExtractionPath = @"..\..\..\TVDB.Test\TestData\Extracted\";

        #region Constructor tests

        [Fact]
        public void ConstructorTestFailedDirectoryDoesNotExist()
        {
            const string fakePath = @"C:\Some\Director\";

            var expected = new System.IO.DirectoryNotFoundException($"The directory \"{fakePath}\" could not be found.");
            var actual = Assert.Throws<System.IO.DirectoryNotFoundException>(() => new SeriesDetails(fakePath, "en"));

            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void ConstructorTestFailedNoLanguage()
        {
            var expected = new ArgumentNullException("language", "Provided language must not be null or empty.");
            var actual = Assert.Throws<ArgumentNullException>(() => new SeriesDetails(TestExtractionPath, string.Empty));

            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void ConstructorTestSuccessful()
        {
            var target = new SeriesDetails(TestExtractionPath, "en");

            Assert.Equal("en", target.Language);
            Assert.NotNull(target.Actors);
            Assert.NotNull(target.Banners);
            Assert.NotNull(target.Series);
        }

        #endregion Constructor tests

        #region Deserialize tests

        [Fact]
        public void DeserializeActorsTest()
        {
            var target = new SeriesDetails(TestExtractionPath, "en");
            var targetType = typeof(SeriesDetails);
            var method = targetType.GetMethod("DeserializeActors", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            method?.Invoke(target, Array.Empty<object>());

            Assert.NotNull(target.Actors);
            Assert.Equal(9, target.Actors.Count);
        }

        [Fact]
        public void DeserializeBannersTest()
        {
            var target = new SeriesDetails(TestExtractionPath, "en");
            var targetType = typeof(SeriesDetails);
            var method = targetType.GetMethod("DeserializeBanners", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            method?.Invoke(target, Array.Empty<object>());

            Assert.NotNull(target.Banners);
            Assert.Equal(125, target.Banners.Count);
        }

        [Fact]
        public void DeserializeSeriesTest()
        {
            var target = new SeriesDetails(TestExtractionPath, "en");
            var targetType = typeof(SeriesDetails);
            var method = targetType.GetMethod("DeserializeSeries", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            method?.Invoke(target, Array.Empty<object>());

            Assert.NotNull(target.Series);
            Assert.Equal(83462, target.Series.Id);
            Assert.Equal("Castle (2009)", target.Series.Name);
            Assert.Equal(121, target.Series.Episodes.Count);
        }

        #endregion Deserialize tests

        #region Dispose tests

        [Fact]
        public void DisposeTestSuccessful()
        {
            var target = new SeriesDetails(TestExtractionPath, "en");

            var dummyCall = target.Actors;
            dummyCall = null;

            target.Dispose();

            Assert.Null(target.Language);
            Assert.Null(target.Actors);
            Assert.Null(target.Banners);
            Assert.Null(target.Series);
        }

        #endregion Dispose tests
    }
}
