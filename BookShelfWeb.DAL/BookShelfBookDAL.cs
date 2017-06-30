/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .DataAccess
 * Project name: .BookShelfWeb.DAL
 * File name: BookShelfBookDAL.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using BookShelfWeb.IDAL;
using BookShelfWeb.BookShelfModel;
using BookShelfWeb.DataAccessHelper;
using System.Data.SqlClient;

namespace BookShelfWeb.DAL
{
    /// <summary>
    ///  BookShelfBook data access layer manipulations
    /// </summary>
    public class BookShelfBookDAL : IBookShelfBookDAL
    {
        #region member variables

        public BookShelfBook bsb = new BookShelfBook();

        #endregion member variables

        #region constructors

        /// <summary>
        /// Ctor**
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="isbn"></param>
        /// <param name="bookName"></param>
        public BookShelfBookDAL(int bookID, string isbn, string bookName, string authorName, int userID)
        {
            bsb.BookID = bookID;
            bsb.Isbn = isbn;
            bsb.BookName = bookName;
            bsb.AuthorName = authorName;
            bsb.UserID = userID;
        }

        /// <summary>
        /// Ctor**
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="isbn"></param>
        /// <param name="bookName"></param>
        /// <param name="authorName"></param>
        public BookShelfBookDAL(int bookID, string isbn, string bookName, string authorName)
        {
            bsb.BookID = bookID;
            bsb.Isbn = isbn;
            bsb.BookName = bookName;
            bsb.AuthorName = authorName;
        }

        /// <summary>
        /// Ctor**
        /// </summary>
        /// <param name="bookID"></param>
        public BookShelfBookDAL(int bookID)
        {
            bsb.BookID = bookID;
        }

        /// <summary>
        /// Ctor**
        /// </summary>
        public BookShelfBookDAL()
        {
        }

        #endregion constructors

        #region Add

