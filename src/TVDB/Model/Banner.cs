using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TVDB.Model
{
    /// <summary>
    /// Types of a banner
    /// </summary>
    public enum BannerType
    {
        /// <summary>
        /// A Fanart.
        /// </summary>
        Fanart = 0,

        /// <summary>
        /// Original poster.
        /// </summary>
        Poster = 1,

        /// <summary>
        /// Season image.
        /// </summary>
        Season = 2,

        /// <summary>
        /// Series image.
        /// </summary>
        Series = 3,

        /// <summary>
        /// Default value.
        /// </summary>
        Unknown = 4
    }

    /// <summary>
    /// Image of a series.
    /// </summary>
    public class Banner : INotifyPropertyChanged, Interfaces.IXmlSerializer
    {
        /// <summary>
        /// Path of the image.
        /// </summary>
        private string? _bannerPath;

        /// <summary>
        /// Colors of the banner.
        /// </summary>
        private string? _colors;

        /// <summary>
        /// Dimension of the image.
        /// </summary>
        private string? _dimension;

        /// <summary>
        /// Id of the banner.
        /// </summary>
        private int _id = -1;

        /// <summary>
        /// Language of the banner image.
        /// </summary>
        private string? _language;

        /// <summary>
        /// Rating fo the banner.
        /// </summary>
        private double _rating = -1.0;

        /// <summary>
        /// Number of ratings.
        /// </summary>
        private int _ratingCount = -1;

        /// <summary>
        /// The season of the banner.
        /// </summary>
        private int _season = -1;

        /// <summary>
        /// Series name.
        /// </summary>
        private bool _seriesName;

        /// <summary>
        /// Path to the thumbnail of the image.
        /// </summary>
        private string? _thumbnailPath;

        /// <summary>
        /// Type of the banner.
        /// </summary>
        private BannerType _type = BannerType.Unknown;

        /// <summary>
        /// Path to the vignette image.
        /// </summary>
        private string? _vignettePath;

        /// <summary>
        /// Occurs when a property changed its value
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets the Path of the image.
        /// </summary>
        public string? BannerPath
        {
            get => _bannerPath;

            set
            {
                if (string.Equals(value, _bannerPath, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _bannerPath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Colors of the banner.
        /// </summary>
        public string? Color
        {
            get => _colors;

            set
            {
                if (string.Equals(value, _colors, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _colors = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Dimension of the image.
        /// </summary>
        public string? Dimension
        {
            get => _dimension;

            set
            {
                if (string.Equals(value, _dimension, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _dimension = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Id of the banner.
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
        /// Gets or sets the Language of the banner image.
        /// </summary>
        public string? Language
        {
            get => _language;

            set
            {
                if (string.Equals(value, _language, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _language = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Rating fo the banner.
        /// </summary>
        public double Rating
        {
            get => _rating;

            set
            {
                if (value == _rating)
                {
                    return;
                }

                _rating = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Number of ratings.
        /// </summary>
        public int RatingCount
        {
            get => _ratingCount;

            set
            {
                if (value == _ratingCount)
                {
                    return;
                }

                _ratingCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the season.
        /// </summary>
        public int Season
        {
            get => _season;

            set
            {
                if (value == _season)
                {
                    return;
                }

                _season = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Series name.
        /// </summary>
        public bool SeriesName
        {
            get => _seriesName;

            set
            {
                if (value == _seriesName)
                {
                    return;
                }

                _seriesName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Path to the thumbnail of the image.
        /// </summary>
        public string? ThumbnailPath
        {
            get => _thumbnailPath;

            set
            {
                if (string.Equals(value, _thumbnailPath, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _thumbnailPath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Type of the banner.
        /// </summary>
        public BannerType Type
        {
            get => _type;

            set
            {
                if (value == _type)
                {
                    return;
                }

                _type = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Path to the vignette image.
        /// </summary>
        public string? VignettePath
        {
            get => _vignettePath;

            set
            {
                if (string.Equals(value, _vignettePath, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _vignettePath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Deserializes a banner xml node.
        /// </summary>
        /// <param name="node">Node to deserialize.</param>
        /// <exception cref="ArgumentNullException">Occurs when the provided <see cref="XmlNode"/> is null.</exception>
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
        /// 		private XmlDocument bannersDoc = null;
        ///
        /// 		/// <summary>
        /// 		/// Initializes a new instance of the DocuClass class.
        /// 		/// </summary>
        /// 		public DocuClass(string extractionPath)
        /// 		{
        /// 			// load actors xml.
        /// 			this.bannersDoc = new XmlDocument();
        /// 			this.bannersDoc.Load(System.IO.Path.Combine(this.extractionPath, "banners.xml"));
        /// 		}
        ///
        /// 		/// <summary>
        /// 		/// Deserializes all banners of the series.
        /// 		/// </summary>
        /// 		public List&#60;Banner&#62; DeserializeBanners()
        /// 		{
        /// 			List&#60;Banner&#62; banners = new List&#60;Banner&#62;();
        ///
        /// 			// load the xml docs second child.
        /// 			XmlNode bannersNode = this.bannersDoc.ChildNodes[1];
        ///
        /// 			// deserialize all banners.
        /// 			foreach (XmlNode currentNode in bannersNode.ChildNodes)
        /// 			{
        /// 				if (currentNode.Name.Equals("Banner", StringComparison.OrdinalIgnoreCase))
        /// 				{
        /// 					Banner deserialized = new Banner();
        /// 					deserialized.Deserialize(currentNode);
        ///
        /// 					banners.Add(deserialized);
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

                    case "BannerPath" when !string.IsNullOrEmpty(currentNode.InnerText):
                        BannerPath = currentNode.InnerText;
                        break;

                    case "BannerType" when Enum.TryParse(currentNode.InnerText, out BannerType bannerType):
                        Type = bannerType;
                        break;

                    case "BannerType2" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Dimension = currentNode.InnerText;
                        break;

                    case "Colors" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Color = currentNode.InnerText;
                        break;

                    case "Language" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Language = currentNode.InnerText;
                        break;

                    case "Rating" when double.TryParse(currentNode.InnerText, out var result):
                        Rating = result;
                        break;

                    case "RatingCount" when int.TryParse(currentNode.InnerText, out var result):
                        RatingCount = result;
                        break;

                    case "SeriesName" when bool.TryParse(currentNode.InnerText, out var result):
                        SeriesName = result;
                        break;

                    case "ThumbnailPath" when !string.IsNullOrEmpty(currentNode.InnerText):
                        ThumbnailPath = currentNode.InnerText;
                        break;

                    case "VignettePath" when !string.IsNullOrEmpty(currentNode.InnerText):
                        VignettePath = currentNode.InnerText;
                        break;

                    case "Season" when int.TryParse(currentNode.InnerText, out var result):
                        Season = result;
                        break;
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
