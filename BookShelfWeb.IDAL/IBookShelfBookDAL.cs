/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .DataAccess
 * Project name: .BookShelfWeb.IDAL
 * File name: IBookShelfBookDAL.cs
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
    /// Data Access Layer interface to operate on book entity
    /// </summary>
    public interface IBookShelfBookDAL
    {
        #region Add

        /// <summary>
        /// add book
        /// </summary>
        /// <param name="bookEntity">book</param>
        /// <returns>Affected row count</returns>
        int AddBook(BookShelfBook bookEntity);

        #endregion Add

        #region Delete

        /// <summary>
        /// Delete book by book id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>Affected row count</returns>
        int DeleteBook(int bookID);

        #endregion Delete

        #region Update

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="userEntity">book</param>
        /// <returns>Affected row count</returns>
        int UpdateBook(BookShelfBook bookEntity);

        #endregion Update

        #region Get

        /// <summary>
        /// Get book by book id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null if not found</returns>
        BookShelfBook GetBookbyID(int bookID);

        /// <summary>
        /// Get book by book name
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <returns>null if not found</returns>        
        BookShelfBook GetBookbyName(string bookName);

        /// <summary>
        /// get all book list
        /// </summary>
        /// <returns>empty list if not found</returns>
        IList<BookShelfBook> GetBooks();

        /// <summary>
        /// get all loaned book list
        /// </summary>
        /// <param name="bookStatus">book status</param>
        /// <returns></returns>
        IList<BookShelfBook> GetLoanedBooks();

        /// <summary>
        /// get all returned book list
        /// </summary>
        /// <param name="bookStatus">book status</param>
        /// <returns></returns>
        IList<BookShelfBook> GetReturnedBooks();

        #endregion Get
    }
}
