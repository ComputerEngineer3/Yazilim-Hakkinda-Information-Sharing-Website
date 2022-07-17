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
    public class EditorManager : IEditorService
    {
        IEditorDAL _editorDAL;

        public EditorManager(IEditorDAL editorDAL)
        {
            _editorDAL = editorDAL;
        }

        public void TAddBL(Editor t)
        {
            _editorDAL.Add(t);
        }

        public void TDeleteBL(Editor t)
        {
            _editorDAL.Delete(t);
        }

        public Editor TGetByIDBL(int id)
        {
            return _editorDAL.Get(p => p.EditorID == id);
        }

        public Editor TGetByUsernameBL(string username)
        {
            return _editorDAL.Get(p => p.EditorUsername == username);
        }

        public Editor TGetByEmailBL(string email)
        {
            return _editorDAL.Get(p => p.EditorEmail == email);
        }

        public List<Editor> TGetListBL()
        {
            return _editorDAL.List();
        }

        public void TUpdateBL(Editor t)
        {
            _editorDAL.Update(t);
        }

        public Editor TGetEditorBL(Editor editor)
        {
            return _editorDAL.List(p => p.EditorUsername == editor.EditorUsername && p.EditorPassword == editor.EditorPassword).FirstOrDefault();
        }
    }
}
