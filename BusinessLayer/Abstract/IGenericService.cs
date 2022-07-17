using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAddBL(T t);
        void TDeleteBL(T t);
        void TUpdateBL(T t);
        List<T> TGetListBL();
        T TGetByIDBL(int id);

    }
}
