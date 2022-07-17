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
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MemberProfile()
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var memberUsername = Session["UserName"].ToString();
            var member = memberManager.TGetByUsernameBL(memberUsername);

            return View(member);
        }

        [HttpPost]
        public ActionResult MemberProfile(Member member)
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var memberUsername = Session["UserName"].ToString();
            var updatedMember = memberManager.TGetByUsernameBL(memberUsername);
            var memberEmail = updatedMember.MemberEmail;

            var usernameRegistrationStatus = memberManager.TGetByUsernameBL(member.MemberUsername);
            var emailRegistrationStatus = memberManager.TGetByEmailBL(member.MemberEmail);
            var isUsernameUpdated = false;
            var updatedError = false;


            member.MemberPassword = updatedMember.MemberPassword;
            MemberValidator mv = new MemberValidator();
            ValidationResult results = mv.Validate(member);


            if (results.IsValid)
            {
                if (memberUsername != member.MemberUsername)
                {
                    if (usernameRegistrationStatus == null)
                    {
                        updatedMember.MemberUsername = member.MemberUsername;
                        isUsernameUpdated = true;
                    }
                    else
                    {
                        updatedError = true;
                        ViewBag.Message = String.Format("Bu kullanıcı adı zaten kayıtlı.Lütfen farklı bir kullanıcı adı ile tekrar deneyiniz!");
                    }
                }

                if (memberEmail != member.MemberEmail)
                {
                    if (emailRegistrationStatus == null)
                    {
                        updatedMember.MemberEmail = member.MemberEmail;
                    }
                    else
                    {
                        updatedError = true;
                        ViewBag.Message = String.Format("Bu e-mail adresi zaten kayıtlı. Lütfen farklı bir e-mail adresi ile tekrar deneyiniz!");
                    }
                }

                if (updatedError == false)
                {
                    updatedMember.MemberName = member.MemberName;
                    updatedMember.MemberSurname = member.MemberSurname;
                    updatedMember.MemberJob = member.MemberJob;
                    updatedMember.MemberAbout = member.MemberAbout;
                    memberManager.TUpdateBL(updatedMember);
                    ViewBag.Message = String.Format("Profiliniz güncellenmiştir.");

                    if (isUsernameUpdated == true)
                    {
                        Session.Remove("UserName");
                        ViewBag.Message = String.Format("Başarılı");
                    }
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
        public ActionResult AddWriting(int titleID, int subtitleID)
        {
            TitleManager titleManager = new TitleManager(new EfTitleDAL());
            SubtitleManager subtitleManager = new SubtitleManager(new EfSubtitleDAL());

            if (titleID != 0 && subtitleID != 0)
            {
                List<SelectListItem> titles = (from x in titleManager.TGetByTitleIDBL(titleID)
                                               select new SelectListItem
                                               {
                                                   Text = x.TitleName,
                                                   Value = x.TitleID.ToString()
                                               }).ToList();

                List<SelectListItem> subtitles = (from x in subtitleManager.TGetBySubtitleIDBL(subtitleID)
                                                  select new SelectListItem
                                                  {
                                                      Text = x.SubtitleName,
                                                      Value = x.SubtitleID.ToString()
                                                  }).ToList();

                ViewBag.titleList = titles;
                ViewBag.subtitleList = subtitles;
            }
            else
            {
                List<SelectListItem> titles = (from x in titleManager.TGetListBL()
                                               select new SelectListItem
                                               {
                                                   Text = x.TitleName,
                                                   Value = x.TitleID.ToString()
                                               }).ToList();

                List<SelectListItem> subtitles = (from x in subtitleManager.TGetListStatusTrueBL()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.SubtitleName,
                                                      Value = x.SubtitleID.ToString()
                                                  }).ToList();

                ViewBag.titleList = titles;
                ViewBag.subtitleList = subtitles;
            }



            return View();
        }

        [HttpPost]
        public ActionResult AddWriting(Writing writing)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());

            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var memberUsername = Session["UserName"].ToString();
            var memberID = memberManager.TGetByUsernameBL(memberUsername).MemberID;

            WritingValidator wv = new WritingValidator();
            ValidationResult results = wv.Validate(writing);

            if (results.IsValid)
            {
                writing.WritingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                writing.ApprovalStatus = false;
                writing.MemberID = memberID;

                writingManager.TAddBL(writing);
                return RedirectToAction("PendingApprovalWritings");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                AddWriting(writing.TitleID, writing.SubtitleID);
                return View();
            }

        }

        public ActionResult PublishedWritings()
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var memberUsername = Session["UserName"].ToString();
            var memberID = memberManager.TGetByUsernameBL(memberUsername).MemberID;

            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var sortedList = writingManager.TGetListByMemberIDAndApprovalStatus(memberID, true).OrderByDescending(x => x.WritingDate);

            return View(sortedList);
        }

        public ActionResult PendingApprovalWritings()
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var memberUserName = Session["UserName"].ToString();
            var memberID = memberManager.TGetByUsernameBL(memberUserName).MemberID;

            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var sortedList = writingManager.TGetListByMemberIDAndApprovalStatus(memberID, false).OrderByDescending(x => x.WritingDate);

            return View(sortedList);
        }

        public ActionResult DeletePendingApprovalWritings(int writingID)
        {
            WritingManager writingManager = new WritingManager(new EfWritingDAL());
            var writing = writingManager.TGetByIDBL(writingID);
            writingManager.TDeleteBL(writing);

            return RedirectToAction("PendingApprovalWritings");
        }

        public ActionResult EditorialApplication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditorialApplication(EditorialApplication editorialApplication)
        {
            EditorialApplicationManager editorialApplicationManager = new EditorialApplicationManager(new EfEditorialApplicationDAL());

            EditorialApplicationValidator eav = new EditorialApplicationValidator();
            ValidationResult results = eav.Validate(editorialApplication);

            if (results.IsValid)
            {
                editorialApplicationManager.TAddBL(editorialApplication);
                ViewBag.Message = String.Format("Editörlük başvurunuz başarıyla yapılmıştır. Başvurunuz en kısa sürede değerlendirilip geri dönüş yapılacaktır.");
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

        [HttpGet]
        public ActionResult MemberPasswordUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberPasswordUpdate(string oldPassword, string newPassword1, string newPassword2)
        {
            MemberManager memberManager = new MemberManager(new EfMemberDAL());
            var memberUsername = Session["UserName"].ToString();
            var member = memberManager.TGetByUsernameBL(memberUsername);

            var memberOldPassword = member.MemberPassword;

            if (memberOldPassword == oldPassword)
            {
                if (newPassword1 == newPassword2)
                {
                    member.MemberPassword = newPassword1;
                    memberManager.TUpdateBL(member);
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