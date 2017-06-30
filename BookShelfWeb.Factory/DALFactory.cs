/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Factory
 * Project name: .BookShelfWeb.Factory
 * File name: DALFactory.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShelfWeb.IDAL;

namespace BookShelfWeb.Factory
{
    /// <summary>
    /// DAL factory to produce DAL objects
    /// </summary>
    public class DALFactory : FactoryTemplate<DALFactory>
    {
        #region constructors

        /// <summary>
        /// constructor, you can change AppSetting key name here
        /// </summary>
        public DALFactory()
        {
            _lowerLayerBinaryPath = "DAL";
            _lowerLayerBinaryPathCacheName = "DALName";
        }

        #endregion constructors

        #region Retrieve User Interface
        /// <summary>
        /// Factory method to get IBookShelfUserDAL Interface
        /// </summary>
        /// <typeparam name="T">implement of IBookShelfUserDAL.Constructor with various parameter(s) is required</typeparam>
        /// <returns>IBookShelfUserDAL</returns>
        public static IBookShelfUserDAL GetUserInterface<T>(int userId, string fullName, string password)
        {         
            return CreateInstance<IBookShelfUserDAL, T>(new object[] { userId, fullName, password }, false);
        }

        public static IBookShelfUserDAL GetUserInterface<T>(int userId)
        {            
            return CreateInstance<IBookShelfUserDAL, T>(new object[] { userId }, false);
        }

        public static IBookShelfUserDAL GetUserInterface<T>(string fullName)
        {            
            return CreateInstance<IBookShelfUserDAL, T>(new object[] { fullName }, false);
        }

        public static IBookShelfUserDAL GetUserInterface<T>()
        {         
            return CreateInstance<IBookShelfUserDAL, T>(new object[] { }, false);
        }

        #endregion Retrieve User Interface

        #region Retrieve Book Interface
        /// <summary>
        /// Factory method to get IBookShelfModelMembershipDAL Interface
        /// </summary>
        /// <typeparam name="T">implement of IBookShelfModelMembershipDAL.Constructor with two parameter(int,int) is required</typeparam>
        /// <returns>IBookShelfModelMembershipDAL</returns>
        public static IBookShelfBookDAL GetBookInterface<T>(int bookID, string isbn, string bookName, string authorName)
        {         
            return CreateInstance<IBookShelfBookDAL, T>(new object[] { bookID, isbn, bookName, authorName }, false);
        }

        public static IBookShelfBookDAL GetBookInterface<T>(int bookID)
        {          
            return CreateInstance<IBookShelfBookDAL, T>(new object[] { bookID }, false);
        }

        public static IBookShelfBookDAL GetBookInterface<T>()
        {            
            return CreateInstance<IBookShelfBookDAL, T>(new object[] { }, false);
        }
        #endregion Retrieve Book Interface

    }
}
