using System;
using System.Xml;
using TVDB.Model;
using Xunit;

namespace TVDB.Test.Model
{
    public class ActorTest
    {
        [Fact]
        public void DeserializeTestFailedNoNode()
        {
            var target = new Actor();
            var expected = new ArgumentNullException("node", "Provided node must not be null.");
            var actual = Assert.Throws<ArgumentNullException>(() => target.Deserialize(null));

            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void DeserializeTestSuccessful()
        {
            const string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Actors><Actor><id>79415</id><Image>actors/79415.jpg</Image><Name>Nathan Fillion</Name><Role>Richard Castle</Role><SortOrder>0</SortOrder></Actor></Actors>";

            var doc = new XmlDocument();
            using var sreader = new System.IO.StringReader(xmlContent);
            using var reader = XmlReader.Create(sreader, new XmlReaderSettings { XmlResolver = null });
            doc.Load(reader);

            var actorsNode = doc.ChildNodes[1];
            Assert.NotNull(actorsNode);
            var actorNode = actorsNode.ChildNodes[0];
            var target = new Actor();
            target.Deserialize(actorNode);

            Assert.Equal(79415, target.Id);
            Assert.Equal("actors/79415.jpg", target.ImagePath);
            Assert.Equal("Nathan Fillion", target.Name);
            Assert.Equal("Richard Castle", target.Role);
            Assert.Equal(0, target.SortOrder);
        }
    }
}
