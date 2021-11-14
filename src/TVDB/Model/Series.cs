using System;
using System.Collections.ObjectModel;
using System.Xml;

namespace TVDB.Model
{
    /// <summary>
    /// A Series with all details and episodes.
    /// </summary>
    public class Series : SeriesElement, Interfaces.IXmlSerializer
    {
        /// <summary>
        /// All actors of the series.
        /// </summary>
        private string? _actors;

        /// <summary>
        /// Collection of the actors of the series.
        /// </summary>
        private ObservableCollection<Actor> _actorsCollection = new ObservableCollection<Actor>();

        /// <summary>
        /// Id of the user who added the series.
        /// </summary>
        private int _addedByUserId = -1;

        /// <summary>
        /// Date the series was added to the system.
        /// </summary>
        private DateTime _addedDate = DateTime.MinValue;

        /// <summary>
        /// Day the series is aired.
        /// </summary>
        private string? _airsDayOfWeek;

        /// <summary>
        /// Time the series is aired.
        /// </summary>
        private string? _airsTime;

        /// <summary>
        /// Path of the banner for the series.
        /// </summary>
        private string? _bannerPath;

        /// <summary>
        /// The content rating of the series.
        /// </summary>
        private string? _contentRating;

        /// <summary>
        /// Collection of all assigned episodes.
        /// </summary>
        private ObservableCollection<Episode> _episodes = new ObservableCollection<Episode>();

        /// <summary>
        /// Path of the fan art.
        /// </summary>
        private string? _fanArt;

        /// <summary>
        /// The genre of the series.
        /// </summary>
        private string? _genre;

        /// <summary>
        /// Value indicating whether the series has episodes assigned or not.
        /// </summary>
        private bool _hasEpisodes;

        /// <summary>
        /// Last updated id.
        /// </summary>
        private long _lastUpdated = -1;

        /// <summary>
        /// The network name that airs the series.
        /// </summary>
        private string? _network;

        /// <summary>
        /// Id of the network.
        /// </summary>
        private int _networkId = -1;

        /// <summary>
        /// Path of the poster.
        /// </summary>
        private string? _poster;

        /// <summary>
        /// Rating fo the series.
        /// </summary>
        private double _rating = -1.0;

        /// <summary>
        /// Count of rates.
        /// </summary>
        private int _ratingCount = -1;

        /// <summary>
        /// Runtime of the series.
        /// </summary>
        private double _runtime = -1.0;

        /// <summary>
        /// Series ID.
        /// </summary>
        private int _seriesId = -1;

        /// <summary>
        /// Status of the series.
        /// </summary>
        private string? _status;

        /// <summary>
        /// Value indicating whether the tms is wanted for the series or not.
        /// </summary>
        private bool _tmsWanted;

        /// <summary>
        /// Zap2It id of the series.
        /// </summary>
        private string? _zap2ItId;

