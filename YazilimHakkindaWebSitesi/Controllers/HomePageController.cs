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
using System.Web.Security;
using YazilimHakkindaWebSitesi.Models;

namespace YazilimHakkindaWebSitesi.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        [HttpGet]
        public ActionResult Index()
        {
            TitleManager titleManager = new TitleManager(new EfTitleDAL());
            var titles = titleManager.TGetListBL();
            return View(titles);
        }

        [HttpPost]
        public ActionResult Index(string islem)
        {
            Session.Remove("UserName");
            return View();
        }

        public ActionResult Title(string titleName)
        {
            TitleManager titleManager = new TitleManager(new EfTitleDAL());
            var titleID = titleManager.TGetByTitleNameBL(titleName).TitleID;

            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitles = subtitleManager.TGetListFilterBL(titleID);

            return View(subtitles);
        }

        public ActionResult TitleWritings(int titleID, string subtitleName)
        {
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitles = subtitleManager.TGetListFilterBL(titleID);

            var subtitleID = subtitleManager.TGetBySubtitleNameBL(subtitleName).SubtitleID;

            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writings = writingManager.TGetListByFilter(titleID, subtitleID);

            SubtitlesAndWritingsModel titlesAndWritingsModel = new SubtitlesAndWritingsModel();
            titlesAndWritingsModel.Subtitles = subtitles;
            titlesAndWritingsModel.Writings = writings;
            return View(titlesAndWritingsModel);
        }

        public ActionResult Writing(int titleID, int writingID)
        {
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());
            var subtitles = subtitleManager.TGetListFilterBL(titleID);

            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);

            SubtitlesAndWritingModel subtitlesAndWritingModel = new SubtitlesAndWritingModel();
            subtitlesAndWritingModel.Subtitles = subtitles;
            subtitlesAndWritingModel.Writing = writing;
            return View(subtitlesAndWritingModel);
        }

        [HttpGet]
        public ActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iletisim(ContactMessage contactMessage)
        {
            ContactMessageManager contactMessageManager = new ContactMessageManager(new EfContactMessageDAL());

            ContactMessageValidator cmv = new ContactMessageValidator();
            ValidationResult results = cmv.Validate(contactMessage);

            if (results.IsValid)
            {
                contactMessage.ContactMessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contactMessageManager.TAddBL(contactMessage);
                ViewBag.Message = String.Format("Mesajınız başarıyla iletilmiştir. En kısa sürede geri dönüş yapılmaya çalışılacaktır.");
                return View();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult UyeOlGirisYap()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UyeGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeGiris(Member member)
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var returningMember = memberManager.TGetMemberBL(member);

            if (returningMember != null)
            {
                //FormsAuthentication.SetAuthCookie(member.MemberUsername, false);
                Session["UserName"] = member.MemberUsername;
                return RedirectToAction("Index", "Member");
            }
            else
            {
                ViewBag.Message = String.Format("Girdiğiniz kullanıcı adı ve şifreye sahip bir kullanıcı bulunamadı. Lütfen tekrar deneyiniz.");
                return View();
            }
        }

        [HttpGet]
        public ActionResult UyeOlmaSayfasi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOlmaSayfasi(Member member)
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());

            MemberValidator mv = new MemberValidator();
            ValidationResult results = mv.Validate(member);

            var returningMemberUsername = memberManager.TGetByUsernameBL(member.MemberUsername);
            var returningMemberEmail = memberManager.TGetByEmailBL(member.MemberEmail);

            if (results.IsValid)
            {
                if (returningMemberUsername == null)
                {
                    if (returningMemberEmail == null)
                    {
                        memberManager.TAddBL(member);
                        ViewBag.Message = String.Format("Başarılı");
                    }
                    else
                    {
                        ViewBag.Message = String.Format("Girdiğiniz e-mail zaten sistemde kayıtlı. Lütfen farklı bir e-mail adresi girerek tekrar deneyiniz.");
                    }
                }
                else
                {
                    ViewBag.Message = String.Format("Girdiğiniz kullanıcı adı zaten sistemde kayıtlı. Lütfen farklı bir kullanıcı adı girerek tekrar deneyiniz.");
                }

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();
        }

        [HttpGet]
        public ActionResult EditorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditorLogin(Editor editor)
        {
            EditorManager editorManager = new EditorManager(new EfEditorDAL());
            var returningEditor = editorManager.TGetEditorBL(editor);

            if (returningEditor != null)
            {
                Session["UserName"] = editor.EditorUsername;
                return RedirectToAction("Index", "Editor");
            }
            else
            {
                ViewBag.Message = String.Format("Girdiğiniz kullanıcı adı ve şifreye sahip bir editör bulunamadı. Lütfen tekrar deneyiniz.");
                return View();
            }
        }

        public ActionResult WritingSearch(string word)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writings = writingManager.TGetByWordBL(word);

            if (writings != null)
            {
                return View(writings);
            }
            else
            {
                ViewBag.Message("Sonuç bulunamadı...");
                return View(writings);
            }
        }

        public ActionResult WritingReview(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);

            return View(writing);
        }

    }
}