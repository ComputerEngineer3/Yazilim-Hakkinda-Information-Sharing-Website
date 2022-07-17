using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {
        ITitleDAL _titleDAL;

        public TitleManager(ITitleDAL titleDAL)
        {
            _titleDAL = titleDAL;
        }

        public void TAddBL(Title t)
        {
            _titleDAL.Add(t);
        }

        public void TDeleteBL(Title t)
        {
            _titleDAL.Delete(t);
        }

        public Title TGetByIDBL(int id)
        {
            return _titleDAL.Get(p => p.TitleID == id);
        }

        public Title TGetByTitleNameBL(string titleName)
        {
            return _titleDAL.Get(p => p.TitleName == titleName);
        }

        public List<Title> TGetByTitleIDBL(int titleID)
        {
            return _titleDAL.List(p => p.TitleID == titleID);
        }

        public List<Title> TGetListBL()
        {
            return _titleDAL.List();
        }

        public void TUpdateBL(Title t)
        {
            _titleDAL.Update(t);
        }
    }
}
