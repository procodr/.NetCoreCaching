using Microsoft.Extensions.Caching.Memory;
using NCC.Infrustructure.Cache.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Infrustructure.Cache.Implemention
{
    public class InMemoryCacheAdapter : ICacheAdapter
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheAdapter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add<T>(string key, T value)
        {
            _memoryCache.Set(key, value);
        }

        public bool Exists(string key)
        {
            return _memoryCache.TryGetValue(key, out object value);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
