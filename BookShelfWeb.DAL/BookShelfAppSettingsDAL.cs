/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .DataAccess
 * Project name: .BookShelfWeb.DAL
 * File name: BookShelfAppSettingsDAL.cs
 * Status: Ongoing - Future use
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using BookShelfWeb.BookShelfModel;
using BookShelfWeb.IDAL;
using BookShelfWeb.Definitions;

namespace BookShelfWeb.DAL
{
    /// <summary>
    /// This class is responsible for reading/updating Application Settings which are applied to the entire application.
    /// </summary>
    public class BookShelfAppSettingsDAL : IBookShelfSettingsDAL<BookShelfApplicationSettings>
    {
        #region Related Constants/Enums

        public const string WEB_CONFIG_LANGUAGE = "Language";
        public const string LANGUAGE_ENGLISH = "English";
        public const string LANGUAGE_SWEDISH = "Swedish";
        public const string WEB_CONFIG_CURRENTPATH = "~";

        #endregion

        #region Member Variables

        private BookShelfApplicationSettings _appSettings = new BookShelfApplicationSettings();

        #endregion

        #region Settings

        /// <summary>
        /// Get Settings
        /// </summary>
        /// <returns>RWApplicationSettings, a default RWApplicationSettings object will be returned if not found or failed.</returns>
        BookShelfApplicationSettings IBookShelfSettingsDAL<BookShelfApplicationSettings>.GetSettings()
        {
            try
            {
                //get language setting
                string configLang = WebConfigurationManager.AppSettings[WEB_CONFIG_LANGUAGE];

                switch (configLang)
                {
                    case LANGUAGE_ENGLISH:
                        _appSettings.Language = Language.English;
                        break;
                    case LANGUAGE_SWEDISH:
                        _appSettings.Language = Language.Swedish;
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception /*ex*/)
            {
            }
            return _appSettings;
        }

        /// <summary>
        /// Update Application Settings
        /// </summary>
        /// <param name="appSettings">AppSetting Entity</param>
        /// <returns>true if success, otherwise false</returns>
        bool IBookShelfSettingsDAL<BookShelfApplicationSettings>.UpdateSettings(BookShelfApplicationSettings obj)
        {
            try
            {
                //Open web configuration
                Configuration config = WebConfigurationManager.OpenWebConfiguration(WEB_CONFIG_CURRENTPATH);
                AppSettingsSection app = config.AppSettings;

                //Update language setting
                switch (obj.Language)
                {
                    case Language.English:
                        app.Settings[WEB_CONFIG_LANGUAGE].Value = LANGUAGE_ENGLISH;
                        break;
                    case Language.Swedish:
                        app.Settings[WEB_CONFIG_LANGUAGE].Value = LANGUAGE_SWEDISH;
                        break;
                    default:
                        break;
                }

                config.Save(ConfigurationSaveMode.Modified);
                return true;
            }
            catch (System.Exception /*ex*/)
            {
            }
            return false;
        }

        #endregion Settings
    }
}