        /// <summary>
        /// Adding book
        /// </summary>
        /// <param name="bookEntity">book</param>
        /// <returns></returns>
        public int AddBook(BookShelfBook bookEntity)
        {
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.INSERT,
                   typeof(BookShelfBook),
                "Book",
                null,
                new string[] { "isbn", "bookName", "authorName" },
                new object[] { bookEntity.Isbn, bookEntity.BookName, bookEntity.AuthorName });
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetInsertSql(),
                objCommandHelper.GetParameters());
        }

        #endregion Add

        #region Update

        /// <summary>
        /// Update book 
        /// </summary>
        /// <param name="bookEntity">book</param>
        /// <returns>Affected row count</returns>
        public int UpdateBook(BookShelfBook bookEntity)
        {
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.UPDATE,
                   typeof(BookShelfBook),
                "Book",
                null,
                new string[] { "isbn", "bookName", "authorName" },
                new object[] { bookEntity.Isbn, bookEntity.BookName, bookEntity.AuthorName });

            objCommandHelper.AddAditionalParameters("bookID = @bookID", new string[] { "bookID" }, new object[] { bookEntity.BookID });

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetUpdateSql(),
                objCommandHelper.GetParameters());
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Delete book by book id
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns>Affected row count</returns>
        public int DeleteBook(int bookID)
        {
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.DELETE,
                   typeof(BookShelfBook),
                "Book",
                null,
                new string[] { "bookID" },
                new object[] { bookID });

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetDeleteSql(),
                objCommandHelper.GetParameters());
        }

        #endregion Delete

        #region Get

        /// <summary>
        /// Get book by book id
        /// </summary>
        /// <param name="bookID">book id</param>
        /// <returns>null if not found</returns>
        public BookShelfBook GetBookbyID(int bookID)
        {
            //build sql script
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfBook),
                "Book",
                null,
                new string[] { "bookID" },
                new object[] { bookID });

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetSelectSql(),
                objCommandHelper.GetParameters());
            dr.Read();
            BookShelfBook bsb = new BookShelfBook();
            bsb.BookID = dr.GetInt32(0);
            bsb.Isbn = dr.GetString(1);
            bsb.BookName = dr.GetString(2);
            bsb.AuthorName = dr.GetString(3);
            return bsb;

        }

        /// <summary>
        /// Get book by book name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public BookShelfBook GetBookbyName(string bookName)
        {
            //build sql script
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfBook),
                "Book",
                null,
                new string[] { "bookName" },
                new object[] { bookName });

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetSelectSql(),
                objCommandHelper.GetParameters());
            dr.Read();
            BookShelfBook bsb = new BookShelfBook();
            bsb.BookID = dr.GetInt32(0);
            bsb.Isbn = dr.GetString(1);
            bsb.BookName = dr.GetString(2);
            bsb.AuthorName = dr.GetString(3);
            return bsb;
        }

        /// <summary>
        /// get all book list
        /// </summary>
        /// <returns>empty list if not found</returns>
        public IList<BookShelfBook> GetBooks()
        {
            List<BookShelfBook> bookEntityList = new List<BookShelfBook>();
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfBook), "Book", null, null, null);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction, CommandType.Text, objCommandHelper.GetSelectSql(), objCommandHelper.GetParameters()))
            {
                while (dr.Read())
                {
                    BookShelfBook tmpBook = new BookShelfBook();

                    tmpBook.BookID = dr.GetInt32(0);
                    tmpBook.Isbn = dr.GetString(1);
                    tmpBook.BookName = dr.GetString(2);
                    tmpBook.AuthorName = dr.GetString(3);
                    bookEntityList.Add(tmpBook);
                }
            }
            return bookEntityList;
        }

        /// <summary>
        /// Get boaned books, by check of null nature, if not null, the book is loaned else
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<BookShelfBook> GetLoanedBooks()
        {
            List<BookShelfBook> loanedBookEntityList = new List<BookShelfBook>();
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                //typeof(BookShelfBook), "Book", null, new string[] { "bookStatus" }, new object[] { bookStatus });
                typeof(BookShelfBook), "Book", null, null, null);
            objCommandHelper.AddAditionalParameters("bookStatus = 1", null, null);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction, CommandType.Text, objCommandHelper.GetSelectSql(), objCommandHelper.GetParameters()))
            {
                while (dr.Read())
                {
                    if (dr.GetInt32(5) == 1)
                    {
                        BookShelfBook tmpBook = new BookShelfBook();
                        tmpBook.BookID = dr.GetInt32(0);
                        tmpBook.Isbn = dr.GetString(1);
                        tmpBook.BookName = dr.GetString(2);
                        tmpBook.AuthorName = dr.GetString(3);
                        tmpBook.UserID = dr.GetInt32(4);
                        tmpBook.BookStatus = dr.GetInt32(5);
                        loanedBookEntityList.Add(tmpBook);
                    }
                }
            }
            return loanedBookEntityList;
        }

        public IList<BookShelfBook> GetReturnedBooks()
        {
            List<BookShelfBook> returnedBookEntityList = new List<BookShelfBook>();
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
              typeof(BookShelfBook), "Book", null, null, null);
            objCommandHelper.AddAditionalParameters("bookStatus = 2", null, null);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction, CommandType.Text, objCommandHelper.GetSelectSql(), objCommandHelper.GetParameters()))
            {
                while (dr.Read())
                {
                    if (dr.GetInt32(5) == 2)
                    {
                        BookShelfBook tmpBook = new BookShelfBook();
                        tmpBook.BookID = dr.GetInt32(0);
                        tmpBook.Isbn = dr.GetString(1);
                        tmpBook.BookName = dr.GetString(2);
                        tmpBook.AuthorName = dr.GetString(3);
                        tmpBook.UserID = dr.GetInt32(4);
                        tmpBook.BookStatus = dr.GetInt32(5);
                        returnedBookEntityList.Add(tmpBook);
                    }
                }
            }
            return returnedBookEntityList;
        }

        #endregion Get
    }
}
