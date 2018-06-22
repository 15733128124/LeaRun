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
    /// ѧ��������Ϣ������ݽ���������
    /// </summary>
    public class DStudentInfosController : PublicController<DStudent_Infos>
    {
        DStudent_InfosBll sInfosBll = new DStudent_InfosBll();
        DStudent_TestScoreBll sTestScoreBll = new DStudent_TestScoreBll();
        DStudent_ClassBll sClssBll = new DStudent_ClassBll();
        DBase_NationsBll bNationBll = new DBase_NationsBll();
        DBase_UsersBll bUsersBll = new DBase_UsersBll();
        DBase_CitiesBll bCityBll = new DBase_CitiesBll();

        #region ѧ������json
        /// <summary>
        /// ѧ������json
        /// </summary>
        /// <returns></returns>
        //public ActionResult TreeJson()
        //{


        //    List<TreeJsonEntity> TreeList = new List<TreeJsonEntity>();
        //    TreeJsonEntity tree = new TreeJsonEntity();
        //    tree.id = "1";
        //    tree.text = "��׳���";
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
        //    tree1.text = "ѧ����Ϣ";
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
        //    tree2.text = "������Ϣ";
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
        //    tree3.text = "�����Ϣ";
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
        //    tree4.text = "���ݶԱ�";
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
        //    tree5.text = "�ɼ���Ϣ";
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

        #region ѧ����������
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ��Ϣ����Json
        /// </summary>
        /// <param name="valueKey">�ؼ���</param>
        /// <param name="jqgridparam">�������</param>
        /// <returns>Json����</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ���ѧ����Ϣ
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="schoolcode">ѧԺ���</param>
        /// <param name="schoolname">ѧԺ����</param>
        /// <param name="classcode">�༶���</param>
        /// <param name="classname">�༶����</param>
        /// <param name="studentcode">ѧ��ѧ��</param>
        /// <param name="studentname">ѧ������</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <param name="studentborndate">ѧ����������</param>
        /// <param name="studenthomeaddress">ѧ����ͥסַ</param>
        /// <param name="nationname">��������</param>
        /// <param name="nationcode">������</param>
        /// <param name="studentnative">ѧ������</param>
        /// <param name="studentmovetype">ѧ���춯����</param>
        /// <param name="studentidnumber">ѧ�����֤��</param>
        /// <param name="studentphone">ѧ���绰</param>
        /// <param name="studentisregister">�Ƿ�ע��</param>
        /// <returns></returns>
       
        public ActionResult AddDStudentInfo(string gradecode, string schoolcode, string schoolname, string classcode, string classname, string studentcode, string studentname,
           string studentsex, string studentborndate, string studenthomeaddress, string nationname, string nationcode, string studentnative, string studentmovetype, string studentidnumber, string studentphone,
            string studentisregister)
        {
            try
            {
                string Message = "��ӳɹ�";
                int IsOk = 0;
                if (sInfosBll.CheckStudentInfoRepeat(studentcode, CookieHelper.GetCookie("NK")) > 0)
                {
                    Message = "���ݿ��и�ѧ���Ѵ��ڣ�";
                    return Content(new JsonMessage { Success = false, Code = IsOk.ToString(), Message = Message }.ToString());
                }
                else
                {
                    #region ʵ����ѧ����Ϣʵ����
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
                            #region ʵ����ѧ���ɼ�ʵ����
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
                                TestType = "��������",
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Add, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// �޸�ѧ����Ϣ
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="schoolcode">ѧԺ���</param>
        /// <param name="schoolname">ѧԺ����</param>
        /// <param name="classcode">�༶���</param>
        /// <param name="classname">�༶����</param>
        /// <param name="studentcode">ѧ�����</param>
        /// <param name="studentname">ѧ������</param>
        /// <param name="studentsex">ѧ���Ա�</param>
        /// <param name="studentborndate">ѧ����������</param>
        /// <param name="studenthomeaddress">ѧ����ͥסַ</param>
        /// <param name="nationname">��������</param>
        /// <param name="nationcode">������</param>
        /// <param name="studentnative">ѧ������</param>
        /// <param name="studentmovetype">�춯����</param>
        /// <param name="studentidnumber">���֤��</param>
        /// <param name="studentphone">ѧ���绰</param>
        /// <param name="studentisregister">�Ƿ�ע��</param>
        /// <param name="keyvalue">�ؼ���</param>
        /// <returns></returns>
       
        public ActionResult UpdDStudentInfo(string gradecode, string schoolcode, string schoolname, string classcode, string classname, string studentcode, string studentname,
          string studentsex, string studentborndate, string studenthomeaddress, string nationname, string nationcode, string studentnative, string studentmovetype, string studentidnumber, string studentphone,
           string studentisregister, string keyvalue)
        {
            try
            {
                string Message = "�޸ĳɹ�";
                int IsOk = 0;

                #region ʵ����ѧ����Ϣʵ����
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
                        #region ʵ����ѧ���ɼ�ʵ����
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
                            TestResult = "δ��",
                            StudentTrueScore = "",
                            TestType = "��������",
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
                        //��������е�ѧ���Ա𣬺ͻ��������Ա���ͬ���޸��Ա��޸ĳɼ�
                        if (testScoreModel.StudentSex != studentsex)
                        {

                            //�޸��Ա�
                            if (sTestScoreBll.UpdDStudentTestScoreSex(studentcode, studentsex, CookieHelper.GetCookie("NK")) > 0)
                            {
                               
                                //����ѧ���ɼ����Ա�ͬ���ɼ��㷨��ͬ
                                int n = UpdateStudentScore(testScoreModel.StudentName, studentsex, gradecode, heigh, weight, pulmonary, fiftyrun,
                      standjump, sitandreach, thousandrun, eighthundred, pullup, minsupination, testScoreModel.StudentCode);
                                if (n <= 0)
                                    flg = false;
                            }

                        }
                        else
                        {
                            //����ѧ���ɼ�
                            int n = UpdateStudentScore(testScoreModel.StudentName, studentsex, gradecode, heigh, weight, pulmonary, fiftyrun,
                    standjump, sitandreach, eighthundred, thousandrun, minsupination, pullup, testScoreModel.StudentCode);
                            if (n <= 0)
                                flg = false;
                        }
                    }
                    if (flg)
                        return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
                    else
                        return Content(new JsonMessage { Success = false, Code = IsOk.ToString(), Message = "�޸�ʧ�ܣ�δ֪����" }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = false, Code = IsOk.ToString(), Message = "�޸�ʧ�ܣ�δ֪����" }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        //�޸ĳɼ�
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
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Update, "-1", "�쳣����" + ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// ��ȡѧԺ����
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <returns>json����</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ��ȡ�༶����
        /// </summary>
        /// <param name="schoolcode">ѧԺ���</param>
        /// <returns>json����</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns>json����</returns>
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
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ��ȡѧ��Model
        /// </summary>
        /// <param name="studencode">ѧ��ѧ��</param>
        /// <returns>json����</returns>       
        public ActionResult GetDStudentInfosModel(string studentcode)
        {

            try
            {
                DStudent_Infos model = sInfosBll.GetDStudentInfosModel(studentcode, CookieHelper.GetCookie("NK"));
                return Content(model.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// ɾ��ѧ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DelDStudentInfos(int KeyValue)
        {
            try
            {
                string Message = "ɾ���ɹ���";
                int IsOk = 0;
                IsOk = sInfosBll.DelDStudentInfos(KeyValue, CookieHelper.GetCookie("NK"));

                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPassword()
        {
            ViewBag.Account = Request["Account"];
            return View();
        }


        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="KeyValue">����</param>
        /// <param name="Password">������</param>
        /// <returns></returns>
        public ActionResult ResetPasswordSubmit(string KeyValue, string Password)
        {
            try
            {
                int IsOk = 0;
                IsOk = bUsersBll.UpdDBase_UsersPwd(KeyValue, DESEncrypt.Encrypt(Password));
                if (IsOk > 0)
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "�����޸ĳɹ���" }.ToString());
                }
                else
                {
                    return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "�����޸�ʧ�ܡ�" }.ToString());
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog(KeyValue, OperationType.Update, "-1", "�����޸�ʧ�ܣ�" + ex.Message);
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "�����޸�ʧ�ܣ�" + ex.Message }.ToString());
            }
        }

        #endregion

        #region ѧ��������Ϣ�������

        //���ѧ��������Ϣ
        [LoginAuthorize]
        public JsonResult DelAllStudentInfos()
        {
            Base_SysLogBll.Instance.WriteLog("System", OperationType.Delete, "-1", "������ݿ⡣");
            return Json(new { IsOk = sInfosBll.DelStudentInfoAll(CookieHelper.GetCookie("NK")) > 0 ? true : false });
        }


        //������ͼ
       
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
                return Content("<div style=\"color:red;font-size:50px;text-align:center;margin-top:5%\">��û��ѡ����⣡��ѡ����⣡</div>", "text/html");
            }
        }

        //���빦��ʵ��
        [LoginAuthorize]
        public JsonResult ImportExcelStudentInfos()
        {
            string filePath = "";

            //�ļ���С��Ϊ0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //������Լ����ļ�ȫ·��,newfile�������ϴ��󱣴���ļ�,
            //�������ϵ�UpLoadFile�ļ��б����ж�дȨ�ޡ�
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region ���������ϵ�excel���ݵ��������ݼ�,������

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelData(xmlDate, CookieHelper.GetCookie("NK"));

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
        private string AddExcelData(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//����ĸ���
            int sumcount = xmlDate.Rows.Count;//�������ݵ��ܸ���
            int rowindex = 1;//�б�
            string comname = string.Empty;
            int i = 1;
            foreach (DataRow excelRow in xmlDate.Rows)
            {
                DStudent_Infos model = new DStudent_Infos();
                bool flg = true;//��������ı�ʶ
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
                        model.StudentSex = excelRow[2].ToString().Trim() == "��" ? "1" : "2";
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ�ջ��߳��ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }


                    /***************ѧ��ѧԺ*****************/
                    int schoolNameLength = excelRow[3].ToString().Trim().Length;

                    if (schoolNameLength > 0 & schoolNameLength <= 100)
                    {

                        model.SchoolName = excelRow[3].ToString().Trim();


                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ�ջ��߳��ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }


                    /***************ѧ����������*****************/
                    int studentBornDateLength = excelRow[4].ToString().Trim().Length;
                    if (studentBornDateLength <= 100)
                    {
                        try
                        {
                            //������ת�����ض���ʽ
                            model.StudentBornDate = Convert.ToDateTime(excelRow[4].ToString().Trim()).ToString("yyyy-MM-dd");

                        }
                        catch
                        {
                            model.StudentBornDate = CommonHelper.DataTimeChange(excelRow[4].ToString().Trim());
                            //lbMesg.Items.Add(ErrorMsgTitle(rowindex, comname) + "�������ڸ�ʽ����ȱ���ʧ��\r\n");
                        }
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /***************��ͥסַ*****************/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************������**********/
                    int classNameLength = excelRow[6].ToString().Trim().Length;
                    if (classNameLength > 0 & classNameLength <= 100)
                    {
                        model.ClassName = excelRow[6].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ��,���߳��ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************����**********/
                    int nationNameLength = excelRow[7].ToString().Trim().Length;
                    if (nationNameLength <= 100)
                    {
                        model.NationName = excelRow[7].ToString().Trim();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************���֤��**********/
                    int studentIDNumberLength = excelRow[8].ToString().Trim().Length;
                    if (studentIDNumberLength <= 100)
                    {
                        model.StudentIDNumber = excelRow[8].ToString().Trim().ToUpper();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************�绰��**********/
                    int studentPhoneLength = excelRow[9].ToString().Trim().Length;
                    if (studentPhoneLength <= 100)
                    {
                        model.StudentPhone = excelRow[9].ToString().Trim();

                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************����**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************�춯����**********/
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
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }

                    /**************�Ƿ�ע��**********/
                    int studentIsRegisterLength = excelRow[12].ToString().Trim().Length;
                    if (studentIsRegisterLength > 0 & studentIsRegisterLength <= 100)
                    {
                        model.StudentIsRegister = excelRow[12].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ��,���߳��ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
                    }
                    /**************��ͱ��**********/
                    int studentGradeCodeLength = excelRow[13].ToString().Trim().Length;
                    if (studentGradeCodeLength > 0 & studentGradeCodeLength <= 100)
                    {
                        model.GradeCode = excelRow[13].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "Ϊ��,���߳��ȳ���100���ַ�),���ʧ��<br/>";
                        flg = false;
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
                        result = sInfosBll.AddDStudentImport(model, CookieHelper.GetCookie("NK"));
                        if (result == 1)
                        {
                            bUsersBll.AddDBase_User(model.StudentCode, DESEncrypt.Encrypt("123456"));
                        }
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
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "���ʧ��(ԭ��:���ݿ��������ϵ����Ա)" + "<br/>";
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
            FilePathResult file = new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/ѧ����Ϣ����ģ��.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "ѧ����Ϣ����ģ��.xlsx";
            return file;
        }


        #endregion
    }
}