        /// <summary>
        /// Gets or sets a collection of the actors of the series.
        /// </summary>
        public ObservableCollection<Actor> ActorCollection
        {
            get => _actorsCollection;

            set
            {
                if (value == _actorsCollection)
                {
                    return;
                }

                _actorsCollection = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets all actors of the series.
        /// </summary>
        public string? Actors
        {
            get => _actors;

            set
            {
                if (string.Equals(value, _actors, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _actors = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the user who added the series.
        /// </summary>
        public int AddedByUserId
        {
            get => _addedByUserId;

            set
            {
                if (value == _addedByUserId)
                {
                    return;
                }

                _addedByUserId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date the series was added to the system.
        /// </summary>
        public DateTime AddedDate
        {
            get => _addedDate;

            set
            {
                if (value == _addedDate)
                {
                    return;
                }

                _addedDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the day the series is aired.
        /// </summary>
        public string? AirsDayOfWeek
        {
            get => _airsDayOfWeek;

            set
            {
                if (string.Equals(value, _airsDayOfWeek, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _airsDayOfWeek = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the time the series is aired.
        /// </summary>
        public string? AirsTime
        {
            get => _airsTime;

            set
            {
                if (string.Equals(value, _airsTime, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _airsTime = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the path of the banner for the series.
        /// </summary>
        public string? Banner
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
        /// Gets or sets the content rating of the series.
        /// </summary>
        public string? ContentRating
        {
            get => _contentRating;

            set
            {
                if (string.Equals(value, _contentRating, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _contentRating = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a collection of all assigned episodes.
        /// </summary>
        public ObservableCollection<Episode> Episodes
        {
            get => _episodes;

            set
            {
                if (value == _episodes)
                {
                    return;
                }

                _episodes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the path of the fan art.
        /// </summary>
        public string? FanArt
        {
            get => _fanArt;

            set
            {
                if (string.Equals(value, _fanArt, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _fanArt = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the genre of the series.
        /// </summary>
        public string? Genre
        {
            get => _genre;

            set
            {
                if (string.Equals(value, _genre, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _genre = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the series has episodes assigned or not.
        /// </summary>
        public bool HasEpisodes
        {
            get => _hasEpisodes;

            set
            {
                if (value == _hasEpisodes)
                {
                    return;
                }

                _hasEpisodes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the last updated id.
        /// </summary>
        public long LastUpdated
        {
            get => _lastUpdated;

            set
            {
                if (value == _lastUpdated)
                {
                    return;
                }

                _lastUpdated = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the network name that airs the series.
        /// </summary>
        public string? Network
        {
            get => _network;

            set
            {
                if (string.Equals(value, _network, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _network = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the network.
        /// </summary>
        public int NetworkId
        {
            get => _networkId;

            set
            {
                if (value == _networkId)
                {
                    return;
                }

                _networkId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the path of the poster.
        /// </summary>
        public string? Poster
        {
            get => _poster;

            set
            {
                if (string.Equals(value, _poster, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _poster = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the rating fo the series.
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
        /// Gets or sets the count of rates.
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
        /// Gets or sets the runtime of the series.
        /// </summary>
        public double Runtime
        {
            get => _runtime;

            set
            {
                if (value == _runtime)
                {
                    return;
                }

                _runtime = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        public int SeriesId
        {
            get => _seriesId;

            set
            {
                if (value == _seriesId)
                {
                    return;
                }

                _seriesId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of the series.
        /// </summary>
        public string? Status
        {
            get => _status;

            set
            {
                if (string.Equals(value, _status, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _status = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tms is wanted for the series or not.
        /// </summary>
        public bool TmsWanted
        {
            get => _tmsWanted;

            set
            {
                if (value == _tmsWanted)
                {
                    return;
                }

                _tmsWanted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Zap2It id of the series.
        /// </summary>
        public string? Zap2ItId
        {
            get => _zap2ItId;

            set
            {
                if (string.Equals(value, _zap2ItId, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _zap2ItId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Adds the provided episode to the series.
        /// </summary>
        /// <param name="toAdd">Episode to add.</param>
        /// <exception cref="ArgumentNullException">Occurs when the provided <see cref="Episode"/> is null.</exception>
        public void AddEpisode(Episode toAdd)
        {
            if (toAdd == null)
            {
                throw new ArgumentNullException(nameof(toAdd), "Episode to add must not be null.");
            }

            Episodes.Add(toAdd);
        }

        /// <summary>
        /// Deserializes the provided xml node.
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
        /// 		/// Xml document that contains all details of a series.
        /// 		/// </summary>
        /// 		private XmlDocument languageDoc = null;
        ///
        /// 		/// <summary>
        /// 		/// Initializes a new instance of the DocuClass class.
        /// 		/// </summary>
        /// 		public DocuClass(string extractionPath)
        /// 		{
        /// 			// load series xml.
        /// 			this.languageDoc = new XmlDocument();
        /// 			this.languageDoc.Load(System.IO.Path.Combine(this.extractionPath, string.Format("{0}.xml", this.Language)));
        /// 		}
        ///
        /// 		/// <summary>
        /// 		/// Deserializes all actors of the series.
        /// 		/// </summary>
        /// 		public Series DeserializeSeries()
        /// 		{
        /// 			Series series = new Series();
        ///
        /// 			// load the xml docs second child.
        /// 			XmlNode dataNode = this.languageDoc.ChildNodes[1];
        ///
        /// 			// deserialize all episodes and series details.
        /// 			foreach (XmlNode currentNode in dataNode.ChildNodes)
        /// 			{
        /// 				if (currentNode.Name.Equals("Episode", StringComparison.OrdinalIgnoreCase))
        /// 				{
        /// 					Episode deserialized = new Episode();
        /// 					deserialized.Deserialize(currentNode);
        ///
        /// 					series.AddEpisode(deserialized);
        /// 					continue;
        /// 				}
        /// 				else if (currentNode.Name.Equals("Series", StringComparison.OrdinalIgnoreCase))
        /// 				{
        /// 					series.Deserialize(currentNode);
        /// 					continue;
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

            var cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            foreach (XmlNode currentNode in node.ChildNodes)
            {
                switch (currentNode.Name)
                {
                    case "id" when int.TryParse(currentNode.InnerText, out var result):
                        Id = result;
                        break;

                    case "Language" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Language = currentNode.InnerText;
                        break;

                    case "SeriesName" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Name = currentNode.InnerText;
                        break;

                    case "banner" when !string.IsNullOrEmpty(currentNode.InnerText):
                        Banner = currentNode.InnerText;
                        break;
                }

                if (currentNode.Name.Equals("SeriesID", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    SeriesId = result;
                    continue;
                }

                if (currentNode.Name.Equals("Overview", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Overview = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("FirstAired", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    FirstAired = DateTime.Parse(currentNode.InnerText);
                    continue;
                }
                if (currentNode.Name.Equals("IMDB_ID", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    ImdbId = currentNode.InnerText;
                    continue;
                }
                if (currentNode.Name.Equals("zap2it_id", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    Zap2ItId = currentNode.InnerText;
                    continue;
                }
                if (currentNode.Name.Equals("Actors", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Actors = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("Airs_DayOfWeek", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    AirsDayOfWeek = currentNode.InnerText;
                    continue;
                }
                if (currentNode.Name.Equals("Airs_Time", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    AirsTime = currentNode.InnerText;
                    continue;
                }
                if (currentNode.Name.Equals("ContentRating", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        ContentRating = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("Genre", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    Genre = currentNode.InnerText;
                    continue;
                }
                if (currentNode.Name.Equals("Network", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    Network = currentNode.InnerText;
                }
                else if (currentNode.Name.Equals("NetworkID", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    NetworkId = result;
                    continue;
                }
                else if (currentNode.Name.Equals("Rating", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    double.TryParse(currentNode.InnerText, System.Globalization.NumberStyles.Number, cultureInfo, out var result);
                    Rating = result;
                    continue;
                }
                else if (currentNode.Name.Equals("RatingCount", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    RatingCount = result;
                    continue;
                }
                else if (currentNode.Name.Equals("Runtime", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    double.TryParse(currentNode.InnerText, System.Globalization.NumberStyles.Number, cultureInfo, out var result);
                    Runtime = result;
                    continue;
                }
                else if (currentNode.Name.Equals("Status", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    Status = currentNode.InnerText;
                    continue;
                }
                else if (currentNode.Name.Equals("added", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    AddedDate = DateTime.Parse(currentNode.InnerText);
                    continue;
                }
                else if (currentNode.Name.Equals("addedBy", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    AddedByUserId = result;
                    continue;
                }
                else if (currentNode.Name.Equals("fanart", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        FanArt = currentNode.InnerText;
                    }
                    continue;
                }
                else if (currentNode.Name.Equals("lastupdated", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    long.TryParse(currentNode.InnerText, out var result);
                    LastUpdated = result;
                    continue;
                }
                else if (currentNode.Name.Equals("poster", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Poster = currentNode.InnerText;
                    }
                    continue;
                }
                else if (currentNode.Name.Equals("tms_wanted", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);

                    TmsWanted = result > 0;
                    continue;
                }
            }

            Initialize();
        }

        /// <summary>
        /// Initializes the properties.
        /// </summary>
        private void Initialize()
        {
            if (Episodes.Count > 0)
            {
                HasEpisodes = true;
            }

            Actors = PrepareText(_actors);
            Genre = PrepareText(_genre);
        }
    }
}
