/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Entity
 * Project name: .BookShelfWeb.BookShelfModel
 * File name: BookShelfUser.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfWeb.BookShelfModel
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class BookShelfUser
    {
        #region member variables
        /// <summary>
        /// user id
        /// </summary>
        private int _UserID;

        /// <summary>
        /// user id accessor
        /// </summary>
        public int UserID { get; set; }

        //Can be converted to name and last name member variables in future, for simplicity, it's done like this currently

        /// <summary>
        /// full name
        /// </summary>
        private string _FullName;

        /// <summary>
        /// full name accessor
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// password
        /// </summary>
        private string _Password;

        /// <summary>
        /// password accessor
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Books owned collection
        /// </summary>        
        private BookShelfBookCollection _Books;

        /// <summary>
        /// Books owned collection accessor
        /// </summary>
        public BookShelfBookCollection Books { get; set; }
        
        /// <summary>
        /// email
        /// </summary>
        private string _Email;

        /// <summary>
        /// email accessor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// address
        /// </summary>
        private string _Address;

        /// <summary>
        /// address accessor
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// city
        /// </summary>
        private string _City;

        /// <summary>
        /// city accessor
        /// </summary>
        public string City { get; set; }

        /*
        /// <summary>
        /// Is Edited
        /// </summary>
        public bool IsEdited;

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted;

        /// <summary>
        /// Is New
        /// </summary>
        public bool IsNew;
        */

        #endregion member variables
    }
}
