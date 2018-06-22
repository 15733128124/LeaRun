using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// 加班申请表控制器
    /// </summary>
    public class OvertimeRequestController : PublicController<OvertimeRequest>
    {
        OvertimeRequestBll otBll = new OvertimeRequestBll();

        public virtual ActionResult Edit()
        {
            return View();
        }
       
        public ActionResult GetMember(string DepartmentId) {
            DataTable dt = otBll.GetMemberList(DepartmentId);
            return Content(dt.ToJson());
        }

        /// <summary>
        /// 加载用户列表
        /// </summary>
        /// <param name="CompanyId">公司ID</param>
        /// <param name="DepartmentId">部门ID</param>
        /// <param name="ObjectId">对象主键</param>
        /// <param name="Category">对象分类:1-部门2-角色3-岗位4-群组</param>
        /// <returns></returns>
        public ActionResult MemberList(string CompanyId, string DepartmentId)
        {
            StringBuilder sb = new StringBuilder();
            DataTable ListData = otBll.GetList(CompanyId, DepartmentId);
            if (ListData != null && ListData.Rows.Count != 0)
            {
                foreach (DataRow item in ListData.Rows)
                {
                    string Genderimg = "user_female.png";
                    if (item["Gender"].ToString() == "男")
                    {
                        Genderimg = "user_green.png";
                    }
                    string strchecked = "";
                    sb.Append("<li class=\"" + item["departmentid"] + " " + strchecked + "\">");
                    sb.Append("<a class=\"a_" + strchecked + "\" id=\"" + item["userid"] + "\" title='工号：" + item["code"] + "\r\n账户：" + item["account"] + "'><img src=\"/Content/Images/Icon16/" + Genderimg + "\">" + item["realname"] + "</a><i></i>");
                    sb.Append("</li>");
                }
            }
            return Content(sb.ToString());
        }

        public ActionResult SubmitOvertimeForm(string UserId, string DepartmentId, OvertimeRequest ot)
        {
            string ModuleId = DESEncrypt.Decrypt(CookieHelper.GetCookie("ModuleId"));
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            try
            {
                string[] array = UserId.Split(',');
                for (int i = 0; i < array.Length - 1; i++) {
                    ot.Create();
                    ot.UserId = array[i];
                    ot.DepartmentId = DepartmentId;
                    database.Insert(ot, isOpenTrans);
                }
                database.Commit();
                return Content(new JsonMessage { Success = true, Code = "1", Message = "提交成功" }.ToString());
            }
            catch (Exception ex)
            {
                database.Rollback();
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 绑定表格
        /// </summary>
        /// <param name="ParameterJson">查询条件</param>
        /// <param name="Gridpage">分页条件</param>
        /// <returns></returns>
        [LoginAuthorize]
        public virtual ActionResult GridPageJsonOT(string keywords, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable ListData = otBll.GetPageList(keywords, ref jqgridparam);
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
    }
}