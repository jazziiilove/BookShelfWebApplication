/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .ConstantsAndDefs
 * Project name: .BookShelfWeb.Definitions
 * File name: Constants.cs
 * Status: Finished
 */

using System;
using System.Configuration;

namespace BookShelfWeb.Definitions
{
    /// <summary>
    /// Constants for the whole application
    /// </summary>
    public class Constants
    {
        #region constants

        public const char DEFAULT_SEPERATOR = ',';

        /// <summary>
        /// Connection string
        /// </summary>

        //Template:
        //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;

        //Original:
        //public const string SQL_CONNECTION_STRING = @"Database=BookShelfWeb;Server=BARAN-VAIO\RISKSPECTRUM_PSA;Trusted_Connection=True";

        public static readonly string SQL_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["BookShelfWebConnectionString"].ConnectionString;
               
        /// <summary>
        /// Maximum Date time for SQL Data type, DateTime        
        /// </summary>
        public static DateTime MAX_TIME = DateTime.Parse("9999-12-31");

        /// <summary>
        /// Minimum Date time for SQL Data type, DateTime
        /// </summary>
        public static DateTime MIN_TIME = DateTime.Parse("1753-1-1");

        /// <summary>
        /// Maximum Date time for SQL Data type, SmallDateTime
        /// </summary>
        public static DateTime MAX_SMALL_TIME = DateTime.Parse("1079-6-6");

        /// <summary>
        /// Minimum Date time for SQL Data type, SmallDateTime
        /// </summary>
        public static DateTime MIN_SMALL_TIME = DateTime.Parse("1900-1-1");

        #endregion constants
    }
}
