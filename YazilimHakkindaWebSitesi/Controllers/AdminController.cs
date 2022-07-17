using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazilimHakkindaWebSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            AdminManager adminManager = new AdminManager(new EfAdminDAL());
            var returningAdmin = adminManager.TGetAdminBL(admin);

            if (returningAdmin != null)
            {
                Session["UserName"] = admin.AdminUsername;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = String.Format("Kullanıcı adı veya şifre hatalı!");
                return View();
            }
        }

        public ActionResult EditorOperations()
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editors = editorManager.TGetListBL();

            return View(editors);
        }

        public ActionResult DeleteEditor(int id)
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editor = editorManager.TGetByIDBL(id);
            editorManager.TDeleteBL(editor);

            return RedirectToAction("EditorOperations");
        }

        [HttpGet]
        public ActionResult AddEditor(int titleID)
        {
            TitleManager titleManager = new TitleManager(new EfTitleDAL());


            if (titleID != 0)
            {
                List<SelectListItem> titles = (from x in titleManager.TGetByTitleIDBL(titleID)
                                               select new SelectListItem
                                               {
                                                   Text = x.TitleName,
                                                   Value = x.TitleID.ToString()
                                               }).ToList();
                ViewBag.titleList = titles;
            }
            else
            {
                List<SelectListItem> titles = (from x in titleManager.TGetListBL()
                                               select new SelectListItem
                                               {
                                                   Text = x.TitleName,
                                                   Value = x.TitleID.ToString()
                                               }).ToList();
                ViewBag.titleList = titles;
            }


            return View();
        }

        [HttpPost]
        public ActionResult AddEditor(Editor editor)
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());

            EditorValidator ev = new EditorValidator();
            ValidationResult results = ev.Validate(editor);

            if (results.IsValid)
            {
                editorManager.TAddBL(editor);
                return RedirectToAction("EditorOperations");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                AddEditor(editor.TitleID);
                return View();
            }
        }

        public ActionResult AllEditorialApplications()
        {
            EditorialApplicationManager editorialApplicationManager = new EditorialApplicationManager(new EfEditorialApplicationDAL());
            var editorialApplications = editorialApplicationManager.TGetListBL();

            return View(editorialApplications);
        }

        public ActionResult EditorialApplicationReview(int id)
        {
            EditorialApplicationManager editorialApplicationManager = new EditorialApplicationManager(new EfEditorialApplicationDAL());
            var editorialApplication = editorialApplicationManager.TGetByIDBL(id);

            return View(editorialApplication);
        }

        public ActionResult DeleteEditorialApplication(int id)
        {
            EditorialApplicationManager editorialApplicationManager = new EditorialApplicationManager(new EfEditorialApplicationDAL());
            var editorialApplication = editorialApplicationManager.TGetByIDBL(id);

            editorialApplicationManager.TDeleteBL(editorialApplication);

            return RedirectToAction("AllEditorialApplications");
        }

        public ActionResult ContactMessages()
        {
            ContactMessageManager contactMessageManager = new ContactMessageManager(new EfContactMessageDAL());
            var contactMessages = contactMessageManager.TGetListBL();

            return View(contactMessages);
        }

        public ActionResult DeleteContactMessage(int id)
        {
            ContactMessageManager contactMessageManager = new ContactMessageManager(new EfContactMessageDAL());
            var contactMessage = contactMessageManager.TGetByIDBL(id);

            contactMessage.ContactMessageStatus = false;
            contactMessageManager.TUpdateBL(contactMessage);

            return RedirectToAction("ContactMessages");
        }

        [HttpGet]
        public ActionResult AdminPasswordUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminPasswordUpdate(string oldPassword, string newPassword1, string newPassword2)
        {
            AdminManager adminManager = new AdminManager(new EfAdminDAL());
            var adminUsername = Session["UserName"].ToString();
            var admin = adminManager.TGetByUsernameBL(adminUsername);

            var adminOldPassword = admin.AdminPassword;

            if (adminOldPassword == oldPassword)
            {
                if (newPassword1 == newPassword2)
                {
                    admin.AdminPassword = newPassword1;
                    adminManager.TUpdateBL(admin);
                    ViewBag.Message = String.Format("Şifreniz başarıyla güncellenmiştir.");
                }
                else
                {
                    ViewBag.Message = String.Format("Girilen yeni şifreler uyuşmuyor. Lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                ViewBag.Message = String.Format("Girilen eski şifre hatalı.");
            }

            return View();
        }

    }
}