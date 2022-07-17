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
    public class EditorController : Controller
    {
        // GET: Editor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditorProfile()
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var editor = editorManager.TGetByUsernameBL(editorUsername);

            return View(editor);
        }

        [HttpPost]
        public ActionResult EditorProfile(Editor editor)
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var updatedEditor = editorManager.TGetByUsernameBL(editorUsername);
            var editorEmail = updatedEditor.EditorEmail;

            var emailregistrationStatus = editorManager.TGetByEmailBL(editor.EditorEmail);

            if (editor.EditorEmail != null)
            {
                if (emailregistrationStatus == null)
                {
                    updatedEditor.EditorEmail = editor.EditorEmail;
                    editorManager.TUpdateBL(updatedEditor);
                    ViewBag.Message = String.Format("E-mail adresi başarıyla güncellenmiştir.");
                    return View();
                }
                else
                {
                    ViewBag.Message = String.Format("Bu e-mail adresi zaten kayıtlı. Lütfen farklı bir e-mail adresi ile tekrar deneyiniz!");
                }

            }
            else
            {
                ViewBag.Message = String.Format("E-mail adresi boş geçilemez!");
            }

            return View();
        }

        [HttpGet]
        public ActionResult SubtitleEdit()
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var editorTitleID = editorManager.TGetByUsernameBL(editorUsername).TitleID;

            var titleName = editorManager.TGetByUsernameBL(editorUsername).Title.TitleName;
            ViewBag.TitleName = String.Format(titleName);

            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitles = subtitleManager.TGetListAllByTitleIDBL(editorTitleID);

            return View(subtitles);
        }

        [HttpPost]
        public ActionResult SubtitleEdit(string titleName)
        {
            //ViewBag.Message = String.Format("Başarılı.");

            TitleManager titleManager = new TitleManager(new EfTitleDAL());
            var titleID = titleManager.TGetByTitleNameBL(titleName).TitleID;

            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitles = subtitleManager.TGetListAllByTitleIDBL(titleID);

            return View(subtitles);
        }

        [HttpGet]
        public ActionResult AddSubtitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubtitle(Subtitle subtitle)
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var editorTitleID = editorManager.TGetByUsernameBL(editorUsername).TitleID;

            subtitle.SubtitleStatus = true;
            subtitle.TitleID = editorTitleID;

            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            subtitleManager.TAddBL(subtitle);

            return RedirectToAction("SubtitleEdit");
        }

        public ActionResult DeleteSubtitle(int id)
        {
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitle = subtitleManager.TGetByIDBL(id);

            subtitle.SubtitleStatus = false;
            subtitleManager.TUpdateBL(subtitle);

            return RedirectToAction("SubtitleEdit");
        }

        public ActionResult AddAgainSubtitle(int id)
        {
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitle = subtitleManager.TGetByIDBL(id);

            subtitle.SubtitleStatus = true;
            subtitleManager.TUpdateBL(subtitle);

            return RedirectToAction("SubtitleEdit");
        }

        [HttpGet]
        public ActionResult UpdateSubtitle(int id)
        {
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitle = subtitleManager.TGetByIDBL(id);

            return View(subtitle);
        }

        [HttpPost]
        public ActionResult UpdateSubtitle(Subtitle subtitle)
        {
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var updatedSubtitle = subtitleManager.TGetByIDBL(subtitle.SubtitleID);

            updatedSubtitle.SubtitleName = subtitle.SubtitleName;
            subtitleManager.TUpdateBL(updatedSubtitle);
            ViewBag.Message = String.Format("Alt başlık güncellenmiştir.");

            return RedirectToAction("SubtitleEdit");
        }

        public ActionResult NewAddedWritings()
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var editorTitleID = editorManager.TGetByUsernameBL(editorUsername).TitleID;

            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writings = writingManager.TGetListTitleIDAndApprovalStatus(editorTitleID, false);

            return View(writings);
        }

        public ActionResult PublishedWritings()
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var editorTitleID = editorManager.TGetByUsernameBL(editorUsername).TitleID;

            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writings = writingManager.TGetListTitleIDAndApprovalStatus(editorTitleID, true);

            return View(writings);
        }

        public ActionResult NewAddedWritingsReview(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);

            return View(writing);
        }

        public ActionResult PublishedWritingsReview(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);

            return View(writing);
        }

        public ActionResult DeleteWriting(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);
            writingManager.TDeleteBL(writing);

            return RedirectToAction("NewAddedWritings");
        }

        public ActionResult RemoveWriting(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);
            writingManager.TDeleteBL(writing);

            return RedirectToAction("PublishedWritings");
        }

        public ActionResult AddWriting(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);
            writing.ApprovalStatus = true;
            writingManager.TUpdateBL(writing);

            return RedirectToAction("NewAddedWritings");
        }

        [HttpGet]
        public ActionResult EditorPasswordUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditorPasswordUpdate(string oldPassword, string newPassword1, string newPassword2)
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var editorUsername = Session["UserName"].ToString();
            var editor = editorManager.TGetByUsernameBL(editorUsername);

            var editorOldPassword = editor.EditorPassword;

            if (editorOldPassword == oldPassword)
            {
                if (newPassword1 == newPassword2)
                {
                    editor.EditorPassword = newPassword1;
                    editorManager.TUpdateBL(editor);
                    ViewBag.Message = String.Format("Şifreniz başarıyla güncellenmiştir.");
                }
                else
                {
                    ViewBag.Message = String.Format("Girilen yeni şifreler uyuşmuyor. Lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                ViewBag.Message = String.Format("Girilen eski şifre hatalı!");
            }


            return View();
        }

    }
}