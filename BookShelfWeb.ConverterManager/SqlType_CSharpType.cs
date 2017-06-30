/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Util
 * Project name: .BookShelfWeb.ConverterManager
 * File name: SqlType_CSharpType.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BookShelfWeb.ConverterManager
{
    /// <summary>
    /// Convertion between SqlType and CSharp Type .
    /// this class can only be internally used.
    /// </summary>
    public class SqlType_CSharpType
    {
        #region member variables

        /// <summary>
        /// This mapping is just for common data type.
        /// The relationship between CSharp Type and SqlDbType is multiple-multiple.
        /// Please take care when there is need to map String to nvarchar or ntext, etc.
        /// </summary>
        private Dictionary<Type, SqlDbType> _csharpType_SqlType_map = new Dictionary<Type, SqlDbType>()
        {
            //basic data type
            {typeof(Int64),SqlDbType.BigInt},
            {typeof(Object),SqlDbType.Binary},
            {typeof(Boolean),SqlDbType.Bit},
            {typeof(String),SqlDbType.Char},
            {typeof(DateTime),SqlDbType.DateTime},
            {typeof(Decimal),SqlDbType.Decimal},
            {typeof(Double),SqlDbType.Float},
            {typeof(Int32),SqlDbType.Int},
            {typeof(Single),SqlDbType.Real},
            {typeof(Int16),SqlDbType.SmallInt},
            {typeof(Byte),SqlDbType.TinyInt},
            
        };

        #endregion member variables

        #region Public Methods

        /// <summary>
        /// Convert C# type to SqlType (used in SqlParameter), e.g. an integer will be defined as "int" or "Int32" for basic variable
        /// while for SqlType it is "SqlType.Int"
        /// </summary>
        /// <param name="type">C# type</param>
        /// <returns>Converted SqlType</returns>
        public SqlDbType CSharpType2SqlType(Type type)
        {
            return _csharpType_SqlType_map[type];
        }
        /// <summary>
        /// Convert SqlType(used in SqlParameter) to C# type, e.g. an integer will be defined as "SqlType.Int" for SqlType
        /// while for basic variable it is "int" or "Int32"
        /// </summary>
        /// <param name="sqlType">SqlType</param>
        /// <returns>basic C# type</returns>
        public Type SqlType2CSharpType(SqlDbType sqlType)
        {
            var query = from d in _csharpType_SqlType_map
                        where d.Value == sqlType
                        select d.Key;
            return query.SingleOrDefault();

        }

        #endregion Public Methods
    }
}
