/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .DataAccess
 * Project name: .BookShelfWeb.DAL
 * File name: BookShelfBookDAL.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfWeb.IDAL
{
    /// <summary>
    /// Template Interface for app settings.
    /// T for Setting Entity Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBookShelfSettingsDAL<T>
    {
        #region settings

        /// <summary>
        /// Get Setting
        /// </summary>
        /// <returns>Setting Entity</returns>

        T GetSettings();

        /// <summary>
        /// Update Settings
        /// </summary>
        /// <param name="obj">Setting Entity</param>
        /// <returns>true if success, false otherwise</returns>
        bool UpdateSettings(T obj);

        #endregion settings
    }
}
