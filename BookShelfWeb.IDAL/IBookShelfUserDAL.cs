/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .DataAccess
 * Project name: .BookShelfWeb.DAL
 * File name: BookShelfUserDAL.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelfWeb.BookShelfModel;

namespace BookShelfWeb.IDAL
{
    /// <summary>
    /// Data Access Layer interface to operate on user entity
    /// </summary>
    public interface IBookShelfUserDAL
    {
        #region Add

        /// <summary>
        /// add user
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>Affected row count</returns>
        int AddUser(BookShelfUser userEntity);

        #endregion Add

        #region Update

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>Affected row count</returns>
        int UpdateUser(BookShelfUser userEntity);

        /// <summary>
        /// Update book membership of the user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <param name="action">action</param>
        /// <returns></returns>
        int UpdateBookMembership(int userID, BookShelfBook bookEntity, string action);

        /// <summary>
        /// Get book membership of the user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <returns></returns>    
        int GetBookMembership(int userID, BookShelfBook bookEntity);

        IList<BookShelfUser> GetUserTableContent();

        #endregion Update

        #region Delete

        /// <summary>
        /// Delete user by user id
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>Affected row count</returns>
        int DeleteUser(int userID);

        #endregion Delete

        #region Get

        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>null if not found</returns>
        BookShelfUser GetUserbyID(int userID);

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="fullName">full name</param>
        /// <returns>BookShelfUser, null if not found</returns>
        BookShelfUser GetUserbyName(string fullName);

        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns>empty list if not found</returns>
        IList<BookShelfUser> GetUsers();

        #endregion Get

    }
}
