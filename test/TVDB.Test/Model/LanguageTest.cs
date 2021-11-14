using System;
using TVDB.Model;
using Xunit;

namespace TVDB.Test.Model
{
    public class LanguageTest
    {
        #region Constructor tests

        [Fact]
        public void DefaultConstructorTestSuccessful()
        {
            var target = new Language();

            Assert.Equal(0, target.Id);
            Assert.True(string.IsNullOrEmpty(target.Name));
            Assert.True(string.IsNullOrEmpty(target.Abbreviation));
        }

        #endregion Constructor tests

        #region Deserialize tests

        [Fact]
        public void DeserializeTestFailedNoNode()
        {
            var target = new Language();

            var expected = new ArgumentNullException("node", "Provided node must not be null or empty");
            var actual = Assert.Throws<ArgumentNullException>(() => target.Deserialize(null));

            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void DeserializeTestSuccessful()
        {
            const string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Languages><Language><name>Dansk</name><abbreviation>da</abbreviation><id>10</id></Language></Languages>";

            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xmlContent);

            var dataNode = doc.ChildNodes[1];
            Assert.NotNull(dataNode);
            var languageNode = dataNode.ChildNodes[0];

            var target = new Language();
            target.Deserialize(languageNode);

            const int expectedId = 10;
            const string expectedName = "Dansk";
            const string expectedAbbreviation = "da";

            Assert.Equal(expectedId, target.Id);
            Assert.Equal(expectedName, target.Name);
            Assert.Equal(expectedAbbreviation, target.Abbreviation);
        }

        #endregion Deserialize tests
    }
}
