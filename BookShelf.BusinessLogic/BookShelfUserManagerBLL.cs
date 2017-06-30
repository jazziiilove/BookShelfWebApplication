/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .BusinessLogic
 * Project name: .BookShelfWeb.BLL
 * File name: BookShelfUserManagerBLL.cs
 * Status: Finished 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelfWeb.BookShelfModel;
using BookShelf.IBLL;
using BookShelfWeb.DAL;
using BookShelfWeb.Factory;
using BookShelfWeb.IDAL;

namespace BookShelf.BusinessLogic
{
    /// <summary>
    /// BookShelfUser business layer manipulations
    /// </summary>
    public class BookShelfUserManagerBLL : IBookShelfUserManagerBLL
    {
        #region Add

        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>true if success, false otherwise</returns>
        public bool AddUser(BookShelfUser userEntity)
        {
            try
            {
                return DALFactory.GetUserInterface<BookShelfUserDAL>().AddUser(userEntity) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Add BookMembership for a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <returns>true if success, false otherwise</returns>
        public bool AddBookMembership(int userID, BookShelfBook bookEntity)
        {
            try
            {
                IBookShelfUserDAL objUser = DALFactory.GetUserInterface<BookShelfUserDAL>();
                BookShelfUser objUserEntity = objUser.GetUserbyID(userID);

                if (null != objUserEntity)
                {
                    objUserEntity.Books.Add(bookEntity);

                    return objUser.UpdateUser(objUserEntity) > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Add

        #region Update

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>true if success, false otherwise</returns>
        public bool UpdateUser(BookShelfUser userEntity)
        {
            try
            {
                return DALFactory.GetUserInterface<BookShelfUserDAL>().UpdateUser(userEntity) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Update BookMembership by user id
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <param name="action">action</param>
        /// <returns>true if success, false otherwise</returns>
        public bool UpdateBookMembership(int userID, BookShelfBook bookEntity, string action)
        {
            try
            {
                if (DALFactory.GetUserInterface<BookShelfUserDAL>(userID).UpdateBookMembership(userID, bookEntity, action) > 0)
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>true if success, false otherwise</returns>
        public bool DeleteUser(int userID)
        {
            try
            {
                IBookShelfUserDAL objUser = DALFactory.GetUserInterface<BookShelfUserDAL>();
                return objUser.DeleteUser(userID) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Book for specific user/Return the book for the given user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <returns>true if success, false otherwise</returns>
        public bool DeleteBookMembership(int userID, BookShelfBook bookEntity)
        {
            try
            {
                IBookShelfUserDAL objUser = DALFactory.GetUserInterface<BookShelfUserDAL>();
                BookShelfUser objUserEntity = objUser.GetUserbyID(userID);

                if (null != objUserEntity)
                    return objUserEntity.Books.Remove(bookEntity);
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Delete

        #region Get

        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>List of users, null if not found</returns>
        public BookShelfUser GetUserbyID(int userID)
        {
            return DALFactory.GetUserInterface<BookShelfUserDAL>(userID).GetUserbyID(userID);
        }

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="fullName">full name</param>
        /// <returns>BookShelfUser, null if not found</returns>
        public BookShelfUser GetUserbyName(string fullName)
        {
            return DALFactory.GetUserInterface<BookShelfUserDAL>().GetUserbyName(fullName);
        }

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>list of users, empty list if not found</returns>
        public IList<BookShelfUser> GetUsers()
        {
            return (DALFactory.GetUserInterface<BookShelfUserDAL>().GetUsers());
        }

        /// <summary>
        /// Get BookMembership by user id
        /// </summary>
        /// <param name="bookEntity">book entity</param>
        /// <returns>true if success, false otherwise</returns>
        public bool GetBookMembership(int userID, BookShelfBook bookEntity)
        {
            try
            {
                if (DALFactory.GetUserInterface<BookShelfUserDAL>().GetBookMembership(userID, bookEntity) > 0)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        #endregion Get
    }
}
