using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.ZhangCeModule.Controllers
{
    public class ExcelExportController : Controller
    {
        public ActionResult Index()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                return View();
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">您没有选择年库！请选择年库！</div>", "text/html");
            }
        }

        //导出学生测试模版
        [LoginAuthorize]
        public ActionResult TestModuleExcelExport()
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            TestMoudleBll tmBll = new TestMoudleBll();
            // 1.获取数据集合
            List<TestMoudle> list = tmBll.GetTestMoudleAllInfo(CookieHelper.GetCookie("NK"));

            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            Dictionary<string, string> cellheader = new Dictionary<string, string>{
            { "GradeCode", "年级" },
            { "ClassCode", "班级编号" },
            { "ClassName", "班级名称" },
            { "ItemName", "项目名称" },
            { "TestTeacher", "测试老师" },
            { "TestTime", "测试时间" },
            { "TestAddress", "测试地点" },
            { "TestMaterial", "测试器材" },
            { "TestType", "测试方式（手工/仪器）" },
        };
            // 3.进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "测试信息模版");
            var path = Server.MapPath("~/" + urlPath);
            var name = Path.GetFileName(path);
            return File(path, "application/vnd.ms-excel", name);

        }

        //班级信息上报表的导出
        [LoginAuthorize]
        public ActionResult ClassInfoExcelExport()
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            DStudent_ClassBll scBll = new DStudent_ClassBll();
            // 1.获取数据集合
            List<DStudent_Class> list = scBll.GetAllStudentClassInfoList(CookieHelper.GetCookie("NK"));

            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            Dictionary<string, string> cellheader = new Dictionary<string, string>{
            { "GradeCode", "年级" },
            { "ClassCode", "班级编号" },
            { "ClassName", "班级名称" },
        };
            // 3.进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "班级信息上报表");
            var path = Server.MapPath("~/" + urlPath);
            var name = Path.GetFileName(path);
            return File(path, "application/vnd.ms-excel", name);
        }

        //学生成绩上报表的导出（男）
        [LoginAuthorize]
        public ActionResult StudentScoreManExcelExport()
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            DStudent_TestScoreBll tcBll = new DStudent_TestScoreBll();
            // 1.获取数据集合
            List<StudentScoreExcel> list = tcBll.GetDStudentTestScoreListExport(CookieHelper.GetCookie("NK"), "1");

            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            Dictionary<string, string> cellheader = new Dictionary<string, string>{
             { "GradeCode", "年级编号" },
            { "ClassCode", "班级编号" },
            { "ClassName", "班级名称" },
            { "StudentCode", "学籍号" },
            { "NationCode", "民族代码" },
            { "StudentName", "姓名" },
            { "StudentSex", "性别（男：1，女：2）" },
            { "StudentBornDate", "出生日期" },
             { "StudentSource", "学生来源" },
              { "StudentIDNumber", "身份证号" },
            { "StudentNative", "家庭住址" },
            { "Heigh", "身高" },
            { "Weight", "体重" },
            { "Pulmonary", "肺活量" },
             { "FiftyRun", "50米跑" },
            { "StandJump", "立定跳远" },
            { "SitAndReach", "坐位体前屈" },
            { "EightHundred", "800米跑" },
            { "ThousandRun", "1000米跑" },
            { "MinSupination", "一分钟仰卧起坐" },
            {"PullUp","引体向上"},
        };
            // 3.进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "学生上报成绩表（男）");
            var path = Server.MapPath("~/" + urlPath);
            var name = Path.GetFileName(path);
            return File(path, "application/vnd.ms-excel", name);
        }
        //学生成绩上报表的导出（女）
        [LoginAuthorize]
        public ActionResult StudentScoreWoManExcelExport()
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            DStudent_TestScoreBll tcBll = new DStudent_TestScoreBll();
            // 1.获取数据集合
            List<StudentScoreExcel> list = tcBll.GetDStudentTestScoreListExport(CookieHelper.GetCookie("NK"), "2");
            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            Dictionary<string, string> cellheader = new Dictionary<string, string>{
            { "GradeCode", "年级编号" },
            { "ClassCode", "班级编号" },
            { "ClassName", "班级名称" },
            { "StudentCode", "学籍号" },
            { "NationCode", "民族代码" },
            { "StudentName", "性别（男：1，女：2）" },
            { "StudentSex", "性别" },
            { "StudentBornDate", "出生日期" },
             { "StudentSource", "学生来源" },
              { "StudentIDNumber", "身份证号" },
            { "StudentNative", "家庭住址" },
            { "Heigh", "身高" },
            { "Weight", "体重" },
            { "Pulmonary", "肺活量" },
             { "FiftyRun", "50米跑" },
            { "StandJump", "立定跳远" },
            { "SitAndReach", "坐位体前屈" },
            { "EightHundred", "800米跑" },
            { "ThousandRun", "1000米跑" },
            { "MinSupination", "一分钟仰卧起坐" },
            {"PullUp","引体向上"},
        };
            // 3.进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "学生上报成绩表（女）");
            var path = Server.MapPath("~/" + urlPath);
            var name = Path.GetFileName(path);
            return File(path, "application/vnd.ms-excel", name);
        }

        //河北省导出
        [LoginAuthorize]
        public ActionResult HeBeiStudentTestTableExport()
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            DStudent_TestScoreBll tcBll = new DStudent_TestScoreBll();
            List<HeBeiStudents> heBeiSList = tcBll.GetHeBeiStudentInfoExport(CookieHelper.GetCookie("NK"));
            StringBuilder HeBeiHtmlTable = new StringBuilder();
            HeBeiHtmlTable.Append("<table>");
            HeBeiHtmlTable.Append("<tr><th >序号</th><th>新生来源地（以省内11个设区市为单位）</th><th>性别</th><th>人数</th><th>优秀率</th><th>良好率</th><th>及格率</th><th>总达标率</th></tr>");
            string mes = "";
            foreach (HeBeiStudents heBeiS in heBeiSList)
            {
                mes = mes + string.Format("<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th></tr>",
                    heBeiS.ID, heBeiS.StudentAddress, heBeiS.StudentSex, heBeiS.StudentCount, heBeiS.Outstanding, heBeiS.Goodrate, heBeiS.PassRate, heBeiS.TotalRate);
            }
            HeBeiHtmlTable.Append(mes);
            HeBeiHtmlTable.Append("</table>");

            // 进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ExportHtmlTableToExcel(HeBeiHtmlTable.ToString(), "河北新生表");
            var path = Server.MapPath("~/" + urlPath);
            var name = Path.GetFileName(path);
            return File(path, "application/vnd.ms-excel", name);
        }

        //其它导出
        public ActionResult OtherIndex()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                return View();
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">您没有选择年库！请选择年库！</div>", "text/html");
            }
        }


        //导出窗体
        public ActionResult DeriveForm()
        {
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
        /// <summary>
        /// 学生信息自定义导出
        /// </summary>
        /// <param name="ExportField"></param>
        /// <param name="ResultType"></param>
        /// <returns></returns>
        public ActionResult StudentOtherExcelExport(string ExportField, string ResultType)
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            DStudent_TestScoreBll tcBll = new DStudent_TestScoreBll();
            ExportField = ExportField.Substring(0, ExportField.Length - 1);
            string[] pName = ExportField.Split(',');

            // 1.获取数据集合
            List<StudentScoreExcel> list = tcBll.StudentOtherExport(ResultType, CookieHelper.GetCookie("NK"));

            // 2.设置单元格抬头
            // key：实体对象属性名称，可通过反射获取值
            // value：Excel列的名称
            Dictionary<string, string> cellheader = new Dictionary<string, string> { };
            for (int i = 0; i < pName.Length; i++)
            {

                if (pName[i] == "studentcode") cellheader.Add("StudentCode", "学生学号");
                if (pName[i] == "studentname") cellheader.Add("StudentName", "学生姓名");
                if (pName[i] == "studentsex") cellheader.Add("StudentSex", "学生性别");
                if (pName[i] == "studentborndate") cellheader.Add("StudentBornDate", "出生日期");
                if (pName[i] == "studenthomeaddress") cellheader.Add("StudentHomeAddress", "学生住址");
                if (pName[i] == "gradecode") cellheader.Add("GradeCode", "年级编号");
                if (pName[i] == "schoolname") cellheader.Add("SchoolName", "学院名称");
                if (pName[i] == "schoolcode") cellheader.Add("SchoolCode", "学院编号");
                if (pName[i] == "classname") cellheader.Add("ClassName", "班级名称");
                if (pName[i] == "classcode") cellheader.Add("ClassCode", "班级编号");
                if (pName[i] == "nationcode") cellheader.Add("NationCode", "民族编号");
                if (pName[i] == "nationname") cellheader.Add("NationName", "民族名称");
                if (pName[i] == "studentnative") cellheader.Add("StudentNative", "学生籍贯");
                if (pName[i] == "studentmovetype") cellheader.Add("StudentMoveType", "异动类型");
                if (pName[i] == "studentidnumber") cellheader.Add("StudentIDNumber", "学生身份证号");
                if (pName[i] == "studentphone") cellheader.Add("StudentPhone", "学生电话");
                if (pName[i] == "studentisregister") cellheader.Add("StudentIsRegister", "是否注册");
                if (pName[i] == "heigh") cellheader.Add("Heigh", "身高");
                if (pName[i] == "weight") cellheader.Add("Weight", "体重");
                if (pName[i] == "bmi") cellheader.Add("BMI", "体重指数");
                if (pName[i] == "bmiscore") cellheader.Add("BMIScore", "体重指数得分");
                if (pName[i] == "bmilevel") cellheader.Add("BMILevel", "体重指数级别");
                if (pName[i] == "pulmonary") cellheader.Add("Pulmonary", "肺活量");
                if (pName[i] == "pulmonaryscore") cellheader.Add("PulmonaryScore", "肺活量得分");
                if (pName[i] == "pulmonarylevel") cellheader.Add("PulmonaryLevel", "肺活量级别");
                if (pName[i] == "fiftyrun") cellheader.Add("FiftyRun", "50米跑");
                if (pName[i] == "fiftyrunscore") cellheader.Add("FiftyRunScore", "50米跑得分");
                if (pName[i] == "fiftyrunlevel") cellheader.Add("FiftyRunLevel", "50米跑级别");
                if (pName[i] == "standjump") cellheader.Add("StandJump", "立定跳远");
                if (pName[i] == "standjumpscore") cellheader.Add("StandJumpScore", "立定跳远得分");
                if (pName[i] == "standjumplevel") cellheader.Add("StandJumpLevel", "立定跳远级别");
                if (pName[i] == "sitandreach") cellheader.Add("SitAndReach", "座位体前屈");
                if (pName[i] == "sitandreachscore") cellheader.Add("SitAndReachScore", "座位体前屈得分");
                if (pName[i] == "sitandreachlevel") cellheader.Add("SitAndReachLevel", "座位体前屈级别");
                if (pName[i] == "eighthundred") cellheader.Add("EightHundred", "800米");
                if (pName[i] == "eighthundredscore") cellheader.Add("EightHundredScore", "800米得分");
                if (pName[i] == "eighthundredlevel") cellheader.Add("EightHundredLevel", "800米级别");
                if (pName[i] == "eighthundredaddscore") cellheader.Add("EightHundredAddScore", "800米加分");
                if (pName[i] == "thousandrun") cellheader.Add("ThousandRun", "1000米");
                if (pName[i] == "thousandrunscore") cellheader.Add("ThousandRunScore", "1000米得分");
                if (pName[i] == "thousandrunlevel") cellheader.Add("ThousandRunLevel", "1000米级别");
                if (pName[i] == "thousandrunaddscore") cellheader.Add("ThousandRunAddScore", "1000米加分");
                if (pName[i] == "minsupination") cellheader.Add("MinSupination", "1分钟仰卧起坐");
                if (pName[i] == "minsupinationscore") cellheader.Add("MinSupinationScore", "1分钟仰卧起坐得分");
                if (pName[i] == "minsupinationlevel") cellheader.Add("MinSupinationLevel", "1分钟仰卧起坐级别");
                if (pName[i] == "minsupinationaddscore") cellheader.Add("MinSupinationAddScore", "1分钟仰卧起坐加分");
                if (pName[i] == "pullup") cellheader.Add("PullUp", "引体向上");
                if (pName[i] == "pullupscore") cellheader.Add("PullUpScore", "引体向上得分");
                if (pName[i] == "pulluplevel") cellheader.Add("PullUpLevel", "引体向上级别");
                if (pName[i] == "pullupaddscore") cellheader.Add("PullUpAddScore", "引体向上加分");
                if (pName[i] == "testresult") cellheader.Add("TestResult", "测试结果：补测、通过、免测，作弊");
                if (pName[i] == "studenttruescore") cellheader.Add("StudentTrueScore", "学生最后真是成绩");
                if (pName[i] == "testtype") cellheader.Add("TestType", "测试类型：正常测试、补测测试");
                if (pName[i] == "createtime") cellheader.Add("CreateTime", "创建时间");
                if (pName[i] == "updatetime") cellheader.Add("UpdateTime", "更新时间");
                if (pName[i] == "remark") cellheader.Add("Remark", "备注");



            }
            string fuStr = "学生信息自定义导出.xls";
            // 3.进行Excel转换操作，并返回转换的文件下载链接
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "导出老师体测信息表");
            FilePathResult file = new FilePathResult("~/" + urlPath, "application/vnd.ms-excel");
            file.FileDownloadName = fuStr;
            return file;
        }


        //获取学生信息自定义导出
        [LoginAuthorize]
        public ActionResult GridOtherStudentInfoJson(string keyvalue, JqGridParam jqgridparam)
        {
            try
            {
              
                Stopwatch watch = CommonHelper.TimerStart();
                DStudent_TestScoreBll tcBll = new DStudent_TestScoreBll();
                // 1.获取数据集合
                DataTable ListData = tcBll.StudentOtherAll(CookieHelper.GetCookie("NK"), ref jqgridparam);
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
