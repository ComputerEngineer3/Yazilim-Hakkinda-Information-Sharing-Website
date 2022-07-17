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
    public class EditorialApplicationManager : IEditorialApplicationService
    {
        IEditorialApplicationDAL _editorialApplicationDAL;

        public EditorialApplicationManager(IEditorialApplicationDAL editorialApplicationDAL)
        {
            _editorialApplicationDAL = editorialApplicationDAL;
        }

        public void TAddBL(EditorialApplication t)
        {
            _editorialApplicationDAL.Add(t);
        }

        public void TDeleteBL(EditorialApplication t)
        {
            _editorialApplicationDAL.Delete(t);
        }

        public EditorialApplication TGetByIDBL(int id)
        {
            return _editorialApplicationDAL.Get(p => p.EditorialApplicationID == id);
        }

        public List<EditorialApplication> TGetListBL()
        {
            return _editorialApplicationDAL.List();
        }

        public void TUpdateBL(EditorialApplication t)
        {
            _editorialApplicationDAL.Update(t);
        }
    }
}
