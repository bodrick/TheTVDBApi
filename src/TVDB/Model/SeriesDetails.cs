using System;
using System.Collections.Generic;
using System.Xml;

namespace TVDB.Model
{
    /// <summary>
    /// Contains all details for the requested series like Actors, Banners and all episodes of the series.
    /// </summary>
    public class SeriesDetails
    {
        /// <summary>
        /// Xml document that contains all actors.
        /// </summary>
        private readonly XmlDocument _actorsDoc;

        /// <summary>
        /// Xml document that contains all banners.
        /// </summary>
        private readonly XmlDocument _bannersDoc;

        /// <summary>
        /// Xml document that contains all details of a series.
        /// </summary>
        private readonly XmlDocument _languageDoc;

        /// <summary>
        /// The Actors.
        /// </summary>
        private IList<Actor>? _actors;

        /// <summary>
        /// The Banners.
        /// </summary>
        private IList<Banner>? _banners;

        /// <summary>
        /// The Language.
        /// </summary>
        private string? _language;

        /// <summary>
        /// The Series.
        /// </summary>
        private Series? _series;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesDetails"/> class.
        /// </summary>
        /// <param name="extractionPath">Path of the extracted files.</param>
        /// <param name="language">Language of the series.</param>
        /// <exception cref="System.IO.DirectoryNotFoundException">Occurs when the provided extraction path doesn't exists.</exception>
        /// <exception cref="ArgumentNullException">Occurs when to provided language is null or empty.</exception>
        public SeriesDetails(string extractionPath, string language)
        {
            var dirInfo = new System.IO.DirectoryInfo(extractionPath);
            if (!dirInfo.Exists)
            {
                throw new System.IO.DirectoryNotFoundException($"The directory \"{dirInfo.FullName}\" could not be found.");
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentNullException(nameof(language), "Provided language must not be null or empty.");
            }

            Language = language;

            // load actors xml.
            _actorsDoc = new XmlDocument();
            _actorsDoc.Load(System.IO.Path.Combine(extractionPath, "actors.xml"));

            // load banners xml.
            _bannersDoc = new XmlDocument();
            _bannersDoc.Load(System.IO.Path.Combine(extractionPath, "banners.xml"));

            // load series xml.
            _languageDoc = new XmlDocument();
            _languageDoc.Load(System.IO.Path.Combine(extractionPath, $"{Language}.xml"));
        }

        /// <summary>
        /// Gets or sets the Actors property.
        /// </summary>
        public IList<Actor>? Actors
        {
            get
            {
                if (_actors == null)
                {
                    DeserializeActors();
                }

                return _actors;
            }

            private set
            {
                if (Equals(value, _actors))
                {
                    return;
                }

                _actors = value;
            }
        }

        /// <summary>
        /// Gets or sets the Banners property.
        /// </summary>
        public IList<Banner>? Banners
        {
            get
            {
                if (_banners == null)
                {
                    DeserializeBanners();
                }

                return _banners;
            }

            private set
            {
                if (Equals(value, _banners))
                {
                    return;
                }

                _banners = value;
            }
        }

        /// <summary>
        /// Gets or sets the Language property.
        /// </summary>
        public string? Language
        {
            get => _language;

            private set
            {
                if (string.Equals(value, _language, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _language = value;
            }
        }

        /// <summary>
        /// Gets or sets the Series property.
        /// </summary>
        public Series? Series
        {
            get
            {
                if (_series == null)
                {
                    DeserializeSeries();
                }

                return _series;
            }

            private set
            {
                if (Equals(value, _series))
                {
                    return;
                }

                _series = value;
            }
        }

        /// <summary>
        /// Deserializes all actors of the series.
        /// </summary>
        private void DeserializeActors()
        {
            if (_actorsDoc.ChildNodes.Count == 0)
            {
                return;
            }

            Actors = new List<Actor>();
            foreach (XmlNode currentNode in _actorsDoc.ChildNodes[_actorsDoc.ChildNodes.Count - 1])
            {
                if (currentNode.Name.Equals("Actor", StringComparison.OrdinalIgnoreCase))
                {
                    var deserializes = new Actor();
                    deserializes.Deserialize(currentNode);

                    Actors.Add(deserializes);
                }
            }
        }

        /// <summary>
        /// Deserializes all banners of the series.
        /// </summary>
        private void DeserializeBanners()
        {
            if (_bannersDoc.ChildNodes.Count == 0)
            {
                return;
            }

            Banners = new List<Banner>();
            var bannersNode = _bannersDoc.ChildNodes[_bannersDoc.ChildNodes.Count - 1];

            foreach (XmlNode currentNode in bannersNode.ChildNodes)
            {
                if (currentNode.Name.Equals("Banner", StringComparison.OrdinalIgnoreCase))
                {
                    var deserialized = new Banner();
                    deserialized.Deserialize(currentNode);

                    Banners.Add(deserialized);
                }
            }
        }

        /// <summary>
        /// Deserializes the series.
        /// </summary>
        private void DeserializeSeries()
        {
            if (_languageDoc.ChildNodes.Count == 0)
            {
                return;
            }

            Series = new Series();
            if (Actors?.Count > 0)
            {
                Series.ActorCollection = new System.Collections.ObjectModel.ObservableCollection<Actor>(Actors);
            }

            var dataNode = _languageDoc.ChildNodes[_languageDoc.ChildNodes.Count - 1];

            foreach (XmlNode currentNode in dataNode.ChildNodes)
            {
                if (currentNode.Name.Equals("Episode", StringComparison.OrdinalIgnoreCase))
                {
                    var deserialized = new Episode();
                    deserialized.Deserialize(currentNode);

                    Series.AddEpisode(deserialized);
                }
                else if (currentNode.Name.Equals("Series", StringComparison.OrdinalIgnoreCase))
                {
                    Series.Deserialize(currentNode);
                }
            }
        }
    }
}
