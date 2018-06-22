using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.ZhangCeModule.Controllers
{
    /// <summary>
    /// 学生基本信息表（随年份建表）控制器
    /// </summary>
    public class DStudentInfosController : PublicController<DStudent_Infos>
    {
        DStudent_InfosBll sInfosBll = new DStudent_InfosBll();
        DStudent_TestScoreBll sTestScoreBll = new DStudent_TestScoreBll();
        DStudent_ClassBll sClssBll = new DStudent_ClassBll();
        DBase_NationsBll bNationBll = new DBase_NationsBll();
        DBase_UsersBll bUsersBll = new DBase_UsersBll();
        DBase_CitiesBll bCityBll = new DBase_CitiesBll();

        #region 学生的树json
        /// <summary>
        /// 学生的树json
        /// </summary>
        /// <returns></returns>
        //public ActionResult TreeJson()
        //{


        //    List<TreeJsonEntity> TreeList = new List<TreeJsonEntity>();
        //    TreeJsonEntity tree = new TreeJsonEntity();
        //    tree.id = "1";
        //    tree.text = "康壮体测";
        //    tree.value = "kz";
        //    tree.parentId = "0";
        //    tree.Attribute = "Type";
        //    tree.AttributeValue = "";
        //    tree.AttributeA = "";
        //    tree.AttributeValueA = "";
        //    tree.isexpand = true;
        //    tree.complete = true;
        //    tree.hasChildren = true;

        //    tree.img = "/Content/Images/Icon16/molecule.png";

        //    TreeJsonEntity tree1 = new TreeJsonEntity();
        //    tree1.id = "11";
        //    tree1.text = "学生信息";
        //    tree1.value = "";
        //    tree1.parentId = "1";
        //    tree1.Attribute = "Type";
        //    tree1.AttributeValue = "";
        //    tree1.AttributeA = "";
        //    tree1.AttributeValueA = "";
        //    tree1.isexpand = false;
        //    tree1.complete = true;
        //    tree1.hasChildren = true;

        //    tree1.img = "/Content/Images/Icon16/hostname.png";

        //    TreeJsonEntity tree2 = new TreeJsonEntity();
        //    tree2.id = "21";
        //    tree2.text = "基本信息";
        //    tree2.value = "";
        //    tree2.parentId = "11";
        //    tree2.Attribute = "Type";
        //    tree2.AttributeValue = "";
        //    tree2.AttributeA = "";
        //    tree2.AttributeValueA = "";
        //    tree2.isexpand = true;
        //    tree2.complete = true;
        //    tree2.hasChildren = false;

        //    tree2.img = "/Content/Images/Icon16/chart_organisation.png";

        //    TreeJsonEntity tree3 = new TreeJsonEntity();
        //    tree3.id = "22";
        //    tree3.text = "体测信息";
        //    tree3.value = "";
        //    tree3.parentId = "11";
        //    tree3.Attribute = "Type";
        //    tree3.AttributeValue = "";
        //    tree3.AttributeA = "";
        //    tree3.AttributeValueA = "";
        //    tree3.isexpand = true;
        //    tree3.complete = true;
        //    tree3.hasChildren = false;

        //    tree3.img = "/Content/Images/Icon16/chart_organisation.png";



        //    TreeJsonEntity tree4 = new TreeJsonEntity();
        //    tree4.id = "12";
        //    tree4.text = "数据对比";
        //    tree4.value = "";
        //    tree4.parentId = "1";
        //    tree4.Attribute = "Type";
        //    tree4.AttributeValue = "";
        //    tree4.AttributeA = "";
        //    tree4.AttributeValueA = "";
        //    tree4.isexpand = false;
        //    tree4.complete = true;
        //    tree4.hasChildren = true;

        //    tree4.img = "/Content/Images/Icon16/hostname.png";

        //    TreeJsonEntity tree5 = new TreeJsonEntity();
        //    tree5.id = "22";
        //    tree5.text = "成绩信息";
        //    tree5.value = "";
        //    tree5.parentId = "12";
        //    tree5.Attribute = "Type";
        //    tree5.AttributeValue = "";
        //    tree5.AttributeA = "";
        //    tree5.AttributeValueA = "";
        //    tree5.isexpand = true;
        //    tree5.complete = true;
        //    tree5.hasChildren = false;

        //    tree5.img = "/Content/Images/Icon16/chart_organisation.png";

        //    TreeList.Add(tree);
        //    TreeList.Add(tree1);
        //    TreeList.Add(tree2);
        //    TreeList.Add(tree3);
        //    TreeList.Add(tree4);
        //    TreeList.Add(tree5);


        //    return Content(TreeList.TreeToJson());
        //}
        #endregion

        #region 学生基本操作
        /// <summary>
        /// 根据关键字查询信息返回Json
        /// </summary>
        /// <param name="valueKey">关键字</param>
        /// <param name="jqgridparam">表格属性</param>
        /// <returns>Json数据</returns>
        [LoginAuthorize]
        public ActionResult GridDStudentInfosJson(string keyvalue, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable ListData = sInfosBll.GetDStudentInfosList(keyvalue, CookieHelper.GetCookie("NK"), ref jqgridparam);
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
        /// 添加学生信息
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="schoolcode">学院编号</param>
        /// <param name="schoolname">学院名称</param>
        /// <param name="classcode">班级编号</param>
        /// <param name="classname">班级名称</param>
        /// <param name="studentcode">学生学号</param>
        /// <param name="studentname">学生姓名</param>
        /// <param name="studentsex">学生性别</param>
        /// <param name="studentborndate">学生出生日期</param>
        /// <param name="studenthomeaddress">学生家庭住址</param>
        /// <param name="nationname">民族名称</param>
        /// <param name="nationcode">民族编号</param>
        /// <param name="studentnative">学生籍贯</param>
        /// <param name="studentmovetype">学生异动类型</param>
        /// <param name="studentidnumber">学生身份证号</param>
        /// <param name="studentphone">学生电话</param>
        /// <param name="studentisregister">是否注册</param>
        /// <returns></returns>
       
        public ActionResult AddDStudentInfo(string gradecode, string schoolcode, string schoolname, string classcode, string classname, string studentcode, string studentname,
           string studentsex, string studentborndate, string studenthomeaddress, string nationname, string nationcode, string studentnative, string studentmovetype, string studentidnumber, string studentphone,
            string studentisregister)
        {
            try
            {
                string Message = "添加成功";
                int IsOk = 0;
                if (sInfosBll.CheckStudentInfoRepeat(studentcode, CookieHelper.GetCookie("NK")) > 0)
                {
                    Message = "数据库中该学生已存在！";
                    return Content(new JsonMessage { Success = false, Code = IsOk.ToString(), Message = Message }.ToString());
                }
                else
                {
                    #region 实例化学生信息实体类
                    DStudent_Infos model = new DStudent_Infos
                    {
                        StudentCode = studentcode,
                        StudentName = studentname,
                        StudentSex = studentsex,
                        StudentBornDate = studentborndate,
                        StudentHomeAddress = studenthomeaddress,
                        GradeCode = gradecode,
                        SchoolName = schoolname,
                        SchoolCode = schoolcode,
                        ClassName = classname,
                        ClassCode = classcode,
                        NationCode = nationcode,
                        NationName = nationname,
                        StudentNative = studentnative,
                        StudentMoveType = studentmovetype,
                        StudentIDNumber = studentidnumber,
                        StudentPhone = studentphone,
                        StudentIsRegister = studentisregister,
                        CreateTime = DateTime.Now.ToString(),
                        UpdateTime = DateTime.Now.ToString(),
                        Remark = ""
                    };
                    #endregion

                    IsOk = sInfosBll.AddDStudentInfo(model, CookieHelper.GetCookie("NK"));
                    if (IsOk > 0)
                    {
                        bUsersBll.AddDBase_User(model.StudentCode, DESEncrypt.Encrypt("123456"));
                        if (sTestScoreBll.CheckStudentTestScoreRepeat(studentcode, CookieHelper.GetCookie("NK")) <= 0)
                        {
                            #region 实例化学生成绩实体类
                            DStudent_TestScore testScoreModel = new DStudent_TestScore
                            {
                                StudentCode = studentcode,
                                StudentName = studentname,
                                StudentSex = studentsex,
                                Heigh = "",
                                Weight = "",
                                BMI = "",
                                BMIScore = "",
                                BMILevel = "",
                                Pulmonary = "",
                                PulmonaryScore = "",
                                PulmonaryLevel = "",
                                FiftyRun = "",
                                FiftyRunScore = "",
                                FiftyRunLevel = "",
                                StandJump = "",
                                StandJumpScore = "",
                                StandJumpLevel = "",
                                SitAndReach = "",
                                SitAndReachScore = "",
                                SitAndReachLevel = "",
                                EightHundred = "",
                                EightHundredScore = "",
                                EightHundredLevel = "",
                                EightHundredAddScore = "",
                                ThousandRun = "",
                                ThousandRunScore = "",
                                ThousandRunLevel = "",
                                ThousandRunAddScore = "",
                                MinSupination = "",
                                MinSupinationScore = "",
                                MinSupinationLevel = "",
                                MinSupinationAddScore = "",
                                PullUp = "",
                                PullUpScore = "",
                                PullUpLevel = "",
                                PullUpAddScore = "",
                                TestResult = "",
                                StudentTrueScore = "",
                                TestType = "正常测试",
                                CreateTime = DateTime.Now.ToString(),
                                UpdateTime = DateTime.Now.ToString(),
                                Remark = ""
                            };
                            #endregion
                            sTestScoreBll.AddDStudentTestScore(testScoreModel, gradecode, CookieHelper.GetCookie("NK"));
                        }
                    }
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="schoolcode">学院编号</param>
        /// <param name="schoolname">学院名称</param>
        /// <param name="classcode">班级编号</param>
        /// <param name="classname">班级名称</param>
        /// <param name="studentcode">学生编号</param>
        /// <param name="studentname">学生姓名</param>
        /// <param name="studentsex">学生性别</param>
        /// <param name="studentborndate">学生出生日期</param>
        /// <param name="studenthomeaddress">学生家庭住址</param>
        /// <param name="nationname">民族名称</param>
        /// <param name="nationcode">民族编号</param>
        /// <param name="studentnative">学生籍贯</param>
        /// <param name="studentmovetype">异动类型</param>
        /// <param name="studentidnumber">身份证号</param>
        /// <param name="studentphone">学生电话</param>
        /// <param name="studentisregister">是否注册</param>
        /// <param name="keyvalue">关键字</param>
        /// <returns></returns>
       
        public ActionResult UpdDStudentInfo(string gradecode, string schoolcode, string schoolname, string classcode, string classname, string studentcode, string studentname,
          string studentsex, string studentborndate, string studenthomeaddress, string nationname, string nationcode, string studentnative, string studentmovetype, string studentidnumber, string studentphone,
           string studentisregister, string keyvalue)
        {
            try
            {
                string Message = "修改成功";
                int IsOk = 0;

                #region 实例化学生信息实体类
                DStudent_Infos model = new DStudent_Infos
                {
                    StudentCode = studentcode,
                    StudentName = studentname,
                    StudentSex = studentsex,
                    StudentBornDate = studentborndate,
                    StudentHomeAddress = studenthomeaddress,
                    GradeCode = gradecode,
                    SchoolName = schoolname,
                    SchoolCode = schoolcode,
                    ClassName = classname,
                    ClassCode = classcode,
                    NationCode = nationcode,
                    NationName = nationname,
                    StudentNative = studentnative,
                    StudentMoveType = studentmovetype,
                    StudentIDNumber = studentidnumber,
                    StudentPhone = studentphone,
                    StudentIsRegister = studentisregister,
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                };
                #endregion
                IsOk = sInfosBll.UpdDStudentInfo(model, CookieHelper.GetCookie("NK"));
                if (IsOk > 0)
                {
                    bool flg = true;
                    if (sTestScoreBll.CheckStudentTestScoreRepeat(studentcode, CookieHelper.GetCookie("NK")) <= 0)
                    {
                        #region 实例化学生成绩实体类
                        DStudent_TestScore testScoreModel = new DStudent_TestScore
                        {
                            StudentCode = studentcode,
                            StudentName = studentname,
                            StudentSex = studentsex,
                            Heigh = "",
                            Weight = "",
                            BMI = "",
                            BMIScore = "",
                            BMILevel = "",
                            Pulmonary = "",
                            PulmonaryScore = "",
                            PulmonaryLevel = "",
                            FiftyRun = "",
                            FiftyRunScore = "",
                            FiftyRunLevel = "",
                            StandJump = "",
                            StandJumpScore = "",
                            StandJumpLevel = "",
                            SitAndReach = "",
                            SitAndReachScore = "",
                            SitAndReachLevel = "",
                            EightHundred = "",
                            EightHundredScore = "",
                            EightHundredLevel = "",
                            EightHundredAddScore = "",
                            ThousandRun = "",
                            ThousandRunScore = "",
                            ThousandRunLevel = "",
                            ThousandRunAddScore = "",
                            MinSupination = "",
                            MinSupinationScore = "",
                            MinSupinationLevel = "",
                            MinSupinationAddScore = "",
                            PullUp = "",
                            PullUpScore = "",
                            PullUpLevel = "",
                            PullUpAddScore = "",
                            TestResult = "未测",
                            StudentTrueScore = "",
                            TestType = "正常测试",
                            CreateTime = DateTime.Now.ToString(),
                            UpdateTime = DateTime.Now.ToString(),
                            Remark = ""
                        };
                        #endregion
                        sTestScoreBll.AddDStudentTestScore(testScoreModel, gradecode, CookieHelper.GetCookie("NK"));
                    }
                    else
                    {
                        DStudent_TestScore testScoreModel = sTestScoreBll.GetDStudentTestScoreModel(studentcode, CookieHelper.GetCookie("NK"));
                        string heigh = testScoreModel.Heigh == null || testScoreModel.Heigh == "" ? "-1" : testScoreModel.Heigh;
                        string weight = testScoreModel.Weight == null || testScoreModel.Weight == "" ? "-1" : testScoreModel.Weight;
                        string pulmonary = testScoreModel.Pulmonary == null || testScoreModel.Pulmonary == "" ? "-1" : testScoreModel.Pulmonary;
                        string fiftyrun = testScoreModel.FiftyRun == null || testScoreModel.FiftyRun == "" ? "-1" : testScoreModel.FiftyRun.Replace(".", "");
                        string standjump = testScoreModel.StandJump == null || testScoreModel.StandJump == "" ? "-1" : testScoreModel.StandJump;
                        string sitandreach = testScoreModel.SitAndReach == null || testScoreModel.SitAndReach == "" ? "-1000" : testScoreModel.SitAndReach.Replace(".", ""); ;
                        string eighthundred = testScoreModel.EightHundred == null || testScoreModel.EightHundred == "" ? "-1" : testScoreModel.EightHundred;
                        string thousandrun = testScoreModel.ThousandRun == null || testScoreModel.ThousandRun == "" ? "-1" : testScoreModel.ThousandRun;
                        string minsupination = testScoreModel.MinSupination == null || testScoreModel.MinSupination == "" ? "-1" : testScoreModel.MinSupination;
                        string pullup = testScoreModel.PullUp == null || testScoreModel.PullUp == "" ? "-1" : testScoreModel.PullUp;
                        //如果体测库中的学生性别，和基本库中性别不相同则修改性别，修改成绩
                        if (testScoreModel.StudentSex != studentsex)
                        {

                            //修改性别
                            if (sTestScoreBll.UpdDStudentTestScoreSex(studentcode, studentsex, CookieHelper.GetCookie("NK")) > 0)
                            {
                               
                                //更新学生成绩，性别不同，成绩算法不同
                                int n = UpdateStudentScore(testScoreModel.StudentName, studentsex, gradecode, heigh, weight, pulmonary, fiftyrun,
                      standjump, sitandreach, thousandrun, eighthundred, pullup, minsupination, testScoreModel.StudentCode);
                                if (n <= 0)
                                    flg = false;
                            }

                        }
                        else
                        {
                            //更新学生成绩
                            int n = UpdateStudentScore(testScoreModel.StudentName, studentsex, gradecode, heigh, weight, pulmonary, fiftyrun,
                    standjump, sitandreach, eighthundred, thousandrun, minsupination, pullup, testScoreModel.StudentCode);
                            if (n <= 0)
                                flg = false;
                        }
                    }
                    if (flg)
                        return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                    else
                        return Content(new JsonMessage { Success = false, Code = IsOk.ToString(), Message = "修改失败，未知错误！" }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = false, Code = IsOk.ToString(), Message = "修改失败，未知错误！" }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        //修改成绩
        public int UpdateStudentScore(string studentname, string studentsex, string gradecode, string heigh, string weight, string pulmonary, string fiftyrun,
               string standjump, string sitandreach, string eighthundred, string thousandrun, string minsupination, string pullup, string studentcode)
        {
            try
            {
                DStudent_TestScore testScoreModel = new DStudent_TestScore();
                testScoreModel.StudentCode = studentcode;
                testScoreModel.StudentName = studentname.ToString().Trim();
                testScoreModel.StudentSex = studentsex.ToString().Trim();
                testScoreModel.Heigh = heigh.ToString().Trim() == "-1" ? "" : heigh.ToString().Trim();

                testScoreModel.Weight = weight.ToString().Trim() == "-1" ? "" : weight.ToString().Trim();
                string BMI = "";
                if (heigh != "-1" && weight != "-1")
                {
                    BMI = MarkHelper.BMI(Convert.ToSingle(heigh), Convert.ToSingle(weight));
                }
                if (BMI.Length >= 6)
                {
                    testScoreModel.BMI = CommonHelper.Round(Convert.ToDouble(BMI.Substring(0, 5)), 2).ToString();
                }
                else
                {
                    testScoreModel.BMI = BMI;
                }
                if (BMI != "")
                {
                    testScoreModel.BMIScore = MarkHelper.BMIScore(Convert.ToDouble(BMI), studentsex);
                    testScoreModel.BMILevel = MarkHelper.BMILevel(Convert.ToSingle(BMI), studentsex);
                }
                else
                {
                    testScoreModel.BMIScore = "";
                    testScoreModel.BMILevel = "";
                }
                testScoreModel.Pulmonary = pulmonary.ToString().Trim() == "-1" ? "" : pulmonary.ToString().Trim();
                if (pulmonary != "-1")
                {
                    testScoreModel.PulmonaryScore = MarkHelper.PulmonaryScore(Convert.ToInt32(pulmonary), studentsex, gradecode);
                    testScoreModel.PulmonaryLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.PulmonaryScore));
                }
                else
                {
                    testScoreModel.PulmonaryScore = "";
                    testScoreModel.PulmonaryLevel = "";
                }

                testScoreModel.FiftyRun = fiftyrun.ToString().Trim() == "-1" ? "" : fiftyrun.ToString().Trim();
                if (fiftyrun != "-1")
                {
                    testScoreModel.FiftyRunScore = MarkHelper.FiftyRunScore(Convert.ToDouble(fiftyrun), studentsex, gradecode);
                    testScoreModel.FiftyRunLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.FiftyRunScore));
                }
                else
                {
                    testScoreModel.FiftyRunScore = "";
                    testScoreModel.FiftyRunLevel = "";
                }
                testScoreModel.StandJump = standjump.ToString().Trim() == "-1" ? "" : standjump.ToString().Trim();
                if (standjump != "-1")
                {
                    testScoreModel.StandJumpScore = MarkHelper.StandJumpScore(Convert.ToInt32(standjump), studentsex, gradecode);
                    testScoreModel.StandJumpLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.StandJumpScore));
                }
                else
                {
                    testScoreModel.StandJumpScore = "";
                    testScoreModel.StandJumpLevel = "";
                }


                testScoreModel.SitAndReach = sitandreach.ToString().Trim() == "-1000" ? "" : sitandreach.ToString().Trim();
                if (sitandreach != "-1000")
                {
                    testScoreModel.SitAndReachScore = MarkHelper.SitAndReachScore(Convert.ToDouble(sitandreach), studentsex, gradecode);
                    testScoreModel.SitAndReachLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.SitAndReachScore));
                }
                else
                {
                    testScoreModel.SitAndReachScore = "";
                    testScoreModel.SitAndReachLevel = "";
                }

                testScoreModel.EightHundred = eighthundred.ToString().Trim() == "-1" ? "" : eighthundred.ToString().Trim();
                int eightHundredAddScore = 0;
                if (eighthundred != "-1")
                {
                    testScoreModel.EightHundredScore = MarkHelper.EightHundredScore(Convert.ToInt32(eighthundred), studentsex, gradecode);
                    testScoreModel.EightHundredLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.EightHundredScore));
                    eightHundredAddScore = Convert.ToInt32(testScoreModel.EightHundredScore) > 100 ? Convert.ToInt32(testScoreModel.EightHundredScore) - 100 : 0;
                    testScoreModel.EightHundredAddScore = eightHundredAddScore.ToString();
                }
                else
                {
                    testScoreModel.EightHundredScore = "";
                    testScoreModel.EightHundredLevel = "";
                    testScoreModel.EightHundredAddScore = "";
                }
                testScoreModel.ThousandRun = thousandrun.ToString().Trim() == "-1" ? "" : thousandrun.ToString().Trim();
                int thousandRunAddScore = 0;
                if (thousandrun != "-1")
                {
                    testScoreModel.ThousandRunScore = MarkHelper.ThousandRunScore(Convert.ToInt32(thousandrun), studentsex, gradecode);
                    testScoreModel.ThousandRunLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.ThousandRunScore));
                    thousandRunAddScore = Convert.ToInt32(testScoreModel.ThousandRunAddScore) > 100 ? Convert.ToInt32(testScoreModel.ThousandRunAddScore) - 100 : 0;
                    testScoreModel.ThousandRunAddScore = thousandRunAddScore.ToString();
                }
                else
                {
                    testScoreModel.ThousandRunScore = "";
                    testScoreModel.ThousandRunLevel = "";
                    testScoreModel.ThousandRunAddScore = "";
                }
                int minSupinationAddScore = 0;
                if (minsupination != "-1")
                {
                    testScoreModel.MinSupination = minsupination.ToString().Trim() == "-1" ? "" : minsupination.ToString().Trim();
                    testScoreModel.MinSupinationScore = MarkHelper.MinSupinationScore(Convert.ToInt32(minsupination), studentsex, gradecode);
                    testScoreModel.MinSupinationLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.MinSupinationScore));
                    minSupinationAddScore = Convert.ToInt32(testScoreModel.MinSupinationAddScore) > 100 ? Convert.ToInt32(testScoreModel.MinSupinationAddScore) - 100 : 0;
                    testScoreModel.MinSupinationAddScore = minSupinationAddScore.ToString();
                }
                else
                {
                    testScoreModel.MinSupination = "";
                    testScoreModel.MinSupinationScore = "";
                    testScoreModel.MinSupinationLevel = "";
                    testScoreModel.MinSupinationAddScore = "";
                }
                int pullUpAddScore = 0;
                if (pullup != "-1")
                {
                    testScoreModel.PullUp = pullup.ToString().Trim() == "0" ? "" : pullup.ToString().Trim();
                    testScoreModel.PullUpScore = MarkHelper.PullUpScore(Convert.ToInt32(pullup), studentsex, gradecode);
                    testScoreModel.PullUpLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.PullUpScore));
                    pullUpAddScore = Convert.ToInt32(testScoreModel.PullUpAddScore) > 100 ? Convert.ToInt32(testScoreModel.PullUpAddScore) - 100 : 0;
                    testScoreModel.PullUpAddScore = pullUpAddScore.ToString();
                }
                else
                {
                    testScoreModel.PullUp = "";
                    testScoreModel.PullUpScore = "";
                    testScoreModel.PullUpLevel = "";
                    testScoreModel.PullUpAddScore = "";
                }
                double trueTest = 0;
                if (studentsex == "1")
                {
                    trueTest = Convert.ToInt32(testScoreModel.BMIScore = testScoreModel.BMIScore == "" ? "0" : testScoreModel.BMIScore) * 0.15
                        + Convert.ToInt32(testScoreModel.PulmonaryScore == "" ? "0" : testScoreModel.PulmonaryScore) * 0.15
                        + Convert.ToInt32(testScoreModel.FiftyRunScore == "" ? "0" : testScoreModel.FiftyRunScore) * 0.2
                        + Convert.ToInt32(testScoreModel.StandJumpScore == "" ? "0" : testScoreModel.StandJumpScore) * 0.1
                        + Convert.ToInt32(testScoreModel.SitAndReachScore == "" ? "0" : testScoreModel.SitAndReachScore) * 0.1
                        + (Convert.ToInt32(testScoreModel.ThousandRunScore == "" ? "0" : testScoreModel.ThousandRunScore) > 100 ? 100 : Convert.ToInt32(testScoreModel.ThousandRunScore == "" ? "0" : testScoreModel.ThousandRunScore)) * 0.2
                        + (Convert.ToInt32(testScoreModel.PullUpScore == "" ? "0" : testScoreModel.PullUpScore) > 100 ? 100 : Convert.ToInt32(testScoreModel.PullUpScore == "" ? "0" : testScoreModel.PullUpScore)) * 0.1
                        + thousandRunAddScore + pullUpAddScore;
                    testScoreModel.StudentTrueScore = trueTest.ToString();
                }
                if (studentsex == "2")
                {
                    trueTest = Convert.ToInt32(testScoreModel.BMIScore = testScoreModel.BMIScore == "" ? "0" : testScoreModel.BMIScore) * 0.15
                        + Convert.ToInt32(testScoreModel.PulmonaryScore == "" ? "0" : testScoreModel.PulmonaryScore) * 0.15
                        + Convert.ToInt32(testScoreModel.FiftyRunScore == "" ? "0" : testScoreModel.FiftyRunScore) * 0.2
                        + Convert.ToInt32(testScoreModel.StandJumpScore == "" ? "0" : testScoreModel.StandJumpScore) * 0.1
                        + Convert.ToInt32(testScoreModel.SitAndReachScore == "" ? "0" : testScoreModel.SitAndReachScore) * 0.1
                        + (Convert.ToInt32(testScoreModel.EightHundredScore == "" ? "0" : testScoreModel.EightHundredScore) > 100 ? 100 : Convert.ToInt32(testScoreModel.EightHundredScore == "" ? "0" : testScoreModel.EightHundredScore)) * 0.2
                        + (Convert.ToInt32(testScoreModel.MinSupinationScore == "" ? "0" : testScoreModel.MinSupinationScore) > 100 ? 100 : Convert.ToInt32(testScoreModel.MinSupinationScore == "" ? "0" : testScoreModel.MinSupinationScore)) * 0.1
                        + eightHundredAddScore + minSupinationAddScore;
                    testScoreModel.StudentTrueScore = trueTest.ToString();
                }
                if (trueTest < 60)
                {
                    testScoreModel.TestResult = "补测";
                }
                else
                {
                    testScoreModel.TestResult = "通过";
                }
                testScoreModel.UpdateTime = System.DateTime.Now.ToString();

                int IsOk = sTestScoreBll.UpdDStudentTestScore(testScoreModel, gradecode, CookieHelper.GetCookie("NK"));
                if (IsOk > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 获取学院名称
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <returns>json数据</returns>
        [HttpPost]
        [LoginAuthorize]
        public JsonResult GetSchoolNameList(string gradecode)
        {
            try
            {
                DataTable schoolNameList = sClssBll.GetAllSchoolInfoByGradeCode(gradecode, 2, CookieHelper.GetCookie("NK"));
                return Json(schoolNameList.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取班级名称
        /// </summary>
        /// <param name="schoolcode">学院编号</param>
        /// <returns>json数据</returns>
        [HttpPost]
        [LoginAuthorize]
        public JsonResult GetClassNameList(string schoolcode)
        {
            try
            {
                DataTable classNameList = sClssBll.GetAllClassInfoBySchoolCode(schoolcode, 2, CookieHelper.GetCookie("NK"));
                return Json(classNameList.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取民族名称
        /// </summary>
        /// <returns>json数据</returns>
        [LoginAuthorize]
        public JsonResult GetNationName()
        {
            try
            {
                DataTable nationList = bNationBll.GetNationList();
                return Json(nationList.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取学生Model
        /// </summary>
        /// <param name="studencode">学生学号</param>
        /// <returns>json数据</returns>       
        public ActionResult GetDStudentInfosModel(string studentcode)
        {

            try
            {
                DStudent_Infos model = sInfosBll.GetDStudentInfosModel(studentcode, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DelDStudentInfos(int KeyValue)
        {
            try
            {
                string Message = "删除成功！";
                int IsOk = 0;
                IsOk = sInfosBll.DelDStudentInfos(KeyValue, CookieHelper.GetCookie("NK"));

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPassword()
        {
            ViewBag.Account = Request["Account"];
            return View();
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="KeyValue">主键</param>
        /// <param name="Password">新密码</param>
        /// <returns></returns>
        public ActionResult ResetPasswordSubmit(string KeyValue, string Password)
        {
            try
            {
                int IsOk = 0;
                IsOk = bUsersBll.UpdDBase_UsersPwd(KeyValue, DESEncrypt.Encrypt(Password));
                if (IsOk > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "密码修改成功。" }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "密码修改失败。" }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog(KeyValue, OperationType.Update, "-1", "密码修改失败：" + ex.Message);
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "密码修改失败：" + ex.Message }.ToString());
            }
        }

        #endregion

        #region 学生基本信息导入操作

        //清空学生基本信息
        [LoginAuthorize]
        public JsonResult DelAllStudentInfos()
        {
            Base_SysLogBll.Instance.WriteLog("System", OperationType.Delete, "-1", "清空数据库。");
            return Json(new { IsOk = sInfosBll.DelStudentInfoAll(CookieHelper.GetCookie("NK")) > 0 ? true : false });
        }


        //导入视图
       
        public ActionResult ImportStudentInfoFrom()
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

        //导入功能实现
        [LoginAuthorize]
        public JsonResult ImportExcelStudentInfos()
        {
            string filePath = "";

            //文件大小不为0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //保存成自己的文件全路径,newfile就是你上传后保存的文件,
            //服务器上的UpLoadFile文件夹必须有读写权限　
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region 将服务器上的excel数据导出成数据集,添加入库

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelData(xmlDate, CookieHelper.GetCookie("NK"));

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
        private string AddExcelData(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//错误的个数
            int sumcount = xmlDate.Rows.Count;//导入数据的总个数
            int rowindex = 1;//行标
            string comname = string.Empty;
            int i = 1;
            foreach (DataRow excelRow in xmlDate.Rows)
            {
                DStudent_Infos model = new DStudent_Infos();
                bool flg = true;//可添加入库的标识
                rowindex++;
                try
                {


                    model.StudentCode = excelRow[0].ToString().Trim();
                    /**************学生学号**********/
                    int studentCodeLength = excelRow[0].ToString().Trim().Length;
                    comname = excelRow[0].ToString().Trim();
                    if (studentCodeLength > 0 && studentCodeLength <= 100)
                    {
                        model.StudentCode = excelRow[0].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************学生姓名**********/
                    int studentNameLength = excelRow[1].ToString().Trim().Length;
                    if (studentNameLength > 0 & studentNameLength <= 100)
                    {
                        model.StudentName = excelRow[1].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /***************学生性别*****************/
                    int studentSexLength = excelRow[2].ToString().Trim().Length;

                    if (studentSexLength > 0 & studentSexLength <= 100)
                    {
                        model.StudentSex = excelRow[2].ToString().Trim() == "男" ? "1" : "2";
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空或者长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }


                    /***************学生学院*****************/
                    int schoolNameLength = excelRow[3].ToString().Trim().Length;

                    if (schoolNameLength > 0 & schoolNameLength <= 100)
                    {

                        model.SchoolName = excelRow[3].ToString().Trim();


                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空或者长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }


                    /***************学生出生日期*****************/
                    int studentBornDateLength = excelRow[4].ToString().Trim().Length;
                    if (studentBornDateLength <= 100)
                    {
                        try
                        {
                            //把日期转换成特定格式
                            model.StudentBornDate = Convert.ToDateTime(excelRow[4].ToString().Trim()).ToString("yyyy-MM-dd");

                        }
                        catch
                        {
                            model.StudentBornDate = CommonHelper.DataTimeChange(excelRow[4].ToString().Trim());
                            //lbMesg.Items.Add(ErrorMsgTitle(rowindex, comname) + "出生日期格式不正缺添加失败\r\n");
                        }
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /***************家庭住址*****************/
                    int studentHomeAddressLength = excelRow[5].ToString().Trim().Length;

                    if (studentHomeAddressLength <= 100)
                    {
                        if (excelRow[5].ToString().Trim() != "")
                        {
                            model.StudentHomeAddress = excelRow[5].ToString().Trim();
                        }
                        else
                        {
                            try
                            {
                                model.StudentHomeAddress = bCityBll.GetCityNameByCityCode(model.StudentIDNumber.Substring(0, 6));
                            }
                            catch
                            {
                                model.StudentHomeAddress = "";
                            }
                        }
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************行政班**********/
                    int classNameLength = excelRow[6].ToString().Trim().Length;
                    if (classNameLength > 0 & classNameLength <= 100)
                    {
                        model.ClassName = excelRow[6].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************民族**********/
                    int nationNameLength = excelRow[7].ToString().Trim().Length;
                    if (nationNameLength <= 100)
                    {
                        model.NationName = excelRow[7].ToString().Trim();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************身份证号**********/
                    int studentIDNumberLength = excelRow[8].ToString().Trim().Length;
                    if (studentIDNumberLength <= 100)
                    {
                        model.StudentIDNumber = excelRow[8].ToString().Trim().ToUpper();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************电话号**********/
                    int studentPhoneLength = excelRow[9].ToString().Trim().Length;
                    if (studentPhoneLength <= 100)
                    {
                        model.StudentPhone = excelRow[9].ToString().Trim();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************籍贯**********/
                    int studentNativeLength = excelRow[10].ToString().Trim().Length;
                    if (studentNativeLength <= 100)
                    {
                        if (excelRow[10].ToString().Trim() != "")
                        {
                            model.StudentNative = excelRow[10].ToString().Trim();
                        }
                        else
                        {
                            try
                            {
                                model.StudentNative = bCityBll.GetCityNameByCityCode(model.StudentIDNumber.Substring(0, 6));
                            }
                            catch
                            {
                                model.StudentNative = "";
                            }
                        }

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************异动类型**********/
                    int studentMoveTypeLength = excelRow[11].ToString().Trim().Length;
                    if (studentMoveTypeLength <= 100)
                    {
                        int type = 0;
                        string studentType = excelRow[11].ToString().Trim();

                        model.StudentMoveType = studentType == "" ? "" : studentType.ToString();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }

                    /**************是否注册**********/
                    int studentIsRegisterLength = excelRow[12].ToString().Trim().Length;
                    if (studentIsRegisterLength > 0 & studentIsRegisterLength <= 100)
                    {
                        model.StudentIsRegister = excelRow[12].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败<br/>";
                        flg = false;
                    }
                    /**************年纪编号**********/
                    int studentGradeCodeLength = excelRow[13].ToString().Trim().Length;
                    if (studentGradeCodeLength > 0 & studentGradeCodeLength <= 100)
                    {
                        model.GradeCode = excelRow[13].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败<br/>";
                        flg = false;
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
                        result = sInfosBll.AddDStudentImport(model, CookieHelper.GetCookie("NK"));
                        if (result == 1)
                        {
                            bUsersBll.AddDBase_User(model.StudentCode, DESEncrypt.Encrypt("123456"));
                        }
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
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "添加失败(原因:数据库错误，请联系管理员)" + "<br/>";
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
            FilePathResult file = new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/学生信息导入模版.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "学生信息导入模版.xlsx";
            return file;
        }


        #endregion
    }
}