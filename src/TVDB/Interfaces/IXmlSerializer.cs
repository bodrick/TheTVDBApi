using System.Xml;

namespace TVDB.Interfaces
{
    /// <summary>
    /// Deserializes an object from the received XML.
    /// </summary>
    public interface IXmlSerializer
    {
        /// <summary>
        /// Deserializes the provided XML node.
        /// </summary>
		/// <param name="node">Node to deserialize.</param>
        void Deserialize(XmlNode? node);
    }
}
