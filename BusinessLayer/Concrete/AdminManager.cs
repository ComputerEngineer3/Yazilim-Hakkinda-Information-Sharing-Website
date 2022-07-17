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
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void TAddBL(Admin t)
        {
            _adminDAL.Add(t);
        }

        public void TDeleteBL(Admin t)
        {
            _adminDAL.Delete(t);
        }

        public Admin TGetByIDBL(int id)
        {
            return _adminDAL.Get(p => p.AdminID == id);
        }

        public Admin TGetByUsernameBL(string username)
        {
            return _adminDAL.Get(p => p.AdminUsername == username);
        }

        public List<Admin> TGetListBL()
        {
            return _adminDAL.List();
        }

        public void TUpdateBL(Admin t)
        {
            _adminDAL.Update(t);
        }

        public Admin TGetAdminBL(Admin admin)
        {
            return _adminDAL.List(p => p.AdminUsername == admin.AdminUsername && p.AdminPassword == admin.AdminPassword).FirstOrDefault();
        }
    }
}
