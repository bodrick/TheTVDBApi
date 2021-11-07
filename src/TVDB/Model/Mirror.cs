// -----------------------------------------------------------------------
// <copyright company="Christoph van der Fecht - VDsoft">
// This code can be used in commercial, free and open source projects.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace TVDB.Model
{
    /// <summary>
    /// A mirror to load the data.
    /// </summary>
    public class Mirror : INotifyPropertyChanged, Interfaces.IXmlSerializer, IComparable<Mirror>
    {
        /// <summary>
        /// Name of the <see cref="Address"/> property.
        /// </summary>
        private const string AddressName = "Address";

        /// <summary>
        /// Name of the <see cref="ContainsBannerFile"/> property.
        /// </summary>
        private const string ContainsBannerFileName = "ContainsBannerFile";

        /// <summary>
        /// Name of the <see cref="ContainsXmlFile"/> property.
        /// </summary>
        private const string ContainsXmlFileName = "ContainsXmlFile";

        /// <summary>
        /// Name of the <see cref="ContainsZipFile"/> property.
        /// </summary>
        private const string ContainsZipFileName = "ContainsZipFile";

        /// <summary>
        /// Name of the <see cref="Id"/> property.
        /// </summary>
        private const string IdName = "Id";

        /// <summary>
        /// Address of the mirror.
        /// </summary>
        private string _address;

        /// <summary>
        /// Value indicating whether the mirror provides banner file.
        /// </summary>
        private bool _containsBannerFile;

        /// <summary>
        /// Value indicating whether the mirror provides xml files.
        /// </summary>
        private bool _containsXmlFile;

        /// <summary>
        /// Value indicating whether the mirror provides zip file.
        /// </summary>
        private bool _containsZipFile;

        /// <summary>
        /// Id of the mirror.
        /// </summary>
        private int _id;

        /// <summary>
        /// Occurs when a property changed its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the address of the mirror.
        /// </summary>
        public string Address
        {
            get => _address;

            set
            {
                if (value == _address)
                {
                    return;
                }

                _address = value;
                RaisePropertyChanged(AddressName);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the mirror provides banner file.
        /// </summary>
        public bool ContainsBannerFile
        {
            get => _containsBannerFile;

            set
            {
                if (value == _containsBannerFile)
                {
                    return;
                }

                _containsBannerFile = value;
                RaisePropertyChanged(ContainsBannerFileName);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the mirror provides xml files.
        /// </summary>
        public bool ContainsXmlFile
        {
            get => _containsXmlFile;

            set
            {
                if (value == _containsXmlFile)
                {
                    return;
                }

                _containsXmlFile = value;
                RaisePropertyChanged(ContainsXmlFileName);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the mirror provides zip file.
        /// </summary>
        public bool ContainsZipFile
        {
            get => _containsZipFile;

            set
            {
                if (value == _containsZipFile)
                {
                    return;
                }

                _containsZipFile = value;
                RaisePropertyChanged(ContainsZipFileName);
            }
        }

        /// <summary>
        /// Gets or sets the id of the mirror.
        /// </summary>
        public int Id
        {
            get => _id;

            set
            {
                if (value == _id)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IdName);
            }
        }

        /// <summary>
        /// Compares the <see cref="Id"/> of the provided Mirror with this one.
        /// </summary>
        /// <param name="other">Mirror object to compare.</param>
        /// <returns>
        /// 0: Ids are equal.
        /// -1: Provided id is smaller than this one.
        /// 1: Provided id is greater than this one.
        /// </returns>
        public int CompareTo(Mirror other)
        {
            if (other.Id.Equals(Id))
            {
                return 0;
            }

            if (other.Id > Id)
            {
                return 1;
            }
            if (other.Id < Id)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Deserializes the provided xml node.
        /// </summary>
        /// <param name="node">Node to deserialize.</param>
		/// <exception cref="ArgumentNullException">Occurs when the provided <see cref="System.Xml.XmlNode"/> is null.</exception>
		/// <example>This example shows how to use the deserialize method.
		/// <code>
		/// namespace Docunamespace
		/// {
		/// 	/// <summary>
		/// 	/// Class for the docu.
		/// 	/// </summary>
		/// 	class DocuClass
		/// 	{
		/// 		/// <summary>
		/// 		/// Xml document that contains all banners.
		/// 		/// </summary>
		/// 		private XmlDocument mirrorDoc = null;
		///
		/// 		/// <summary>
		/// 		/// Initializes a new instance of the DocuClass class.
		/// 		/// </summary>
		/// 		public DocuClass(string extractionPath)
		/// 		{
		/// 			// load actors xml.
		/// 			this.mirrorDoc = new XmlDocument();
		/// 			this.mirrorDoc.Load(System.IO.Path.Combine(this.extractionPath, "mirrors.xml"));
		/// 		}
		///
		/// 		/// <summary>
		/// 		/// Deserializes all mirrors that are available.
		/// 		/// </summary>
		/// 		public List&#60;Mirror&#62; DeserializeMirrors()
		/// 		{
		/// 			List&#60;Mirror&#62; mirrors = new List&#60;Mirror&#62;();
		///
		/// 			// load the xml docs second child.
		/// 			XmlNode mirrorNode = this.mirrorDoc.ChildNodes[1];
		///
		/// 			// deserialize all mirrors.
		/// 			foreach (XmlNode currentNode in mirrorNode.ChildNodes)
		/// 			{
		/// 				Mirror deserialized = new Mirror();
		/// 				deserialized.Deserialize(currentNode);
		///
		/// 				if (this.defaultMirror == null)
		/// 				{
		/// 					if (deserialized.ContainsBannerFile &#38;&#38;
		/// 						deserialized.ContainsXmlFile &#38;&#38;
		/// 						deserialized.ContainsZipFile)
		/// 					{
		/// 						this.defaultMirror = deserialized;
		/// 					}
		/// 				}
		///
		/// 				receivedMirrors.Add(deserialized);
		/// 			}
		/// 		}
		/// 	}
		/// }
		/// </code>
		/// </example>
        public void Deserialize(System.Xml.XmlNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Provided node must not be null.");
            }

            foreach (System.Xml.XmlNode currentNode in node.ChildNodes)
            {
                if (currentNode.Name.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    Id = result;
                    continue;
                }

                if (currentNode.Name.Equals("mirrorpath", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Address = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("typemask", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    ConvertTypeMask(result);
                    continue;
                }
            }
        }

        /// <summary>
        /// Converts the provided typemask into the bool values.
        /// </summary>
        /// <param name="typemask">Typemask value to convert.</param>
        private void ConvertTypeMask(int typemask)
        {
            ContainsXmlFile = ((typemask >> 0) & 1) == 1;
            ContainsBannerFile = ((typemask >> 1) & 1) == 1;
            ContainsZipFile = ((typemask >> 2) & 1) == 1;
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Name fo the property which changed its value.</param>
        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
