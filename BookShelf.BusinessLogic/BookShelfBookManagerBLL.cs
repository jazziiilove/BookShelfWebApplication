/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .BusinessLogic
 * Project name: .BookShelfWeb.BLL
 * File name: BookShelfBookManagerBLL.cs
 * Status: Finished 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelf.IBLL;
using BookShelfWeb.BookShelfModel;
using BookShelfWeb.Factory;
using BookShelfWeb.DAL;
using BookShelfWeb.IDAL;

namespace BookShelf.BusinessLogic
{
    /// <summary>
    /// BookShelfBook business layer manipulations
    /// </summary>
    public class BookShelfBookManagerBLL : IBookShelfBookManagerBLL
    {
        #region Add

        /// <summary>
        /// Add a book
        /// </summary>
        /// <param name="bookEntity">book</param>
        /// <returns>true if success, false otherwise</returns>
        public bool AddBook(BookShelfBook bookEntity)
        {
            try
            {
                return DALFactory.GetBookInterface<BookShelfBookDAL>().AddBook(bookEntity) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Add

        #region Update

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns>true if success, false otherwise</returns>
        public bool UpdateBook(BookShelfBook bookEntity)
        {
            try
            {
                return DALFactory.GetBookInterface<BookShelfBookDAL>().UpdateBook(bookEntity) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="bookID">book id</param>
        /// <returns>true if success, false otherwise</returns>
        public bool DeleteBook(int bookID)
        {
            try
            {
                IBookShelfBookDAL objBook = DALFactory.GetBookInterface<BookShelfBookDAL>();
                return objBook.DeleteBook(bookID) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Delete

        #region Get

        /// <summary>
        /// Get all book list
        /// </summary>
        /// <returns>list of books, empty list if not found</returns>
        public IList<BookShelfBook> GetBooks()
        {
            return (DALFactory.GetBookInterface<BookShelfBookDAL>().GetBooks());
        }

        /// <summary>
        /// Get book by book id
        /// </summary>
        /// <param name="bookID">book id</param>
        /// <returns>null if not found</returns>
        public BookShelfBook GetBookbyID(int bookID)
        {
            return DALFactory.GetBookInterface<BookShelfBookDAL>(bookID).GetBookbyID(bookID);
        }

        /// <summary>
        /// Get book by book name
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <returns>null if not found</returns>
        public BookShelfBook GetBookbyName(string bookName)
        {
            return DALFactory.GetBookInterface<BookShelfBookDAL>().GetBookbyName(bookName);
        }

        /// <summary>
        /// Get loaned book list
        /// </summary>
        /// <returns>list of books, empty list if not found</returns>
        public IList<BookShelfBook> GetLoanedBooks()
        {
            return (DALFactory.GetBookInterface<BookShelfBookDAL>().GetLoanedBooks());
        }

        /// <summary>
        /// Get returned book list
        /// </summary>
        /// <returns>list of books, empty list if not found</returns>
        public IList<BookShelfBook> GetReturnedBooks()
        {
            return (DALFactory.GetBookInterface<BookShelfBookDAL>().GetReturnedBooks());
        }
        
        #endregion Get
    }
}
