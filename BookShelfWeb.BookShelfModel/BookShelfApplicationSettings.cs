/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Entity
 * Project name: .BookShelfWeb.BookShelfModel
 * File name: BookShelfApplicationSettings.cs
 * Status: Ongoing - Future use 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelfWeb.Definitions;

namespace BookShelfWeb.BookShelfModel
{
    /// <summary>
    /// Application settings
    /// </summary>
    public class BookShelfApplicationSettings
    {
        #region constants

        /// <summary>
        /// Language setting in web.config file
        /// </summary>
        public const string WEB_CONFIG_LANGUAGE = "Language";

        public const string LANGUAGE_ENGLISH = "English";

        public const string LANGUAGE_SWEDISH = "Swedish";

        #endregion constants

        #region member variables

        public Language Language;

        #endregion member variables
    }
}
