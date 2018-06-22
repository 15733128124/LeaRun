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
    /// 学生公告表（随年份建表）控制器
    /// </summary>
    public class DStudentAnnouncementController : PublicController<DStudent_Announcement>
    {

        #region 公告的基本操作

        //实例化客户表操作类的对象
        DStudent_AnnouncementBll bLL = new DStudent_AnnouncementBll();


        /// <summary>
        /// 根据关键字查询信息返回Json
        /// </summary>
        /// <param name="valueKey">关键字</param>
        /// <param name="jqgridparam">表格属性</param>
        /// <returns>Json数据</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 添加公告
        /// </summary>
        /// <returns></returns>
       
        public ActionResult AddAnnouncement(string title, string content)
        {
            try
            {
                string Message = "添加成功";
                int IsOk = 0;

                DStudent_Announcement model = new DStudent_Announcement
                {
                    Title = title,
                    Content = content,
                    ContentState = "开启",
                    CreateTime = DateTime.Now.ToString(),
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                IsOk = bLL.AddAnnouncement(model);

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 修改公告
        /// </summary>
        /// <returns></returns>
       
        public ActionResult UpdAnnouncement(string title, string content, string KeyValue)
        {
            try
            {
                string Message = "修改成功";
                int IsOk = 0;

                DStudent_Announcement model = new DStudent_Announcement
                {
                    ID = Convert.ToInt32(KeyValue),
                    Title = title,
                    Content = content,
                    ContentState = "开启",
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                IsOk = bLL.UpdAnnouncement(model);

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 获取编辑信息
        /// </summary>
        /// <param name="KeyValue">主键</param>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="KeyValue">唯一值</param>
        /// <returns></returns>
      
        public ActionResult DelAnnoucement(string KeyValue)
        {
            try
            {
                string Message = "删除成功！";
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
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "删除失败！" }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Delete, "-1", "异常错误：" + ex.Message);
                return null;
            }

        }
        #endregion




    }
}