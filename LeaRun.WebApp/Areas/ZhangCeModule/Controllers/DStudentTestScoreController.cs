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
    /// 学生成绩测试表（随年份建表）控制器
    /// </summary>
    public class DStudentTestScoreController : PublicController<DStudent_TestScore>
    {
        DStudent_TestScoreBll sTestScoreBll = new DStudent_TestScoreBll();
        DStudent_InfosBll bStudentsBll = new DStudent_InfosBll();

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="keyvalue">关键字</param>
        /// <param name="jqgridparam">分页参数</param>
        /// <returns>json数据</returns>
        [LoginAuthorize]
        public ActionResult GridDStudentTestScoreJson(string keyvalue, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                DataTable ListData = sTestScoreBll.GridDStudentTestScoreList(keyvalue, CookieHelper.GetCookie("NK"), ref jqgridparam);
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


        //修改编辑
        public ActionResult UpdateStudentScore(string studentname, string studentsex, string gradecode, string heigh, string weight, string pulmonary, string fiftyrun,
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
                testScoreModel.MinSupination = minsupination.ToString().Trim() == "-1" ? "" : minsupination.ToString().Trim();
                if (minsupination != "-1")
                {
                    testScoreModel.MinSupinationScore = MarkHelper.MinSupinationScore(Convert.ToInt32(minsupination), studentsex, gradecode);
                    testScoreModel.MinSupinationLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.MinSupinationScore));
                    minSupinationAddScore = Convert.ToInt32(testScoreModel.MinSupinationAddScore) > 100 ? Convert.ToInt32(testScoreModel.MinSupinationAddScore) - 100 : 0;
                    testScoreModel.MinSupinationAddScore = minSupinationAddScore.ToString();
                }
                else
                {
                    testScoreModel.MinSupinationScore = "";
                    testScoreModel.MinSupinationLevel = "";
                    testScoreModel.MinSupinationAddScore = "";
                }
                int pullUpAddScore = 0;
                testScoreModel.PullUp = pullup.ToString().Trim() == "-1" ? "" : pullup.ToString().Trim();
                if (pullup != "-1")
                {
                    testScoreModel.PullUpScore = MarkHelper.PullUpScore(Convert.ToInt32(pullup), studentsex, gradecode);
                    testScoreModel.PullUpLevel = MarkHelper.Level(Convert.ToInt32(testScoreModel.PullUpScore));
                    pullUpAddScore = Convert.ToInt32(testScoreModel.PullUpAddScore) > 100 ? Convert.ToInt32(testScoreModel.PullUpAddScore) - 100 : 0;
                    testScoreModel.PullUpAddScore = pullUpAddScore.ToString();
                }
                else
                {
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
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "修改成功。" }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "修改失败。" }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        #region 基本操作按钮

        /// <summary>
        /// 获取学生体侧信息
        /// </summary>
        /// <param name="studentcode">学生学号</param>
        /// <returns></returns>       
        public ActionResult GetDStudentTestScoreModel(string studentcode)
        {
            try
            {
                DStudent_TestScore model = sTestScoreBll.GetDStudentTestScoreModel(studentcode, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取学生基本信息的方法
        /// </summary>
        /// <param name="studentcode">学生学号</param>
        /// <returns></returns>       
        public ActionResult GetDStudentInfosModel(string studentcode)
        {
            try
            {
                DStudent_Infos model = bStudentsBll.GetDStudentInfosModel(studentcode, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        //删除学生基本信息

       
        public ActionResult DelDStudentTestScore(string KeyValue)
        {
            try
            {
                string Message = "删除成功！";
                if (bStudentsBll.CheckStudentInfoRepeat(KeyValue, CookieHelper.GetCookie("NK")) > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = "0", Message = "学生基本信息已存在！请先删除学生基本信息！" }.ToString());
                }
                else
                {
                    int IsOk = 0;
                    IsOk = sTestScoreBll.DelDStudentTestScore(KeyValue, CookieHelper.GetCookie("NK"));

                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Delete, "-1", "异常错误：" + ex.Message);
                return null;
            }
        }

        //标记为免测
        [LoginAuthorize]
        public JsonResult MarkFree(string studentcode)
        {
            try
            {
                if (sTestScoreBll.MarkFree(studentcode, CookieHelper.GetCookie("NK")) > 0)
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

        //标记为作弊
        [LoginAuthorize]
        public JsonResult MarkCheat(string studentcode)
        {
            try
            {
                if (sTestScoreBll.MarkCheat(studentcode, CookieHelper.GetCookie("NK")) > 0)
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

        //取消作弊
        [LoginAuthorize]
        public JsonResult DelCheat(string studentcode)
        {
            try
            {
                DStudent_TestScore model = sTestScoreBll.GetDStudentTestScoreModel(studentcode, CookieHelper.GetCookie("NK"));
                string testResult = "";
                if (model.StudentTrueScore != "")
                {
                    if (Convert.ToSingle(model.StudentTrueScore) < 60)
                    {
                        testResult = "补测";
                    }
                    if (Convert.ToSingle(model.StudentTrueScore) >= 60)
                    {
                        testResult = "通过";
                    }
                    if (sTestScoreBll.DelCheat(studentcode, testResult, CookieHelper.GetCookie("NK")) > 0)
                    {
                        return Json(new { IsOk = true });
                    }
                    else
                    {
                        return Json(new { IsOk = false });
                    }
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

        #endregion

        #region 单项成绩得分

        /// <summary>
        /// 引体向上分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="pullup">引体向上</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>       
        public JsonResult PullUp(string gradecode, string pullup, string studentsex)
        {
            string pullUpScore = "";
            string pullUpAddScore = "";
            if (pullup != "-1")
            {
                string pull = pullup.ToString().Trim();
                pullUpScore = MarkHelper.PullUpScore(Convert.ToInt32(pull), studentsex, gradecode);
                pullUpAddScore = Convert.ToInt32(pullUpScore) > 100 ? (Convert.ToInt32(pullUpScore) - 100).ToString() : "";
            }
            return Json(new { PullUpScore = pullUpScore, pullUpAddScore = pullUpAddScore.ToString() });

        }

        /// <summary>
        /// 一分钟仰卧起坐分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="minsupination">一分钟仰卧起坐</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>      
        public JsonResult MinSupination(string gradecode, string minsupination, string studentsex)
        {
            string miScore = "";
            string minSupinationAddScore = "";
            if (minsupination != "-1")
            {
                string mi = minsupination.ToString().Trim();
                miScore = MarkHelper.MinSupinationScore(Convert.ToInt32(minsupination), studentsex, gradecode);
                minSupinationAddScore = Convert.ToInt32(miScore) > 100 ? (Convert.ToInt32(miScore) - 100).ToString() : "";
            }
            return Json(new { MinSupinationScore = miScore, MinSupinationAddScore = minSupinationAddScore.ToString() });

        }

        /// <summary>
        /// 1000米分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="thousandrun">1000米</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns></returns>        
        public JsonResult ThousandRun(string gradecode, string thousandrun, string studentsex)
        {
            string thoScore = "";
            string thousandRunAddScore = "";
            if (thousandrun != "-1")
            {
                string tho = thousandrun.ToString().Trim();
                thoScore = MarkHelper.ThousandRunScore(Convert.ToInt32(thousandrun), studentsex, gradecode);
                thousandRunAddScore = Convert.ToInt32(thoScore) > 100 ? (Convert.ToInt32(thoScore) - 100).ToString() : "";
            }
            return Json(new { ThousandRunScore = thoScore, ThousandRunAddScore = thousandRunAddScore.ToString() });

        }

        /// <summary>
        /// 800米分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="eighthundred">800米</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns></returns>       
        public JsonResult EightHundred(string gradecode, string eighthundred, string studentsex)
        {
            string eigScore = "";
            string eightHundredAddScore = "";
            if (eighthundred != "-1")
            {
                string eig = eighthundred.ToString().Trim();
                eigScore = MarkHelper.EightHundredScore(Convert.ToInt32(eighthundred), studentsex, gradecode);
                eightHundredAddScore = Convert.ToInt32(eigScore) > 100 ? (Convert.ToInt32(eigScore) - 100).ToString() : "";
            }
            return Json(new { EightHundredScore = eigScore, EightHundredAddScore = eightHundredAddScore.ToString() });

        }

        /// <summary>
        /// 座位体前屈分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="sitandreach">座位体前屈</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>       
        public JsonResult SitAndReach(string gradecode, string sitandreach, string studentsex)
        {
            string siScore = "";
            if (sitandreach != "-1000")
            {
                var si = sitandreach.ToString().Trim();
                siScore = MarkHelper.SitAndReachScore(Convert.ToDouble(sitandreach), studentsex, gradecode);

            }
            return Json(new { SitAndReachScore = siScore });
        }

        /// <summary>
        /// 肺活量分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="pulmonary">肺活量</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>      
        public JsonResult Pulmonary(string gradecode, string pulmonary, string studentsex)
        {
            string pulScore = "";
            if (pulmonary != "-1")
            {
                string pul = pulmonary.ToString().Trim();
                pulScore = MarkHelper.PulmonaryScore(Convert.ToInt32(pulmonary), studentsex, gradecode);
            }
            return Json(new { PulmonaryScore = pulScore });
        }

        /// <summary>
        /// 立定跳远分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="standjump">立定跳远</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>    
        public JsonResult StandJump(string gradecode, string standjump, string studentsex)
        {
            string jupScore = "";
            if (standjump != "-1")
            {
                string jup = standjump.ToString().Trim();
                jupScore = MarkHelper.StandJumpScore(Convert.ToInt32(standjump), studentsex, gradecode);
            }
            return Json(new { StandJumpScore = jupScore });
        }

        /// <summary>
        /// 50米跑分数操作
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="fiftyrun">50米跑</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>       
        public JsonResult FiftyRun(string gradecode, string fiftyrun, string studentsex)
        {
            string fifScore = "";
            if (fiftyrun != "-1")
            {
                string fif = fiftyrun.ToString().Trim();
                fifScore = MarkHelper.FiftyRunScore(Convert.ToDouble(fiftyrun), studentsex, gradecode);
            }
            return Json(new { FiftyRunScore = fifScore });
        }

        /// <summary>
        /// 体重指数分数操作
        /// </summary>
        /// <param name="heigh">身高</param>
        /// <param name="weight">体重</param>
        /// <param name="studentsex">学生性别</param>
        /// <returns>json数据</returns>       
        public JsonResult BMI(string heigh, string weight, string studentsex)
        {
            string BMI = "";
            string BMIScore = "";
            if (heigh != "-1" && weight != "-1")
            {
                BMI = MarkHelper.BMI(Convert.ToSingle(heigh), Convert.ToSingle(weight));

                if (BMI.Length >= 6)
                {
                    BMI = CommonHelper.Round(Convert.ToDouble(BMI.Substring(0, 5)), 2).ToString();
                }

                BMIScore = MarkHelper.BMIScore(Convert.ToDouble(BMI), studentsex);
            }
            return Json(new { BMI = BMI, BMIScore = BMIScore });
        }

        #endregion


        #region 导入

        //导入学生体测信息，选取最好成绩作为学生成绩
        //导入视图
       
        public ActionResult ImportStudentTestFrom()
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


        //导入功能实现取学生最好成绩
        [LoginAuthorize]
        public JsonResult ImportExcelStudentTestBest()
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

            string returnMsg = AddExcelDataBest(xmlDate, CookieHelper.GetCookie("NK"));

            #endregion

            return Json(new { Msg = returnMsg });
        }

        //覆盖型导入，原成绩作废，导入的为最新成绩
        [LoginAuthorize]
        public JsonResult ImportExcelStudentTestRep()
        {
            string filePath = "";

            //文件大小不为0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //保存成自己的文件全路径,newfile就是你上传后保存的文件,
            //服务器上的UpLoadFile文件夹必须有读写权限　
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region 将服务器上的excel数据导出成数据集,添加入库

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelDataRep(xmlDate, CookieHelper.GetCookie("NK"));

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
        private string AddExcelDataRep(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//错误的个数
            int sumcount = xmlDate.Rows.Count;//导入数据的总个数
            int rowindex = 1;//行标
            string comname = string.Empty;
            int i = 1;
            foreach (DataRow excelRow in xmlDate.Rows)
            {
                DStudent_TestScore model = new DStudent_TestScore();
                DStudent_Infos studentModel;
                bool flg;
                RepNewMethod(NK, ref errorMsg, ref errorcount, ref rowindex, ref comname, excelRow, model, out studentModel, out flg);
                if (flg)
                {
                    int result = 1;
                    try
                    {
                        //导入信息返回的结果
                        result = sTestScoreBll.UpdDStudentTestScore(model, studentModel.GradeCode, CookieHelper.GetCookie("NK"));

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

        /// <summary>
        /// 添加Excel的数据
        /// </summary>
        /// <param name="xmlDate"></param>
        private string AddExcelDataBest(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//错误的个数
            int sumcount = xmlDate.Rows.Count;//导入数据的总个数
            int rowindex = 1;//行标
            string comname = string.Empty;
            int i = 1;
            foreach (DataRow excelRow in xmlDate.Rows)
            {
                DStudent_TestScore model = new DStudent_TestScore();
                bool flg;
                DStudent_Infos studentModel;
                RepNewMethod(NK, ref errorMsg, ref errorcount, ref rowindex, ref comname, excelRow, model, out studentModel, out flg);
                DStudent_TestScore modelOld = sTestScoreBll.GetDStudentTestScoreModel(excelRow[0].ToString().Trim(), NK);
                if (modelOld.StudentCode!=null)
                {
                    model.StudentCode = modelOld.StudentCode;
                    model.StudentName = modelOld.StudentName;
                    model.StudentSex = model.StudentSex;
                    if (modelOld.BMIScore != "" && modelOld.BMIScore != null && model.BMIScore != "")
                    {
                        if (Convert.ToInt32(modelOld.BMIScore) > Convert.ToInt32(model.BMIScore))
                        {
                            model.Heigh = modelOld.Heigh;
                            model.Weight = modelOld.Weight;
                            model.BMI = modelOld.BMI;
                            model.BMIScore = modelOld.BMIScore;
                            model.BMILevel = modelOld.BMILevel;
                        }
                    }
                    else if (modelOld.BMIScore != "" && modelOld.BMIScore != null && model.BMIScore == "")
                    {
                        model.Heigh = modelOld.Heigh;
                        model.Weight = modelOld.Weight;
                        model.BMI = modelOld.BMI;
                        model.BMIScore = modelOld.BMIScore;
                        model.BMILevel = modelOld.BMILevel;

                    }

                    if (modelOld.PulmonaryScore != "" && modelOld.PulmonaryScore != null && model.PulmonaryScore != "")
                    {
                        int sss = Convert.ToInt32(modelOld.PulmonaryScore);
                        if (Convert.ToInt32(modelOld.PulmonaryScore) > Convert.ToInt32(model.PulmonaryScore))
                        {
                            model.Pulmonary = modelOld.Pulmonary;
                            model.PulmonaryScore = modelOld.PulmonaryScore;
                            model.PulmonaryLevel = modelOld.PulmonaryLevel;
                        }
                    }
                    else if (modelOld.PulmonaryScore != "" && modelOld.PulmonaryScore != null && model.PulmonaryScore == "")
                    {
                        model.Pulmonary = modelOld.Pulmonary;
                        model.PulmonaryScore = modelOld.PulmonaryScore;
                        model.PulmonaryLevel = modelOld.PulmonaryLevel;
                    }

                    if (modelOld.FiftyRunScore != "" && modelOld.FiftyRunScore != null && model.FiftyRunScore != "")
                    {
                        if (Convert.ToInt32(modelOld.FiftyRunScore) > Convert.ToInt32(model.FiftyRunScore))
                        {
                            model.FiftyRun = modelOld.FiftyRun;
                            model.FiftyRunScore = modelOld.FiftyRunScore;
                            model.FiftyRunLevel = modelOld.FiftyRunLevel;
                        }

                    }
                    else if (modelOld.FiftyRunScore != "" && modelOld.FiftyRunScore != null && model.FiftyRunScore == "")
                    {
                        model.FiftyRun = modelOld.FiftyRun;
                        model.FiftyRunScore = modelOld.FiftyRunScore;
                        model.FiftyRunLevel = modelOld.FiftyRunLevel;
                    }


                    if (modelOld.StandJumpScore != "" && modelOld.StandJumpScore != null && model.StandJumpScore != "")
                    {
                        if (Convert.ToInt32(modelOld.StandJumpScore) > Convert.ToInt32(model.StandJumpScore))
                        {
                            model.StandJump = modelOld.StandJump;
                            model.StandJumpScore = modelOld.StandJumpScore;
                            model.StandJumpLevel = modelOld.StandJumpLevel;
                        }
                    }
                    else if (modelOld.StandJumpScore != "" && modelOld.StandJumpScore != null && model.StandJumpScore == "")
                    {
                        model.StandJump = modelOld.StandJump;
                        model.StandJumpScore = modelOld.StandJumpScore;
                        model.StandJumpLevel = modelOld.StandJumpLevel;
                    }

                    if (modelOld.SitAndReachScore != "" && modelOld.SitAndReachScore != null && model.SitAndReachScore != "")
                    {
                        if (Convert.ToInt32(modelOld.SitAndReachScore) > Convert.ToInt32(model.SitAndReachScore))
                        {
                            model.SitAndReach = modelOld.SitAndReach;
                            model.SitAndReachScore = modelOld.SitAndReachScore;
                            model.SitAndReachLevel = modelOld.SitAndReachLevel;
                        }
                    }
                    else if (modelOld.SitAndReachScore != "" && modelOld.SitAndReachScore != null && model.SitAndReachScore == "")
                    {
                        model.SitAndReach = modelOld.SitAndReach;
                        model.SitAndReachScore = modelOld.SitAndReachScore;
                        model.SitAndReachLevel = modelOld.SitAndReachLevel;
                    }


                    if (modelOld.EightHundredScore != "" && modelOld.EightHundredScore != null && model.EightHundredScore != "")
                    {
                        if (Convert.ToInt32(modelOld.EightHundredScore) > Convert.ToInt32(model.EightHundredScore))
                        {
                            model.EightHundred = modelOld.EightHundred;
                            model.EightHundredScore = modelOld.EightHundredScore;
                            model.EightHundredLevel = modelOld.EightHundredLevel;
                            model.EightHundredAddScore = modelOld.EightHundredAddScore;

                        }
                    } 
                    else if(modelOld.EightHundredScore != "" && modelOld.EightHundredScore != null && model.EightHundredScore == "")
                    {
                        model.EightHundred = modelOld.EightHundred;
                        model.EightHundredScore = modelOld.EightHundredScore;
                        model.EightHundredLevel = modelOld.EightHundredLevel;
                        model.EightHundredAddScore = modelOld.EightHundredAddScore;

                    }

                    if (modelOld.ThousandRunScore != "" && modelOld.ThousandRunScore != null && model.ThousandRunScore != "")
                    {
                        if (Convert.ToInt32(modelOld.ThousandRunScore) > Convert.ToInt32(model.ThousandRunScore))
                        {
                            model.ThousandRun = modelOld.ThousandRun;
                            model.ThousandRunScore = modelOld.ThousandRunScore;
                            model.ThousandRunLevel = modelOld.ThousandRunLevel;
                            model.ThousandRunAddScore = modelOld.ThousandRunAddScore;
                        }
                    }
                    else if (modelOld.ThousandRunScore != "" && modelOld.ThousandRunScore != null && model.ThousandRunScore == "")
                    {
                        model.ThousandRun = modelOld.ThousandRun;
                        model.ThousandRunScore = modelOld.ThousandRunScore;
                        model.ThousandRunLevel = modelOld.ThousandRunLevel;
                        model.ThousandRunAddScore = modelOld.ThousandRunAddScore;
                    }

                    if (modelOld.MinSupinationScore != "" && modelOld.MinSupinationScore != null && model.MinSupinationScore != "")
                    {
                        if (Convert.ToInt32(modelOld.MinSupinationScore) > Convert.ToInt32(model.MinSupinationScore))
                        {
                            model.MinSupination = modelOld.MinSupination;
                            model.MinSupinationScore = modelOld.MinSupinationScore;
                            model.MinSupinationLevel = modelOld.MinSupinationLevel;
                            model.MinSupinationAddScore = modelOld.MinSupinationAddScore;

                        }
                    }
                    else if (modelOld.MinSupinationScore != "" && modelOld.MinSupinationScore != null && model.MinSupinationScore == "")
                    {
                        model.MinSupination = modelOld.MinSupination;
                        model.MinSupinationScore = modelOld.MinSupinationScore;
                        model.MinSupinationLevel = modelOld.MinSupinationLevel;
                        model.MinSupinationAddScore = modelOld.MinSupinationAddScore;
                    }

                    if (modelOld.PullUpScore != "" && modelOld.PullUpScore != null && model.PullUpScore != "")
                    {
                        if (Convert.ToInt32(modelOld.PullUpScore) > Convert.ToInt32(model.PullUpScore))
                        {
                            model.PullUp = modelOld.PullUp;
                            model.PullUpScore = modelOld.PullUpScore;
                            model.PullUpLevel = modelOld.PullUpLevel;
                            model.PullUpAddScore = modelOld.PullUpAddScore;
                        }
                    }
                    else if (modelOld.PullUpScore != "" && modelOld.PullUpScore != null && model.PullUpScore == "")
                    {
                        model.PullUp = modelOld.PullUp;
                        model.PullUpScore = modelOld.PullUpScore;
                        model.PullUpLevel = modelOld.PullUpLevel;
                        model.PullUpAddScore = modelOld.PullUpAddScore;

                    }

                    double trueTest = 0;
                    if (studentModel.StudentSex == "1")
                    {
                        trueTest = Convert.ToInt32(model.BMIScore = model.BMIScore == "" ? "0" : model.BMIScore) * 0.15
                            + Convert.ToInt32(model.PulmonaryScore == "" ? "0" : model.PulmonaryScore) * 0.15
                            + Convert.ToInt32(model.FiftyRunScore == "" ? "0" : model.FiftyRunScore) * 0.2
                            + Convert.ToInt32(model.StandJumpScore == "" ? "0" : model.StandJumpScore) * 0.1
                            + Convert.ToInt32(model.SitAndReachScore == "" ? "0" : model.SitAndReachScore) * 0.1
                            + (Convert.ToInt32(model.ThousandRunScore == "" ? "0" : model.ThousandRunScore) > 100 ? 100 : Convert.ToInt32(model.ThousandRunScore == "" ? "0" : model.ThousandRunScore)) * 0.2
                            + (Convert.ToInt32(model.PullUpScore == "" ? "0" : model.PullUpScore) > 100 ? 100 : Convert.ToInt32(model.PullUpScore == "" ? "0" : model.PullUpScore)) * 0.1
                            + Convert.ToInt32(model.ThousandRunAddScore == "" ? "0" : model.ThousandRunAddScore) + Convert.ToInt32(model.PullUpAddScore == "" ? "0" : model.PullUpAddScore);
                        model.StudentTrueScore = trueTest.ToString();
                    }
                    if (studentModel.StudentSex == "2")
                    {
                        trueTest = Convert.ToInt32(model.BMIScore = model.BMIScore == "" ? "0" : model.BMIScore) * 0.15
                            + Convert.ToInt32(model.PulmonaryScore == "" ? "0" : model.PulmonaryScore) * 0.15
                            + Convert.ToInt32(model.FiftyRunScore == "" ? "0" : model.FiftyRunScore) * 0.2
                            + Convert.ToInt32(model.StandJumpScore == "" ? "0" : model.StandJumpScore) * 0.1
                            + Convert.ToInt32(model.SitAndReachScore == "" ? "0" : model.SitAndReachScore) * 0.1
                            + (Convert.ToInt32(model.EightHundredScore == "" ? "0" : model.EightHundredScore) > 100 ? 100 : Convert.ToInt32(model.EightHundredScore == "" ? "0" : model.EightHundredScore)) * 0.2
                            + (Convert.ToInt32(model.MinSupinationScore == "" ? "0" : model.MinSupinationScore) > 100 ? 100 : Convert.ToInt32(model.MinSupinationScore == "" ? "0" : model.MinSupinationScore)) * 0.1
                            + Convert.ToInt32(model.EightHundredAddScore == "" ? "0" : model.EightHundredAddScore) + Convert.ToInt32(model.MinSupinationAddScore == "" ? "0" : model.MinSupinationAddScore);
                        model.StudentTrueScore = trueTest.ToString();
                    }
                    if (trueTest < 60)
                    {
                        model.TestResult = "补测";
                    }
                    else
                    {
                        model.TestResult = "通过";
                    }
                    model.UpdateTime = System.DateTime.Now.ToString();
                }
                if (flg)
                {
                    int result = 1;
                    try
                    {
                        //导入信息返回的结果
                        result = sTestScoreBll.UpdDStudentTestScore(model, studentModel.GradeCode, CookieHelper.GetCookie("NK"));

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

        //覆盖
        private void RepNewMethod(string NK, ref string errorMsg, ref int errorcount, ref int rowindex, ref string comname, DataRow excelRow, DStudent_TestScore model, out DStudent_Infos studentModel, out bool flg)
        {
            studentModel = bStudentsBll.GetDStudentInfosModel(excelRow[0].ToString().Trim(), NK);
            flg = true;
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
                if (flg)
                {

                    if (studentModel.StudentCode==null)
                    {
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "该年库中没有该学生,请先添加该学生基本信息,添加失败<br/>";
                        flg = false;
                    }
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

                    if (excelRow[2].ToString().Trim() != "1" && excelRow[2].ToString().Trim() != "2")
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "性别格式不正确),添加失败<br/>";
                        flg = false;
                    }
                    else
                    { model.StudentSex = excelRow[2].ToString().Trim(); }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空或者长度超过100个字符),添加失败<br/>";
                    flg = false;
                }


                /***************学生身高*****************/
                int studentHeightLength = excelRow[3].ToString().Trim().Length;

                if (studentHeightLength <= 100)
                {

                    if (CommonHelper.IsInt(excelRow[3].ToString().Trim()))
                    {
                        model.Heigh = excelRow[3].ToString().Trim();
                    }
                    else if (excelRow[3].ToString().Trim() == "")
                    {
                        model.Heigh = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "身高格式不正确),添加失败<br/>";
                        flg = false;
                    }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }


                /***************学生体重*****************/
                int studentWeightLength = excelRow[4].ToString().Trim().Length;

                if (studentWeightLength <= 100)
                {

                    if (CommonHelper.IsInt(excelRow[4].ToString().Trim()))
                    {
                        model.Weight = excelRow[4].ToString().Trim();
                    }
                    else if (excelRow[4].ToString().Trim() == "")
                    {
                        model.Weight = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "体重格式不正确),添加失败<br/>";
                        flg = false;
                    }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }

                if (flg)
                {
                    string BMI = "";
                    if (model.Heigh != "" && model.Weight != "")
                    {
                        BMI = MarkHelper.BMI(Convert.ToSingle(model.Heigh), Convert.ToSingle(model.Weight));
                    }
                    if (BMI.Length >= 6)
                    {
                        model.BMI = CommonHelper.Round(Convert.ToDouble(BMI.Substring(0, 5)), 2).ToString();
                    }
                    else
                    {
                        model.BMI = BMI;
                    }
                    if (BMI != "")
                    {
                        model.BMIScore = MarkHelper.BMIScore(Convert.ToDouble(BMI), model.StudentSex);
                        model.BMILevel = MarkHelper.BMILevel(Convert.ToSingle(BMI), model.StudentSex);
                    }
                    else
                    {
                        model.BMIScore = "";
                        model.BMILevel = "";

                    }
                }

                /***************肺活量*****************/
                int studentPulmonaryLength = excelRow[5].ToString().Trim().Length;

                if (studentPulmonaryLength <= 100)
                {

                    if (CommonHelper.IsInt(excelRow[5].ToString().Trim()))
                    {
                        model.Pulmonary = excelRow[5].ToString().Trim();
                    }
                    else if (excelRow[5].ToString().Trim() == "")
                    {
                        model.Pulmonary = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "肺活量格式不正确),添加失败<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }

                if (flg)
                {
                    if (model.Pulmonary != "")
                    {
                        model.PulmonaryScore = MarkHelper.PulmonaryScore(Convert.ToInt32(model.Pulmonary), studentModel.StudentSex, studentModel.GradeCode);
                        model.PulmonaryLevel = MarkHelper.Level(Convert.ToInt32(model.PulmonaryScore));
                    }
                    else
                    {
                        model.PulmonaryScore = "";
                        model.PulmonaryLevel = "";
                    }
                }

                /**************50米跑**********/
                int studentFiftyRunLength = excelRow[6].ToString().Trim().Length;
                if (studentFiftyRunLength > 0 & studentFiftyRunLength <= 100)
                {
                    if (CommonHelper.IsInt(excelRow[6].ToString().Trim()))
                    {
                        model.FiftyRun = excelRow[6].ToString().Trim();
                        if (studentFiftyRunLength == 1)
                        {
                            model.FiftyRun = model.FiftyRun + "." + "0";
                        }
                        else
                        {
                            model.FiftyRun = model.FiftyRun.Substring(0, studentFiftyRunLength - 1) + "." + model.FiftyRun.Substring(studentFiftyRunLength - 1, 1);
                        }
                       
                    }
                    else if (excelRow[6].ToString().Trim() == "")
                    {
                        model.FiftyRun = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "50米跑格式不正确),添加失败<br/>";
                        flg = false;
                    }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }
                if (flg)
                {
                    if (model.FiftyRun != "")
                    {
                        model.FiftyRunScore = MarkHelper.FiftyRunScore(Convert.ToDouble(model.FiftyRun), studentModel.StudentSex, studentModel.GradeCode);
                        model.FiftyRunLevel = MarkHelper.Level(Convert.ToInt32(model.FiftyRunScore));
                    }
                    else
                    {
                        model.FiftyRunScore = "";
                        model.FiftyRunLevel = "";
                    }
                }

                /**************立定跳远**********/
                int studentStandJumpLength = excelRow[7].ToString().Trim().Length;
                if (studentStandJumpLength <= 100)
                {
                    if (CommonHelper.IsInt(excelRow[7].ToString().Trim()))
                    {
                        model.StandJump = excelRow[7].ToString().Trim();
                    }
                    else if (excelRow[7].ToString().Trim() == "")
                    {
                        model.StandJump = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "立定跳远格式不正确),添加失败<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }
                if (flg)
                {
                    if (model.StandJump != "")
                    {
                        model.StandJumpScore = MarkHelper.StandJumpScore(Convert.ToInt32(model.StandJump), studentModel.StudentSex, studentModel.GradeCode);
                        model.StandJumpLevel = MarkHelper.Level(Convert.ToInt32(model.StandJumpScore));
                    }
                    else
                    {
                        model.StandJumpScore = "";
                        model.StandJumpLevel = "";
                    }
                }
                /**************座位体前屈**********/
                int studentSitAndReachLength = excelRow[8].ToString().Trim().Length;
                if (studentSitAndReachLength <= 100)
                {
                    if (CommonHelper.IsInt(excelRow[8].ToString().Trim()))
                    {
                        model.SitAndReach = excelRow[8].ToString().Trim();
                        if (studentSitAndReachLength == 1)
                        {
                            model.SitAndReach = model.SitAndReach + "." + "0";
                        }
                        
                        else
                        {
                            model.SitAndReach = model.SitAndReach.Substring(0, studentSitAndReachLength - 1) + "." + model.SitAndReach.Substring(studentSitAndReachLength - 1, 1);
                        }
                    }
                    else if (excelRow[8].ToString().Trim() == "")
                    {
                        model.SitAndReach = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "座位体前屈格式不正确),添加失败<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }
                if (flg)
                {
                    if (model.SitAndReach != "")
                    {
                        model.SitAndReachScore = MarkHelper.SitAndReachScore(Convert.ToDouble(model.SitAndReach), studentModel.StudentSex, studentModel.GradeCode);
                        model.SitAndReachLevel = MarkHelper.Level(Convert.ToInt32(model.SitAndReachScore));
                    }
                    else
                    {
                        model.SitAndReachScore = "";
                        model.SitAndReachLevel = "";
                    }
                }

                /**************800米跑**********/
                int studentEightHundredLength = excelRow[9].ToString().Trim().Length;
                if (studentEightHundredLength <= 100)
                {

                    if (CommonHelper.IsInt(excelRow[9].ToString().Trim()))
                    {
                        model.EightHundred = excelRow[9].ToString().Trim();
                    }
                    else if (excelRow[9].ToString().Trim() == "")
                    {
                        model.EightHundred = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "800米格式不正确),添加失败<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }

                int eightHundredAddScore = 0;
                if (flg)
                {
                    if (model.EightHundred != "")
                    {
                        model.EightHundredScore = MarkHelper.EightHundredScore(Convert.ToInt32(model.EightHundred), studentModel.StudentSex, studentModel.GradeCode);
                        model.EightHundredLevel = MarkHelper.Level(Convert.ToInt32(model.EightHundredScore));
                        eightHundredAddScore = Convert.ToInt32(model.EightHundredScore) > 100 ? Convert.ToInt32(model.EightHundredScore) - 100 : 0;
                        model.EightHundredAddScore = eightHundredAddScore.ToString();
                    }
                    else
                    {
                        model.EightHundredScore = "";
                        model.EightHundredLevel = "";
                        model.EightHundredAddScore = "";
                    }
                }

                /**************1000米**********/
                int studentNativeLength = excelRow[10].ToString().Trim().Length;
                if (studentNativeLength <= 100)
                {

                    if (CommonHelper.IsInt(excelRow[10].ToString().Trim()))
                    {
                        model.ThousandRun = excelRow[10].ToString().Trim();
                    }
                    else if (excelRow[10].ToString().Trim() == "")
                    {
                        model.ThousandRun = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "1000米格式不正确),添加失败<br/>";
                        flg = false;
                    }


                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }


                int thousandRunAddScore = 0;
                if (flg)
                {
                    if (model.ThousandRun != "")
                    {
                        model.ThousandRunScore = MarkHelper.ThousandRunScore(Convert.ToInt32(model.ThousandRun), studentModel.StudentSex, studentModel.GradeCode);
                        model.ThousandRunLevel = MarkHelper.Level(Convert.ToInt32(model.ThousandRunScore));
                        thousandRunAddScore = Convert.ToInt32(model.ThousandRunAddScore) > 100 ? Convert.ToInt32(model.ThousandRunAddScore) - 100 : 0;
                        model.ThousandRunAddScore = thousandRunAddScore.ToString();
                    }
                    else
                    {
                        model.ThousandRunScore = "";
                        model.ThousandRunLevel = "";
                        model.ThousandRunAddScore = "";
                    }
                }

                /**************一分钟仰卧起坐**********/
                int studentMinSupinationLength = excelRow[11].ToString().Trim().Length;
                if (studentMinSupinationLength <= 100)
                {
                    if (CommonHelper.IsInt(excelRow[11].ToString().Trim()))
                    {
                        model.MinSupination = excelRow[11].ToString().Trim();
                    }
                    else if (excelRow[11].ToString().Trim() == "")
                    {
                        model.MinSupination = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "1000米格式不正确),添加失败<br/>";
                        flg = false;
                    }


                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }

                int minSupinationAddScore = 0;
                if (flg)
                {
                    if (model.MinSupination != "")
                    {
                        model.MinSupinationScore = MarkHelper.MinSupinationScore(Convert.ToInt32(model.MinSupination), studentModel.StudentSex, studentModel.GradeCode);
                        model.MinSupinationLevel = MarkHelper.Level(Convert.ToInt32(model.MinSupinationScore));
                        minSupinationAddScore = Convert.ToInt32(model.MinSupinationAddScore) > 100 ? Convert.ToInt32(model.MinSupinationAddScore) - 100 : 0;
                        model.MinSupinationAddScore = minSupinationAddScore.ToString();
                    }
                    else
                    {
                        model.MinSupinationScore = "";
                        model.MinSupinationLevel = "";
                        model.MinSupinationAddScore = "";
                    }
                }


                /**************引体向上**********/
                int studenPullUpLength = excelRow[12].ToString().Trim().Length;
                if (studenPullUpLength <= 100)
                {
                    if (CommonHelper.IsInt(excelRow[12].ToString().Trim()))
                    {
                        model.PullUp = excelRow[12].ToString().Trim();
                    }
                    else if (excelRow[12].ToString().Trim() == "")
                    {
                        model.PullUp = "";
                    }
                    else
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "1000米格式不正确),添加失败<br/>";
                        flg = false;
                    }


                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "长度超过100个字符),添加失败<br/>";
                    flg = false;
                }
                int pullUpAddScore = 0;
                if (flg)
                {
                    if (model.PullUp != "")
                    {
                        model.PullUpScore = MarkHelper.PullUpScore(Convert.ToInt32(model.PullUp), studentModel.StudentSex, studentModel.GradeCode);
                        model.PullUpLevel = MarkHelper.Level(Convert.ToInt32(model.PullUpScore));
                        pullUpAddScore = Convert.ToInt32(model.PullUpAddScore) > 100 ? Convert.ToInt32(model.PullUpAddScore) - 100 : 0;
                        model.PullUpAddScore = pullUpAddScore.ToString();
                    }
                    else
                    {
                        model.PullUpScore = "";
                        model.PullUpLevel = "";
                        model.PullUpAddScore = "";
                    }
                }


                double trueTest = 0;
                if (studentModel.StudentSex == "1")
                {
                    trueTest = Convert.ToInt32(model.BMIScore = model.BMIScore == "" ? "0" : model.BMIScore) * 0.15
                        + Convert.ToInt32(model.PulmonaryScore == "" ? "0" : model.PulmonaryScore) * 0.15
                        + Convert.ToInt32(model.FiftyRunScore == "" ? "0" : model.FiftyRunScore) * 0.2
                        + Convert.ToInt32(model.StandJumpScore == "" ? "0" : model.StandJumpScore) * 0.1
                        + Convert.ToInt32(model.SitAndReachScore == "" ? "0" : model.SitAndReachScore) * 0.1
                        + (Convert.ToInt32(model.ThousandRunScore == "" ? "0" : model.ThousandRunScore) > 100 ? 100 : Convert.ToInt32(model.ThousandRunScore == "" ? "0" : model.ThousandRunScore)) * 0.2
                        + (Convert.ToInt32(model.PullUpScore == "" ? "0" : model.PullUpScore) > 100 ? 100 : Convert.ToInt32(model.PullUpScore == "" ? "0" : model.PullUpScore)) * 0.1
                        + thousandRunAddScore + pullUpAddScore;
                    model.StudentTrueScore = trueTest.ToString();
                }
                if (studentModel.StudentSex == "2")
                {
                    trueTest = Convert.ToInt32(model.BMIScore = model.BMIScore == "" ? "0" : model.BMIScore) * 0.15
                        + Convert.ToInt32(model.PulmonaryScore == "" ? "0" : model.PulmonaryScore) * 0.15
                        + Convert.ToInt32(model.FiftyRunScore == "" ? "0" : model.FiftyRunScore) * 0.2
                        + Convert.ToInt32(model.StandJumpScore == "" ? "0" : model.StandJumpScore) * 0.1
                        + Convert.ToInt32(model.SitAndReachScore == "" ? "0" : model.SitAndReachScore) * 0.1
                        + (Convert.ToInt32(model.EightHundredScore == "" ? "0" : model.EightHundredScore) > 100 ? 100 : Convert.ToInt32(model.EightHundredScore == "" ? "0" : model.EightHundredScore)) * 0.2
                        + (Convert.ToInt32(model.MinSupinationScore == "" ? "0" : model.MinSupinationScore) > 100 ? 100 : Convert.ToInt32(model.MinSupinationScore == "" ? "0" : model.MinSupinationScore)) * 0.1
                        + eightHundredAddScore + minSupinationAddScore;
                    model.StudentTrueScore = trueTest.ToString();
                }
                if (trueTest < 60)
                {
                    model.TestResult = "补测";
                }
                else
                {
                    model.TestResult = "通过";
                }
                model.UpdateTime = System.DateTime.Now.ToString();

            }

            catch (Exception ex)
            {
                if (flg)
                    errorcount++;
                errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",添加失败;失败原因:" + ex.Message + "<br/>";
                flg = false;
            }
        }



        //返回一个下载路径
        [LoginAuthorize]
        public FileResult GetExcelFile()
        {
            FilePathResult file=   new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/学生体测成绩导入模版.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "学生体测成绩导入模版.xlsx";
            return file;
        }

        #endregion
    }
}