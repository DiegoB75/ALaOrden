using System.Collections.Generic;
using System;

namespace TFinal.Service
{
    public interface ICrudService<T>
    {
        void Delete(T entity);
        void Save(T entity);
        void Update(T entity);
        T FindById(T entity);
        List<T> ListAll();
    }
}
