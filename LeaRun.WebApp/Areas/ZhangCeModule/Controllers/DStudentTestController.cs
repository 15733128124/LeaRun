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
    /// 学生测试表（随年份建表）控制器
    /// </summary>
    public class DStudentTestController : PublicController<DStudent_Test>
    {
        DStudent_TestBll dSTestBll = new DStudent_TestBll();
        /// <summary>
        /// 根据关键字查询信息返回Json
        /// </summary>
        /// <param name="valueKey">关键字</param>
        /// <param name="jqgridparam">表格属性</param>
        /// <returns>Json数据</returns>
        [HttpGet]
        [LoginAuthorize]
        public ActionResult GridPageDStudentTestJson(string schoolName, string className,
            string testTeacher, string testType, string testBeginDate, string studentCode, string gradeCode, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable ListData = dSTestBll.GetDStudentTestList(schoolName, className, testTeacher, testType, testBeginDate, studentCode, gradeCode, CookieHelper.GetCookie("NK"), ref jqgridparam);
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

        #region 导出
        //导出窗体
        public ActionResult DeriveForm()
        { 
            //ViewBag.schoolName = Request.QueryString["schoolName"].ToString();
            //ViewBag.className = Request.QueryString["className"].ToString();
            //ViewBag.testTeacher = Request.QueryString["testTeacher"].ToString();
            //ViewBag.studentSex = Request.QueryString["studentSex"].ToString();
            //ViewBag.testBeginDate = Request.QueryString["testBeginDate"].ToString();
            //ViewBag.studentCode = Request.QueryString["studentCode"].ToString();
            //ViewBag.gradeCode = Request.QueryString["gradeCode"].ToString();
            return View();
        }

        /// <summary>
        /// 获取要导出表头字段
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDeriveExcelColumn()
        {
            string JsonColumn = GZipHelper.Uncompress(CookieHelper.GetCookie("JsonColumn_DeriveExcel"));
            return Content(JsonColumn);
        }

        //导出学生测试  
        [HttpGet]
        [LoginAuthorize]
        public FileResult GetDeriveExcel(string ExportField, string schoolName, string className,
            string testTeacher, string studentSex, string testBeginDate, string studentCode, string gradeCode)
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            ExportField =ExportField.Substring(0, ExportField.Length-1);
            string[] pName = ExportField.Split(',');
            // 1.获取数据集合
            List<DStudent_Test> list = dSTestBll.TestStudentExport(ExportField, schoolName, className,
             testTeacher, studentSex, testBeginDate, studentCode, gradeCode, CookieHelper.GetCookie("NK"));

            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            Dictionary<string, string> cellheader = new Dictionary<string, string> { };
            for (int i = 0; i < pName.Length; i++)
            {
                if (pName[i] == "studentcode")
                    cellheader.Add("StudentCode", "学生学号");
                if (pName[i] == "gradecode")
                    cellheader.Add("GradeCode", "所属年级");
                if (pName[i] == "schoolcode")
                    cellheader.Add("SchoolCode", "学院编号");
                if (pName[i] == "schoolname")
                    cellheader.Add("AchoolName", "学院名称");
                if (pName[i] == "classcode")
                    cellheader.Add("ClassCode", "班级编号");
                if (pName[i] == "classname")
                    cellheader.Add("ClassName", "班级名称");
                if (pName[i] == "testsetid")
                    cellheader.Add("TestSetID", "测试设置ID");
                if (pName[i] == "studentname")
                    cellheader.Add("StudentName", "学生名称");
                if (pName[i] == "studentsex")
                    cellheader.Add("StudentSex", "学生性别 男：1，女：2");
                if (pName[i] == "testteacher")
                    cellheader.Add("TestTeacher", "测试老师");
                if (pName[i] == "testaddress")
                    cellheader.Add("TestAddress", "测试地址");
                if (pName[i] == "beginpradate")
                    cellheader.Add("BeginPraDate", "开始测试日期");
                if (pName[i] == "beginweek")
                    cellheader.Add("BeginWeek", "开始测试星期");
                if (pName[i] == "beginpratime")
                    cellheader.Add("BeginPraTime", "开始测试时间");
                if (pName[i] == "applyfor")
                    cellheader.Add("ApplyFor", "是否有效 有效：1，无效：2");
                if (pName[i] == "testgroup")
                    cellheader.Add("Testgroup", "测试组");
                if (pName[i] == "testgroupcode")
                    cellheader.Add("TestGroupCode", "测试组号");
                if (pName[i] == "testtype")
                    cellheader.Add("TestType", "测试类型 ");
                if (pName[i] == "createtime")
                    cellheader.Add("CreateTime", "创建时间");
                if (pName[i] == "updatetime")
                    cellheader.Add("UpdateTime", "更改时间");
                if (pName[i] == "remark")
                    cellheader.Add("Remark", "备注");

            }

            string stustr = "";
            if(studentSex=="1")
                stustr = "男";
            if (studentSex == "2")
                stustr = "女";
            string fuStr= "体测信息表(" + testTeacher + "_" + testBeginDate + "_" + stustr + ").xls";
            // 3.进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "导出老师体测信息表");
            FilePathResult file = new FilePathResult("~/" + urlPath, "application/vnd.ms-excel");
            file.FileDownloadName = fuStr;
            return file;

        }

        #endregion

      

    }
}