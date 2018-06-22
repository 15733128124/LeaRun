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
    /// ѧ�����������ݽ���������
    /// </summary>
    public class DStudentAnnouncementController : PublicController<DStudent_Announcement>
    {

        #region ����Ļ�������

        //ʵ�����ͻ��������Ķ���
        DStudent_AnnouncementBll bLL = new DStudent_AnnouncementBll();


        /// <summary>
        /// ���ݹؼ��ֲ�ѯ��Ϣ����Json
        /// </summary>
        /// <param name="valueKey">�ؼ���</param>
        /// <param name="jqgridparam">�������</param>
        /// <returns>Json����</returns>
        [LoginAuthorize]
        public ActionResult GridAnnouncementPageJson(string KeyValue, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable ListData = bLL.GetAnnouncementPageList(KeyValue, ref jqgridparam);
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
        /// ��ӹ���
        /// </summary>
        /// <returns></returns>
       
        public ActionResult AddAnnouncement(string title, string content)
        {
            try
            {
                string Message = "��ӳɹ�";
                int IsOk = 0;

                DStudent_Announcement model = new DStudent_Announcement
                {
                    Title = title,
                    Content = content,
                    ContentState = "����",
                    CreateTime = DateTime.Now.ToString(),
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                IsOk = bLL.AddAnnouncement(model);

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// �޸Ĺ���
        /// </summary>
        /// <returns></returns>
       
        public ActionResult UpdAnnouncement(string title, string content, string KeyValue)
        {
            try
            {
                string Message = "�޸ĳɹ�";
                int IsOk = 0;

                DStudent_Announcement model = new DStudent_Announcement
                {
                    ID = Convert.ToInt32(KeyValue),
                    Title = title,
                    Content = content,
                    ContentState = "����",
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                IsOk = bLL.UpdAnnouncement(model);

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
      
        public ActionResult GetAnnouncementModel(int KeyValue)
        {
            try
            {
                DStudent_Announcement model = bLL.GetAnnouncementModel(KeyValue);
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="KeyValue">Ψһֵ</param>
        /// <returns></returns>
      
        public ActionResult DelAnnoucement(string KeyValue)
        {
            try
            {
                string Message = "ɾ���ɹ���";
                int IsOk = 0;
                string[] array = KeyValue.Split(',');
                if (array.Length == 1)
                {
                    IsOk = bLL.DelAnnoucement(Convert.ToInt32(KeyValue));
                }
                else
                {
                    int count = 0;
                    foreach (string delId in array)
                    {
                        count = IsOk = bLL.DelAnnoucement(Convert.ToInt32(delId));
                        if (count > 0)
                        {
                            IsOk = IsOk + count;
                        }
                    }
                }
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
        #endregion




    }
}