using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.ZhangCeModule.Controllers
{
    /// <summary>
    /// ѧ���������ñ�����ݽ���������
    /// </summary>
    public class DStudentTestSetController : PublicController<DStudent_TestSet>
    {
        DStudent_TestSetBll dTestSetBll = new DStudent_TestSetBll();
        DStudent_TestAllotBll dTestAllotBll = new DStudent_TestAllotBll();
        DStudent_InfosBll dInfoBll = new DStudent_InfosBll();
        DStudent_TestBll dTestBll = new DStudent_TestBll();

        #region ��������
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ��Ϣ����Json
        /// </summary>
        /// <param name="valueKey">�ؼ���</param>
        /// <param name="jqgridparam">�������</param>
        /// <returns>Json����</returns>
        [LoginAuthorize]
        public ActionResult GridDStudentTestSetJson(string testBeginDate, string studentSex, string testBeginTime, string allotState, string testLimit, JqGridParam jqgridparam, string testType)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable ListData = dTestSetBll.GetDStudentInfosList(testBeginDate, studentSex, testBeginTime, allotState, testLimit, CookieHelper.GetCookie("NK"), ref jqgridparam, testType);
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
        /// ��ȡ����������Ϣ
        /// </summary>
        /// <param name="id">ID����</param>
        /// <returns>json����</returns>
        public ActionResult GetDStudentTestSetModel(int id)
        {
            try
            {
                DStudent_TestSet model = dTestSetBll.GetDStudentTestSetModel(id, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }

        }

        /// <summary>
        /// ��Ӳ���������Ϣ
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDStudentTestSet(string testBeginDate, string testAddress, string studentSex, string testBeginTime, string testStudentCount, string testLimit, string testType)
        {
            try
            {
                string Message = "��ӳɹ���";
                int IsOk = 0;

                #region ʵ����ѧ����������ʵ����
                DStudent_TestSet model = new DStudent_TestSet
                {
                    TestBeginDate = testBeginDate,
                    TestBeginWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Parse(testBeginDate).DayOfWeek),
                    TestAddress = testAddress,
                    StudentSex = studentSex,
                    TestStudentCount = testStudentCount,
                    TestBeginTime = testBeginTime,
                    TestStudentOkCount = "0",
                    TestStudentNoCount = testStudentCount,
                    AllotState = "δ����",
                    TestLimit = testLimit,
                    TestType = testType,
                    CreateTime = DateTime.Now.ToString(),
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                #endregion
                IsOk = dTestSetBll.AddDStudentTestSet(model, CookieHelper.GetCookie("NK"));
                if (IsOk > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "���ʧ�ܡ�" }.ToString());
                }

            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// �޸Ĳ���������Ϣ
        /// </summary>
        /// <param name="testBeginDate"></param>
        /// <param name="testAddress"></param>
        /// <param name="studentSex"></param>
        /// <param name="testBeginTime"></param>
        /// <param name="testStudentCount"></param>
        /// <param name="testLimit"></param>
        /// <param name="testType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdDStudentTestSet(string testBeginDate, string testAddress, string studentSex, string testBeginTime, string testStudentCount, string testLimit, string testType, int id)
        {
            try
            {
                string Message = "�޸ĳɹ���";
                int IsOk = 0;

                #region ʵ����ѧ����Ϣʵ����
                DStudent_TestSet model = new DStudent_TestSet
                {
                    ID = id,
                    TestBeginDate = testBeginDate,
                    TestBeginWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Parse(testBeginDate).DayOfWeek),
                    TestAddress = testAddress,
                    StudentSex = studentSex,
                    TestStudentCount = testStudentCount,
                    TestBeginTime = testBeginTime,
                    TestStudentOkCount = "0",
                    TestStudentNoCount = testStudentCount,
                    AllotState = "δ����",
                    TestLimit = testLimit,
                    TestType = testType,
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                #endregion
                IsOk = dTestSetBll.UpdDStudentTestSet(model, CookieHelper.GetCookie("NK"));
                if (IsOk > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "�޸�ʧ�ܡ�" }.ToString());
                }

            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ɾ������ѧ����Ϣ
        /// </summary>
        /// <param name="id">id ����</param>
        /// <returns></returns>
        public ActionResult DelDStudentTestSet(string id)
        {
            try
            {
                string[] array = id.Split(',');

                string Message = "ɾ���ɹ���";
                int IsOk = 0;
                if (array.Length == 1)
                {
                    IsOk = dTestSetBll.DelDStudentTestScore(Convert.ToInt32(id), CookieHelper.GetCookie("NK"));
                }
                else
                {
                    int count = 0;
                    foreach (string delId in array)
                    {

                        count = dTestSetBll.DelDStudentTestScore(Convert.ToInt32(delId), CookieHelper.GetCookie("NK"));
                        if (count > 0)
                            IsOk = IsOk + count;
                    }

                }
                if (IsOk > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "ɾ��ʧ�ܣ�" }.ToString());
                }


            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Delete, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }
        #endregion


        #region Լ�����ԺͲ���Լ�� ���䷽��
        //������Դ���       
        public ActionResult AllotForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }



        //����Ƿ��Ѿ�����
        [LoginAuthorize]
        public JsonResult CheakAllotGroup(string testSetID)
        {
            try
            {

                if (dTestAllotBll.CheckDStudentTestAllotRepeat(testSetID, CookieHelper.GetCookie("NK")) > 0)
                {
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ���״̬
        /// </summary>
        /// <param name="testSetID">��������Id</param>
        /// <param name="allotState">״̬</param>
        /// <returns></returns>
        [LoginAuthorize]
        public JsonResult AuditState(string testSetID, string allotState)
        {
            try
            {
                //������Ѳ�������ӵ����Լ�¼��ȥ
                if (allotState == "�Ѳ���")
                {
                    //��֤testSetIdΪ��int���͵�ƴ�Ӵ�������sqlע��
                    string[] array = testSetID.Split(',');
                    bool flg = true;
                    foreach (string id in array)
                    {
                        if (!CommonHelper.IsInt(id))
                        {
                            flg = false;
                            break;
                        }
                    }
                    if (flg)
                    {
                        StringBuilder sqlWhere = new StringBuilder();
                        sqlWhere.Append(" And TestSetID in (");
                        sqlWhere.Append(testSetID);
                        sqlWhere.Append(")");
                        dTestBll.InsertDStudentTestLog(sqlWhere.ToString(), CookieHelper.GetCookie("NK"));
                    }
                }
                string[] testSetIdArray = testSetID.Split(',');
                int n = 0;
                if (testSetIdArray.Length == 1)
                {
                   n = dTestSetBll.UpdDStudentTestSetState(allotState, Convert.ToInt32(testSetID), CookieHelper.GetCookie("NK"));
                }
                else
                {
                    int m = 0;
                    foreach (string testid in testSetIdArray)
                    {                       
                        n = dTestSetBll.UpdDStudentTestSetState(allotState, Convert.ToInt32(testid), CookieHelper.GetCookie("NK"));
                        if (n > 0)
                            n = m + n;
                    }
                }
                if (n > 0)
                {
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //��շ���
        [LoginAuthorize]
        public JsonResult DelAllotGroup(string testSetID)
        {
            try
            {

                if (dTestAllotBll.DelDStudentTestAllotByTestSetID(Convert.ToInt32(testSetID), CookieHelper.GetCookie("NK")) > 0)
                {
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //����
        [LoginAuthorize]
        public JsonResult AllotGroup(string testSetId, string testBeginDate, string testBeginWeek, string testBeginTime, string groupNum, string everyGroupCount, string surplusCount, string studentSex)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                int everyGroupCountUp = Convert.ToInt32(everyGroupCount) + 1;
                for (int i = 1; i <= Convert.ToInt32(groupNum); i++)
                {
                    if (i <= Convert.ToInt32(surplusCount))
                    {
                        strSql.Append(" select ");
                        strSql.Append(testSetId + "," + "'" + studentSex + i + "'," + everyGroupCountUp + "," + "'" + testBeginDate + "'," + "'" + testBeginWeek + "',");
                        strSql.Append("'" + testBeginTime + "'," + "'',''");
                        strSql.Append(" union all ");
                    }
                    else
                    {
                        strSql.Append(" select ");
                        strSql.Append(testSetId + "," + "'" + studentSex + i + "'," + everyGroupCount + "," + "'" + testBeginDate + "'," + "'" + testBeginWeek + "',");
                        strSql.Append("'" + testBeginTime + "'," + "'',''");
                        if (i != Convert.ToInt32(groupNum))
                            strSql.Append(" union all ");
                    }

                }

                if (dTestAllotBll.AddDStudentTestAllot(strSql.ToString(), CookieHelper.GetCookie("NK")) > 0)
                {
                    //��ѧ������
                    List<DStudent_TestAllot> allotList = dTestAllotBll.GetDStudentTestAllotListByTestSetID(testSetId, CookieHelper.GetCookie("NK"));
                    foreach (DStudent_TestAllot model in allotList)
                    {
                        for (int i = 1; i <= model.GroupCount; i++)
                        {
                            dTestAllotBll.AllotGroup(Convert.ToInt32(testSetId), model.TestGroup, i, CookieHelper.GetCookie("NK"));
                        }
                    }
                    //����״̬
                    dTestSetBll.UpdDStudentTestSetState("�ѷ���", Convert.ToInt32(testSetId), CookieHelper.GetCookie("NK"));
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //������ʦ
        [LoginAuthorize]
        public JsonResult AllotTeacher(int id, string testGroup, int groupCount, string testTeacher)
        {
            try
            {
                //��ѧ��������ʦ
                int n = dTestAllotBll.AllotTeacher(id, testGroup, groupCount, testTeacher, CookieHelper.GetCookie("NK"));
                if (n > 0)
                {
                    //����״̬
                    dTestSetBll.UpdDStudentTestSetState("�ѷ���", Convert.ToInt32(id), CookieHelper.GetCookie("NK"));
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        #endregion

        #region ��Ԫ���Զ��з���

        //���䵥Ԫ���Դ���
        public ActionResult UnitAllotForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        #endregion

        #region ��Ӳ���
        //���Լ�����Դ���
        public ActionResult AddTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //��Ӳ���Լ������
        public ActionResult AddReTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //��ӵ�Ԫ���Դ���
        public ActionResult AddUnitTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //���ѧ������
        public ActionResult AddTestStudent(string studentCode, int testSetID, string studentSex, string testBeginDate, string testBeginWeek, string testBeginTime, string testAddress, string testGroup, string groupCount, string testTeacher, string testType, string testLimit)
        {
            try
            {

                DStudent_Infos model = dInfoBll.GetDStudentInfosModel(studentCode, CookieHelper.GetCookie("NK"));
                if (model.SchoolCode == "" || model == null || model.StudentCode == null)
                {
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "���в����ڸ�ѧ������Ӳ���ʧ�ܣ�" }.ToString());
                }
                else if (model.StudentSex != studentSex)
                {
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "ѧ���Ա�͸���������Ϣ�Ա���ͬ����Ӳ���ʧ�ܣ�" }.ToString());
                }
                else
                {
                    if (testLimit != "40")
                    {
                        //���ѧ�������ϲ������ƣ����޷�����
                        if (model.GradeCode != testLimit)
                        {
                            return Content(new JsonMessage { Success = false, Code = "0", Message = "��ѧ�������ϲ������ƣ�" }.ToString());
                        }
                        else
                        {
                            DStudent_Test testModel = new DStudent_Test
                            {
                                StudentCode = model.StudentCode,
                                GradeCode = model.GradeCode,
                                SchoolCode = model.SchoolCode,
                                SchoolName = model.SchoolName,
                                ClassCode = model.ClassCode,
                                ClassName = model.ClassName,
                                TestSetID = testSetID,
                                StudentName = model.StudentName,
                                StudentSex = model.StudentSex,
                                TestTeacher = testTeacher,
                                TestAddress = testAddress,
                                BeginPraDate = testBeginDate,
                                BeginWeek = testBeginWeek,
                                BeginPraTime = testBeginTime,
                                ApplyFor = "1",
                                TestGroup = testGroup,
                                TestGroupCode = groupCount == "" ? "" : (Convert.ToInt32(groupCount) + 1).ToString(),
                                TestType = testType,
                                CreateTime = System.DateTime.Now.ToString(),
                                UpdateTime = System.DateTime.Now.ToString(),
                                Remark = ""
                            };
                            int n = dTestBll.AddDStudentTestAdmin(testModel, CookieHelper.GetCookie("NK"));
                            if (n == 1)
                            {
                                return Content(new JsonMessage { Success = true, Code = "1", Message = "��ӳɹ���" }.ToString());
                            }
                            else
                            {
                                return Content(new JsonMessage { Success = true, Code = "0", Message = "��ѧ���Ѿ�Լ���������ظ���ӣ�" }.ToString());
                            }

                        }
                    }
                    else
                    {
                        DStudent_Test testModel = new DStudent_Test
                        {
                            StudentCode = model.StudentCode,
                            GradeCode = model.GradeCode,
                            SchoolCode = model.SchoolCode,
                            SchoolName = model.SchoolName,
                            ClassCode = model.ClassCode,
                            ClassName = model.ClassName,
                            TestSetID = testSetID,
                            StudentName = model.StudentName,
                            StudentSex = model.StudentSex,
                            TestTeacher = testTeacher,
                            TestAddress = testAddress,
                            BeginPraDate = testBeginDate,
                            BeginWeek = testBeginWeek,
                            BeginPraTime = testBeginTime,
                            ApplyFor = "1",
                            TestGroup = testGroup,
                            TestGroupCode = groupCount == "" ? "" : (Convert.ToInt32(groupCount) + 1).ToString(),
                            TestType = testType,
                            CreateTime = System.DateTime.Now.ToString(),
                            UpdateTime = System.DateTime.Now.ToString(),
                            Remark = ""
                        };
                        int n = dTestBll.AddDStudentTestAdmin(testModel, CookieHelper.GetCookie("NK"));
                        if (n == 1)
                        {
                            return Content(new JsonMessage { Success = true, Code = "1", Message = "��ӳɹ���" }.ToString());
                        }
                        else
                        {
                            return Content(new JsonMessage { Success = true, Code = "0", Message = "��ѧ���Ѿ�Լ���������ظ���ӣ�" }.ToString());
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        #endregion

        #region ȡ��Լ��
        //ȡ��Լ�����Դ���
        public ActionResult DeleteTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }


        //ȡ������Լ������
        public ActionResult DeleteReTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //ȡ����Ԫ���Դ���
        public ActionResult DeleteUnitTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //��ȡѧ��������Ϣ
        public ActionResult GetDStudentTestModel(string studentCode, string testType)
        {
            try
            {
                DStudent_Test model = dTestBll.GetDStudentTestModel(studentCode, testType, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }

        }

        //ȡ��Լ������
        [LoginAuthorize]
        public JsonResult DeleteTestStudent(string studentCode, string testSetID)
        {
            try
            {
                int isOk = dTestBll.DeleteTestStudent(studentCode, testSetID, CookieHelper.GetCookie("NK"));
                if (isOk > 0)
                    return Json(new { IsOk = true });
                else
                    return Json(new { IsOk = false });
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }

        }

        #endregion


        //��ӣ��޸Ĳ���Լ������
        public ActionResult ReTestForm()
        {
            return View();
        }

        //����Լ����ҳ
        public ActionResult ReTestIndex()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                return View();
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }

        //��ӣ��޸ĵ�Ԫ���Դ���
        public ActionResult UnitTestForm()
        {
            return View();
        }

        //��Ԫ������ҳ
        public ActionResult UnitTestIndex()
        {
            string NK = CookieHelper.GetCookie("NK");
            if (NK != "")
            {
                ViewBag.NK = NK;
                return View();
            }
            else
            {
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }

        #region ������� ����

        //���빦��ʵ��
        [LoginAuthorize]
        public JsonResult ImportExcelData(string testSetID, string studentSex, string testBeginDate,
             string testBeginWeek, string testBeginTime, string testAddress, string testGroup, string groupCount, string testTeacher, string testType, string testLimit)
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            string filePath = "";

            //�ļ���С��Ϊ0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //������Լ����ļ�ȫ·��,newfile�������ϴ��󱣴���ļ�,
            //�������ϵ�UpLoadFile�ļ��б����ж�дȨ�ޡ�
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region ���������ϵ�excel���ݵ��������ݼ�,������

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelData(xmlDate, testLimit, Convert.ToInt32(testSetID), testTeacher, testAddress, testBeginDate, testBeginWeek, testBeginTime, testGroup, groupCount, testType, CookieHelper.GetCookie("NK"));

            #endregion

            return Json(new { Msg = returnMsg });
        }

        //������Ϣչʾ
        public string ErrorMsgTitle(int rowindex, string cloumn)
        {
            return "��" + rowindex + "������[" + cloumn + "]";
        }
        /// <summary>
        /// ���Excel������
        /// </summary>
        /// <param name="xmlDate"></param>
        private string AddExcelData(DataTable xmlDate, string testLimit, int testSetID, string testTeacher, string testAddress, string testBeginDate, string testBeginWeek, string testBeginTime, string testGroup, string groupCount, string testType, string NK)
        {
            //��ԭ����ͷ�����ʦ
            dTestAllotBll.DelDStudentTestAllotByTestSetID(Convert.ToInt32(testSetID), CookieHelper.GetCookie("NK"));
            string errorMsg = "";
            int errorcount = 0;//����ĸ���
            int sumcount = xmlDate.Rows.Count;//�������ݵ��ܸ���
            int rowindex = 1;//�б�
            string comname = string.Empty;
            int i = 1;
            foreach (DataRow excelRow in xmlDate.Rows)
            {
                DStudent_Test testModel = null;
                bool flg = true;//��������ı�ʶ
                rowindex++;
                try
                {

                    comname = excelRow[0].ToString().Trim();
                    DStudent_Infos model = dInfoBll.GetDStudentInfosModel(excelRow[0].ToString().Trim(), NK);
                    if (model.SchoolCode == "" || model == null || model.StudentCode == null)
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",���ʧ��;ʧ��ԭ��:���в����ڸ�ѧ������Ӳ���ʧ�ܣ� <br/>";
                        flg = false;
                    }
                    else if (model.StudentSex != excelRow[1].ToString().Trim())
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",���ʧ��;ʧ��ԭ��:ѧ���Ա�͸���������Ϣ�Ա���ͬ����Ӳ���ʧ�ܣ�<br/>";
                        flg = false;
                    }
                    else
                    {
                        if (model.GradeCode != "40")
                        {
                            if (model.GradeCode == testLimit)
                            {
                            }
                            else
                            {
                                testModel = new DStudent_Test
                                {
                                    StudentCode = model.StudentCode,
                                    GradeCode = model.GradeCode,
                                    SchoolCode = model.SchoolCode,
                                    SchoolName = model.SchoolName,
                                    ClassCode = model.ClassCode,
                                    ClassName = model.ClassName,
                                    TestSetID = testSetID,
                                    StudentName = model.StudentName,
                                    StudentSex = model.StudentSex,
                                    TestTeacher = testTeacher,
                                    TestAddress = testAddress,
                                    BeginPraDate = testBeginDate,
                                    BeginWeek = testBeginWeek,
                                    BeginPraTime = testBeginTime,
                                    ApplyFor = "1",
                                    TestGroup = testGroup,
                                    TestGroupCode = groupCount == "" ? "" : (Convert.ToInt32(groupCount) + 1).ToString(),
                                    TestType = testType,
                                    CreateTime = System.DateTime.Now.ToString(),
                                    UpdateTime = System.DateTime.Now.ToString(),
                                    Remark = ""
                                };
                            }
                        }
                        else
                        {
                            testModel = new DStudent_Test
                            {
                                StudentCode = model.StudentCode,
                                GradeCode = model.GradeCode,
                                SchoolCode = model.SchoolCode,
                                SchoolName = model.SchoolName,
                                ClassCode = model.ClassCode,
                                ClassName = model.ClassName,
                                TestSetID = testSetID,
                                StudentName = model.StudentName,
                                StudentSex = model.StudentSex,
                                TestTeacher = testTeacher,
                                TestAddress = testAddress,
                                BeginPraDate = testBeginDate,
                                BeginWeek = testBeginWeek,
                                BeginPraTime = testBeginTime,
                                ApplyFor = "1",
                                TestGroup = testGroup,
                                TestGroupCode = groupCount == "" ? "" : (Convert.ToInt32(groupCount) + 1).ToString(),
                                TestType = testType,
                                CreateTime = System.DateTime.Now.ToString(),
                                UpdateTime = System.DateTime.Now.ToString(),
                                Remark = ""
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",���ʧ��;ʧ��ԭ��:" + ex.Message + "<br/>";
                    flg = false;
                }


                if (flg)
                {
                    int result = 1;
                    try
                    {
                        //������Ϣ���صĽ��
                        result = dTestBll.AddDStudentTestAdmin(testModel, CookieHelper.GetCookie("NK"));
                        if (result == 2)
                        {
                            if (flg)
                                errorcount++;
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "(���ݿ��Ѿ�����),���ʧ��" + "<br/>";
                        }
                        else if (result <= 0)
                        {
                            if (flg)
                                errorcount++;
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ʧ��(ԭ��:���ݿ���ܴ���)" + "<br/>";
                        }
                    }
                    catch (Exception ex)
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ʧ��;ʧ��ԭ��:" + ex.Message + "<br/>";
                    }
                }

                i++;

            }



            string importMsg = "�����롾" + sumcount + "������¼<br/>" +
                            "����ɹ���" + (sumcount - errorcount) + "������¼<br/>" +
                            "����ʧ�ܡ�" + (errorcount) + "������¼<br/>";

            return importMsg + "<br><div style='color:blue' id='errorMsg'>" + errorMsg + "</div>";


        }



        //����һ������·��
        [LoginAuthorize]
        public FileResult GetExcelFile()
        {
            FilePathResult file=  new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/ѧ���������ģ��.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "ѧ���������ģ��.xlsx";

            return file;
        }


        #endregion
    }
}