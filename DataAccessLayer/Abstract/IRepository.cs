﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T Get(Expression<Func<T, bool>> filter);
        List<T> List(Expression<Func<T, bool>> filter);
        List<T> List();
    }
}
