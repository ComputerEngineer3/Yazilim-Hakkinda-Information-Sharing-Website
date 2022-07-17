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
    public class WritingManager : IWritingService
    {
        IWritingDAL _writingDAL;

        public WritingManager(IWritingDAL writingDAL)
        {
            _writingDAL = writingDAL;
        }

        public void TAddBL(Writing t)
        {
            _writingDAL.Add(t);
        }

        public void TDeleteBL(Writing t)
        {
            _writingDAL.Delete(t);
        }

        public Writing TGetByIDBL(int id)
        {
            return _writingDAL.Get(p => p.WritingID == id);
        }

        public List<Writing> TGetByWordBL(string word)
        {
            return _writingDAL.List(p => (p.WritingTitle.Contains(word) || p.WritingText.Contains(word) || p.Member.MemberName.Contains(word) || p.Member.MemberSurname.Contains(word)) & (p.ApprovalStatus == true));
        }

        public List<Writing> TGetListByFilter(int titleID, int subtitleID)
        {
            return _writingDAL.List(p => p.TitleID == titleID && p.SubtitleID == subtitleID && p.ApprovalStatus == true);
        }

        public List<Writing> TGetListByMemberIDAndApprovalStatus(int memberID, bool approvalStatus)
        {
            return _writingDAL.List(p => p.MemberID == memberID && p.ApprovalStatus == approvalStatus);
        }

        public List<Writing> TGetListTitleIDAndApprovalStatus(int titleID, bool approvalStatus)
        {
            return _writingDAL.List(p => p.TitleID == titleID && p.ApprovalStatus == approvalStatus);
        }

        public List<Writing> TGetListBL()
        {
            return _writingDAL.List();
        }

        public void TUpdateBL(Writing t)
        {
            _writingDAL.Update(t);
        }
    }
}
