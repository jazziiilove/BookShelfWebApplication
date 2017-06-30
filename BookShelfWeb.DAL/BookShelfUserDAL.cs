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
using System.Data;
using System.Data.SqlClient;
using BookShelfWeb.IDAL;
using BookShelfWeb.BookShelfModel;
using BookShelfWeb.DataAccessHelper;

namespace BookShelfWeb.DAL
{
    /// <summary>
    /// BookShelfUser data access layer manipulations
    /// </summary>
    public class BookShelfUserDAL : IBookShelfUserDAL
    {
        #region member variables

        public BookShelfUser bsu = new BookShelfUser();

        #endregion member variables

        #region constructors

        /// <summary>
        /// Ctor**
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="fullName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        public BookShelfUserDAL(int userID, string fullName, string password, string email, string address, string city)
        {
            bsu.UserID = userID;
            bsu.FullName = fullName;
            bsu.Password = password;
            bsu.Email = email;
            bsu.Address = address;
            bsu.City = city;
        }
    
        /// <summary>
        /// Ctor**
        /// </summary>
        /// <param name="userID"></param>
        public BookShelfUserDAL(int userID)
        {
            bsu.UserID = userID;
        }

        /// <summary>
        /// Ctor**
        /// </summary>
        public BookShelfUserDAL()
        {

        }

        #endregion constructors

        #region Add

        /// <summary>
        /// Adding user
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>affected row count</returns>
        public int AddUser(BookShelfUser userEntity)
        {
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.INSERT,
                   typeof(BookShelfUser),
                "User",
                null,
                new string[] { "fullName", "password", "email", "address", "city" },
                new object[] { userEntity.FullName, userEntity.Password, userEntity.Email, userEntity.Address, userEntity.City });
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetInsertSql(),
                objCommandHelper.GetParameters());
        }

        #endregion Add

        #region Update

        /// <summary>
        /// Update user 
        /// </summary>
        /// <param name="userEntity">user</param>
        /// <returns>Affected row count</returns>
        public int UpdateUser(BookShelfUser userEntity)
        {
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.UPDATE,
                  typeof(BookShelfUser),
               "User",
               null,
               new string[] { "fullName", "password", "email", "address", "city" },
               new object[] { userEntity.FullName, userEntity.Password, userEntity.Email, userEntity.Address, userEntity.City });

            objCommandHelper.AddAditionalParameters("userID = @userID", new string[] { "userID" }, new object[] { userEntity.UserID });

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetUpdateSql(),
                objCommandHelper.GetParameters());
        }

        /// <summary>
        /// Update book membership of the user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="bookEntity">book</param>
        /// <param name="action">action</param>
        /// <returns></returns>
        public int UpdateBookMembership(int userID, BookShelfBook bookEntity, string action)
        {
            string bookName = bookEntity.BookName;
            SqlCommandHelper objCommandHelper = null;
            if (action == "Loan")
            {
                objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.UPDATE,
                    typeof(BookShelfBook),
                 "Book",
                 null,
                 new string[] { "userID", "bookStatus" },
                 new object[] { userID, 1 });

            }
            else
            {
                objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.UPDATE,
                  typeof(BookShelfBook),
               "Book",
               null,
               new string[] { "userID", "bookStatus" },
               new object[] { userID, 2 });
            }
            objCommandHelper.AddAditionalParameters("bookName = @bookName", new string[] { "bookName" }, new object[] { bookName });

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetUpdateSql(),
                objCommandHelper.GetParameters());
        }

        #endregion Update

        #region Delete

        /// <summary>
        /// Delete user by user id
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>Affected row count</returns>
        public int DeleteUser(int userID)
        {
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.DELETE,
                  typeof(BookShelfUser),
               "User",
               null,
               new string[] { "userID" },
               new object[] { userID });
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetDeleteSql(),
                objCommandHelper.GetParameters());
        }

        #endregion Delete

        #region Get

        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>null if not found</returns>
        public BookShelfUser GetUserbyID(int userID)
        {
            //build sql script
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfUser),
                "User",
                null,
                new string[] { "userID" },
                new object[] { userID });

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetSelectSql(),
                objCommandHelper.GetParameters());

            BookShelfUser bsu = new BookShelfUser();
            dr.Read();
            bsu.UserID = dr.GetInt32(0);
            bsu.FullName = dr.GetString(1);
            bsu.Password = dr.GetString(2);
            bsu.Email = dr.GetString(3);
            bsu.Address = dr.GetString(4);
            bsu.City = dr.GetString(5);
            return bsu;
        }

        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name="fullName">full name</param>
        /// <returns>BookShelfUser, null if not found</returns>
        public BookShelfUser GetUserbyName(string fullName)
        {
            //build sql script
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfUser),
                "User",
                null,
                new string[] { "fullName" },
                new object[] { fullName });

            SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction,
                CommandType.Text,
                objCommandHelper.GetSelectSql(),
                objCommandHelper.GetParameters());

            BookShelfUser bsu = new BookShelfUser();
            dr.Read();
            bsu.UserID = dr.GetInt32(0);
            bsu.FullName = dr.GetString(1);
            bsu.Password = dr.GetString(2);
            bsu.Email = dr.GetString(3);
            bsu.Address = dr.GetString(4);
            bsu.City = dr.GetString(5);
            return bsu;
        }



        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns>empty list if not found</returns>
        public IList<BookShelfUser> GetUsers()
        {
            List<BookShelfUser> userEntityList = new List<BookShelfUser>();
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfUser), "User", null, null, null);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction, CommandType.Text, objCommandHelper.GetSelectSql(), objCommandHelper.GetParameters()))
            {
                while (dr.Read())
                {
                    BookShelfUser tmpUser = new BookShelfUser();
                    tmpUser.UserID = dr.GetInt32(0);
                    tmpUser.FullName = dr.GetString(1);
                    tmpUser.Password = dr.GetString(2);
                    tmpUser.Email = dr.GetString(3);
                    tmpUser.Address = dr.GetString(4);
                    tmpUser.City = dr.GetString(5);
                    userEntityList.Add(tmpUser);
                }

            }
            return userEntityList;
        }

        /// <summary>
        /// get all user table content list, POSSIBLE Debugging Use
        /// </summary>
        /// <returns>empty list if not found</returns>
        public IList<BookShelfUser> GetUserTableContent()
        {
            List<BookShelfUser> userTableEntityList = new List<BookShelfUser>();
            SqlCommandHelper objCommandHelper = new SqlCommandHelper(SqlCommandHelper.SqlCommandType.SELECT,
                typeof(BookShelfUser), "User", null, null, null);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringBookShelfTransaction, CommandType.Text, objCommandHelper.GetSelectSql(), objCommandHelper.GetParameters()))
            {

                while (dr.Read())
                {
                    BookShelfUser tmpUser = new BookShelfUser();
                    tmpUser.UserID = dr.GetInt32(0);
                    tmpUser.FullName = dr.GetString(1);
                    tmpUser.Password = dr.GetString(2);
                    tmpUser.Email = dr.GetString(3);
                    tmpUser.Address = dr.GetString(4);
                    tmpUser.City = dr.GetString(5);
                }
            }
            return userTableEntityList;
        }

        /// <summary>
        /// POSSIBLE Debugging Use
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="bookEntity"></param>
        /// <returns></returns>
        public int GetBookMembership(int userID, BookShelfBook bookEntity)
        {
            //TODO for POSSIBLE Debugging Use
            return 1;
        }

        #endregion Get
    }
}
