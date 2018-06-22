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
    /// ѧ���ɼ����Ա�����ݽ���������
    /// </summary>
    public class DStudentTestScoreController : PublicController<DStudent_TestScore>
    {
        DStudent_TestScoreBll sTestScoreBll = new DStudent_TestScoreBll();
        DStudent_InfosBll bStudentsBll = new DStudent_InfosBll();

        /// <summary>
        /// ��ȡѧ����Ϣ
        /// </summary>
        /// <param name="keyvalue">�ؼ���</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns>json����</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }


        //�޸ı༭
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
                    testScoreModel.TestResult = "����";
                }
                else
                {
                    testScoreModel.TestResult = "ͨ��";
                }
                testScoreModel.UpdateTime = System.DateTime.Now.ToString();

                int IsOk = sTestScoreBll.UpdDStudentTestScore(testScoreModel, gradecode, CookieHelper.GetCookie("NK"));
                if (IsOk > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "�޸ĳɹ���" }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "�޸�ʧ�ܡ�" }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        #region ����������ť

        /// <summary>
        /// ��ȡѧ�������Ϣ
        /// </summary>
        /// <param name="studentcode">ѧ��ѧ��</param>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ��ȡѧ��������Ϣ�ķ���
        /// </summary>
        /// <param name="studentcode">ѧ��ѧ��</param>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //ɾ��ѧ��������Ϣ

       
        public ActionResult DelDStudentTestScore(string KeyValue)
        {
            try
            {
                string Message = "ɾ���ɹ���";
                if (bStudentsBll.CheckStudentInfoRepeat(KeyValue, CookieHelper.GetCookie("NK")) > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = "0", Message = "ѧ��������Ϣ�Ѵ��ڣ�����ɾ��ѧ��������Ϣ��" }.ToString());
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Delete, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //���Ϊ���
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //���Ϊ����
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //ȡ������
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
                        testResult = "����";
                    }
                    if (Convert.ToSingle(model.StudentTrueScore) >= 60)
                    {
                        testResult = "ͨ��";
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        #endregion

        #region ����ɼ��÷�

        /// <summary>
        /// �������Ϸ�������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="pullup">��������</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>       
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
        /// һ��������������������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="minsupination">һ������������</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>      
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
        /// 1000�׷�������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="thousandrun">1000��</param>
        /// <param name="studentsex">ѧ���Ա�</param>
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
        /// 800�׷�������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="eighthundred">800��</param>
        /// <param name="studentsex">ѧ���Ա�</param>
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
        /// ��λ��ǰ����������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="sitandreach">��λ��ǰ��</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>       
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
        /// �λ�����������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="pulmonary">�λ���</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>      
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
        /// ������Զ��������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="standjump">������Զ</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>    
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
        /// 50���ܷ�������
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="fiftyrun">50����</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>       
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
        /// ����ָ����������
        /// </summary>
        /// <param name="heigh">���</param>
        /// <param name="weight">����</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <returns>json����</returns>       
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


        #region ����

        //����ѧ�������Ϣ��ѡȡ��óɼ���Ϊѧ���ɼ�
        //������ͼ
       
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
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }


        //���빦��ʵ��ȡѧ����óɼ�
        [LoginAuthorize]
        public JsonResult ImportExcelStudentTestBest()
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

            string returnMsg = AddExcelDataBest(xmlDate, CookieHelper.GetCookie("NK"));

            #endregion

            return Json(new { Msg = returnMsg });
        }

        //�����͵��룬ԭ�ɼ����ϣ������Ϊ���³ɼ�
        [LoginAuthorize]
        public JsonResult ImportExcelStudentTestRep()
        {
            string filePath = "";

            //�ļ���С��Ϊ0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //������Լ����ļ�ȫ·��,newfile�������ϴ��󱣴���ļ�,
            //�������ϵ�UpLoadFile�ļ��б����ж�дȨ�ޡ�
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region ���������ϵ�excel���ݵ��������ݼ�,������

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelDataRep(xmlDate, CookieHelper.GetCookie("NK"));

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
        private string AddExcelDataRep(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//����ĸ���
            int sumcount = xmlDate.Rows.Count;//�������ݵ��ܸ���
            int rowindex = 1;//�б�
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
                        //������Ϣ���صĽ��
                        result = sTestScoreBll.UpdDStudentTestScore(model, studentModel.GradeCode, CookieHelper.GetCookie("NK"));

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

        /// <summary>
        /// ���Excel������
        /// </summary>
        /// <param name="xmlDate"></param>
        private string AddExcelDataBest(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//����ĸ���
            int sumcount = xmlDate.Rows.Count;//�������ݵ��ܸ���
            int rowindex = 1;//�б�
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
                        model.TestResult = "����";
                    }
                    else
                    {
                        model.TestResult = "ͨ��";
                    }
                    model.UpdateTime = System.DateTime.Now.ToString();
                }
                if (flg)
                {
                    int result = 1;
                    try
                    {
                        //������Ϣ���صĽ��
                        result = sTestScoreBll.UpdDStudentTestScore(model, studentModel.GradeCode, CookieHelper.GetCookie("NK"));

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

        //����
        private void RepNewMethod(string NK, ref string errorMsg, ref int errorcount, ref int rowindex, ref string comname, DataRow excelRow, DStudent_TestScore model, out DStudent_Infos studentModel, out bool flg)
        {
            studentModel = bStudentsBll.GetDStudentInfosModel(excelRow[0].ToString().Trim(), NK);
            flg = true;
            rowindex++;
            try
            {
                model.StudentCode = excelRow[0].ToString().Trim();

                /**************ѧ��ѧ��**********/
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
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ��,���߳��ȳ���100���ַ�),���ʧ��<br/>";
                    flg = false;
                }
                if (flg)
                {

                    if (studentModel.StudentCode==null)
                    {
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "�������û�и�ѧ��,������Ӹ�ѧ��������Ϣ,���ʧ��<br/>";
                        flg = false;
                    }
                }
                /**************ѧ������**********/
                int studentNameLength = excelRow[1].ToString().Trim().Length;
                if (studentNameLength > 0 & studentNameLength <= 100)
                {
                    model.StudentName = excelRow[1].ToString().Trim();
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ��,���߳��ȳ���100���ַ�),���ʧ��<br/>";
                    flg = false;
                }

                /***************ѧ���Ա�*****************/
                int studentSexLength = excelRow[2].ToString().Trim().Length;

                if (studentSexLength > 0 & studentSexLength <= 100)
                {

                    if (excelRow[2].ToString().Trim() != "1" && excelRow[2].ToString().Trim() != "2")
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "�Ա��ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }
                    else
                    { model.StudentSex = excelRow[2].ToString().Trim(); }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ�ջ��߳��ȳ���100���ַ�),���ʧ��<br/>";
                    flg = false;
                }


                /***************ѧ�����*****************/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "��߸�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                    flg = false;
                }


                /***************ѧ������*****************/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ظ�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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

                /***************�λ���*****************/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "�λ�����ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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

                /**************50����**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "50���ܸ�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }
                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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

                /**************������Զ**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "������Զ��ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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
                /**************��λ��ǰ��**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "��λ��ǰ����ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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

                /**************800����**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "800�׸�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }

                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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

                /**************1000��**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "1000�׸�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }


                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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

                /**************һ������������**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "1000�׸�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }


                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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


                /**************��������**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "1000�׸�ʽ����ȷ),���ʧ��<br/>";
                        flg = false;
                    }


                }
                else
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
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
                    model.TestResult = "����";
                }
                else
                {
                    model.TestResult = "ͨ��";
                }
                model.UpdateTime = System.DateTime.Now.ToString();

            }

            catch (Exception ex)
            {
                if (flg)
                    errorcount++;
                errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",���ʧ��;ʧ��ԭ��:" + ex.Message + "<br/>";
                flg = false;
            }
        }



        //����һ������·��
        [LoginAuthorize]
        public FileResult GetExcelFile()
        {
            FilePathResult file=   new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/ѧ�����ɼ�����ģ��.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "ѧ�����ɼ�����ģ��.xlsx";
            return file;
        }

        #endregion
    }
}