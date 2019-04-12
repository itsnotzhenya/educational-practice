using System;
using System.Collections.Generic;
using webApi.Model;
namespace webApi.DAL
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Get(); // получение всех объектов

        void Create(Film film);
        bool Delete(int id);
        void Update(Film film);
    }
}