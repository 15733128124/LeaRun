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
    /// ѧ�����Ա�����ݽ���������
    /// </summary>
    public class DStudentTestController : PublicController<DStudent_Test>
    {
        DStudent_TestBll dSTestBll = new DStudent_TestBll();
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ��Ϣ����Json
        /// </summary>
        /// <param name="valueKey">�ؼ���</param>
        /// <param name="jqgridparam">�������</param>
        /// <returns>Json����</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        #region ����
        //��������
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
        /// ��ȡҪ������ͷ�ֶ�
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDeriveExcelColumn()
        {
            string JsonColumn = GZipHelper.Uncompress(CookieHelper.GetCookie("JsonColumn_DeriveExcel"));
            return Content(JsonColumn);
        }

        //����ѧ������  
        [HttpGet]
        [LoginAuthorize]
        public FileResult GetDeriveExcel(string ExportField, string schoolName, string className,
            string testTeacher, string studentSex, string testBeginDate, string studentCode, string gradeCode)
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            ExportField =ExportField.Substring(0, ExportField.Length-1);
            string[] pName = ExportField.Split(',');
            // 1.��ȡ���ݼ���
            List<DStudent_Test> list = dSTestBll.TestStudentExport(ExportField, schoolName, className,
             testTeacher, studentSex, testBeginDate, studentCode, gradeCode, CookieHelper.GetCookie("NK"));

            // 2.���õ�Ԫ��̧ͷ
            // key��ʵ������������ƣ���ͨ�������ȡֵ
            // value��Excel�е�����
            Dictionary<string, string> cellheader = new Dictionary<string, string> { };
            for (int i = 0; i < pName.Length; i++)
            {
                if (pName[i] == "studentcode")
                    cellheader.Add("StudentCode", "ѧ��ѧ��");
                if (pName[i] == "gradecode")
                    cellheader.Add("GradeCode", "�����꼶");
                if (pName[i] == "schoolcode")
                    cellheader.Add("SchoolCode", "ѧԺ���");
                if (pName[i] == "schoolname")
                    cellheader.Add("AchoolName", "ѧԺ����");
                if (pName[i] == "classcode")
                    cellheader.Add("ClassCode", "�༶���");
                if (pName[i] == "classname")
                    cellheader.Add("ClassName", "�༶����");
                if (pName[i] == "testsetid")
                    cellheader.Add("TestSetID", "��������ID");
                if (pName[i] == "studentname")
                    cellheader.Add("StudentName", "ѧ������");
                if (pName[i] == "studentsex")
                    cellheader.Add("StudentSex", "ѧ���Ա� �У�1��Ů��2");
                if (pName[i] == "testteacher")
                    cellheader.Add("TestTeacher", "������ʦ");
                if (pName[i] == "testaddress")
                    cellheader.Add("TestAddress", "���Ե�ַ");
                if (pName[i] == "beginpradate")
                    cellheader.Add("BeginPraDate", "��ʼ��������");
                if (pName[i] == "beginweek")
                    cellheader.Add("BeginWeek", "��ʼ��������");
                if (pName[i] == "beginpratime")
                    cellheader.Add("BeginPraTime", "��ʼ����ʱ��");
                if (pName[i] == "applyfor")
                    cellheader.Add("ApplyFor", "�Ƿ���Ч ��Ч��1����Ч��2");
                if (pName[i] == "testgroup")
                    cellheader.Add("Testgroup", "������");
                if (pName[i] == "testgroupcode")
                    cellheader.Add("TestGroupCode", "�������");
                if (pName[i] == "testtype")
                    cellheader.Add("TestType", "�������� ");
                if (pName[i] == "createtime")
                    cellheader.Add("CreateTime", "����ʱ��");
                if (pName[i] == "updatetime")
                    cellheader.Add("UpdateTime", "����ʱ��");
                if (pName[i] == "remark")
                    cellheader.Add("Remark", "��ע");

            }

            string stustr = "";
            if(studentSex=="1")
                stustr = "��";
            if (studentSex == "2")
                stustr = "Ů";
            string fuStr= "�����Ϣ��(" + testTeacher + "_" + testBeginDate + "_" + stustr + ").xls";
            // 3.����Excelת��������������ת�����ļ���������
            string urlPath = DeriveExcel.ListToExcel2003(cellheader, list, "������ʦ�����Ϣ��");
            FilePathResult file = new FilePathResult("~/" + urlPath, "application/vnd.ms-excel");
            file.FileDownloadName = fuStr;
            return file;

        }

        #endregion

      

    }
}