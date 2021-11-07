// -----------------------------------------------------------------------
// <copyright company="Christoph van der Fecht - VDsoft">
// This code can be used in commercial, free and open source projects.
// </copyright>
// -----------------------------------------------------------------------

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
        /// Name of the <see cref="FirstAired"/> property.
        /// </summary>
        private const string FirstAiredName = "FirstAired";

        /// <summary>
        /// Name of the <see cref="Id"/> property.
        /// </summary>
        private const string IdName = "Id";

        /// <summary>
        /// Name of the <see cref="ImdbId"/> property.
        /// </summary>
        private const string ImdbIdName = "IMDBId";

        /// <summary>
        /// Name of the <see cref="Language"/> property.
        /// </summary>
        private const string LanguageName = "Language";

        /// <summary>
        /// Name of the <see cref="Name"/> property.
        /// </summary>
        private const string NameName = "Name";

        /// <summary>
        /// Name of the <see cref="Overview"/> property.
        /// </summary>
        private const string OverviewName = "Overview";

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
                RaisePropertyChanged(FirstAiredName);
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
                RaisePropertyChanged(IdName);
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
                if (value == _imdbId)
                {
                    return;
                }

                _imdbId = value;
                RaisePropertyChanged(ImdbIdName);
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
                if (value == _language)
                {
                    return;
                }

                _language = value;
                RaisePropertyChanged(LanguageName);
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
                if (value == _name)
                {
                    return;
                }

                _name = value;
                RaisePropertyChanged(NameName);
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
                if (value == _overview)
                {
                    return;
                }

                _overview = value;
                RaisePropertyChanged(OverviewName);
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

            if (result.StartsWith(", "))
            {
                result = result.Remove(0, 1).Trim();
            }

            if (result.EndsWith(","))
            {
                result = result.Remove(result.LastIndexOf(",", StringComparison.OrdinalIgnoreCase), 1).Trim();
            }

            return result;
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Name of the property that changed its value.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
