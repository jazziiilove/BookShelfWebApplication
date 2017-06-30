/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Util
 * Project name: .BookShelfWeb.CacheManager
 * File name: CacheAccess.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace BookShelfWeb.CacheManager
{
    /// <summary>
    /// This class is designed to do caching for .BookShelfWeb,
    /// it is the only public class in CacheManager module,
    /// all public methods should be static
    /// </summary>
    public sealed class CacheAccess
    {
        #region Public Method

        /// <summary>
        /// get Cached object by key, return null if not found
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>null if not found</returns>
        public static object GetFromCache(string key)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache.Get(key);
        }

        /// <summary>
        /// key should be not empty and not null, so is for value,
        /// otherwise return false
        /// Note: duplicated key can be saved
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns>true if success, otherwise false</returns>
        public static bool SaveToCache(string key, object value)
        {
            if (null == key || null == value || String.IsNullOrEmpty(key))
            {
                return false;
            }
            Cache objCache = HttpRuntime.Cache;
            try
            {
                object objLock = new object();
                lock (objLock)
                {
                    objCache.Insert(key, value);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion Public Method
    }

}

