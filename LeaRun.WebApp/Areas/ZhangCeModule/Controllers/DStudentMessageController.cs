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
    /// �༶������ݽ���������
    /// </summary>
    public class DStudentMessageController : PublicController<DStudent_Class>
    {
        DStudent_TestOnOffBll studentOnOffBll = new DStudent_TestOnOffBll();
        private delegate bool StudentTestType(string testType);

        //ѧ��Ȩ����ͼ
        public ActionResult StudentLimit()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                List<DStudent_TestOnOff> list = studentOnOffBll.GetListDStudentTestOnOff(CookieHelper.GetCookie("NK"));
                string msg = "<span style=\"color:red\">��һ:</span>���޿���,<span style=\"color:red\">���:</span>���޿���,<span style=\"color:red\">����:</span>���޿���,<span style=\"color:red\">����:</span>���޿���";
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
                        if (model.TestType == "Լ������")
                        {
                            if (model.GradeCode == "41")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">��һ:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">��һ:</span>���޿���,";
                            if (model.GradeCode == "42")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">���:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">���:</span>���޿���,";
                            if (model.GradeCode == "43")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
                            if (model.GradeCode == "44")
                                yueKaoMsg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
                            yueKaoMsgResult = yueKaoMsgResult + yueKaoMsg;
                        }
                        if (model.TestType == "����Լ��")
                        {
                            if (model.GradeCode == "41")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">��һ:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">��һ:</span>���޿���,";
                            if (model.GradeCode == "42")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">���:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">���:</span>���޿���,";
                            if (model.GradeCode == "43")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
                            if (model.GradeCode == "44")
                                buCeMsg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
                            buCeMsgResult = buCeMsgResult + buCeMsg;
                        }
                        if (model.TestType == "��Ԫ����")
                        {
                            if (model.GradeCode == "41")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">��һ:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">��һ:</span>���޿���,";
                            if (model.GradeCode == "42")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">���:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">���:</span>���޿���,";
                            if (model.GradeCode == "43")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
                            if (model.GradeCode == "44")
                                danYuanMsg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
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
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }


        //ѧ����Լ������Ȩ��
        public JsonResult YueKao(string state, string yueKaoLimit)
        {
            StudentTestType typeDelegate = new StudentTestType(GetYueKao);
            return TypeResultMsg(state, yueKaoLimit, "Լ������", typeDelegate);
        }
        //ѧ���˵�Ԫ����Ȩ��
        public JsonResult DanYuan(string state, string danYuanLimit)
        {
            StudentTestType typeDelegate = new StudentTestType(GetDanYuan);
            return TypeResultMsg(state, danYuanLimit, "��Ԫ����", typeDelegate);
        }
        //ѧ���˲���Լ��Ȩ��
        public JsonResult BuCe(string state, string buCeLimit)
        {
            StudentTestType typeDelegate = new StudentTestType(GetBuCe);
            return TypeResultMsg(state, buCeLimit, "����Լ��", typeDelegate);
        }

        //˽�з���
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
                            msg = model.State == "1" ? "<span style=\"color:red\">��һ:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">��һ:</span>���޿���,";
                        if (model.GradeCode == "42")
                            msg = model.State == "1" ? "<span style=\"color:red\">���:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">���:</span>���޿���,";
                        if (model.GradeCode == "43")
                            msg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
                        if (model.GradeCode == "44")
                            msg = model.State == "1" ? "<span style=\"color:red\">����:</span><span style=\"color:blue\">�ѿ���,</span>" : "<span style=\"color:red\">����:</span>���޿���,";
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

        //˽�з���
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

        //Լ����������
        private bool GetYueKao(string testType)
        {
            return testType == "Լ������" ? true : false;
        }
        //����Լ������
        private bool GetBuCe(string testType)
        {
            return testType == "����Լ��" ? true : false;
        }
        //��Ԫ��������
        private bool GetDanYuan(string testType)
        {
            return testType == "��Ԫ����" ? true : false;
        }
    }
}