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
    public class MemberManager : IMemberService
    {
        IMemberDAL _memberDAL;

        public MemberManager(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        public void TAddBL(Member t)
        {
            _memberDAL.Add(t);
        }

        public void TDeleteBL(Member t)
        {
            _memberDAL.Delete(t);
        }

        public Member TGetByIDBL(int id)
        {
            return _memberDAL.Get(p => p.MemberID == id);
        }

        public Member TGetByUsernameBL(string username)
        {
            return _memberDAL.Get(p => p.MemberUsername == username);
        }

        public Member TGetByEmailBL(string email)
        {
            return _memberDAL.Get(p => p.MemberEmail == email);
        }

        public List<Member> TGetListBL()
        {
            return _memberDAL.List();
        }

        public void TUpdateBL(Member t)
        {
            _memberDAL.Update(t);
        }

        public Member TGetMemberBL(Member member)
        {
            return _memberDAL.List(p => p.MemberUsername == member.MemberUsername && p.MemberPassword == member.MemberPassword).FirstOrDefault();
        }
    }
}
