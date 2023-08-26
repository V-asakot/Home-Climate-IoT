﻿using System.Text;

namespace RoomsClimate.Service.Utils
{
    public static class CacheUtils
    {
        public static string FormCacheKey(string keyBase,params string[] keyParams)
        {
            var builder = new StringBuilder(keyBase);
            foreach(var param in keyParams) 
                builder.Append(param);
            return builder.ToString();
        }
    }
}
