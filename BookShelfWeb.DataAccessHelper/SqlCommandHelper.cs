/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .DataAccess
 * Project name: .BookShelfWeb.DataAccessHelper
 * File name: SqlCommandHelper.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BookShelfWeb.ConverterManager;

namespace BookShelfWeb.DataAccessHelper
{
    /// <summary>
    /// A customized SqlCommandHelper modified by Baran Topal
    /// </summary>
    public class SqlCommandHelper
    {
        #region enums, strucuts

        public enum SqlCommandType
        {
            SELECT = 0,
            INSERT,
            UPDATE,
            DELETE
        }

        #endregion enums, strucuts

        #region member variables

        private SqlCommandType _commandType;
        private string _tableName;
        private string _selectSql;
        private string _insertSql;
        private string _updateSql;
        private string _deleteSql;
        private bool _bDeleteCoditionClauseExists = false;
        private bool _bSelectCoditionClauseExists = false;
        private bool _bUpdateCoditionClauseExists = false;
        private List<SqlParameter> _paramList = new List<SqlParameter>();

        private Type _entityType;
        private List<string> _paramColumnList = new List<string>();
        private List<object> _paramValueList = new List<object>();
        private List<string> _selectColumnList = new List<string>();

        #endregion member variables

        #region constructors

        /// <summary>
        /// Each param name in paramColumnList should be consistent with entityType definition
        /// </summary>
        /// <param name="commandType">insert/select/update/delete</param>
        /// <param name="entityType">type of Entity</param>
        /// <param name="tableName">table name</param>
        /// <param name="selectColumnList">column list to be selected</param>
        /// <param name="paramColumnList">column list of parameterized condition</param>
        /// <param name="paramValueList">value list of parameterized condition</param>
        public SqlCommandHelper(SqlCommandType commandType, Type entityType, string tableName, string[] selectColumnList, string[] paramColumnList, object[] paramValueList)
        {
            _commandType = commandType;
            _entityType = entityType;
            _tableName = tableName;
            if (null != selectColumnList && selectColumnList.Count() > 0)
                _selectColumnList = new List<string>(selectColumnList);
            if (null != paramColumnList && paramColumnList.Count() > 0)
                _paramColumnList = new List<string>(paramColumnList);
            if (null != paramValueList && paramValueList.Count() > 0)
                _paramValueList = new List<object>(paramValueList);
            BuildParameters();
            switch (commandType)
            {
                case SqlCommandType.SELECT:
                    BuildSelectSql();
                    break;
                case SqlCommandType.INSERT:
                    BuildInsertSql();
                    break;
                case SqlCommandType.UPDATE:
                    BuildUpdateSql();
                    break;
                case SqlCommandType.DELETE:
                    BuildDeleteSql();
                    break;
            }
        }

        #endregion constructors

        #region public methods

        /// <summary>
        /// Get built SqlParameter array
        /// </summary>
        /// <returns></returns>
        public SqlParameter[] GetParameters()
        {
            return _paramList.ToArray();
        }

        /// <summary>
        /// Get Built select sql script
        /// </summary>
        /// <returns></returns>
        public string GetSelectSql()
        {
            return _selectSql;
        }

        /// <summary>
        /// Get built insert sql script
        /// </summary>
        /// <returns></returns>
        public string GetInsertSql()
        {
            return _insertSql;
        }

        /// <summary>
        /// Get built update sql script
        /// </summary>
        /// <returns></returns>
        public string GetUpdateSql()
        {
            return _updateSql;
        }

        /// <summary>
        /// Get built delete sql script
        /// </summary>
        /// <returns></returns>
        public string GetDeleteSql()
        {
            return _deleteSql;
        }

        /// <summary>
        /// Add aditional "where" condition clause to sql query
        /// </summary>
        /// <param name="conditionStr">condition clause</param>
        /// <param name="paramNameList">parameter list exists in condition clause, it can be null if previous parameter list already contains all the parameters</param>
        /// <param name="paramValueList">corresponding parameter value list</param>
        public void AddAditionalParameters(string conditionStr, string[] paramNameList, object[] paramValueList)
        {
            switch (_commandType)
            {
                case SqlCommandType.SELECT:
                    if (_bSelectCoditionClauseExists)
                    {
                        _selectSql += " and " + conditionStr;
                    }
                    else
                        _selectSql += " where " + conditionStr;
                    break;
                case SqlCommandType.INSERT:
                    break;
                case SqlCommandType.UPDATE:
                    if (_bUpdateCoditionClauseExists)
                    {
                        _updateSql += " and " + conditionStr;
                    }
                    else
                        _updateSql += " where " + conditionStr;
                    break;
                case SqlCommandType.DELETE:
                    if (_bDeleteCoditionClauseExists)
                    {
                        _deleteSql += " and " + conditionStr;
                    }
                    else
                        _deleteSql += " where " + conditionStr;
                    break;
            }
            if (null != paramNameList)
            {
                for (int i = 0; i < paramNameList.Count(); ++i)
                {
                    Type fieldType = paramValueList[i].GetType();

                    SqlType_CSharpType sc = new SqlType_CSharpType();
                    SqlDbType sqlType = sc.CSharpType2SqlType(fieldType);
                    //SqlDbType sqlType = BookShelfConverter.SqlType_CSharpType(fieldType);
                    SqlParameter sqlParam = new SqlParameter("@" + paramNameList[i], sqlType);
                    sqlParam.Value = paramValueList[i];
                    _paramList.Add(sqlParam);
                }
            }
        }

