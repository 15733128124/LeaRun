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
    /// 班级表（随年份建表）控制器
    /// </summary>
    public class DStudentMessageController : PublicController<DStudent_Class>
    {
        DStudent_TestOnOffBll studentOnOffBll = new DStudent_TestOnOffBll();
        private delegate bool StudentTestType(string testType);

        //学生权限视图
        public ActionResult StudentLimit()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                List<DStudent_TestOnOff> list = studentOnOffBll.GetListDStudentTestOnOff(CookieHelper.GetCookie("NK"));
                string msg = "<span style=\"color:red\">大一:</span>暂无开启,<span style=\"color:red\">大二:</span>暂无开启,<span style=\"color:red\">大三:</span>暂无开启,<span style=\"color:red\">大四:</span>暂无开启";
                if (list.Count == 0)
                {
                    ViewBag.YueKao = msg;
                    ViewBag.BuCe = msg;
                    ViewBag.DanYuan = msg;
                }
                else
                {
                    string yueKaoMsg = "";
                    string buCeMsg = "";
                    string danYuanMsg = "";
                    string yueKaoMsgResult = "";
                    string buCeMsgResult = "";
                    string danYuanMsgResult = "";
                    foreach (DStudent_TestOnOff model in list)
                    {
                        if (model.TestType == "约考测试")
                        {
                            if (model.GradeCode == "41")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">大一:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大一:</span>暂无开启,";
                            if (model.GradeCode == "42")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">大二:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大二:</span>暂无开启,";
                            if (model.GradeCode == "43")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">大三:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大三:</span>暂无开启,";
                            if (model.GradeCode == "44")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">大四:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大四:</span>暂无开启,";
                            yueKaoMsgResult = yueKaoMsgResult + yueKaoMsg;
                        }
                        if (model.TestType == "补测约考")
                        {
                            if (model.GradeCode == "41")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">大一:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大一:</span>暂无开启,";
                            if (model.GradeCode == "42")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">大二:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大二:</span>暂无开启,";
                            if (model.GradeCode == "43")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">大三:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大三:</span>暂无开启,";
                            if (model.GradeCode == "44")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">大四:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大四:</span>暂无开启,";
                            buCeMsgResult = buCeMsgResult + buCeMsg;
                        }
                        if (model.TestType == "单元测试")
                        {
                            if (model.GradeCode == "41")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">大一:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大一:</span>暂无开启,";
                            if (model.GradeCode == "42")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">大二:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大二:</span>暂无开启,";
                            if (model.GradeCode == "43")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">大三:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大三:</span>暂无开启,";
                            if (model.GradeCode == "44")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">大四:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大四:</span>暂无开启,";
                            danYuanMsgResult = danYuanMsgResult + danYuanMsg;
                        }
                    }

                    ViewBag.YueKao = yueKaoMsgResult.Length == 0 ? msg : yueKaoMsgResult.Substring(0, yueKaoMsgResult.Length - 1);
                    ViewBag.BuCe = buCeMsgResult.Length == 0 ? msg : buCeMsgResult.Substring(0, buCeMsgResult.Length - 1);
                    ViewBag.DanYuan = danYuanMsgResult.Length == 0 ? msg : danYuanMsgResult.Substring(0, danYuanMsgResult.Length - 1);
                }
                return View();
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">您没有选择年库！请选择年库！</div>", "text/html");
            }
        }


        //学生端约考测试权限
        public JsonResult YueKao(string state, string yueKaoLimit)
        {
            StudentTestType typeDelegate = new StudentTestType(GetYueKao);
            return TypeResultMsg(state, yueKaoLimit, "约考测试", typeDelegate);
        }
        //学生端单元测试权限
        public JsonResult DanYuan(string state, string danYuanLimit)
        {
            StudentTestType typeDelegate = new StudentTestType(GetDanYuan);
            return TypeResultMsg(state, danYuanLimit, "单元测试", typeDelegate);
        }
        //学生端补测约考权限
        public JsonResult BuCe(string state, string buCeLimit)
        {
            StudentTestType typeDelegate = new StudentTestType(GetBuCe);
            return TypeResultMsg(state, buCeLimit, "补测约考", typeDelegate);
        }

        //私有方法
        private JsonResult TypeResultMsg(string state, string gradeCode, string typeTest, StudentTestType typeDelegate)
        {
            List<DStudent_TestOnOff> studentList = new List<DStudent_TestOnOff>();
            bool flg = false;
            int n = studentOnOffBll.SelectCountStudentTestOnOff(typeTest, CookieHelper.GetCookie("NK"));
            if (studentOnOffBll.SelectCountStudentTestOnOff(typeTest, CookieHelper.GetCookie("NK")) == 4)
            {              
                flg = true;
            }
            else
            {
                if (studentOnOffBll.UnitStudentTestLimit(typeTest, CookieHelper.GetCookie("NK")) == 4)
                {
                    flg = true;
                }
            }
            if (flg)
            {                
                string msg = "";
                string msgResult = "";
                if (studentOnOffBll.UpdDStudentTestOnOff(new DStudent_TestOnOff
                {
                    State = state,
                    TestType = typeTest,
                    GradeCode = gradeCode,
                    CreateTime = System.DateTime.Now.ToString(),
                    UpdateTime = System.DateTime.Now.ToString(),
                    Remark = ""
                }, CookieHelper.GetCookie("NK")) > 0)
                {
                    studentList = studentOnOffBll.GetListDStudentTestOnOff(CookieHelper.GetCookie("NK"));
                    List<DStudent_TestOnOff> list = GetTestTypeList(studentList, typeDelegate);
                    foreach (DStudent_TestOnOff model in list)
                    {
                        if (model.GradeCode == "41")
                            msg = model.State == "1" ? "<span style=\"color:red\">大一:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大一:</span>暂无开启,";
                        if (model.GradeCode == "42")
                            msg = model.State == "1" ? "<span style=\"color:red\">大二:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大二:</span>暂无开启,";
                        if (model.GradeCode == "43")
                            msg = model.State == "1" ? "<span style=\"color:red\">大三:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大三:</span>暂无开启,";
                        if (model.GradeCode == "44")
                            msg = model.State == "1" ? "<span style=\"color:red\">大四:</span><span style=\"color:blue\">已开启,</span>" : "<span style=\"color:red\">大四:</span>暂无开启,";
                        msgResult = msgResult + msg;
                    }
                    msgResult = msgResult.Substring(0, msgResult.Length - 1);
                    return Json(new { IsOk = true, Msg = msgResult });
                }
                else
                {
                    return Json(new { IsOk = false, Msg = "" });
                }
            }
            else
            {
                return Json(new { IsOk = false, Msg = "" });
            }
        }

        //私有方法
        private List<DStudent_TestOnOff> GetTestTypeList(List<DStudent_TestOnOff> list, StudentTestType method)
        {
            List<DStudent_TestOnOff> resultList = new List<DStudent_TestOnOff>();
            foreach (DStudent_TestOnOff model in list)
            {
                if (method.Invoke(model.TestType))
                {
                    resultList.Add(model);
                }
            }
            return resultList;


        }

        //约考测试条件
        private bool GetYueKao(string testType)
        {
            return testType == "约考测试" ? true : false;
        }
        //补测约考条件
        private bool GetBuCe(string testType)
        {
            return testType == "补测约考" ? true : false;
        }
        //单元测试条件
        private bool GetDanYuan(string testType)
        {
            return testType == "单元测试" ? true : false;
        }
    }
}