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
    public class SubtitleManager : ISubtitleService
    {
        ISubtitleDAL _subtitleDAL;

        public SubtitleManager(ISubtitleDAL subtitleDAL)
        {
            _subtitleDAL = subtitleDAL;
        }

        public void TAddBL(Subtitle t)
        {
            _subtitleDAL.Add(t);
        }

        public void TDeleteBL(Subtitle t)
        {
            _subtitleDAL.Delete(t);
        }

        public Subtitle TGetByIDBL(int id)
        {
            return _subtitleDAL.Get(p => p.SubtitleID == id);
        }

        public List<Subtitle> TGetListFilterBL(int titleID)
        {
            return _subtitleDAL.List(p => p.TitleID == titleID && p.SubtitleStatus == true);
        }

        public List<Subtitle> TGetListAllByTitleIDBL(int titleID)
        {
            return _subtitleDAL.List(p => p.TitleID == titleID);
        }

        public Subtitle TGetBySubtitleNameBL(string subtitleName)
        {
            return _subtitleDAL.Get(p => p.SubtitleName == subtitleName);
        }

        public List<Subtitle> TGetListBL()
        {
            return _subtitleDAL.List();
        }

        public List<Subtitle> TGetBySubtitleIDBL(int subtitleID)
        {
            return _subtitleDAL.List(p => p.SubtitleID == subtitleID);
        }

        public List<Subtitle> TGetListStatusTrueBL()
        {
            return _subtitleDAL.List(p => p.SubtitleStatus == true);
        }

        public void TUpdateBL(Subtitle t)
        {
            _subtitleDAL.Update(t);
        }
    }
}