        #endregion public methods

        #region private methods

        private void BuildParameters()
        {
            if (null == _paramColumnList || null == _paramValueList)
            {
                return;
            }
            if (0 == _paramColumnList.Count() || _paramColumnList.Count() != _paramValueList.Count())
            {
                return;
            }
            //_paramList = new SqlParameter[_paramColumnList.Count()];
            for (int i = 0; i < _paramColumnList.Count(); ++i)
            {
                char[] modified = _paramColumnList[i].ToCharArray();
                modified[0] = char.ToUpper(modified[0]);

                string updated = new string(modified);
                //string updated = "UserID";               

                Type propertyType = _entityType.GetProperty(updated).PropertyType;
                SqlType_CSharpType sc = new SqlType_CSharpType();

                //SqlDbType sqlType = BookShelfConverter.CSharpType2SqlType(fieldType);
                SqlDbType sqlType = sc.CSharpType2SqlType(propertyType);

                _paramList.Add(new SqlParameter("@" + _paramColumnList[i], sqlType));
            }
            for (int i = 0; i < _paramValueList.Count(); ++i)
            {
                _paramList[i].Value = _paramValueList[i];
            }

        }
        private void BuildSelectSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            if (null != _selectColumnList && _selectColumnList.Count() > 0)
            {
                sb.Append(_selectColumnList[0]);
                for (int i = 1; i < _selectColumnList.Count(); ++i)
                {
                    sb.Append("," + _selectColumnList[i]);
                }
                sb.Append(" from " + _tableName);
            }
            else
            {
                sb.Append("* from " + _tableName);
            }
            if (null != _paramColumnList && null != _paramValueList &&
                _paramColumnList.Count() > 0 && _paramColumnList.Count() == _paramValueList.Count())
            {
                sb.Append(" where ");
                _bSelectCoditionClauseExists = true;
                sb.Append(_paramColumnList[0] + "=@" + _paramColumnList[0]);
                for (int i = 1; i < _paramColumnList.Count(); ++i)
                {
                    sb.Append(" and " + _paramColumnList[i] + "=@" + _paramColumnList[i]);
                }
            }
            _selectSql = sb.ToString();
        }
        private void BuildInsertSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into " + _tableName + "(");
            if (null != _paramColumnList && null != _paramValueList &&
                _paramColumnList.Count() > 0 && _paramColumnList.Count() == _paramValueList.Count())
            {
                sb.Append(_paramColumnList[0]);
                for (int i = 1; i < _paramColumnList.Count(); ++i)
                {
                    sb.Append("," + _paramColumnList[i]);
                }
                sb.Append(") values (");
                sb.Append("@" + _paramColumnList[0]);
                for (int i = 1; i < _paramColumnList.Count(); ++i)
                {
                    sb.Append(",@" + _paramColumnList[i]);
                }
                sb.Append(")");
                sb.Append(" select SCOPE_IDENTITY()");
                _insertSql = sb.ToString();
            }
        }
        private void BuildUpdateSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update " + _tableName + " set ");
            if (null != _paramColumnList && null != _paramValueList &&
                _paramColumnList.Count() > 0 && _paramColumnList.Count() == _paramValueList.Count())
            {
                sb.Append(_paramColumnList[0] + "=@" + _paramColumnList[0]);
                for (int i = 1; i < _paramColumnList.Count(); ++i)
                {
                    sb.Append("," + _paramColumnList[i] + "=@" + _paramColumnList[i]);
                }
                _updateSql = sb.ToString();
            }
        }
        private void BuildDeleteSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from " + _tableName);
            if (null != _paramColumnList && null != _paramValueList &&
                _paramColumnList.Count() > 0 && _paramColumnList.Count() == _paramValueList.Count())
            {
                sb.Append(" where ");
                _bDeleteCoditionClauseExists = true;
                sb.Append(_paramColumnList[0] + "=@" + _paramColumnList[0]);
                for (int i = 1; i < _paramColumnList.Count(); ++i)
                {
                    sb.Append(" and " + _paramColumnList[i] + "=@" + _paramColumnList[i]);
                }
            }
            _deleteSql = sb.ToString();
        }

        #endregion private methods
    }
}
