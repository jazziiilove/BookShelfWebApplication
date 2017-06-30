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
    /// BookShelfBook business layer interface
    /// </summary>
    public interface IBookShelfBookManagerBLL
    {
        #region Add

        /// <summary>
        /// Add new Book
        /// </summary>
        /// <param name="bookEntity">book</param>
        /// <returns>true if success, false otherwise</returns>        
        bool AddBook(BookShelfBook bookEntity);

        #endregion Add

        #region Delete

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="bookID">book id</param>
        /// <returns>true if success, false otherwise</returns>
        bool DeleteBook(int bookID);

        #endregion Delete

        #region Update

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="bookEntity">book</param>
        /// <returns>true if success, false otherwise</returns>
        bool UpdateBook(BookShelfBook bookEntity);

        #endregion Update

        #region Get

        /// <summary>
        /// Get all book list
        /// </summary>
        /// <returns>list of books, empty list if not</returns>
        IList<BookShelfBook> GetBooks();

        /// <summary>
        /// Get book entity by book id
        /// </summary>
        /// <param name="bookID">book id</param>
        /// <returns>null if not found</returns>
        BookShelfBook GetBookbyID(int bookID);

        /// <summary>
        /// Get book entity by book id
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <returns></returns>
        BookShelfBook GetBookbyName(string bookName);

        /// <summary>
        /// Get loaned book list
        /// </summary>
        /// <param name="bookStatus">book status</param>
        /// <returns>list of books, empty list if not</returns>
        IList<BookShelfBook> GetLoanedBooks();

        /// <summary>
        /// Get returned book list
        /// </summary>
        /// /// <param name="bookStatus">book status</param>
        /// <returns>list of books, empty list if not</returns>
        IList<BookShelfBook> GetReturnedBooks();

        #endregion Get
    }
}
