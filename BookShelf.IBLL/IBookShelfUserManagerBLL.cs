/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .BusinessLogic
 * Project name: .BookShelfWeb.IBLL
 * File name: IBookShelfUserManagerBLL.cs
 * Status: Finished 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelfWeb.BookShelfModel;

namespace BookShelf.IBLL
{
    /// <summary>
    /// BookShelfUser business layer interface
    /// </summary>
    public interface IBookShelfUserManagerBLL
    {
        #region Add

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="userEntity">user entity</param>
        /// <returns>true if success, false otherwise</returns>        
        bool AddUser(BookShelfUser userEntity);

        /// <summary>
        /// Add BookMembership for a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="book">book</param>
        /// <returns></returns>
        bool AddBookMembership(int userID, BookShelfBook book);

        #endregion Add

        #region Delete

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>true if success, false otherwise</returns>
        bool DeleteUser(int userID);

        /// <summary>
        /// Delete BookMembership for a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="book">book</param>
        /// <returns>true if success, false otherwise</returns>
        bool DeleteBookMembership(int userID, BookShelfBook book);

        #endregion Delete

        #region Update

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>true if success, false otherwise</returns>
        bool UpdateUser(BookShelfUser userEntity);

        /// <summary>
        /// Update BookMembership
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <param name="action">action type; loan or return</param>
        /// <returns></returns>
        bool UpdateBookMembership(int userID, BookShelfBook bookEntity, string action);

        #endregion Update

        #region Get

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>list of users, empty list if not</returns>
        IList<BookShelfUser> GetUsers();

        /// <summary>
        /// Get UserEntity by UserID
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>null if not found</returns>
        BookShelfUser GetUserbyID(int userID);

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="fullName">full name</param>
        /// <returns>BookShelfUser, null if not found</returns>
        BookShelfUser GetUserbyName(string fullName);

        /// <summary>
        /// Get Book by bookID
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <returns>null if not found</returns>
        bool GetBookMembership(int userID, BookShelfBook bookEntity);

        #endregion Get
    }
}
