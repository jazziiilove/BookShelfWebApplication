/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Entity
 * Project name: .BookShelfWeb.BookShelfModel
 * File name: BookShelfBookCollection.cs
 * Status: Ongoing - Future use 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfWeb.BookShelfModel
{
    /// <summary>
    /// BookCollection entity
    /// </summary>
    [Serializable]
    public class BookShelfBookCollection : List<BookShelfBook>
    {
        #region Add
        /// <summary>
        /// Add book, if not exists, insert it, otherwise do nothing
        /// </summary>
        /// <param name="newBookEntity"></param>
        /// <returns>always return true</returns>
        public bool AddBook(BookShelfBook newBookEntity)
        {
            if (!this.Exists(t => (t.BookID == newBookEntity.BookID)))
            {
                this.Add(newBookEntity);
            }
            return true;
        }

        #endregion Add

        #region Delete

        /// <summary>
        /// Delete book, if not exists, do nothing
        /// </summary>
        /// <param name="newBookEntity"></param>
        /// <returns>always return true</returns>
        public bool DeleteBook(BookShelfBook newBookEntity)
        {
            if (!this.Exists(t => (t.BookID == newBookEntity.BookID)))
            {
                this.Remove(newBookEntity);
            }
            return true;
        }

        #endregion Delete
    }
}
