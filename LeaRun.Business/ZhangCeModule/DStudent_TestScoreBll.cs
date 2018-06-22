//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2017
// Software Developers @ Learun 2017
//=====================================================================================

using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// 学生成绩测试表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:41</date>
    /// </author>
    /// </summary>
    public class DStudent_TestScoreBll : RepositoryFactory<DStudent_TestScore>
    {
        DStudent_FinshSchoolTestBll finshTestBll = new DStudent_FinshSchoolTestBll();


        #region 基本方法
        /// <summary>
        /// 添加学生成绩
        /// </summary>
        /// <param name="model">学生成绩实体类</param>
        /// <param name="NK">年库</param>
        /// <returns>返回行数</returns>
        public int AddDStudentTestScore(DStudent_TestScore model, string gradeCode, string NK)
        {
            DStudent_FinshSchoolTestBll fstBll = new DStudent_FinshSchoolTestBll();
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "INSERT INTO DStudent_TestScore" + NK;
            strSql.Append(insertTable);
            strSql.Append(@"(StudentCode,StudentName,StudentSex,Heigh,Weight,BMI,BMIScore,BMILevel,Pulmonary,PulmonaryScore,PulmonaryLevel,FiftyRun,FiftyRunScore,FiftyRunLevel,StandJump
,StandJumpScore,StandJumpLevel,SitAndReach,SitAndReachScore,SitAndReachLevel,EightHundred,EightHundredScore,EightHundredLevel,EightHundredAddScore,ThousandRun,ThousandRunScore,ThousandRunLevel
,ThousandRunAddScore,MinSupination,MinSupinationScore,MinSupinationLevel,MinSupinationAddScore,PullUp,PullUpScore,PullUpLevel,PullUpAddScore,TestResult,StudentTrueScore,TestType,CreateTime
,UpdateTime,Remark)VALUES(@StudentCode,@StudentName,@StudentSex,@Heigh,@Weight,@BMI,@BMIScore,@BMILevel,@Pulmonary,@PulmonaryScore,@PulmonaryLevel,@FiftyRun,@FiftyRunScore,@FiftyRunLevel
,@StandJump,@StandJumpScore,@StandJumpLevel,@SitAndReach,@SitAndReachScore,@SitAndReachLevel,@EightHundred,@EightHundredScore,@EightHundredLevel,@EightHundredAddScore,@ThousandRun,@ThousandRunScore
,@ThousandRunLevel,@ThousandRunAddScore,@MinSupination,@MinSupinationScore,@MinSupinationLevel,@MinSupinationAddScore,@PullUp,@PullUpScore,@PullUpLevel,@PullUpAddScore,@TestResult,@StudentTrueScore
,@TestType,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@StudentName", model.StudentName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@Heigh", model.Heigh));
            parameter.Add(DbFactory.CreateDbParameter("@Weight", model.Weight));
            parameter.Add(DbFactory.CreateDbParameter("@BMI", model.BMI));
            parameter.Add(DbFactory.CreateDbParameter("@BMIScore", model.BMIScore));
            parameter.Add(DbFactory.CreateDbParameter("@BMILevel", model.BMILevel));
            parameter.Add(DbFactory.CreateDbParameter("@Pulmonary", model.Pulmonary));
            parameter.Add(DbFactory.CreateDbParameter("@PulmonaryScore", model.PulmonaryScore));
            parameter.Add(DbFactory.CreateDbParameter("@PulmonaryLevel", model.PulmonaryLevel));
            parameter.Add(DbFactory.CreateDbParameter("@FiftyRun", model.FiftyRun));
            parameter.Add(DbFactory.CreateDbParameter("@FiftyRunScore", model.FiftyRunScore));
            parameter.Add(DbFactory.CreateDbParameter("@FiftyRunLevel", model.FiftyRunLevel));
            parameter.Add(DbFactory.CreateDbParameter("@StandJump", model.StandJump));
            parameter.Add(DbFactory.CreateDbParameter("@StandJumpScore", model.StandJumpScore));
            parameter.Add(DbFactory.CreateDbParameter("@StandJumpLevel", model.StandJumpLevel));
            parameter.Add(DbFactory.CreateDbParameter("@SitAndReach", model.SitAndReach));
            parameter.Add(DbFactory.CreateDbParameter("@SitAndReachScore", model.SitAndReachScore));
            parameter.Add(DbFactory.CreateDbParameter("@SitAndReachLevel", model.SitAndReachLevel));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundred", model.EightHundred));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundredScore", model.EightHundredScore));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundredLevel", model.EightHundredLevel));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundredAddScore", model.EightHundredAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRun", model.ThousandRun));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRunScore", model.ThousandRunScore));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRunLevel", model.ThousandRunLevel));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRunAddScore", model.ThousandRunAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupination", model.MinSupination));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupinationScore", model.MinSupinationScore));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupinationLevel", model.MinSupinationLevel));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupinationAddScore", model.MinSupinationAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@PullUp", model.PullUp));
            parameter.Add(DbFactory.CreateDbParameter("@PullUpScore", model.PullUpScore));
            parameter.Add(DbFactory.CreateDbParameter("@PullUpLevel", model.PullUpLevel));
            parameter.Add(DbFactory.CreateDbParameter("@PullUpAddScore", model.PullUpAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@TestResult", model.TestResult));
            parameter.Add(DbFactory.CreateDbParameter("@StudentTrueScore", model.StudentTrueScore));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            string bigOne = "", bigTwo = "", bigThree = "", bigFour = "";
            if (gradeCode == "41")
                bigOne = model.StudentTrueScore;
            if (gradeCode == "42")
                bigTwo = model.StudentTrueScore;
            if (gradeCode == "43")
                bigThree = model.StudentTrueScore;
            if (gradeCode == "44")
                bigFour = model.StudentTrueScore;
            int resultInt = Repository().ExecuteBySql(strSql, parameter.ToArray());
            if (resultInt > 0)
            {
                if (fstBll.DStudentFinshSchoolTestCheckReapt(model.StudentCode) > 0)
                {
                    finshTestBll.UpdDStudentFinshSchoolTest(new DStudent_FinshSchoolTest
                    {
                        StudentCode = model.StudentCode,
                        BigOne = bigOne,
                        BigTwo = bigTwo,
                        BigThree = bigThree,
                        BigFour = bigFour,
                        FinshTest = MarkHelper.FinshTest(bigOne, bigTwo, bigThree, bigFour),
                        FinshYear = gradeCode == "44" ? NK : "",
                        UpdateTime = DateTime.Now.ToString(),
                        Remark = ""
                    }, gradeCode);
                    AddDStudentTestScoreLog(model.StudentCode, NK);
                }
                else
                {
                    finshTestBll.AddDStudentFinshSchoolTest(new DStudent_FinshSchoolTest
                    {
                        StudentCode = model.StudentCode,
                        BigOne = bigOne,
                        BigTwo = bigTwo,
                        BigThree = bigThree,
                        BigFour = bigFour,
                        FinshTest = MarkHelper.FinshTest(bigOne, bigTwo, bigThree, bigFour),
                        FinshYear = gradeCode == "44" ? NK : "",
                        CreateTime = DateTime.Now.ToString(),
                        UpdateTime = DateTime.Now.ToString(),
                        Remark = ""
                    });
                    //添加测试记录
                    AddDStudentTestScoreLog(model.StudentCode, NK);
                }
            }
            return resultInt;
        }

        /// <summary>
        /// 添加学生成绩测试记录
        /// </summary>
        /// <param name="studentCode"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int AddDStudentTestScoreLog(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = @"INSERT INTO DStudent_TestScoreLog" + NK + @"(StudentCode,StudentName,StudentSex,Heigh,Weight,BMI,BMIScore,BMILevel,Pulmonary,PulmonaryScore,PulmonaryLevel,FiftyRun,FiftyRunScore,FiftyRunLevel,StandJump
, StandJumpScore, StandJumpLevel, SitAndReach, SitAndReachScore, SitAndReachLevel, EightHundred, EightHundredScore, EightHundredLevel, EightHundredAddScore, ThousandRun, ThousandRunScore, ThousandRunLevel
, ThousandRunAddScore, MinSupination, MinSupinationScore, MinSupinationLevel, MinSupinationAddScore, PullUp, PullUpScore, PullUpLevel, PullUpAddScore, TestResult, StudentTrueScore, TestType, CreateTime
, UpdateTime, Remark)";
            strSql.Append(insertTable);
            strSql.Append(@" SELECT StudentCode,StudentName,StudentSex,Heigh,Weight,BMI,BMIScore,BMILevel,Pulmonary,PulmonaryScore,PulmonaryLevel,FiftyRun,FiftyRunScore,FiftyRunLevel,StandJump
,StandJumpScore,StandJumpLevel,SitAndReach,SitAndReachScore,SitAndReachLevel,EightHundred,EightHundredScore,EightHundredLevel,EightHundredAddScore,ThousandRun,ThousandRunScore,ThousandRunLevel
,ThousandRunAddScore,MinSupination,MinSupinationScore,MinSupinationLevel,MinSupinationAddScore,PullUp,PullUpScore,PullUpLevel,PullUpAddScore,TestResult,StudentTrueScore,TestType,CreateTime
,UpdateTime,Remark from DStudent_TestScore" + NK + " where StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            int resultInt = Repository().ExecuteBySql(strSql, parameter.ToArray());

            return resultInt;
        }
        /// <summary>
        /// 修改学生成绩
        /// </summary>
        /// <param name="model">学生成绩实体类</param>
        /// <param name="NK">年库</param>
        /// <returns>返回行数</returns>
        public int UpdDStudentTestScore(DStudent_TestScore model, string gradeCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "UPDATE DStudent_TestScore" + NK;
            strSql.Append(insertTable);
            strSql.Append(@" SET StudentName=@StudentName, StudentSex=@StudentSex,Heigh=@Heigh,Weight=@Weight,BMI=@BMI,BMIScore=@BMIScore,BMILevel=@BMILevel,Pulmonary=@Pulmonary,PulmonaryScore=@PulmonaryScore,PulmonaryLevel=@PulmonaryLevel,FiftyRun=@FiftyRun,FiftyRunScore=@FiftyRunScore,FiftyRunLevel=@FiftyRunLevel
,StandJump=@StandJump,StandJumpScore=@StandJumpScore,StandJumpLevel=@StandJumpLevel,SitAndReach=@SitAndReach,SitAndReachScore=@SitAndReachScore,SitAndReachLevel=@SitAndReachLevel,EightHundred=@EightHundred,EightHundredScore=@EightHundredScore,EightHundredLevel=@EightHundredLevel,EightHundredAddScore=@EightHundredAddScore,ThousandRun=@ThousandRun,ThousandRunScore=@ThousandRunScore
,ThousandRunLevel=@ThousandRunLevel,ThousandRunAddScore=@ThousandRunAddScore,MinSupination=@MinSupination,MinSupinationScore=@MinSupinationScore,MinSupinationLevel=@MinSupinationLevel,MinSupinationAddScore=@MinSupinationAddScore,PullUp=@PullUp,PullUpScore=@PullUpScore,PullUpLevel=@PullUpLevel,PullUpAddScore=@PullUpAddScore,TestResult=@TestResult,StudentTrueScore=@StudentTrueScore
,UpdateTime=@UpdateTime WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@StudentName", model.StudentName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@Heigh", model.Heigh));
            parameter.Add(DbFactory.CreateDbParameter("@Weight", model.Weight));
            parameter.Add(DbFactory.CreateDbParameter("@BMI", model.BMI));
            parameter.Add(DbFactory.CreateDbParameter("@BMIScore", model.BMIScore));
            parameter.Add(DbFactory.CreateDbParameter("@BMILevel", model.BMILevel));
            parameter.Add(DbFactory.CreateDbParameter("@Pulmonary", model.Pulmonary));
            parameter.Add(DbFactory.CreateDbParameter("@PulmonaryScore", model.PulmonaryScore));
            parameter.Add(DbFactory.CreateDbParameter("@PulmonaryLevel", model.PulmonaryLevel));
            parameter.Add(DbFactory.CreateDbParameter("@FiftyRun", model.FiftyRun));
            parameter.Add(DbFactory.CreateDbParameter("@FiftyRunScore", model.FiftyRunScore));
            parameter.Add(DbFactory.CreateDbParameter("@FiftyRunLevel", model.FiftyRunLevel));
            parameter.Add(DbFactory.CreateDbParameter("@StandJump", model.StandJump));
            parameter.Add(DbFactory.CreateDbParameter("@StandJumpScore", model.StandJumpScore));
            parameter.Add(DbFactory.CreateDbParameter("@StandJumpLevel", model.StandJumpLevel));
            parameter.Add(DbFactory.CreateDbParameter("@SitAndReach", model.SitAndReach));
            parameter.Add(DbFactory.CreateDbParameter("@SitAndReachScore", model.SitAndReachScore));
            parameter.Add(DbFactory.CreateDbParameter("@SitAndReachLevel", model.SitAndReachLevel));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundred", model.EightHundred));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundredScore", model.EightHundredScore));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundredLevel", model.EightHundredLevel));
            parameter.Add(DbFactory.CreateDbParameter("@EightHundredAddScore", model.EightHundredAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRun", model.ThousandRun));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRunScore", model.ThousandRunScore));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRunLevel", model.ThousandRunLevel));
            parameter.Add(DbFactory.CreateDbParameter("@ThousandRunAddScore", model.ThousandRunAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupination", model.MinSupination));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupinationScore", model.MinSupinationScore));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupinationLevel", model.MinSupinationLevel));
            parameter.Add(DbFactory.CreateDbParameter("@MinSupinationAddScore", model.MinSupinationAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@PullUp", model.PullUp));
            parameter.Add(DbFactory.CreateDbParameter("@PullUpScore", model.PullUpScore));
            parameter.Add(DbFactory.CreateDbParameter("@PullUpLevel", model.PullUpLevel));
            parameter.Add(DbFactory.CreateDbParameter("@PullUpAddScore", model.PullUpAddScore));
            parameter.Add(DbFactory.CreateDbParameter("@TestResult", model.TestResult));
            parameter.Add(DbFactory.CreateDbParameter("@StudentTrueScore", model.StudentTrueScore));
            //parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            //parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));

            string bigOne = "", bigTwo = "", bigThree = "", bigFour = "";
            if (gradeCode == "41")
                bigOne = model.StudentTrueScore;
            if (gradeCode == "42")
                bigTwo = model.StudentTrueScore;
            if (gradeCode == "43")
                bigThree = model.StudentTrueScore;
            if (gradeCode == "44")
                bigFour = model.StudentTrueScore;
            int resultInt = Repository().ExecuteBySql(strSql, parameter.ToArray());
            if (resultInt > 0)
            {
                finshTestBll.UpdDStudentFinshSchoolTest(new DStudent_FinshSchoolTest
                {
                    StudentCode = model.StudentCode,
                    BigOne = bigOne,
                    BigTwo = bigTwo,
                    BigThree = bigThree,
                    BigFour = bigFour,
                    FinshTest = MarkHelper.FinshTest(bigOne, bigTwo, bigThree, bigFour),
                    FinshYear = gradeCode == "44" ? NK : "",
                    UpdateTime = DateTime.Now.ToString(),
                    Remark = ""
                }, gradeCode);
                AddDStudentTestScoreLog(model.StudentCode, NK);
            }
            return Repository().ExecuteBySql(strSql, parameter.ToArray());


        }




        /// <summary>
        ///根据学号删除学生成绩信息
        /// </summary>
        /// <param name="studentCode"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int DeleteStudentTestScoreByStudentCode(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("DELETE  DStudent_TestScore" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 检查学生的成绩是否存在
        /// </summary>
        /// <param name="studentCode"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int CheckStudentTestScoreRepeat(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT COUNT(*) FROM  DStudent_TestScore" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取学生成绩信息
        /// </summary>
        /// <param name="keyvalue">关键字</param>
        /// <param name="NK">年库</param>
        /// <param name="jqgridparam">分页参数</param>
        /// <returns>数据集</returns>
        public DataTable GridDStudentTestScoreList(string keyvalue, string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                        --Id,主键
                                d.StudentCode,               --学生学号
                                d.StudentName,               --学生姓名
                                d.StudentSex,                --性别
                                d.Heigh,                     --身高
                                d.Weight,                    --体重
                                d.BMI,                       --体重指数
                                d.BMIScore,                  --体重指数得分
                                d.BMILevel,                  --体重指数级别
                                d.Pulmonary,                 --肺活量
                                d.PulmonaryScore,            --肺活量得分
                                d.PulmonaryLevel,            --肺活量级别
                                d.FiftyRun,                  --50米跑
                                d.FiftyRunScore,             --50米跑得分
                                d.FiftyRunLevel,             --50米跑级别
                                d.StandJump,                 --立定跳远                                
                                d.StandJumpScore,            --立定跳远得分
                                d.StandJumpLevel,            --立定跳远级别
                                d.SitAndReach,               --座位体前屈
                                d.SitAndReachScore,          --座位体前屈得分
                                d.SitAndReachLevel,          --座位体前屈级别
                                d.EightHundred,              --800米
                                d.EightHundredScore,         --800米得分
                                d.EightHundredLevel,         --800米级别
                                d.EightHundredAddScore,      --800米加分
                                d.ThousandRun,               --1000米
                                d.ThousandRunScore,          --1000米得分
                                d.ThousandRunLevel,          --1000米级别
                                d.ThousandRunAddScore,       --1000米加分
                                d.MinSupination,             --1分钟仰卧起坐
                                d.MinSupinationScore,        --1分钟仰卧起坐得分
                                d.MinSupinationLevel,        --1分钟仰卧起坐级别
                                d.MinSupinationAddScore,     --1分钟仰卧起坐加分
                                d.PullUp,                    --引体向上
                                d.PullUpScore,               --引体向上得分
                                d.PullUpLevel,               --引体向上级别
                                d.PullUpAddScore,            --引体向上加分
                                d.TestResult,                --测试结果：补测、正常
                                d.StudentTrueScore,          --学生最后真是成绩
                                d.TestType,                  --测试类型：正常测试、补测测试
                                d.CreateTime,                --创建时间
                                d.UpdateTime,                --更新时间
                                d.Remark                     --备注
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string sqlConditon = " WHERE 1=1";
            strSql.Append(sqlTableName);
            strSql.Append(sqlConditon);
            if (!string.IsNullOrEmpty(keyvalue))
            {
                strSql.Append(@" AND d.StudentCode LIKE @keyvalue");
                parameter.Add(DbFactory.CreateDbParameter("@keyvalue", '%' + keyvalue + '%'));
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }


        /// <summary>
        /// 导出学生上报成绩
        /// </summary>
        /// <param name="NK">年库</param>
        /// <param name="studentSex">性别</param>
        /// <returns></returns>
        public List<StudentScoreExcel> GetDStudentTestScoreListExport(string NK, string studentSex)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT                                
                                i.StudentCode,               --学生学号
                                i.StudentName,               --学生姓名
                                i.StudentSex,                --性别 
                                i.StudentBornDate,           --出生日期
                                i.StudentHomeAddress,        --学生住址
                                i.GradeCode,                 --年级编号
                                i.SchoolName,                --学院名称
                                i.SchoolCode,                --学院编号
                                i.ClassName,                 --班级名称
                                i.ClassCode,                 --班级编号
                                i.NationCode,                --民族编号
                                i.NationName,                --民族名称
                                i.StudentNative,             --学生籍贯
                                i.StudentMoveType,           --异动类型
                                i.StudentIDNumber,           --学生身份证号                                
                                i.StudentPhone,              --学生电话
                                i.StudentIsRegister,         --是否注册
                                d.Heigh,                     --身高
                                d.Weight,                    --体重
                                d.BMI,                       --体重指数
                                d.BMIScore,                  --体重指数得分
                                d.BMILevel,                  --体重指数级别
                                d.Pulmonary,                 --肺活量
                                d.PulmonaryScore,            --肺活量得分
                                d.PulmonaryLevel,            --肺活量级别
                                d.FiftyRun,                  --50米跑
                                d.FiftyRunScore,             --50米跑得分
                                d.FiftyRunLevel,             --50米跑级别
                                d.StandJump,                 --立定跳远                                
                                d.StandJumpScore,            --立定跳远得分
                                d.StandJumpLevel,            --立定跳远级别
                                d.SitAndReach,               --座位体前屈
                                d.SitAndReachScore,          --座位体前屈得分
                                d.SitAndReachLevel,          --座位体前屈级别
                                d.EightHundred,              --800米
                                d.EightHundredScore,         --800米得分
                                d.EightHundredLevel,         --800米级别
                                d.EightHundredAddScore,      --800米加分
                                d.ThousandRun,               --1000米
                                d.ThousandRunScore,          --1000米得分
                                d.ThousandRunLevel,          --1000米级别
                                d.ThousandRunAddScore,       --1000米加分
                                d.MinSupination,             --1分钟仰卧起坐
                                d.MinSupinationScore,        --1分钟仰卧起坐得分
                                d.MinSupinationLevel,        --1分钟仰卧起坐级别
                                d.MinSupinationAddScore,     --1分钟仰卧起坐加分
                                d.PullUp,                    --引体向上
                                d.PullUpScore,               --引体向上得分
                                d.PullUpLevel,               --引体向上级别
                                d.PullUpAddScore,            --引体向上加分
                                d.TestResult,                --测试结果：补测、通过、免测，作弊
                                d.StudentTrueScore,          --学生最后真是成绩
                                d.TestType,                  --测试类型：正常测试、补测测试
                                d.CreateTime,                --创建时间
                                d.UpdateTime,                --更新时间
                                d.Remark                     --备注
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string innerJoinSql = " INNER JOIN DStudent_Infos" + NK + " i ON d.StudentCode=i.StudentCode ";
            string sqlConditon = " WHERE  d.TestResult='通过' and d.StudentSex=@StudentSex";
            strSql.Append(sqlTableName);
            strSql.Append(innerJoinSql);
            strSql.Append(sqlConditon);
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", studentSex));
            List<StudentScoreExcel> list = GetScoreExcelList(strSql, parameter);
            return list;
        }

        //自定义获取数据方法
        private List<StudentScoreExcel> GetScoreExcelList(StringBuilder strSql, List<DbParameter> parameter)
        {
            DataTable dt = Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
            List<StudentScoreExcel> list = new List<StudentScoreExcel>();

            foreach (DataRow row in dt.Rows)
            {

                StudentScoreExcel model = new StudentScoreExcel();
                model.StudentCode = row["StudentCode"].ToString();
                model.StudentName = row["StudentName"].ToString();
                model.StudentSex = row["StudentSex"].ToString();
                model.StudentBornDate = row["StudentBornDate"].ToString();
                model.StudentHomeAddress = row["StudentHomeAddress"].ToString();
                model.GradeCode = row["GradeCode"].ToString();
                model.SchoolName = row["SchoolName"].ToString();
                model.SchoolCode = row["SchoolCode"].ToString();
                model.ClassName = row["ClassName"].ToString();
                model.ClassCode = row["ClassCode"].ToString();
                model.NationCode = row["NationCode"].ToString();
                model.NationName = row["NationName"].ToString();
                model.StudentNative = row["StudentNative"].ToString();
                model.StudentMoveType = row["StudentMoveType"].ToString();
                model.StudentIDNumber = row["StudentIDNumber"].ToString();
                model.StudentPhone = row["StudentPhone"].ToString();
                model.StudentIsRegister = row["StudentIsRegister"].ToString();
                model.Heigh = row["Heigh"].ToString();
                model.Weight = row["Weight"].ToString();
                model.BMI = row["BMI"].ToString();
                model.BMIScore = row["BMIScore"].ToString();
                model.BMILevel = row["BMILevel"].ToString();
                model.Pulmonary = row["Pulmonary"].ToString();
                model.PulmonaryScore = row["PulmonaryScore"].ToString();
                model.PulmonaryLevel = row["PulmonaryLevel"].ToString();
                model.FiftyRun = row["FiftyRun"].ToString();
                model.FiftyRunScore = row["FiftyRunScore"].ToString();
                model.FiftyRunLevel = row["FiftyRunLevel"].ToString();
                model.StandJump = row["StandJump"].ToString();
                model.StandJumpScore = row["StandJumpScore"].ToString();
                model.StandJumpLevel = row["StandJumpLevel"].ToString();
                model.SitAndReach = row["SitAndReach"].ToString();
                model.SitAndReachScore = row["SitAndReachScore"].ToString();
                model.SitAndReachLevel = row["SitAndReachLevel"].ToString();
                //model.EightHundred = row["EightHundred"].ToString();
                model.EightHundredScore = row["EightHundredScore"].ToString();
                model.EightHundredLevel = row["EightHundredLevel"].ToString();
                model.EightHundredAddScore = row["EightHundredAddScore"].ToString();
                //model.ThousandRun = row["ThousandRun"].ToString();
                model.ThousandRunScore = row["ThousandRunScore"].ToString();
                model.ThousandRunLevel = row["ThousandRunLevel"].ToString();
                model.ThousandRunAddScore = row["ThousandRunAddScore"].ToString();
                model.MinSupination = row["MinSupination"].ToString();
                model.MinSupinationScore = row["MinSupinationScore"].ToString();
                model.MinSupinationLevel = row["MinSupinationLevel"].ToString();
                model.MinSupinationAddScore = row["MinSupinationAddScore"].ToString();
                model.PullUp = row["PullUp"].ToString();
                model.PullUpScore = row["PullUpScore"].ToString();
                model.PullUpLevel = row["PullUpLevel"].ToString();
                model.PullUpAddScore = row["PullUpAddScore"].ToString();
                model.TestResult = row["TestResult"].ToString();
                model.StudentTrueScore = row["StudentTrueScore"].ToString();
                model.TestType = row["TestType"].ToString();
                model.CreateTime = row["CreateTime"].ToString();
                model.UpdateTime = row["UpdateTime"].ToString();
                model.Remark = row["Remark"].ToString();
                string e = row["EightHundred"].ToString();
                if (e != "")
                {
                    if (e.ToString().Trim().Length > 2)
                    {
                        e = e.ToString().Trim().Substring(0, e.ToString().Trim().Length - 2) + "'" +
                        e.ToString().Trim().Substring(e.ToString().Trim().Length - 2, 2) + "\"";
                    }
                    if (e.ToString().Trim().Length <= 2)
                    {
                        e = "0'" + e.ToString().Trim() + "\"";
                    }
                }
                model.EightHundred = e;
                string t = row["ThousandRun"].ToString();
                if (t != "")
                {
                    if (t.ToString().Trim().Length > 2)
                    {
                        t = t.ToString().Trim().Substring(0, t.ToString().Trim().Length - 2) + "'" +
                        t.ToString().Trim().Substring(t.ToString().Trim().Length - 2, 2) + "\"";
                    }
                    if (t.ToString().Trim().Length <= 2)
                    {
                        t = "0'" + e.ToString().Trim() + "\"";
                    }
                }
                model.ThousandRun = t;
                list.Add(model);

            }

            return list;
        }

        /// <summary>
        /// 获取学生信息用于自定义导出
        /// </summary>
        /// <param name="NK"></param>
        /// <param name="jqgridparam"></param>
        /// <returns></returns>
        public DataTable StudentOtherAll(string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT   top 1                              
                                i.StudentCode,               --学生学号
                                i.StudentName,               --学生姓名
                                i.StudentSex,                --性别 
                                i.StudentBornDate,           --出生日期
                                i.StudentHomeAddress,        --学生住址
                                i.GradeCode,                 --年级编号
                                i.SchoolName,                --学院名称
                                i.SchoolCode,                --学院编号
                                i.ClassName,                 --班级名称
                                i.ClassCode,                 --班级编号
                                i.NationCode,                --民族编号
                                i.NationName,                --民族名称
                                i.StudentNative,             --学生籍贯
                                i.StudentMoveType,           --异动类型
                                i.StudentIDNumber,           --学生身份证号                                
                                i.StudentPhone,              --学生电话
                                i.StudentIsRegister,         --是否注册
                                d.Heigh,                     --身高
                                d.Weight,                    --体重
                                d.BMI,                       --体重指数
                                d.BMIScore,                  --体重指数得分
                                d.BMILevel,                  --体重指数级别
                                d.Pulmonary,                 --肺活量
                                d.PulmonaryScore,            --肺活量得分
                                d.PulmonaryLevel,            --肺活量级别
                                d.FiftyRun,                  --50米跑
                                d.FiftyRunScore,             --50米跑得分
                                d.FiftyRunLevel,             --50米跑级别
                                d.StandJump,                 --立定跳远                                
                                d.StandJumpScore,            --立定跳远得分
                                d.StandJumpLevel,            --立定跳远级别
                                d.SitAndReach,               --座位体前屈
                                d.SitAndReachScore,          --座位体前屈得分
                                d.SitAndReachLevel,          --座位体前屈级别
                                d.EightHundred,              --800米
                                d.EightHundredScore,         --800米得分
                                d.EightHundredLevel,         --800米级别
                                d.EightHundredAddScore,      --800米加分
                                d.ThousandRun,               --1000米
                                d.ThousandRunScore,          --1000米得分
                                d.ThousandRunLevel,          --1000米级别
                                d.ThousandRunAddScore,       --1000米加分
                                d.MinSupination,             --1分钟仰卧起坐
                                d.MinSupinationScore,        --1分钟仰卧起坐得分
                                d.MinSupinationLevel,        --1分钟仰卧起坐级别
                                d.MinSupinationAddScore,     --1分钟仰卧起坐加分
                                d.PullUp,                    --引体向上
                                d.PullUpScore,               --引体向上得分
                                d.PullUpLevel,               --引体向上级别
                                d.PullUpAddScore,            --引体向上加分
                                d.TestResult,                --测试结果：补测、通过、免测，作弊
                                d.StudentTrueScore,          --学生最后真是成绩
                                d.TestType,                  --测试类型：正常测试、补测测试
                                d.CreateTime,                --创建时间
                                d.UpdateTime,                --更新时间
                                d.Remark                     --备注
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string innerJoinSql = " INNER JOIN DStudent_Infos" + NK + " i ON d.StudentCode=i.StudentCode ";
            strSql.Append(sqlTableName);
            strSql.Append(innerJoinSql);
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// 导出河北学生表
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public List<HeBeiStudents> GetHeBeiStudentInfoExport(string NK)
        {
            List<HeBeiStudents> heBeiList = new List<HeBeiStudents>();
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@c", 11));
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            DataTable dt = Repository().FindTableByProc("Proc_HeBeiStudentTableExport", parameter.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                HeBeiStudents heBeiS = new HeBeiStudents();
                heBeiS.ID = Convert.ToInt32(row["ID"]);
                heBeiS.StudentAddress = row["StudentAddress"].ToString();
                heBeiS.StudentSex = row["StudentSex"].ToString();
                heBeiS.StudentCount = (int)row["StudentCount"];
                heBeiS.Outstanding = row["Outstanding"].ToString().Length > 5 ? Convert.ToSingle(CommonHelper.Round(Convert.ToDouble(row["Outstanding"]), 3)) : Convert.ToSingle(row["Outstanding"]);
                heBeiS.Goodrate = row["Goodrate"].ToString().Length > 5 ? Convert.ToSingle(CommonHelper.Round(Convert.ToDouble(row["Goodrate"]), 3)) : Convert.ToSingle(row["Goodrate"]);
                heBeiS.PassRate = row["PassRate"].ToString().Length > 5 ? Convert.ToSingle(CommonHelper.Round(Convert.ToDouble(row["PassRate"]), 3)) : Convert.ToSingle(row["PassRate"]);
                heBeiS.TotalRate = row["TotalRate"].ToString().Length > 5 ? Convert.ToSingle(CommonHelper.Round(Convert.ToDouble(row["TotalRate"]), 3)) : Convert.ToSingle(row["TotalRate"]);
                heBeiList.Add(heBeiS);
            }

            return heBeiList;
        }

        /// <summary>
        /// 自定义导出学生信息
        /// </summary>
        /// <param name="resultType"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public List<StudentScoreExcel> StudentOtherExport(string resultType, string NK)
        {

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT                                
                                i.StudentCode,               --学生学号
                                i.StudentName,               --学生姓名
                                i.StudentSex,                --性别 
                                i.StudentBornDate,           --出生日期
                                i.StudentHomeAddress,        --学生住址
                                i.GradeCode,                 --年级编号
                                i.SchoolName,                --学院名称
                                i.SchoolCode,                --学院编号
                                i.ClassName,                 --班级名称
                                i.ClassCode,                 --班级编号
                                i.NationCode,                --民族编号
                                i.NationName,                --民族名称
                                i.StudentNative,             --学生籍贯
                                i.StudentMoveType,           --异动类型
                                i.StudentIDNumber,           --学生身份证号                                
                                i.StudentPhone,              --学生电话
                                i.StudentIsRegister,         --是否注册
                                d.Heigh,                     --身高
                                d.Weight,                    --体重
                                d.BMI,                       --体重指数
                                d.BMIScore,                  --体重指数得分
                                d.BMILevel,                  --体重指数级别
                                d.Pulmonary,                 --肺活量
                                d.PulmonaryScore,            --肺活量得分
                                d.PulmonaryLevel,            --肺活量级别
                                d.FiftyRun,                  --50米跑
                                d.FiftyRunScore,             --50米跑得分
                                d.FiftyRunLevel,             --50米跑级别
                                d.StandJump,                 --立定跳远                                
                                d.StandJumpScore,            --立定跳远得分
                                d.StandJumpLevel,            --立定跳远级别
                                d.SitAndReach,               --座位体前屈
                                d.SitAndReachScore,          --座位体前屈得分
                                d.SitAndReachLevel,          --座位体前屈级别
                                d.EightHundred,              --800米
                                d.EightHundredScore,         --800米得分
                                d.EightHundredLevel,         --800米级别
                                d.EightHundredAddScore,      --800米加分
                                d.ThousandRun,               --1000米
                                d.ThousandRunScore,          --1000米得分
                                d.ThousandRunLevel,          --1000米级别
                                d.ThousandRunAddScore,       --1000米加分
                                d.MinSupination,             --1分钟仰卧起坐
                                d.MinSupinationScore,        --1分钟仰卧起坐得分
                                d.MinSupinationLevel,        --1分钟仰卧起坐级别
                                d.MinSupinationAddScore,     --1分钟仰卧起坐加分
                                d.PullUp,                    --引体向上
                                d.PullUpScore,               --引体向上得分
                                d.PullUpLevel,               --引体向上级别
                                d.PullUpAddScore,            --引体向上加分
                                d.TestResult,                --测试结果：补测、通过、免测，作弊
                                d.StudentTrueScore,          --学生最后真是成绩
                                d.TestType,                  --测试类型：正常测试、补测测试
                                d.CreateTime,                --创建时间
                                d.UpdateTime,                --更新时间
                                d.Remark                     --备注
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string innerJoinSql = " INNER JOIN DStudent_Infos" + NK + " i ON d.StudentCode=i.StudentCode ";
            strSql.Append(sqlTableName);
            strSql.Append(innerJoinSql);
            if (resultType == "0")
                strSql.Append(" WHERE 1 = 1");
            if (resultType == "通过")
                strSql.Append(" WHERE d.TestResult='通过'");
            if (resultType == "免测")
                strSql.Append(" WHERE d.TestResult='免测'");
            if (resultType == "作弊")
                strSql.Append(" WHERE d.TestResult='作弊'");
            if (resultType == "4")
                strSql.Append(" WHERE d.TestResult=''");
            if (resultType == "补测")
                strSql.Append(" WHERE 1 = 1");
            DataTable dt = Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
            List<StudentScoreExcel> resultList = new List<StudentScoreExcel>();
            if (resultType != "补测")
            {
                resultList = GetScoreExcelList(strSql, parameter);
            }
            if (resultType == "补测")
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["StudentSex"].ToString() == "1")
                    {
                        if (row["Heigh"].ToString() == "" || row["Weight"].ToString() == "" || row["Pulmonary"].ToString() == "" || row["FiftyRun"].ToString() == "" || row["StandJump"].ToString() == "" || row["SitAndReach"].ToString() == "" || row["ThousandRun"].ToString() == "" || row["PullUp"].ToString() == "")
                        {
                            StudentScoreExcel model = new StudentScoreExcel();
                            model.StudentCode = row["StudentCode"].ToString();
                            model.StudentName = row["StudentName"].ToString();
                            model.StudentSex = row["StudentSex"].ToString();
                            model.StudentBornDate = row["StudentBornDate"].ToString();
                            model.StudentHomeAddress = row["StudentHomeAddress"].ToString();
                            model.GradeCode = row["GradeCode"].ToString();
                            model.SchoolName = row["SchoolName"].ToString();
                            model.SchoolCode = row["SchoolCode"].ToString();
                            model.ClassName = row["ClassName"].ToString();
                            model.ClassCode = row["ClassCode"].ToString();
                            model.NationCode = row["NationCode"].ToString();
                            model.NationName = row["NationName"].ToString();
                            model.StudentNative = row["StudentNative"].ToString();
                            model.StudentMoveType = row["StudentMoveType"].ToString();
                            model.StudentIDNumber = row["StudentIDNumber"].ToString();
                            model.StudentPhone = row["StudentPhone"].ToString();
                            model.StudentIsRegister = row["StudentIsRegister"].ToString();
                            model.Heigh = row["Heigh"].ToString();
                            model.Weight = row["Weight"].ToString();
                            model.BMI = row["BMI"].ToString();
                            model.BMIScore = row["BMIScore"].ToString();
                            model.BMILevel = row["BMILevel"].ToString();
                            model.Pulmonary = row["Pulmonary"].ToString();
                            model.PulmonaryScore = row["PulmonaryScore"].ToString();
                            model.PulmonaryLevel = row["PulmonaryLevel"].ToString();
                            model.FiftyRun = row["FiftyRun"].ToString();
                            model.FiftyRunScore = row["FiftyRunScore"].ToString();
                            model.FiftyRunLevel = row["FiftyRunLevel"].ToString();
                            model.StandJump = row["StandJump"].ToString();
                            model.StandJumpScore = row["StandJumpScore"].ToString();
                            model.StandJumpLevel = row["StandJumpLevel"].ToString();
                            model.SitAndReach = row["SitAndReach"].ToString();
                            model.SitAndReachScore = row["SitAndReachScore"].ToString();
                            model.SitAndReachLevel = row["SitAndReachLevel"].ToString();
                            //model.EightHundred = row["EightHundred"].ToString();
                            model.EightHundredScore = row["EightHundredScore"].ToString();
                            model.EightHundredLevel = row["EightHundredLevel"].ToString();
                            model.EightHundredAddScore = row["EightHundredAddScore"].ToString();
                            //model.ThousandRun = row["ThousandRun"].ToString();
                            model.ThousandRunScore = row["ThousandRunScore"].ToString();
                            model.ThousandRunLevel = row["ThousandRunLevel"].ToString();
                            model.ThousandRunAddScore = row["ThousandRunAddScore"].ToString();
                            model.MinSupination = row["MinSupination"].ToString();
                            model.MinSupinationScore = row["MinSupinationScore"].ToString();
                            model.MinSupinationLevel = row["MinSupinationLevel"].ToString();
                            model.MinSupinationAddScore = row["MinSupinationAddScore"].ToString();
                            model.PullUp = row["PullUp"].ToString();
                            model.PullUpScore = row["PullUpScore"].ToString();
                            model.PullUpLevel = row["PullUpLevel"].ToString();
                            model.PullUpAddScore = row["PullUpAddScore"].ToString();
                            model.TestResult = row["TestResult"].ToString();
                            model.StudentTrueScore = row["StudentTrueScore"].ToString();
                            model.TestType = row["TestType"].ToString();
                            model.CreateTime = row["CreateTime"].ToString();
                            model.UpdateTime = row["UpdateTime"].ToString();
                            model.Remark = row["Remark"].ToString();
                            string e = row["EightHundred"].ToString();
                            if (e != "")
                            {
                                if (e.ToString().Trim().Length > 2)
                                {
                                    e = e.ToString().Trim().Substring(0, e.ToString().Trim().Length - 2) + "'" +
                                    e.ToString().Trim().Substring(e.ToString().Trim().Length - 2, 2) + "\"";
                                }
                                if (e.ToString().Trim().Length <= 2)
                                {
                                    e = "0'" + e.ToString().Trim() + "\"";
                                }
                            }
                            model.EightHundred = e;
                            string t = row["ThousandRun"].ToString();
                            if (t != "")
                            {
                                if (t.ToString().Trim().Length > 2)
                                {
                                    t = t.ToString().Trim().Substring(0, t.ToString().Trim().Length - 2) + "'" +
                                    t.ToString().Trim().Substring(t.ToString().Trim().Length - 2, 2) + "\"";
                                }
                                if (t.ToString().Trim().Length <= 2)
                                {
                                    t = "0'" + e.ToString().Trim() + "\"";
                                }
                            }
                            resultList.Add(model);
                        }

                    }
                    if (row["StudentSex"].ToString() == "2")
                    {
                        if (row["Heigh"].ToString() == "" || row["Weight"].ToString() == "" || row["Pulmonary"].ToString() == "" || row["FiftyRun"].ToString() == "" || row["StandJump"].ToString() == "" || row["SitAndReach"].ToString() == "" || row["EightHundred"].ToString() == "" || row["MinSupination"].ToString() == "")
                        {
                            StudentScoreExcel model = new StudentScoreExcel();
                            model.StudentCode = row["StudentCode"].ToString();
                            model.StudentName = row["StudentName"].ToString();
                            model.StudentSex = row["StudentSex"].ToString();
                            model.StudentBornDate = row["StudentBornDate"].ToString();
                            model.StudentHomeAddress = row["StudentHomeAddress"].ToString();
                            model.GradeCode = row["GradeCode"].ToString();
                            model.SchoolName = row["SchoolName"].ToString();
                            model.SchoolCode = row["SchoolCode"].ToString();
                            model.ClassName = row["ClassName"].ToString();
                            model.ClassCode = row["ClassCode"].ToString();
                            model.NationCode = row["NationCode"].ToString();
                            model.NationName = row["NationName"].ToString();
                            model.StudentNative = row["StudentNative"].ToString();
                            model.StudentMoveType = row["StudentMoveType"].ToString();
                            model.StudentIDNumber = row["StudentIDNumber"].ToString();
                            model.StudentPhone = row["StudentPhone"].ToString();
                            model.StudentIsRegister = row["StudentIsRegister"].ToString();
                            model.Heigh = row["Heigh"].ToString();
                            model.Weight = row["Weight"].ToString();
                            model.BMI = row["BMI"].ToString();
                            model.BMIScore = row["BMIScore"].ToString();
                            model.BMILevel = row["BMILevel"].ToString();
                            model.Pulmonary = row["Pulmonary"].ToString();
                            model.PulmonaryScore = row["PulmonaryScore"].ToString();
                            model.PulmonaryLevel = row["PulmonaryLevel"].ToString();
                            model.FiftyRun = row["FiftyRun"].ToString();
                            model.FiftyRunScore = row["FiftyRunScore"].ToString();
                            model.FiftyRunLevel = row["FiftyRunLevel"].ToString();
                            model.StandJump = row["StandJump"].ToString();
                            model.StandJumpScore = row["StandJumpScore"].ToString();
                            model.StandJumpLevel = row["StandJumpLevel"].ToString();
                            model.SitAndReach = row["SitAndReach"].ToString();
                            model.SitAndReachScore = row["SitAndReachScore"].ToString();
                            model.SitAndReachLevel = row["SitAndReachLevel"].ToString();
                            //model.EightHundred = row["EightHundred"].ToString();
                            model.EightHundredScore = row["EightHundredScore"].ToString();
                            model.EightHundredLevel = row["EightHundredLevel"].ToString();
                            model.EightHundredAddScore = row["EightHundredAddScore"].ToString();
                            //model.ThousandRun = row["ThousandRun"].ToString();
                            model.ThousandRunScore = row["ThousandRunScore"].ToString();
                            model.ThousandRunLevel = row["ThousandRunLevel"].ToString();
                            model.ThousandRunAddScore = row["ThousandRunAddScore"].ToString();
                            model.MinSupination = row["MinSupination"].ToString();
                            model.MinSupinationScore = row["MinSupinationScore"].ToString();
                            model.MinSupinationLevel = row["MinSupinationLevel"].ToString();
                            model.MinSupinationAddScore = row["MinSupinationAddScore"].ToString();
                            model.PullUp = row["PullUp"].ToString();
                            model.PullUpScore = row["PullUpScore"].ToString();
                            model.PullUpLevel = row["PullUpLevel"].ToString();
                            model.PullUpAddScore = row["PullUpAddScore"].ToString();
                            model.TestResult = row["TestResult"].ToString();
                            model.StudentTrueScore = row["StudentTrueScore"].ToString();
                            model.TestType = row["TestType"].ToString();
                            model.CreateTime = row["CreateTime"].ToString();
                            model.UpdateTime = row["UpdateTime"].ToString();
                            model.Remark = row["Remark"].ToString();
                            string e = row["EightHundred"].ToString();
                            if (e != "")
                            {
                                if (e.ToString().Trim().Length > 2)
                                {
                                    e = e.ToString().Trim().Substring(0, e.ToString().Trim().Length - 2) + "'" +
                                    e.ToString().Trim().Substring(e.ToString().Trim().Length - 2, 2) + "\"";
                                }
                                if (e.ToString().Trim().Length <= 2)
                                {
                                    e = "0'" + e.ToString().Trim() + "\"";
                                }
                            }
                            model.EightHundred = e;
                            string t = row["ThousandRun"].ToString();
                            if (t != "")
                            {
                                if (t.ToString().Trim().Length > 2)
                                {
                                    t = t.ToString().Trim().Substring(0, t.ToString().Trim().Length - 2) + "'" +
                                    t.ToString().Trim().Substring(t.ToString().Trim().Length - 2, 2) + "\"";
                                }
                                if (t.ToString().Trim().Length <= 2)
                                {
                                    t = "0'" + e.ToString().Trim() + "\"";
                                }
                            }
                            resultList.Add(model);
                        }
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// 获取学生体侧信息
        /// </summary>
        /// <param name="studentCode">学生编号</param>
        /// <param name="NK">年库</param>
        /// <returns>实体类</returns>
        public DStudent_TestScore GetDStudentTestScoreModel(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_TestScore" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 删除体侧信息
        /// </summary>
        /// <param name="studentCode">学生学号</param> 
        /// <param name="NK">所属年份</param>
        /// <returns>数值>0成功，=0失败</returns>
        public int DelDStudentTestScore(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("DELETE  DStudent_TestScore" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 标记为免测
        /// </summary>
        /// <param name="studentCode">学生学号</param>
        /// <returns>数值>0成功，=0失败</returns>
        public int MarkFree(string studentCode, string NK)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            return Repository().ExecuteByProc("Proc_MarkFree", parameter.ToArray());
        }

        /// <summary>
        /// 标记为作弊
        /// </summary>
        /// <param name="studentCode">学生学号</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功，=0失败</returns>
        public int MarkCheat(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DStudent_TestScore" + NK + " SET TestResult='作弊'  WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 取消作弊
        /// </summary>
        /// <param name="studentCode">学生类型</param>
        /// <param name="testResult">测试类型</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功，=0失败</returns>
        public int DelCheat(string studentCode, string testResult, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DStudent_TestScore" + NK + " SET TestResult=@TestResult  WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            parameter.Add(DbFactory.CreateDbParameter("@TestResult", testResult));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 修改体侧信息的性别
        /// </summary>
        /// <param name="studentCode"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int UpdDStudentTestScoreSex(string studentCode, string studentSex, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "UPDATE DStudent_TestScore" + NK;
            strSql.Append(insertTable);
            strSql.Append(@" SET StudentSex=@StudentSex WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", studentSex));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
        #endregion
    }
}