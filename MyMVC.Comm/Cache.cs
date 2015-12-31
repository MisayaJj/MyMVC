using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MyMVC.Comm
{
    public class Cache
    {

        /// <summary>
        /// 根据名字获取缓存
        /// </summary>
        /// <param name="cacheKey">缓存名</param>
        /// <returns>值(object)</returns>
        public static object GetCache(string cacheKey)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            return cache[cacheKey];
        }
        /// <summary>
        /// 根据名字清除缓存
        /// </summary>
        /// <param name="cacheKey">缓存名</param>
        /// <returns></returns>
        public static object RemoveCache(string cacheKey)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            return cache.Remove(cacheKey);
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="objObject">值</param>
        public static void SetCache(string cacheKey, object objObject)
        {
            SetCache(cacheKey, objObject, null);
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="objObject">值</param>
        /// <param name="dependencyPath">依赖文件的绝对路径</param>
        public static void SetCache(string cacheKey, object objObject, string dependencyPath)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            if (!string.IsNullOrEmpty(dependencyPath))
                cache.Insert(cacheKey, objObject, new System.Web.Caching.CacheDependency(dependencyPath));
            else
                cache.Insert(cacheKey, objObject);
        }
    }
}
