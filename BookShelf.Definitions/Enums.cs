/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .ConstantsAndDefs
 * Project name: .BookShelfWeb.Definitions
 * File name: Enums.cs
 * Status: Ongoing - Future use
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfWeb.Definitions
{
    /// <summary>
    /// Enumerators for the whole application
    /// </summary>
    public enum Language
    {
        #region enums

        /// <summary>
        /// None
        /// </summary>
        None = -1,

        /// <summary>
        /// English
        /// </summary>
        English = 0,

        /// <summary>
        /// Swedish
        /// </summary>
        Swedish = 1

        #endregion enums
    }
}
