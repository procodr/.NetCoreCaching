using Microsoft.Extensions.Caching.Distributed;
using NCC.Infrustructure.Cache.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Infrustructure.Cache.Implemention
{
    public class DistributedCacheAdapter : ICacheAdapter
    {
        private readonly IDistributedCache _distributedCache;
        public DistributedCacheAdapter(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        } 

        public void Add<T>(string key, T value)
        {
            _distributedCache.SetString(key, JsonConvert.SerializeObject(value));
        }

        public bool Exists(string key)
        {
            return !string.IsNullOrWhiteSpace(_distributedCache.GetString(key));
        }

        public T Get<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(_distributedCache.GetString(key));
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }
    }
}
