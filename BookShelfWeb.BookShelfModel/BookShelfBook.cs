/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Entity
 * Project name: .BookShelfWeb.BookShelfModel
 * File name: BookShelfBook.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfWeb.BookShelfModel
{
    /// <summary>
    /// Book entity
    /// </summary>
    public class BookShelfBook
    {
        #region member variables

        /// <summary>
        /// book id
        /// </summary>
        private int _BookID;

        /// <summary>
        /// book id accessor
        /// </summary>
        public int BookID { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        private int _UserID;

        /// <summary>
        /// user id accessor
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// isbn
        /// </summary>
        private string _Isbn;

        /// <summary>
        /// isbn accessor
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// book name
        /// </summary>
        private string _BookName;

        /// <summary>
        /// book name accessor
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// author name
        /// </summary>
        private string _AuthorName;

        /// <summary>
        /// author name accessor
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// book status
        /// </summary>
        private int _BookStatus;

        /// <summary>
        /// book status accessor
        /// </summary>
        public int BookStatus { get; set; }

        #endregion member variables
    }
}
