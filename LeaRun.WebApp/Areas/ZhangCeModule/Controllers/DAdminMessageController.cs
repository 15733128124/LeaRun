using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.ZhangCeModule.Controllers
{
    /// <summary>
    /// ����Ա���ÿ�����
    /// </summary>
    public class DAdminMessageController : PublicController<DBase_Users>
    {
        DBase_UsersBll buBll = new DBase_UsersBll();

        //����Ա������ͼ
       
        public ActionResult AdminSet()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                DBase_Users model = buBll.GetKouLingModel();
                DBase_Users modelResult = new DBase_Users {
                    UserCode=model.UserCode,
                    UserPassword = DESEncrypt.Decrypt(model.UserPassword)
                };
                return View(modelResult);
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }

        //����Ա���ÿ���
     
        public JsonResult UpdNKKouLing(string updNKMark)
        {
            return Json(new { IsOk = buBll.AdminResetKouLing(ManageProvider.Provider.Current().Account, DESEncrypt.Encrypt(updNKMark)) > 0 ? true : false });
        }
    }
}