// -----------------------------------------------------------------------
// <copyright company="Christoph van der Fecht - VDsoft">
// This code can be used in commercial, free and open source projects.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Xml;

namespace TVDB.Model
{
    /// <summary>
    /// An Actor.
    /// </summary>
    public class Actor : INotifyPropertyChanged, Interfaces.IXmlSerializer, IComparable<Actor>
    {
        /// <summary>
        /// Name of the <see cref="Id"/> property.
        /// </summary>
        private const string IdName = "Id";

        /// <summary>
        /// Name of the <see cref="ImagePath"/> property.
        /// </summary>
        private const string ImagePathName = "ImagePath";

        /// <summary>
        /// Name of the <see cref="Name"/> property.
        /// </summary>
        private const string NameName = "Name";

        /// <summary>
        /// Name of the <see cref="Role"/> property.
        /// </summary>
        private const string RoleName = "Role";

        /// <summary>
        /// Name of the <see cref="SortOrder"/> property.
        /// </summary>
        private const string SortOrderName = "SortOrder";

        /// <summary>
        /// Id of the actor.
        /// </summary>
        private int _id;

        /// <summary>
        /// Path of the actors image.
        /// </summary>
        private string _imagePath;

        /// <summary>
        /// Real name of the actor.
        /// </summary>
        private string _name;

        /// <summary>
        /// Role the actor is playing.
        /// </summary>
        private string _role;

        /// <summary>
        /// Number the actors are sorted.
        /// </summary>
        private int _sortOrder;

        /// <summary>
        /// Occurs when a property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
                RaisePropertyChanged(IdName);
            }
        }

        /// <summary>
        /// Gets or sets the path of the actors image.
        /// </summary>
        public string ImagePath
        {
            get => _imagePath;

            set
            {
                if (value == _imagePath)
                {
                    return;
                }

                _imagePath = value;
                RaisePropertyChanged(ImagePathName);
            }
        }

        /// <summary>
        /// Gets or sets the real name of the actor.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                if (value == _name)
                {
                    return;
                }

                _name = value;
                RaisePropertyChanged(NameName);
            }
        }

        /// <summary>
        /// Gets or sets the role the actor is playing.
        /// </summary>
        public string Role
        {
            get => _role;

            set
            {
                if (value == _role)
                {
                    return;
                }

                _role = value;
                RaisePropertyChanged(RoleName);
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
                RaisePropertyChanged(SortOrderName);
            }
        }

        /// <summary>
        /// Compares the <see cref="SortOrder"/> property of the provided actor and this.
        /// </summary>
        /// <param name="other">Actor to compare.</param>
        /// <returns>Sort indicator.</returns>
        public int CompareTo(Actor other)
        {
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
        public void Deserialize(XmlNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Provided node must not be null.");
            }

            foreach (XmlNode currentNode in node.ChildNodes)
            {
                switch (currentNode.Name)
                {
                    case "id":
                    {
                        int.TryParse(currentNode.InnerText, out var result);
                        Id = result;
                        continue;
                    }
                    case "Image":
                    {
                        if (!string.IsNullOrEmpty(currentNode.InnerText))
                        {
                            ImagePath = currentNode.InnerText;
                        }
                        continue;
                    }
                    case "Name":
                    {
                        if (!string.IsNullOrEmpty(currentNode.InnerText))
                        {
                            Name = currentNode.InnerText;
                        }
                        continue;
                    }
                    case "Role":
                    {
                        if (!string.IsNullOrEmpty(currentNode.InnerText))
                        {
                            Role = currentNode.InnerText;
                        }
                        continue;
                    }
                    case "SortOrder":
                    {
                        int.TryParse(currentNode.InnerText, out var result);
                        SortOrder = result;
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Name of the property that changed its value.</param>
        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
