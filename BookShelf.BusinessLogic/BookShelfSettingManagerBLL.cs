/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .BusinessLogic
 * Project name: .BookShelfWeb.BLL
 * File name: BookShelfSettingManagerBLL.cs
 * Status: TODO - Future use
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelf.IBLL;
using BookShelfWeb.BookShelfModel;
using BookShelfWeb.Factory;
using BookShelfWeb.DAL;

namespace BookShelf.BusinessLogic
{
    /// <summary>
    /// TODO
    /// </summary>
    public class BookShelfSettingManagerBLL : IBookShelfSettingManagerBLL
    {
        /*
        /// <summary>
        /// Get Application Settings
        /// </summary>
        /// <returns>RWApplicationSettings, a default RWApplicationSettings object will be returned if not found or failed.</returns>
        public BookShelfApplicationSettings GetAppSettings()
        {
            return DALFactory.GetSettingInterface<BookShelfAppSettingsDAL, BookShelfApplicationSettings>(null).GetSettings();
        }

        /// <summary>
        /// Update Application Settings
        /// </summary>
        /// <param name="appSettings">AppSetting Entity</param>
        /// <returns>true if success, otherwise false</returns>
        public bool SetAppSettings(BookShelfApplicationSettings appSettings)
        {
            return DALFactory.GetSettingInterface<BookShelfAppSettingsDAL, BookShelfApplicationSettings>(null).UpdateSettings(appSettings);
        }
        */
    }
}
