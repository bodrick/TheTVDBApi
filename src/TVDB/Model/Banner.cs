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
    /// Types of a banner
    /// </summary>
    public enum BannerTyp
    {
        /// <summary>
        /// A Fanart.
        /// </summary>
        Fanart,

        /// <summary>
        /// Original poster.
        /// </summary>
        Poster,

        /// <summary>
        /// Season image.
        /// </summary>
        Season,

        /// <summary>
        /// Series image.
        /// </summary>
        Series,

        /// <summary>
        /// Default value.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Image of a series.
    /// </summary>
    public class Banner : INotifyPropertyChanged, Interfaces.IXmlSerializer
    {
        /// <summary>
        /// Name of the <see cref="BannerPath"/> property.
        /// </summary>
        private const string BannerPathName = "BannerPath";

        /// <summary>
        /// Name of the <see cref="Color"/> property.
        /// </summary>
        private const string ColorName = "Color";

        /// <summary>
        /// Name of the <see cref="Dimension"/> property.
        /// </summary>
        private const string DimensionName = "Dimension";

        /// <summary>
        /// Name of the <see cref="Id"/> property.
        /// </summary>
        private const string IdName = "Id";

        /// <summary>
        /// Name of the <see cref="Language"/> property.
        /// </summary>
        private const string LanguageName = "Language";

        /// <summary>
        /// Name of the <see cref="RatingCount"/> property.
        /// </summary>
        private const string RatingCountName = "RatingCount";

        /// <summary>
        /// Name of the <see cref="Rating"/> property.
        /// </summary>
        private const string RatingName = "Rating";

        /// <summary>
        /// Name of the <see cref="Season"/> property.
        /// </summary>
        private const string SeasonName = "Season";

        /// <summary>
        /// Name of the <see cref="SeriesName"/> property.
        /// </summary>
        private const string SeriesNameName = "SeriesName";

        /// <summary>
        /// Name of the <see cref="ThumbnailPath"/> property.
        /// </summary>
        private const string ThumbnailPathName = "ThumbnailPath";

        /// <summary>
        /// Name of the <see cref="Type"/> property.
        /// </summary>
        private const string TypeName = "Type";

        /// <summary>
        /// Name of the <see cref="VignettePath"/> property.
        /// </summary>
        private const string VignettePathName = "VignettePath";

        /// <summary>
        /// Path of the image.
        /// </summary>
        private string _bannerPath;

        /// <summary>
        /// Colors of the banner.
        /// </summary>
        private string _colors;

        /// <summary>
        /// Dimension of the image.
        /// </summary>
        private string _dimension;

        /// <summary>
        /// Id of the banner.
        /// </summary>
        private int _id = -1;

        /// <summary>
        /// Language of the banner image.
        /// </summary>
        private string _language;

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
        private string _thumbnailPath;

        /// <summary>
        /// Type of the banner.
        /// </summary>
        private BannerTyp _type = BannerTyp.Unknown;

        /// <summary>
        /// Path to the vignette image.
        /// </summary>
        private string _vignettePath;

        /// <summary>
        /// Occurs when a property changed its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the Path of the image.
        /// </summary>
        public string BannerPath
        {
            get => _bannerPath;

            set
            {
                if (value == _bannerPath)
                {
                    return;
                }

                _bannerPath = value;
                RaisePropertyChanged(BannerPathName);
            }
        }

        /// <summary>
        /// Gets or sets the Colors of the banner.
        /// </summary>
        public string Color
        {
            get => _colors;

            set
            {
                if (value == _colors)
                {
                    return;
                }

                _colors = value;
                RaisePropertyChanged(ColorName);
            }
        }

        /// <summary>
        /// Gets or sets the Dimension of the image.
        /// </summary>
        public string Dimension
        {
            get => _dimension;

            set
            {
                if (value == _dimension)
                {
                    return;
                }

                _dimension = value;
                RaisePropertyChanged(DimensionName);
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
                RaisePropertyChanged(IdName);
            }
        }

        /// <summary>
        /// Gets or sets the Language of the banner image.
        /// </summary>
        public string Language
        {
            get => _language;

            set
            {
                if (value == _language)
                {
                    return;
                }

                _language = value;
                RaisePropertyChanged(LanguageName);
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
                RaisePropertyChanged(RatingName);
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
                RaisePropertyChanged(RatingCountName);
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
                RaisePropertyChanged(SeasonName);
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
                RaisePropertyChanged(SeriesNameName);
            }
        }

        /// <summary>
        /// Gets or sets the Path to the thumbnail of the image.
        /// </summary>
        public string ThumbnailPath
        {
            get => _thumbnailPath;

            set
            {
                if (value == _thumbnailPath)
                {
                    return;
                }

                _thumbnailPath = value;
                RaisePropertyChanged(ThumbnailPathName);
            }
        }

        /// <summary>
        /// Gets or sets the Type of the banner.
        /// </summary>
        public BannerTyp Type
        {
            get => _type;

            set
            {
                if (value == _type)
                {
                    return;
                }

                _type = value;
                RaisePropertyChanged(TypeName);
            }
        }

        /// <summary>
        /// Gets or sets the Path to the vignette image.
        /// </summary>
        public string VignettePath
        {
            get => _vignettePath;

            set
            {
                if (value == _vignettePath)
                {
                    return;
                }

                _vignettePath = value;
                RaisePropertyChanged(VignettePathName);
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
        public void Deserialize(XmlNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Provided node must not be null.");
            }

            var cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            foreach (XmlNode currentNode in node.ChildNodes)
            {
                if (currentNode.Name.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    Id = result;
                    continue;
                }

                if (currentNode.Name.Equals("BannerPath", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        BannerPath = currentNode.InnerText;
                    }
                    continue;
                }

                if (currentNode.Name.Equals("BannerType", StringComparison.OrdinalIgnoreCase))
                {
                    Enum.TryParse(currentNode.InnerText, out BannerTyp currentTyp);
                    Type = currentTyp;
                    continue;
                }
                if (currentNode.Name.Equals("BannerType2", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Dimension = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("Colors", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Color = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("Language", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Language = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("Rating", StringComparison.OrdinalIgnoreCase))
                {
                    double.TryParse(currentNode.InnerText, System.Globalization.NumberStyles.Number, cultureInfo, out var result);
                    Rating = result;
                    continue;
                }
                if (currentNode.Name.Equals("RatingCount", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    RatingCount = result;
                    continue;
                }
                if (currentNode.Name.Equals("SeriesName", StringComparison.OrdinalIgnoreCase))
                {
                    bool.TryParse(currentNode.InnerText, out var result);
                    SeriesName = result;
                    continue;
                }
                if (currentNode.Name.Equals("ThumbnailPath", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        ThumbnailPath = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("VignettePath", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        VignettePath = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("Season", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    Season = result;
                    continue;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Name fo the property that changed its value.</param>
        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
