using System;
using System.Xml;

namespace TVDB.Model
{
    /// <summary>
    /// An episode of a series.
    /// </summary>
    public class Episode : SeriesElement, Interfaces.IXmlSerializer
    {
        /// <summary>
        /// Absolute number of the episode.
        /// </summary>
        private int _absoluteNumber = -1;

        /// <summary>
        /// Airs after season name.
        /// </summary>
        private int _airsAfterSeason = -1;

        /// <summary>
        /// Number or episode this one airs before.
        /// </summary>
        private int _airsBeforeEpisode = -1;

        /// <summary>
        /// Number of the season this episode airs before.
        /// </summary>
        private int _airsBeforeSeason = -1;

        /// <summary>
        /// The combined episode number.
        /// </summary>
        private double _combinedEpisodeNumber = -1;

        /// <summary>
        /// The combined season number.
        /// </summary>
        private int _combinedSeason = -1;

        /// <summary>
        /// The director fo the series.
        /// </summary>
        private string? _director;

        /// <summary>
        /// Chapter number of the dvd.
        /// </summary>
        private int _dvdChapter = -1;

        /// <summary>
        /// Id of the dvd disk.
        /// </summary>
        private int _dvdDiskId = -1;

        /// <summary>
        /// The episode number on the dvd.
        /// </summary>
        private double _dvdEpisodeNumber = -1;

        /// <summary>
        /// Season number of the dvd.
        /// </summary>
        private int _dvdSeason = -1;

        /// <summary>
        /// The ep image flag.
        /// </summary>
        private int _epImageFlag = -1;

        /// <summary>
        /// Names of any guest stars that appeared in this episode.
        /// </summary>
        private string? _guestStars;

        /// <summary>
        /// Value indicating whether the episode is a tms export or not.
        /// </summary>
        private bool _isTmsExport;

        /// <summary>
        /// Value indicating whether the tms review is blurry or not.
        /// </summary>
        private bool _isTmsReviewBlurry;

        /// <summary>
        /// Value indicating whether the tms review is dark or not.
        /// </summary>
        private bool _isTmsReviewDark;

        /// <summary>
        /// Value indicating whether the tms review is unsure or not.
        /// </summary>
        private bool _isTmsReviewUnsure;

        /// <summary>
        /// Id of the last update.
        /// </summary>
        private long _lastUpdated = -1;

        /// <summary>
        /// The number of the episode.
        /// </summary>
        private int _number = -1;

        /// <summary>
        /// Path and name of the picture.
        /// </summary>
        private string? _pictureFilename;

        /// <summary>
        /// The production code of the episode.
        /// </summary>
        private int _productionCode = -1;

        /// <summary>
        /// Rating of the episode.
        /// </summary>
        private double _rating = -1;

        /// <summary>
        /// The rating count of the episode.
        /// </summary>
        private int _ratingCount = -1;

        /// <summary>
        /// Id of the season.
        /// </summary>
        private int _seasonId = -1;

        /// <summary>
        /// Number of the season the episode belongs to.
        /// </summary>
        private int _seasonNumber = -1;

        /// <summary>
        /// Id of the series.
        /// </summary>
        private int _seriesId = -1;

        /// <summary>
        /// Thumbadded id.
        /// </summary>
        private int _thumbadded = -1;

        /// <summary>
        /// The height of the thumbimage.
        /// </summary>
        private int _thumbHeight = -1;

        /// <summary>
        /// Width of the thumb image.
        /// </summary>
        private int _thumbWidth = -1;

        /// <summary>
        /// Id of the user who made the tms review.
        /// </summary>
        private int _tmsReviewById = -1;

        /// <summary>
        /// Date the tms review was made.
        /// </summary>
        private DateTime _tmsReviewDate = DateTime.MinValue;

        /// <summary>
        /// Id of the tms review logo.
        /// </summary>
        private int _tmsReviewLogoId = -1;

