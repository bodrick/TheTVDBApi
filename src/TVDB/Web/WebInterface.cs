using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using TVDB.Model;

namespace TVDB.Web
{
    /// <summary>
    /// Communication with the XML interface of the TVDB.
    /// </summary>
    public class WebInterface : ITvDb
    {
        /// <summary>
        /// Api key for the application.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// WebClient to download the file.
        /// </summary>
        private readonly WebClient _client = new();

        /// <summary>
        /// Default mirror site to connect to the api.
        /// </summary>
        private Mirror? _defaultMirror;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebInterface"/> class, using the provided API key.
        /// </summary>
        /// <param name="apiKey">API key obtained from TheTVDB.com to access the XML api.</param>
        public WebInterface(string apiKey) : this(apiKey, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebInterface"/> class.
        /// </summary>
        /// <param name="apiKey">API key obtained from TheTVDB.com to access the XML api.</param>
        /// <param name="fileDirectory">Directory where all loaded files will be stored.</param>
        public WebInterface(string apiKey, string fileDirectory)
        {
            _apiKey = apiKey;
            FileDirectory = fileDirectory;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="WebInterface"/> class from being created.
        /// </summary>
        private WebInterface()
        {
        }

        /// <summary>
        /// Directory for writing zip and extracted files
        /// </summary>
        public string FileDirectory { get; set; }

        /// <summary>
        /// Path of the full series zip file.
        /// </summary>
        private string LoadedSeriesPath => Path.Combine(FileDirectory, "loaded.zip");

        /// <summary>
        /// Gets all details of the series.
        /// </summary>
        /// <param name="id">Id of the series.</param>
        /// <param name="mirror">The mirror to use.</param>
        /// <returns>All details of the series.</returns>
        /// <example>Shows how the get all details of a series by its id.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets all details of a series.
        /// 		/// </summary>
        /// 		public SeriesDetails GetSeries(int id, Mirror mirror, Language language)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			SeriesDetails details = await instance.GetFullSeriesById(id, language.Abbreviation, mirror);
        ///
        /// 			return details;
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<SeriesDetails?> GetFullSeriesByIdAsync(int id, Mirror? mirror)
        {
            if (id == 0)
            {
                return null;
            }

            if (mirror == null)
            {
                return null;
            }

            return await GetFullSeriesByIdAsync(id, "en", mirror).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all details of the series.
        /// </summary>
        /// <param name="id">Id of the series.</param>
        /// <param name="languageAbbreviation">The language abbreviation.</param>
        /// <param name="mirror">The mirror to use.</param>
        /// <returns>All details of the series.</returns>
        /// <example>Shows how the get all details of a series by its id.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets all details of a series.
        /// 		/// </summary>
        /// 		public SeriesDetails GetSeries(int id, Mirror mirror, Language language)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			SeriesDetails details = await instance.GetFullSeriesById(id, language.Abbreviation, mirror);
        ///
        /// 			return details;
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<SeriesDetails?> GetFullSeriesByIdAsync(int id, string languageAbbreviation, Mirror? mirror)
        {
            if (id == 0)
            {
                return null;
            }

            if (string.IsNullOrEmpty(languageAbbreviation))
            {
                return null;
            }

            if (mirror == null)
            {
                return null;
            }

            const string url = "{0}/api/{1}/series/{2}/all/{3}.zip";
            var result = await _client.DownloadDataTaskAsync(string.Format(url, mirror.Address, _apiKey, id, languageAbbreviation)).ConfigureAwait(false);

            // store the zip file.
            using (var zipFile = new FileStream(LoadedSeriesPath, FileMode.Create, FileAccess.Write))
            {
                await zipFile.WriteAsync(result, 0, result.Length).ConfigureAwait(false);
                await zipFile.FlushAsync().ConfigureAwait(false);
            }

            var dirInfo = new DirectoryInfo(Path.Combine(FileDirectory, "extraction"));
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            // extract the file.
            using (var archive = ZipFile.OpenRead(LoadedSeriesPath))
            {
                foreach (var entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(dirInfo.FullName, entry.Name), true);
                }
            }

            return new SeriesDetails(dirInfo.FullName, languageAbbreviation);
        }

        /// <summary>
        /// Gets a list of all available languages.
        /// </summary>
        /// <returns>Collection of all available languages.</returns>
        /// <example>Shows how to get all languages.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets all mirrors that are available.
        /// 		/// </summary>
        /// 		public List&#60;Language&#62; GetAllLanguages(Mirror mirror)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Language&#62; languages = await instance.GetLanguages(mirror);
        ///
        /// 			return languages
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Language>?> GetLanguagesAsync()
        {
            // get the default mirror.
            if (_defaultMirror == null)
            {
                await GetMirrorsAsync().ConfigureAwait(false);
            }

            return await GetLanguagesAsync(_defaultMirror).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a list of all available languages.
        /// </summary>
        /// <param name="mirror">Mirror to use.</param>
        /// <returns>Collection of all available languages.</returns>
        /// <example>Shows how to get all languages.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets all mirrors that are available.
        /// 		/// </summary>
        /// 		public List&#60;Language&#62; GetAllLanguages(Mirror mirror)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Language&#62; languages = await instance.GetLanguages(mirror);
        ///
        /// 			return languages
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Language>?> GetLanguagesAsync(Mirror? mirror)
        {
            if (mirror == null)
            {
                return null;
            }

            const string url = "{0}/api/{1}/languages.xml";

            var result = await _client.DownloadDataTaskAsync(string.Format(url, mirror.Address, _apiKey)).ConfigureAwait(false);
            using var resultStream = new MemoryStream(result);
            var doc = new XmlDocument();
            doc.Load(resultStream);
            var dataNode = doc.ChildNodes[doc.ChildNodes.Count - 1];

            var receivedLanguages = new List<Language>();

            foreach (XmlNode currentNode in dataNode.ChildNodes)
            {
                var deserialized = new Language();
                deserialized.Deserialize(currentNode);

                receivedLanguages.Add(deserialized);
            }

            return receivedLanguages.OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Get all available mirrors.
        /// </summary>
        /// <returns>A Collection of mirrors.</returns>
        /// <exception cref="Exception">Occurs when the main source of the TheTVDB seems to be offline.</exception>
        /// <example>Shows how to request all available mirrors.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets all mirrors that are available.
        /// 		/// </summary>
        /// 		public List&#60;Mirror&#62; GetAllMirrors()
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Mirror&#62; mirrors = await instance.GetMirrors();
        ///
        /// 			return mirrors
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Mirror>> GetMirrorsAsync()
        {
            const string url = "http://thetvdb.com/api/{0}/mirrors.xml";

            byte[] result;

            try
            {
                result = await _client.DownloadDataTaskAsync(string.Format(url, _apiKey)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Source seems to be offline.", ex);
            }

            using var resultStream = new MemoryStream(result);
            var doc = new XmlDocument();
            doc.Load(resultStream);

            var dataNode = doc.ChildNodes[doc.ChildNodes.Count - 1];

            var receivedMirrors = new List<Mirror>();

            foreach (XmlNode current in dataNode)
            {
                var deserialized = new Mirror();
                deserialized.Deserialize(current);

                if (_defaultMirror == null && deserialized.ContainsBannerFile &&
                    deserialized.ContainsXmlFile &&
                    deserialized.ContainsZipFile)
                {
                    _defaultMirror = deserialized;
                }

                receivedMirrors.Add(deserialized);
            }

            return receivedMirrors;
        }

        /// <summary>
        /// Gets all series that match with the provided name.
        /// </summary>
        /// <param name="name">Name of the series.</param>
        /// <param name="mirror">The mirror to use.</param>
        /// <remarks>
        /// When calling this method a default language, which is english will be used to find all series that match the name.
        /// </remarks>
        /// <returns>List of series that matches the provided name.</returns>
        /// <example>Shows how to get a series by name.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets series by name.
        /// 		/// </summary>
        /// 		public List&#60;Series&#62; GetSeries(string name, Mirror mirror, Language language)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Series&#62; series = await instance.GetSeriesByName(name, language.Abbreviation, mirror);
        ///
        /// 			return series;
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Series>?> GetSeriesByNameAsync(string name, Mirror? mirror)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (mirror == null)
            {
                return null;
            }

            return await GetSeriesByNameAsync(name, "en", mirror).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all series that match with the provided name.
        /// </summary>
        /// <param name="name">Name of the series.</param>
        /// <param name="languageAbbreviation">Abbreviation of the language to search the series.</param>
        /// <param name="mirror">The mirror to use.</param>
        /// <returns>List of series that matches the provided name.</returns>
        /// <example>Shows how to get a series by name.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets series by name.
        /// 		/// </summary>
        /// 		public List&#60;Series&#62; GetSeries(string name, Mirror mirror, Language language)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Series&#62; series = await instance.GetSeriesByName(name, language.Abbreviation, mirror);
        ///
        /// 			return series;
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Series>?> GetSeriesByNameAsync(string name, string languageAbbreviation, Mirror? mirror)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (mirror == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(languageAbbreviation))
            {
                return null;
            }

            const string url = "{0}/api/GetSeries.php?seriesname={1}&language={2}";

            var result = await _client.DownloadDataTaskAsync(string.Format(url, mirror.Address, name, languageAbbreviation)).ConfigureAwait(false);
            using var resultStream = new MemoryStream(result);
            var doc = new XmlDocument();
            doc.Load(resultStream);
            var dataNode = doc.ChildNodes[doc.ChildNodes.Count - 1];

            var series = new List<Series>();
            foreach (XmlNode currentNode in dataNode.ChildNodes)
            {
                var deserialized = new Series();
                deserialized.Deserialize(currentNode);

                series.Add(deserialized);
            }

            return series.Where(x => x.Language.Equals(languageAbbreviation, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Gets the series by either its imdb or zap2it id.
        /// </summary>
        /// <param name="imdbId">IMDB id</param>
        /// <param name="zap2Id">Zap2It id</param>
        /// <param name="mirror">The mirror to use.</param>
        /// <returns>The Series belonging to the provided id.</returns>
        /// <remarks>
        /// It is not allowed to provide both imdb and zap2it id, this will lead to a null value as return value.
        /// </remarks>
        /// <example>Shows how the get a series by imdb and zap2 Id.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets series by id.
        /// 		/// </summary>
        /// 		public List&#60;Series&#62; GetSeries(string imdbId, string zap2Id, Mirror mirror, Language language)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Series&#62; series = await instance.GetSeriesByRemoteId(imdbId, zap2Id, language.Abbreviation, mirror);
        ///
        /// 			return series;
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Series>?> GetSeriesByRemoteIdAsync(string imdbId, string zap2Id, Mirror? mirror)
        {
            if (string.IsNullOrEmpty(imdbId) && string.IsNullOrEmpty(zap2Id))
            {
                return null;
            }

            if (!string.IsNullOrEmpty(imdbId) && !string.IsNullOrEmpty(zap2Id))
            {
                return null;
            }

            if (mirror == null)
            {
                return null;
            }

            return await GetSeriesByRemoteIdAsync(imdbId, zap2Id, "en", mirror).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the series by either its imdb or zap2it id.
        /// </summary>
        /// <param name="imdbId">IMDB id</param>
        /// <param name="zap2Id">Zap2It id</param>
        /// <param name="languageAbbreviation">The language abbreviation.</param>
        /// <param name="mirror">The mirror to use.</param>
        /// <returns>The Series belonging to the provided id.</returns>
        /// <remarks>
        /// It is not allowed to provide both imdb and zap2it id, this will lead to a null value as return value.
        /// </remarks>
        /// <example>Shows how the get a series by imdb and zap2 Id.
        /// <code>
        /// namespace Docunamespace
        /// {
        /// 	/// <summary>
        /// 	/// Class for the docu.
        /// 	/// </summary>
        /// 	class DocuClass
        /// 	{
        /// 		/// <summary>
        /// 		/// Gets series by id.
        /// 		/// </summary>
        /// 		public List&#60;Series&#62; GetSeries(string imdbId, string zap2Id, Mirror mirror, Language language)
        /// 		{
        ///				string apiKey = "ABCD12345";
        /// 			TVDB.Web.ITvDb instance = new TVDB.Web.WebInterface(apiKey);
        /// 			List&#60;Series&#62; series = await instance.GetSeriesByRemoteId(imdbId, zap2Id, language.Abbreviation, mirror);
        ///
        /// 			return series;
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        public async Task<IList<Series>?> GetSeriesByRemoteIdAsync(string imdbId, string zap2Id, string languageAbbreviation, Mirror? mirror)
        {
            if (string.IsNullOrEmpty(imdbId) && string.IsNullOrEmpty(zap2Id))
            {
                return null;
            }

            if (!string.IsNullOrEmpty(imdbId) && !string.IsNullOrEmpty(zap2Id))
            {
                return null;
            }

            if (mirror == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(languageAbbreviation))
            {
                return null;
            }

            const string url = "{0}/api/GetSeriesByRemoteID.php?imdbid={1}&language={2}&zap2it={3}";

            var result = await _client.DownloadDataTaskAsync(string.Format(url, mirror.Address, imdbId, languageAbbreviation, zap2Id)).ConfigureAwait(false);
            using var resultStream = new MemoryStream(result);
            var doc = new XmlDocument();
            doc.Load(resultStream);

            var dataNode = doc.ChildNodes[doc.ChildNodes.Count - 1];

            var series = new List<Series>();
            foreach (XmlNode currentNode in dataNode.ChildNodes)
            {
                var deserialized = new Series();
                deserialized.Deserialize(currentNode);

                series.Add(deserialized);
            }

            return series;
        }
    }
}
