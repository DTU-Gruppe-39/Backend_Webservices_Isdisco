using System;
using System.Collections.Generic;

namespace Isdisco_Web_API.DAO
{
    public interface DefaultDAO <T>
    {
        void Add(T element);
        void Update(T element);
        void Delete(int id);
        List<T> GetAll();
        T Get(int id);
    }
}