        /// <summary>
        /// Tms review other.
        /// </summary>
        private int _tmsReviewOther = -1;

        /// <summary>
        /// Name of the writer of the episode.
        /// </summary>
        private string? _writer;

        /// <summary>
        /// Gets or sets the absolute number of the episode.
        /// </summary>
        public int AbsoluteNumber
        {
            get => _absoluteNumber;

            set
            {
                if (value == _absoluteNumber)
                {
                    return;
                }

                _absoluteNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the name of the season this episode airs after.
        /// </summary>
        public int AirsAfterSeason
        {
            get => _airsAfterSeason;
            set
            {
                if (value == _airsAfterSeason)
                {
                    return;
                }

                _airsAfterSeason = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the number of episode this one airs before.
        /// </summary>
        public int AirsBeforeEpisode
        {
            get => _airsBeforeEpisode;
            set
            {
                if (value == _airsBeforeEpisode)
                {
                    return;
                }

                _airsBeforeEpisode = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the number of hte season this episode airs before.
        /// </summary>
        public int AirsBeforeSeason
        {
            get => _airsBeforeSeason;
            set
            {
                if (value == _airsBeforeSeason)
                {
                    return;
                }

                _airsBeforeSeason = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the combined episode number.
        /// </summary>
        public double CombinedEpisodeNumber
        {
            get => _combinedEpisodeNumber;

            set
            {
                if (value == _combinedEpisodeNumber)
                {
                    return;
                }

                _combinedEpisodeNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the combined season number.
        /// </summary>
        public int CombinedSeason
        {
            get => _combinedSeason;

            set
            {
                if (value == _combinedSeason)
                {
                    return;
                }

                _combinedSeason = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the director fo the series.
        /// </summary>
        public string? Director
        {
            get => _director;

            set
            {
                if (string.Equals(value, _director, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _director = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the chapter number of the dvd.
        /// </summary>
        public int DvdChapter
        {
            get => _dvdChapter;

            set
            {
                if (value == _dvdChapter)
                {
                    return;
                }

                _dvdChapter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the dvd disk.
        /// </summary>
        public int DvdDiscId
        {
            get => _dvdDiskId;

            set
            {
                if (value == _dvdDiskId)
                {
                    return;
                }

                _dvdDiskId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the episode number on the dvd.
        /// </summary>
        public double DvdEpisodeNumber
        {
            get => _dvdEpisodeNumber;

            set
            {
                if (value == _dvdEpisodeNumber)
                {
                    return;
                }

                _dvdEpisodeNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the season number of the dvd.
        /// </summary>
        public int DvdSeason
        {
            get => _dvdSeason;

            set
            {
                if (value == _dvdSeason)
                {
                    return;
                }

                _dvdSeason = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the ep image flag.
        /// </summary>
        public int EpImageFlag
        {
            get => _epImageFlag;

            set
            {
                if (value == _epImageFlag)
                {
                    return;
                }

                _epImageFlag = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the names of any guest stars that appeared in this episode.
        /// </summary>
        public string? GuestStars
        {
            get => _guestStars;

            set
            {
                if (string.Equals(value, _guestStars, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _guestStars = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the episode is a tms export or not.
        /// </summary>
        public bool IsTmsExport
        {
            get => _isTmsExport;

            set
            {
                if (value == _isTmsExport)
                {
                    return;
                }

                _isTmsExport = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tms review is blurry or not.
        /// </summary>
        public bool IsTmsReviewBlurry
        {
            get => _isTmsReviewBlurry;

            set
            {
                if (value == _isTmsReviewBlurry)
                {
                    return;
                }

                _isTmsReviewBlurry = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tms review is dark or not.
        /// </summary>
        public bool IsTmsReviewDark
        {
            get => _isTmsReviewDark;

            set
            {
                if (value == _isTmsReviewDark)
                {
                    return;
                }

                _isTmsReviewDark = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tms review is unsure or not.
        /// </summary>
        public bool IsTmsReviewUnsure
        {
            get => _isTmsReviewUnsure;

            set
            {
                if (value == _isTmsReviewUnsure)
                {
                    return;
                }

                _isTmsReviewUnsure = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the last update.
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
        /// Gets or sets the number of the episode.
        /// </summary>
        public int Number
        {
            get => _number;

            set
            {
                if (value == _number)
                {
                    return;
                }

                _number = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the path and name of the picture.
        /// </summary>
        public string? PictureFilename
        {
            get => _pictureFilename;

            set
            {
                if (string.Equals(value, _pictureFilename, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _pictureFilename = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the production code of the episode.
        /// </summary>
        public int ProductionCode
        {
            get => _productionCode;

            set
            {
                if (value == _productionCode)
                {
                    return;
                }

                _productionCode = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the rating of the episode.
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
        /// Gets or sets the rating count of the episode.
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
        /// Gets or sets the id of the season..
        /// </summary>
        public int SeasonId
        {
            get => _seasonId;

            set
            {
                if (value == _seasonId)
                {
                    return;
                }

                _seasonId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the number of the season the episode belongs to.
        /// </summary>
        public int SeasonNumber
        {
            get => _seasonNumber;

            set
            {
                if (value == _seasonNumber)
                {
                    return;
                }

                _seasonNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the series.
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
        /// Gets or sets the thumbadded id.
        /// </summary>
        public int Thumbadded
        {
            get => _thumbadded;

            set
            {
                if (value == _thumbadded)
                {
                    return;
                }

                _thumbadded = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the height of the thumbimage.
        /// </summary>
        public int ThumbHeight
        {
            get => _thumbHeight;

            set
            {
                if (value == _thumbHeight)
                {
                    return;
                }

                _thumbHeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the width of the thumb image.
        /// </summary>
        public int ThumbWidth
        {
            get => _thumbWidth;

            set
            {
                if (value == _thumbWidth)
                {
                    return;
                }

                _thumbWidth = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the user who made the tms review.
        /// </summary>
        public int TmsReviewById
        {
            get => _tmsReviewById;

            set
            {
                if (value == _tmsReviewById)
                {
                    return;
                }

                _tmsReviewById = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date the tms review was made.
        /// </summary>
        public DateTime TmsReviewDate
        {
            get => _tmsReviewDate;

            set
            {
                if (value == _tmsReviewDate)
                {
                    return;
                }

                _tmsReviewDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the tms review logo.
        /// </summary>
        public int TmsReviewLogoId
        {
            get => _tmsReviewLogoId;

            set
            {
                if (value == _tmsReviewLogoId)
                {
                    return;
                }

                _tmsReviewLogoId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the tms review other value.
        /// </summary>
        public int TmsReviewOther
        {
            get => _tmsReviewOther;

            set
            {
                if (value == _tmsReviewOther)
                {
                    return;
                }

                _tmsReviewOther = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the name of the writer of the episode.
        /// </summary>
        public string? Writer
        {
            get => _writer;

            set
            {
                if (string.Equals(value, _writer, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _writer = value;
                OnPropertyChanged();
            }
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
        /// 		/// Deserializes the series.
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
                if (currentNode.Name.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    Id = result;
                    continue;
                }

                if (currentNode.Name.Equals("Combined_episodenumber", StringComparison.OrdinalIgnoreCase))
                {
                    double.TryParse(currentNode.InnerText, System.Globalization.NumberStyles.Number, cultureInfo, out var result);
                    CombinedEpisodeNumber = result;
                    continue;
                }
                if (currentNode.Name.Equals("Combined_season", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    CombinedSeason = result;
                    continue;
                }
                if (currentNode.Name.Equals("DVD_chapter", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    DvdChapter = result;
                    continue;
                }
                if (currentNode.Name.Equals("DVD_discid", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    DvdDiscId = result;
                    continue;
                }
                if (currentNode.Name.Equals("DVD_episodenumber", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    double.TryParse(currentNode.InnerText, System.Globalization.NumberStyles.Number, cultureInfo, out var result);
                    DvdEpisodeNumber = result;
                    continue;
                }
                if (currentNode.Name.Equals("DVD_season", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    DvdSeason = result;
                    continue;
                }
                if (currentNode.Name.Equals("Director", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Director = currentNode.InnerText;
                    }

                    continue;
                }
                if (currentNode.Name.Equals("EpImgFlag", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    EpImageFlag = result;
                    continue;
                }
                if (currentNode.Name.Equals("EpisodeName", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Name = currentNode.InnerText;
                    }
                    continue;
                }
                if (currentNode.Name.Equals("EpisodeNumber", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    Number = result;
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
                if (currentNode.Name.Equals("GuestStars", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        GuestStars = currentNode.InnerText;
                    }
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
                if (currentNode.Name.Equals("Language", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Language = currentNode.InnerText;
                    }
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
                if (currentNode.Name.Equals("ProductionCode", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    ProductionCode = result;
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
                }
                else if (currentNode.Name.Equals("SeasonNumber", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    SeasonNumber = result;
                    continue;
                }
                else if (currentNode.Name.Equals("Writer", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        Writer = currentNode.InnerText;
                    }
                    continue;
                }
                else if (currentNode.Name.Equals("absolute_number", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    AbsoluteNumber = result;
                    continue;
                }
                else if (currentNode.Name.Equals("filename", StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        PictureFilename = currentNode.InnerText;
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
                else if (currentNode.Name.Equals("seasonid", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    SeasonId = result;
                    continue;
                }
                else if (currentNode.Name.Equals("seriesid", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    SeriesId = result;
                    continue;
                }
                else if (currentNode.Name.Equals("thumb_added", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    Thumbadded = result;
                    continue;
                }
                else if (currentNode.Name.Equals("thumb_height", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    ThumbHeight = result;
                    continue;
                }
                else if (currentNode.Name.Equals("thumb_width", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    ThumbWidth = result;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_export", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    IsTmsExport = result > 0;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_blurry", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    IsTmsReviewBlurry = result > 0;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_by", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    TmsReviewById = result;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_dark", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    IsTmsReviewDark = result > 0;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_date", StringComparison.OrdinalIgnoreCase))
                {
                    DateTime.TryParse(currentNode.InnerText, cultureInfo, System.Globalization.DateTimeStyles.AssumeUniversal, out var result);
                    TmsReviewDate = result;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_logo", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    TmsReviewLogoId = result;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_other", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    TmsReviewOther = result;
                    continue;
                }
                else if (currentNode.Name.Equals("tms_review_unsure", StringComparison.OrdinalIgnoreCase))
                {
                    int.TryParse(currentNode.InnerText, out var result);
                    IsTmsReviewUnsure = result > 0;
                    continue;
                }
                else if (currentNode.Name.Equals("airsafter_season", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    AirsAfterSeason = result;
                    continue;
                }
                else if (currentNode.Name.Equals("airsbefore_season", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    AirsBeforeSeason = result;
                    continue;
                }
                else if (currentNode.Name.Equals("airsbefore_episode", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(currentNode.InnerText))
                    {
                        continue;
                    }

                    int.TryParse(currentNode.InnerText, out var result);
                    AirsBeforeEpisode = result;
                    continue;
                }
            }

            // Specials handling for TheTVDB return 0 (v3) instead of NULL (v1)
            if (AirsAfterSeason == 0 && AirsBeforeSeason == 0 && AirsBeforeEpisode == 0)
            {
                AirsBeforeEpisode = -1;
                AirsAfterSeason = -1;
                AirsBeforeSeason = -1;
            }

            Initialize();
        }

        /// <summary>
        /// Initializes the properties of the <see cref="Episode"/>.
        /// </summary>
        private void Initialize()
        {
            GuestStars = PrepareText(_guestStars);

            Writer = PrepareText(_writer);
        }
    }
}
