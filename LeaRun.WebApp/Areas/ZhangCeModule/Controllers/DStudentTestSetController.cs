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
    /// 学生测试设置表（随年份建表）控制器
    /// </summary>
    public class DStudentTestSetController : PublicController<DStudent_TestSet>
    {
        DStudent_TestSetBll dTestSetBll = new DStudent_TestSetBll();
        DStudent_TestAllotBll dTestAllotBll = new DStudent_TestAllotBll();
        DStudent_InfosBll dInfoBll = new DStudent_InfosBll();
        DStudent_TestBll dTestBll = new DStudent_TestBll();

        #region 基本方法
        /// <summary>
        /// 根据关键字查询信息返回Json
        /// </summary>
        /// <param name="valueKey">关键字</param>
        /// <param name="jqgridparam">表格属性</param>
        /// <returns>Json数据</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取测试设置信息
        /// </summary>
        /// <param name="id">ID主键</param>
        /// <returns>json数据</returns>
        public ActionResult GetDStudentTestSetModel(int id)
        {
            try
            {
                DStudent_TestSet model = dTestSetBll.GetDStudentTestSetModel(id, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }

        }

        /// <summary>
        /// 添加测试设置信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDStudentTestSet(string testBeginDate, string testAddress, string studentSex, string testBeginTime, string testStudentCount, string testLimit, string testType)
        {
            try
            {
                string Message = "添加成功。";
                int IsOk = 0;

                #region 实例化学生测试设置实体类
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
                    AllotState = "未分配",
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
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "添加失败。" }.ToString());
                }

            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 修改测试设置信息
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
                string Message = "修改成功。";
                int IsOk = 0;

                #region 实例化学生信息实体类
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
                    AllotState = "未分配",
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
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "修改失败。" }.ToString());
                }

            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 删除测试学生信息
        /// </summary>
        /// <param name="id">id 主键</param>
        /// <returns></returns>
        public ActionResult DelDStudentTestSet(string id)
        {
            try
            {
                string[] array = id.Split(',');

                string Message = "删除成功！";
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
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "删除失败！" }.ToString());
                }


            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Delete, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }
        #endregion


        #region 约考测试和测试约考 分配方法
        //分配测试窗体       
        public ActionResult AllotForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }



        //检查是否已经分组
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        /// <param name="testSetID">测试设置Id</param>
        /// <param name="allotState">状态</param>
        /// <returns></returns>
        [LoginAuthorize]
        public JsonResult AuditState(string testSetID, string allotState)
        {
            try
            {
                //如果是已测完则添加到测试记录中去
                if (allotState == "已测完")
                {
                    //验证testSetId为是int类型的拼接串，避免sql注入
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        //清空分组
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        //分组
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
                    //给学生分组
                    List<DStudent_TestAllot> allotList = dTestAllotBll.GetDStudentTestAllotListByTestSetID(testSetId, CookieHelper.GetCookie("NK"));
                    foreach (DStudent_TestAllot model in allotList)
                    {
                        for (int i = 1; i <= model.GroupCount; i++)
                        {
                            dTestAllotBll.AllotGroup(Convert.ToInt32(testSetId), model.TestGroup, i, CookieHelper.GetCookie("NK"));
                        }
                    }
                    //更新状态
                    dTestSetBll.UpdDStudentTestSetState("已分组", Convert.ToInt32(testSetId), CookieHelper.GetCookie("NK"));
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        //分配老师
        [LoginAuthorize]
        public JsonResult AllotTeacher(int id, string testGroup, int groupCount, string testTeacher)
        {
            try
            {
                //给学生分配老师
                int n = dTestAllotBll.AllotTeacher(id, testGroup, groupCount, testTeacher, CookieHelper.GetCookie("NK"));
                if (n > 0)
                {
                    //更新状态
                    dTestSetBll.UpdDStudentTestSetState("已分配", Convert.ToInt32(id), CookieHelper.GetCookie("NK"));
                    return Json(new { IsOk = true });
                }
                else
                {
                    return Json(new { IsOk = false });
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        #endregion

        #region 单元测试独有方法

        //分配单元测试窗体
        public ActionResult UnitAllotForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        #endregion

        #region 添加测试
        //添加约考测试窗体
        public ActionResult AddTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //添加补测约考窗体
        public ActionResult AddReTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //添加单元测试窗体
        public ActionResult AddUnitTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //添加学生测试
        public ActionResult AddTestStudent(string studentCode, int testSetID, string studentSex, string testBeginDate, string testBeginWeek, string testBeginTime, string testAddress, string testGroup, string groupCount, string testTeacher, string testType, string testLimit)
        {
            try
            {

                DStudent_Infos model = dInfoBll.GetDStudentInfosModel(studentCode, CookieHelper.GetCookie("NK"));
                if (model.SchoolCode == "" || model == null || model.StudentCode == null)
                {
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "库中不存在该学生，添加测试失败！" }.ToString());
                }
                else if (model.StudentSex != studentSex)
                {
                    return Content(new JsonMessage { Success = false, Code = "0", Message = "学生性别和该条测试信息性别不相同，添加测试失败！" }.ToString());
                }
                else
                {
                    if (testLimit != "40")
                    {
                        //如果学生不符合测试限制，则无法测试
                        if (model.GradeCode != testLimit)
                        {
                            return Content(new JsonMessage { Success = false, Code = "0", Message = "该学生不符合测试限制！" }.ToString());
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
                                return Content(new JsonMessage { Success = true, Code = "1", Message = "添加成功！" }.ToString());
                            }
                            else
                            {
                                return Content(new JsonMessage { Success = true, Code = "0", Message = "该学生已经约考，不能重复添加！" }.ToString());
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
                            return Content(new JsonMessage { Success = true, Code = "1", Message = "添加成功！" }.ToString());
                        }
                        else
                        {
                            return Content(new JsonMessage { Success = true, Code = "0", Message = "该学生已经约考，不能重复添加！" }.ToString());
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        #endregion

        #region 取消约考
        //取消约考测试窗体
        public ActionResult DeleteTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }


        //取消补测约考窗体
        public ActionResult DeleteReTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //取消单元测试窗体
        public ActionResult DeleteUnitTestAboutForm()
        {
            ViewBag.TestSetID = Request["KeyValue"];
            ViewBag.NK = CookieHelper.GetCookie("NK");
            return View();
        }

        //获取学生测试信息
        public ActionResult GetDStudentTestModel(string studentCode, string testType)
        {
            try
            {
                DStudent_Test model = dTestBll.GetDStudentTestModel(studentCode, testType, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }

        }

        //取消约考测试
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return null;
            }

        }

        #endregion


        //添加，修改补测约考窗体
        public ActionResult ReTestForm()
        {
            return View();
        }

        //补测约考首页
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
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">您没有选择年库！请选择年库！</div>", "text/html");
            }
        }

        //添加，修改单元测试窗体
        public ActionResult UnitTestForm()
        {
            return View();
        }

        //单元测试首页
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
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">您没有选择年库！请选择年库！</div>", "text/html");
            }
        }

        #region 导入分配 方法

        //导入功能实现
        [LoginAuthorize]
        public JsonResult ImportExcelData(string testSetID, string studentSex, string testBeginDate,
             string testBeginWeek, string testBeginTime, string testAddress, string testGroup, string groupCount, string testTeacher, string testType, string testLimit)
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            string filePath = "";

            //文件大小不为0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //保存成自己的文件全路径,newfile就是你上传后保存的文件,
            //服务器上的UpLoadFile文件夹必须有读写权限　
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region 将服务器上的excel数据导出成数据集,添加入库

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelData(xmlDate, testLimit, Convert.ToInt32(testSetID), testTeacher, testAddress, testBeginDate, testBeginWeek, testBeginTime, testGroup, groupCount, testType, CookieHelper.GetCookie("NK"));

            #endregion

            return Json(new { Msg = returnMsg });
        }

        //错误信息展示
        public string ErrorMsgTitle(int rowindex, string cloumn)
        {
            return "第" + rowindex + "条数据[" + cloumn + "]";
        }
        /// <summary>
        /// 添加Excel的数据
        /// </summary>
        /// <param name="xmlDate"></param>
        private string AddExcelData(DataTable xmlDate, string testLimit, int testSetID, string testTeacher, string testAddress, string testBeginDate, string testBeginWeek, string testBeginTime, string testGroup, string groupCount, string testType, string NK)
        {
            //还原分组和分配老师
            dTestAllotBll.DelDStudentTestAllotByTestSetID(Convert.ToInt32(testSetID), CookieHelper.GetCookie("NK"));
            string errorMsg = "";
            int errorcount = 0;//错误的个数
            int sumcount = xmlDate.Rows.Count;//导入数据的总个数
            int rowindex = 1;//行标
            string comname = string.Empty;
            int i = 1;
            foreach (DataRow excelRow in xmlDate.Rows)
            {
                DStudent_Test testModel = null;
                bool flg = true;//可添加入库的标识
                rowindex++;
                try
                {

                    comname = excelRow[0].ToString().Trim();
                    DStudent_Infos model = dInfoBll.GetDStudentInfosModel(excelRow[0].ToString().Trim(), NK);
                    if (model.SchoolCode == "" || model == null || model.StudentCode == null)
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",添加失败;失败原因:库中不存在该学生，添加测试失败！ <br/>";
                        flg = false;
                    }
                    else if (model.StudentSex != excelRow[1].ToString().Trim())
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",添加失败;失败原因:学生性别和该条测试信息性别不相同，添加测试失败！<br/>";
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
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",添加失败;失败原因:" + ex.Message + "<br/>";
                    flg = false;
                }


                if (flg)
                {
                    int result = 1;
                    try
                    {
                        //导入信息返回的结果
                        result = dTestBll.AddDStudentTestAdmin(testModel, CookieHelper.GetCookie("NK"));
                        if (result == 2)
                        {
                            if (flg)
                                errorcount++;
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "(数据库已经存在),添加失败" + "<br/>";
                        }
                        else if (result <= 0)
                        {
                            if (flg)
                                errorcount++;
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "添加失败(原因:数据库可能存在)" + "<br/>";
                        }
                    }
                    catch (Exception ex)
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "添加失败;失败原因:" + ex.Message + "<br/>";
                    }
                }

                i++;

            }



            string importMsg = "共导入【" + sumcount + "】条记录<br/>" +
                            "导入成功【" + (sumcount - errorcount) + "】条记录<br/>" +
                            "导入失败【" + (errorcount) + "】条记录<br/>";

            return importMsg + "<br><div style='color:blue' id='errorMsg'>" + errorMsg + "</div>";


        }



        //返回一个下载路径
        [LoginAuthorize]
        public FileResult GetExcelFile()
        {
            FilePathResult file=  new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/学生导入分配模板.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "学生导入分配模板.xlsx";

            return file;
        }


        #endregion
    }
}