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
    public class ContactMessageManager : IContactMessageService
    {
        IContactMessageDAL _contactMessageDAL;

        public ContactMessageManager(IContactMessageDAL contactMessageDAL)
        {
            _contactMessageDAL = contactMessageDAL;
        }

        public void TAddBL(ContactMessage t)
        {
            _contactMessageDAL.Add(t);
        }

        public void TDeleteBL(ContactMessage t)
        {
            _contactMessageDAL.Delete(t);
        }

        public ContactMessage TGetByIDBL(int id)
        {
            return _contactMessageDAL.Get(p => p.ContactMessageID == id);
        }

        public List<ContactMessage> TGetListBL()
        {
            return _contactMessageDAL.List(p => p.ContactMessageStatus == true);
        }

        public void TUpdateBL(ContactMessage t)
        {
            _contactMessageDAL.Update(t);
        }
    }
}
