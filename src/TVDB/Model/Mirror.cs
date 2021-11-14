using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace TVDB.Model
{
    /// <summary>
    /// A mirror to load the data.
    /// </summary>
    public class Mirror : INotifyPropertyChanged, Interfaces.IXmlSerializer, IComparable<Mirror>
    {
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
                if (string.Equals(value, _address, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _address = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <c>null</c>.</exception>
        public int CompareTo([NotNull] Mirror other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

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
                if (currentNode.Name.Equals("id", StringComparison.OrdinalIgnoreCase) && int.TryParse(currentNode.InnerText, out var id))
                {
                    Id = id;
                }
                else if (currentNode.Name.Equals("mirrorpath", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(currentNode.InnerText))
                {
                    Address = currentNode.InnerText;
                }
                else if (currentNode.Name.Equals("typemask", StringComparison.OrdinalIgnoreCase) && int.TryParse(currentNode.InnerText, out var typeMask))
                {
                    ConvertTypeMask(typeMask);
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        /// <summary>
        /// Converts the provided typeMask into the bool values.
        /// </summary>
        /// <param name="typeMask">typeMask value to convert.</param>
        private void ConvertTypeMask(int typeMask)
        {
            ContainsXmlFile = ((typeMask >> 0) & 1) == 1;
            ContainsBannerFile = ((typeMask >> 1) & 1) == 1;
            ContainsZipFile = ((typeMask >> 2) & 1) == 1;
        }
    }
}
