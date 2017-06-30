/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Util
 * Project name: .BookShelfWeb.ConverterManager
 * File name: BookShelfConverter.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BookShelfWeb.ConverterManager
{
    /// <summary>
    /// converts data types between each other
    /// </summary>
    public sealed class BookShelfConverter
    {

        #region Data Type Conversion

        /// <summary>
        /// convert DateTime to long
        /// </summary>
        /// <param name="timepoint"></param>
        /// <returns></returns>
        public static long ConvertDateTime2Tick(DateTime timepoint)
        {
            return Convert.ToInt64(timepoint.Subtract(new DateTime(1970, 01, 01)).TotalMilliseconds);
        }

        /// <summary>
        /// Convert long to DateTime
        /// </summary>
        /// <param name="tick"></param>
        /// <returns></returns>
        public static DateTime ConvertTick2DateTime(long tick)
        {
            return new DateTime(1970, 01, 01).AddMilliseconds(tick);
        }
        #endregion
    }
}
