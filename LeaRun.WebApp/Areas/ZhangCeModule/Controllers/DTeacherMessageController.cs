using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.ZhangCeModule.Controllers
{
    /// <summary>
    ///�û��������
    /// </summary>
    public class DTeacherMessageController : PublicController<DBase_Users>
    {
        DBase_UsersBll bull = new DBase_UsersBll();
        DTecher_TestOnOffBll teacherOnOffBll = new DTecher_TestOnOffBll();
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ��Ϣ����Json
        /// </summary>
        /// <param name="valueKey">�ؼ���</param>
        /// <param name="jqgridparam">�������</param>
        /// <returns>Json����</returns>
        [LoginAuthorize]
        public ActionResult GridTeacherMessagetPageJson(string KeyValue, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable resultListData = bull.GetTeacherPageList(KeyValue, ref jqgridparam);
                DataTable ListData = new DataTable();
                ListData = resultListData.Clone();
                foreach (DataRow row in resultListData.Rows)
                {
                    DataRow rowNew = ListData.NewRow();
                    rowNew["ID"] = row["ID"];
                    rowNew["UserName"] = row["UserName"];
                    rowNew["UserCode"] = row["UserCode"];
                    rowNew["UserPassword"] = DESEncrypt.Decrypt(row["UserPassword"].ToString());
                    rowNew["UserLeavel"] = row["UserLeavel"];
                    rowNew["CreateTime"] = row["CreateTime"];
                    rowNew["UpdateTime"] = row["UpdateTime"];
                    rowNew["Remark"] = row["Remark"];
                    rowNew["UserState"] = row["UserState"];
                    ListData.Rows.Add(rowNew);
                }
                var JsonData = new
                {
                    total = jqgridparam.total,
                    page = jqgridparam.page,
                    records = jqgridparam.records,
                    costtime = CommonHelper.TimerEnd(watch),
                    rows = ListData,
                };
                return Content(JsonData.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// �����ʦ
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTeacherMessage(string userName, string userCode, string userPassword)
        {
            try
            {
                string Message = "��ӳɹ�";
                int IsOk = 0;
                IsOk = bull.AddDBase_UserTeacher(userName, userCode, DESEncrypt.Encrypt(userPassword));

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// �޸���ʦ
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdTeacherMessage(string userName, string userCode, string userPassword, string userState, string KeyValue)
        {
            try
            {
                string Message = "�޸ĳɹ�";
                int IsOk = 0;

                DBase_Users model = new DBase_Users
                {
                    ID = Convert.ToInt32(KeyValue),
                    UserName = userName,
                    UserCode = userCode,
                    UserPassword = DESEncrypt.Encrypt(userPassword),
                    UserLeavel = "1",
                    CreateTime = System.DateTime.Now.ToString(),
                    UpdateTime = System.DateTime.Now.ToString(),
                    Remark = "",
                    UserState = userState

                };
                IsOk = bull.UpdDBase_UserTeacber(model);

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// ��ȡ�༭��Ϣ
        /// </summary>
        /// <param name="KeyValue">����</param>
        /// <returns></returns>
        public ActionResult GetTeacherMessageModel(int KeyValue)
        {
            try
            {
                DBase_Users resultModel = bull.GetBaseInfoByID(KeyValue);
                DBase_Users model = new DBase_Users
                {
                    ID = resultModel.ID,
                    UserName = resultModel.UserName,
                    UserCode = resultModel.UserCode,
                    UserPassword = DESEncrypt.Decrypt(resultModel.UserPassword),
                    UserLeavel = resultModel.UserLeavel,
                    CreateTime = resultModel.CreateTime,
                    UpdateTime = resultModel.UpdateTime,
                    Remark = resultModel.Remark,
                    UserState = resultModel.UserState

                };
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ɾ����ʦ
        /// </summary>
        /// <param name="KeyValue">Ψһֵ</param>
        /// <returns></returns>
        public ActionResult DelTeacherMessage(string KeyValue)
        {
            try
            {
                string Message = "ɾ���ɹ���";
                int IsOk = 0;
                IsOk = bull.DelTeacherMessage(Convert.ToInt32(KeyValue));

                if (IsOk > 0)
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                else
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "ɾ��ʧ�ܣ�" }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Delete, "-1", "�쳣����" + ex.Message);
                return null;
            }

        }

        /// <summary>
        /// �б���ͼ
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherLimit()
        {

            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                List<DTecher_TestOnOff> list = teacherOnOffBll.GetListDTeacherTestOnOff(CookieHelper.GetCookie("NK"));
                if (list.Count == 0)
                {
                    ViewBag.YueKao = "���޿���";
                    ViewBag.BuCe = "���޿���";
                    ViewBag.DanYuan = "���޿���";
                }
                foreach (DTecher_TestOnOff model in list)
                {
                    if (model.TestType == "Լ������")
                    {
                        ViewBag.YueKao = model.State == "1" ? "�ѿ���" : "���޿���";
                    }
                    if (model.TestType == "����Լ��")
                    {
                        ViewBag.BuCe = model.State == "1" ? "�ѿ���" : "���޿���";
                    }
                    if (model.TestType == "��Ԫ����")
                    {
                        ViewBag.DanYuan = model.State == "1" ? "�ѿ���" : "���޿���";
                    }
                }
                return View();
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }

        //��ʦ��Լ������Ȩ��
        public JsonResult YueKao(string state)
        {
            DTecher_TestOnOff model = teacherOnOffBll.GetModelDTeacherTestOnOff("Լ������", CookieHelper.GetCookie("NK"));
            if (model.State != null)
            {
                return state == model.State ? Json(new { IsOk = true }) : Json(new
                {
                    IsOk = teacherOnOffBll.UpdDTeacherTestOnOff(new DTecher_TestOnOff
                    {
                        State = state,
                        TestType = "Լ������",
                        CreateTime = System.DateTime.Now.ToString(),
                        UpdateTime = System.DateTime.Now.ToString(),
                        Remark = ""
                    }, CookieHelper.GetCookie("NK"))
                });
            }
            else
            {
                return Json(new
                {
                    IsOk = teacherOnOffBll.AddDTeacherTestOnOff(new DTecher_TestOnOff
                    {
                        State = state,
                        TestType = "Լ������",
                        CreateTime = System.DateTime.Now.ToString(),
                        UpdateTime = System.DateTime.Now.ToString(),
                        Remark = ""
                    }, CookieHelper.GetCookie("NK"))
                });
            }
        }
        //��ʦ�˵�Ԫ����Ȩ��
        public JsonResult DanYuan(string state)
        {
            DTecher_TestOnOff model = teacherOnOffBll.GetModelDTeacherTestOnOff("��Ԫ����", CookieHelper.GetCookie("NK"));
            if (model.State != null)
            {
                return state == model.State ? Json(new { IsOk = true }) : Json(new
                {
                    IsOk = teacherOnOffBll.UpdDTeacherTestOnOff(new DTecher_TestOnOff
                    {
                        State = state,
                        TestType = "��Ԫ����",
                        CreateTime = System.DateTime.Now.ToString(),
                        UpdateTime = System.DateTime.Now.ToString(),
                        Remark = ""
                    }, CookieHelper.GetCookie("NK"))
                });
            }
            else
            {
                return Json(new
                {
                    IsOk = teacherOnOffBll.AddDTeacherTestOnOff(new DTecher_TestOnOff
                    {
                        State = state,
                        TestType = "��Ԫ����",
                        CreateTime = System.DateTime.Now.ToString(),
                        UpdateTime = System.DateTime.Now.ToString(),
                        Remark = ""
                    }, CookieHelper.GetCookie("NK"))
                });
            }
        }
        //��ʦ�˲���Լ��Ȩ��
        public JsonResult BuCe(string state)
        {
            DTecher_TestOnOff model = teacherOnOffBll.GetModelDTeacherTestOnOff("����Լ��", CookieHelper.GetCookie("NK"));
            if (model.State != null)
            {
                return state == model.State ? Json(new { IsOk = true }) : Json(new
                {
                    IsOk = teacherOnOffBll.UpdDTeacherTestOnOff(new DTecher_TestOnOff
                    {
                        State = state,
                        TestType = "����Լ��",
                        CreateTime = System.DateTime.Now.ToString(),
                        UpdateTime = System.DateTime.Now.ToString(),
                        Remark = ""
                    }, CookieHelper.GetCookie("NK"))
                });
            }
            else
            {
                return Json(new
                {
                    IsOk = teacherOnOffBll.AddDTeacherTestOnOff(new DTecher_TestOnOff
                    {
                        State = state,
                        TestType = "����Լ��",
                        CreateTime = System.DateTime.Now.ToString(),
                        UpdateTime = System.DateTime.Now.ToString(),
                        Remark = ""
                    }, CookieHelper.GetCookie("NK"))
                });
            }
        }



    }
}