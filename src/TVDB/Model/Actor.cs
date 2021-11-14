using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TVDB.Model
{
    /// <summary>
    /// An Actor.
    /// </summary>
    public class Actor : INotifyPropertyChanged, Interfaces.IXmlSerializer, IComparable<Actor>
    {
        /// <summary>
        /// Id of the actor.
        /// </summary>
        private int _id;

        /// <summary>
        /// Path of the actors image.
        /// </summary>
        private string? _imagePath;

        /// <summary>
        /// Real name of the actor.
        /// </summary>
        private string? _name;

        /// <summary>
        /// Role the actor is playing.
        /// </summary>
        private string? _role;

        /// <summary>
        /// Number the actors are sorted.
        /// </summary>
        private int _sortOrder;

        /// <summary>
        /// Occurs when a property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets the id of the actor.
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
        /// Gets or sets the path of the actors image.
        /// </summary>
        public string? ImagePath
        {
            get => _imagePath;

            set
            {
                if (string.Equals(value, _imagePath, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _imagePath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the real name of the actor.
        /// </summary>
        public string? Name
        {
            get => _name;

            set
            {
                if (string.Equals(value, _name, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the role the actor is playing.
        /// </summary>
        public string? Role
        {
            get => _role;

            set
            {
                if (string.Equals(value, _role, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _role = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the number the actors are sorted.
        /// </summary>
        public int SortOrder
        {
            get => _sortOrder;

            set
            {
                if (value == _sortOrder)
                {
                    return;
                }

                _sortOrder = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Compares the <see cref="SortOrder"/> property of the provided actor and this.
        /// </summary>
        /// <param name="other">Actor to compare.</param>
        /// <returns>Sort indicator.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <c>null</c>.</exception>
        public int CompareTo(Actor other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (other.SortOrder < SortOrder)
            {
                return -1;
            }

            if (other.SortOrder > SortOrder)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Deserializes the provided xml node.
        /// </summary>
        /// <param name="node">Node to deserialize.</param>
		/// <exception cref="ArgumentNullException">Occurs when the provided <see cref="XmlNode"/> is null.</exception>
		/// <example> This example shows how to use the deserialize method.
		/// <code>
		/// namespace Docunamespace
		/// {
		/// 	/// <summary>
		/// 	/// Class for the docu.
		/// 	/// </summary>
		/// 	class DocuClass
		/// 	{
		/// 		/// <summary>
		/// 		/// Xml document that contains all actors.
		/// 		/// </summary>
		/// 		private XmlDocument actorsDoc = null;
		///
		/// 		/// <summary>
		/// 		/// Initializes a new instance of the DocuClass class.
		/// 		/// </summary>
		/// 		public DocuClass(string extractionPath)
		/// 		{
		/// 			// load actors xml.
		/// 			this.actorsDoc = new XmlDocument();
		/// 			this.actorsDoc.Load(System.IO.Path.Combine(this.extractionPath, "actors.xml"));
		/// 		}
		///
		/// 		/// <summary>
		/// 		/// Deserializes all actors of the series.
		/// 		/// </summary>
		/// 		public List&#60;Actor&#62; DeserializeActors()
		/// 		{
		/// 			List&#60;Actor&#62; actors = new List&#60;Actor&#62;();
		///
		/// 			// load the xml docs second child.
		/// 			XmlNode actorsNode = this.actorsDoc.ChildNodes[1];
		///
		/// 			// deserialize all actors.
		/// 			foreach (XmlNode currentNode in actorsNode)
		/// 			{
		/// 				if (currentNode.Name.Equals("Actor", StringComparison.OrdinalIgnoreCase))
		/// 				{
		/// 					Actor deserializes = new Actor();
		/// 					deserializes.Deserialize(currentNode);
		///
		/// 					actors.Add(deserializes);
		/// 				}
		/// 			}
		/// 		}
		/// 	}
		/// }
		/// </code>
		/// </example>
        public void Deserialize(XmlNode? node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Provided node must not be null.");
            }

            foreach (XmlNode currentNode in node.ChildNodes)
            {
                switch (currentNode.Name)
                {
                    case "id" when int.TryParse(currentNode.InnerText, out var result):
                        Id = result;
                        break;

                    case "Image" when !string.IsNullOrEmpty(currentNode.InnerText):
                        ImagePath = currentNode.InnerText;
                        break;

                    case "Name" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Name = currentNode.InnerText;
                        break;

                    case "Role" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Role = currentNode.InnerText;
                        break;

                    case "SortOrder" when int.TryParse(currentNode.InnerText, out var result):
                        SortOrder = result;
                        break;
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
