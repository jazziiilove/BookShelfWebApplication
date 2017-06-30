/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: .Factory
 * Project name: .BookShelfWeb.Factory
 * File name: FactoryTemplate.cs
 * Status: Finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BookShelfWeb.Factory
{
 
    /// <summary>
    /// This is the Factory Template to create DA and BL instances.
    /// Derived classes should inhert from it, then CreateInstance can be called to
    /// create corresponding interfaces. See DALFactory and BLLFactory for example.
    /// We add constraints on T to allow lower layer dll be replaced at runtime, check _CreateInstance
    /// for detail.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FactoryTemplate<T> where T: FactoryTemplate<T>, new ()
    {
        #region member variables

        /// <summary>
        /// the lower layer dll path
        /// </summary>
        protected string _lowerLayerBinaryPath ="";
        /// <summary>
        /// AppSetting key name which indicate the lower layer dll path 
        /// </summary>
        protected string _lowerLayerBinaryPathCacheName = "";
        /// <summary>
        /// property : lower layer dll path.
        /// For Factories in different layer, it should be different and initiated in constructor.
        /// </summary>
        public string LowerLayerBinaryPath
        {
            get { return _lowerLayerBinaryPath; }
        }
        /// <summary>
        /// property : AppSetting key name which indicate the lower layer dll path .
        /// For Factories in different layer, it should be different and initiated in constructor.
        /// </summary>
        public string LowerLayerBinaryPathCacheName
        {
            get { return _lowerLayerBinaryPathCacheName; }
        }

        #endregion member variables

        #region CreateInstance

        /// <summary>
        /// create instance of ChildType and return it as ParentType, usually ParentType is an interface
        /// while ChildType is an concrete implement
        /// </summary>
        /// <typeparam name="ParentType">interface class</typeparam>
        /// <typeparam name="ChildType">implement class</typeparam>
        /// <param name="param">constructor parameters of implement class</param>
        /// <param name="isCached">whether the instance will be cached for next use.</param>
        /// <returns>the reference of ParentType</returns>
        protected static ParentType CreateInstance<ParentType,ChildType>(object[] param, bool isCached)
        {
            Type t1 = typeof(ParentType);
            Type t2 = typeof(ChildType);
            if (t1.IsAssignableFrom(t2))
            {
                object obj = null;
                if (isCached)
                {
                    //check whether it already loaded (if so, its name should exist in the cache)
                    string typeName = t2.FullName;
                    obj = CacheManager.CacheAccess.GetFromCache(typeName);
                    if (null == obj)
                    {
                        obj = _CreateInstance(t2, param, true);
                    }
                }
                else
                {
                    obj = _CreateInstance(t2, param, false);
                }
                return (ParentType)obj;
            }
            return default(ParentType);
        }

        /// <summary>
        /// Create instance of given assembly type using reflection 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="param"></param>
        /// <param name="bSaveCache"></param>
        /// <returns>null if falied</returns>
        private static object _CreateInstance(Type t, object[] param, bool bSaveCache)
        {
            object objRet = null;
            try
            {
                T objSelf = new T();
                string strPath = "";
                if (bSaveCache)
                {
                    object objPath = CacheManager.CacheAccess.GetFromCache(objSelf.LowerLayerBinaryPathCacheName);
                    if (null == objPath)
                    {
                        objPath = System.Configuration.ConfigurationManager.AppSettings[objSelf.LowerLayerBinaryPath];
                        if (null != objPath)
                            CacheManager.CacheAccess.SaveToCache(objSelf.LowerLayerBinaryPathCacheName, objPath);
                    }
                    strPath = (string)objPath;
                }                
                if (String.IsNullOrEmpty(strPath))
                {//load from current process
                    objRet = Activator.CreateInstance(t, param);
                }
                else
                {//load from outside
                    string strFullClassName = strPath + "." + t.Name;
                    objRet = Assembly.Load(strPath).CreateInstance(strFullClassName);
                }
                if (bSaveCache)
                {
                    //save to cache
                    CacheManager.CacheAccess.SaveToCache(t.FullName, objRet);
                }
            }
            catch
            {
            }            
            return objRet;
        }

        #endregion CreateInstance
    }
}
