using System;
using TVDB.Model;
using Xunit;

namespace TVDB.Test.Model
{
    public class MirrorTest
    {
        #region Constructor tests

        [Fact]
        public void BaseConstructorTest()
        {
            var target = new Mirror();

            Assert.Equal(0, target.Id);
            Assert.True(string.IsNullOrEmpty(target.Address));
            Assert.False(target.ContainsBannerFile);
            Assert.False(target.ContainsXmlFile);
            Assert.False(target.ContainsZipFile);
        }

        #endregion Constructor tests

        #region ConvertTypeMaskTests

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue0()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 0;
            method?.Invoke(target, new object[] { typeMask });

            Assert.False(target.ContainsBannerFile);
            Assert.False(target.ContainsXmlFile);
            Assert.False(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue1()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 1;
            method?.Invoke(target, new object[] { typeMask });

            Assert.False(target.ContainsBannerFile);
            Assert.True(target.ContainsXmlFile);
            Assert.False(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue2()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 2;
            method?.Invoke(target, new object[] { typeMask });

            Assert.True(target.ContainsBannerFile);
            Assert.False(target.ContainsXmlFile);
            Assert.False(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue3()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 3;
            method?.Invoke(target, new object[] { typeMask });

            Assert.True(target.ContainsBannerFile);
            Assert.True(target.ContainsXmlFile);
            Assert.False(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue4()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 4;
            method?.Invoke(target, new object[] { typeMask });

            Assert.False(target.ContainsBannerFile);
            Assert.False(target.ContainsXmlFile);
            Assert.True(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue5()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 5;
            method?.Invoke(target, new object[] { typeMask });

            Assert.False(target.ContainsBannerFile);
            Assert.True(target.ContainsXmlFile);
            Assert.True(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue6()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 6;
            method?.Invoke(target, new object[] { typeMask });

            Assert.True(target.ContainsBannerFile);
            Assert.False(target.ContainsXmlFile);
            Assert.True(target.ContainsZipFile);
        }

        [Fact]
        public void ConvertTypeMaskTestSuccessfulValue7()
        {
            var target = new Mirror();
            var targetType = typeof(Mirror);

            var method = targetType.GetMethod("ConvertTypeMask", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var typeMask = 7;
            method?.Invoke(target, new object[] { typeMask });

            Assert.True(target.ContainsBannerFile);
            Assert.True(target.ContainsXmlFile);
            Assert.True(target.ContainsZipFile);
        }

        #endregion ConvertTypeMaskTests

        #region Deserialize test

        [Fact]
        public void DeserializeTestSuccessfulNoNode()
        {
            var target = new Mirror();

            var expected = new ArgumentNullException("node", "Provided node must not be null.");
            var actual = Assert.Throws<ArgumentNullException>(() => target.Deserialize(null));

            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void DeserializeTestSuccessful()
        {
            const string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Mirrors><Mirror><id>1</id><mirrorpath>http://thetvdb.com</mirrorpath><typemask>7</typemask></Mirror></Mirrors>";

            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xmlContent);

            var dataNode = doc.ChildNodes[1];
            var mirrorNode = dataNode.ChildNodes[0];

            var target = new Mirror();
            target.Deserialize(mirrorNode);

            var expectedID = 1;
            var expectedAddress = "http://thetvdb.com";

            Assert.Equal(expectedID, target.Id);
            Assert.Equal(expectedAddress, target.Address);
            Assert.True(target.ContainsBannerFile);
            Assert.True(target.ContainsXmlFile);
            Assert.True(target.ContainsZipFile);
        }

        #endregion Deserialize test
    }
}
