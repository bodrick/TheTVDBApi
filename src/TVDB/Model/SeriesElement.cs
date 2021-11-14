using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TVDB.Model
{
    /// <summary>
    /// Base for the elements of a series.
    /// </summary>
    public abstract class SeriesElement : INotifyPropertyChanged
    {
        /// <summary>
        /// Date the series was first aired.
        /// </summary>
        private DateTime _firstAired = DateTime.MinValue;

        /// <summary>
        /// Id of the element.
        /// </summary>
        private int _id;

        /// <summary>
        /// IMDB ID fo the series.
        /// </summary>
        private string _imdbId;

        /// <summary>
        /// Language of the element.
        /// </summary>
        private string _language;

        /// <summary>
        /// Name of the element.
        /// </summary>
        private string _name;

        /// <summary>
        /// The overview of the series.
        /// </summary>
        private string _overview;

        /// <summary>
        /// Occurs when a property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the date the series was first aired.
        /// </summary>
        public DateTime FirstAired
        {
            get => _firstAired;

            set
            {
                if (value == _firstAired)
                {
                    return;
                }

                _firstAired = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the id of the element.
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
        /// Gets or sets the IMDB ID fo the series.
        /// </summary>
        public string ImdbId
        {
            get => _imdbId;

            set
            {
                if (string.Equals(value, _imdbId, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _imdbId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the language of the element.
        /// </summary>
        public string Language
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
        /// Gets or sets the name of the element.
        /// </summary>
        public string Name
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
        /// Gets or sets the overview of the series.
        /// </summary>
        public string Overview
        {
            get => _overview;

            set
            {
                if (string.Equals(value, _overview, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                _overview = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Removes all "|" inside the provided text.
        /// </summary>
        /// <param name="text">Text to prepare.</param>
        /// <returns>Clean text.</returns>
        protected static string PrepareText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            string result;

            if (text.Contains("|"))
            {
                result = text.Replace("|", ", ");
            }
            else
            {
                return text;
            }

            if (result.StartsWith(", ", StringComparison.OrdinalIgnoreCase))
            {
                result = result.Remove(0, 1).Trim();
            }

            if (result.EndsWith(",", StringComparison.OrdinalIgnoreCase))
            {
                result = result.Remove(result.LastIndexOf(",", StringComparison.OrdinalIgnoreCase), 1).Trim();
            }

            return result;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
