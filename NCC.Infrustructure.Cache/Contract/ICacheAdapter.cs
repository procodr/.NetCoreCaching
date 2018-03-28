using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Infrustructure.Cache.Contract
{
    public interface ICacheAdapter
    {
        bool Exists(string key);
        T Get<T>(string key);
        void Add<T>(string key, T value);
        void Remove(string key);
    }
}
