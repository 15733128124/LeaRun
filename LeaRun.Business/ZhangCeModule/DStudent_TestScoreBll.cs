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
    /// ѧ���ɼ����Ա�����ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:41</date>
    /// </author>
    /// </summary>
    public class DStudent_TestScoreBll : RepositoryFactory<DStudent_TestScore>
    {
        DStudent_FinshSchoolTestBll finshTestBll = new DStudent_FinshSchoolTestBll();


        #region ��������
        /// <summary>
        /// ���ѧ���ɼ�
        /// </summary>
        /// <param name="model">ѧ���ɼ�ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns>��������</returns>
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
                    //��Ӳ��Լ�¼
                    AddDStudentTestScoreLog(model.StudentCode, NK);
                }
            }
            return resultInt;
        }

        /// <summary>
        /// ���ѧ���ɼ����Լ�¼
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
        /// �޸�ѧ���ɼ�
        /// </summary>
        /// <param name="model">ѧ���ɼ�ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns>��������</returns>
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
        ///����ѧ��ɾ��ѧ���ɼ���Ϣ
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
        /// ���ѧ���ĳɼ��Ƿ����
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
        /// ��ȡѧ���ɼ���Ϣ
        /// </summary>
        /// <param name="keyvalue">�ؼ���</param>
        /// <param name="NK">���</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns>���ݼ�</returns>
        public DataTable GridDStudentTestScoreList(string keyvalue, string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                        --Id,����
                                d.StudentCode,               --ѧ��ѧ��
                                d.StudentName,               --ѧ������
                                d.StudentSex,                --�Ա�
                                d.Heigh,                     --���
                                d.Weight,                    --����
                                d.BMI,                       --����ָ��
                                d.BMIScore,                  --����ָ���÷�
                                d.BMILevel,                  --����ָ������
                                d.Pulmonary,                 --�λ���
                                d.PulmonaryScore,            --�λ����÷�
                                d.PulmonaryLevel,            --�λ�������
                                d.FiftyRun,                  --50����
                                d.FiftyRunScore,             --50���ܵ÷�
                                d.FiftyRunLevel,             --50���ܼ���
                                d.StandJump,                 --������Զ                                
                                d.StandJumpScore,            --������Զ�÷�
                                d.StandJumpLevel,            --������Զ����
                                d.SitAndReach,               --��λ��ǰ��
                                d.SitAndReachScore,          --��λ��ǰ���÷�
                                d.SitAndReachLevel,          --��λ��ǰ������
                                d.EightHundred,              --800��
                                d.EightHundredScore,         --800�׵÷�
                                d.EightHundredLevel,         --800�׼���
                                d.EightHundredAddScore,      --800�׼ӷ�
                                d.ThousandRun,               --1000��
                                d.ThousandRunScore,          --1000�׵÷�
                                d.ThousandRunLevel,          --1000�׼���
                                d.ThousandRunAddScore,       --1000�׼ӷ�
                                d.MinSupination,             --1������������
                                d.MinSupinationScore,        --1�������������÷�
                                d.MinSupinationLevel,        --1����������������
                                d.MinSupinationAddScore,     --1�������������ӷ�
                                d.PullUp,                    --��������
                                d.PullUpScore,               --�������ϵ÷�
                                d.PullUpLevel,               --�������ϼ���
                                d.PullUpAddScore,            --�������ϼӷ�
                                d.TestResult,                --���Խ�������⡢����
                                d.StudentTrueScore,          --ѧ��������ǳɼ�
                                d.TestType,                  --�������ͣ��������ԡ��������
                                d.CreateTime,                --����ʱ��
                                d.UpdateTime,                --����ʱ��
                                d.Remark                     --��ע
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
        /// ����ѧ���ϱ��ɼ�
        /// </summary>
        /// <param name="NK">���</param>
        /// <param name="studentSex">�Ա�</param>
        /// <returns></returns>
        public List<StudentScoreExcel> GetDStudentTestScoreListExport(string NK, string studentSex)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT                                
                                i.StudentCode,               --ѧ��ѧ��
                                i.StudentName,               --ѧ������
                                i.StudentSex,                --�Ա� 
                                i.StudentBornDate,           --��������
                                i.StudentHomeAddress,        --ѧ��סַ
                                i.GradeCode,                 --�꼶���
                                i.SchoolName,                --ѧԺ����
                                i.SchoolCode,                --ѧԺ���
                                i.ClassName,                 --�༶����
                                i.ClassCode,                 --�༶���
                                i.NationCode,                --������
                                i.NationName,                --��������
                                i.StudentNative,             --ѧ������
                                i.StudentMoveType,           --�춯����
                                i.StudentIDNumber,           --ѧ�����֤��                                
                                i.StudentPhone,              --ѧ���绰
                                i.StudentIsRegister,         --�Ƿ�ע��
                                d.Heigh,                     --���
                                d.Weight,                    --����
                                d.BMI,                       --����ָ��
                                d.BMIScore,                  --����ָ���÷�
                                d.BMILevel,                  --����ָ������
                                d.Pulmonary,                 --�λ���
                                d.PulmonaryScore,            --�λ����÷�
                                d.PulmonaryLevel,            --�λ�������
                                d.FiftyRun,                  --50����
                                d.FiftyRunScore,             --50���ܵ÷�
                                d.FiftyRunLevel,             --50���ܼ���
                                d.StandJump,                 --������Զ                                
                                d.StandJumpScore,            --������Զ�÷�
                                d.StandJumpLevel,            --������Զ����
                                d.SitAndReach,               --��λ��ǰ��
                                d.SitAndReachScore,          --��λ��ǰ���÷�
                                d.SitAndReachLevel,          --��λ��ǰ������
                                d.EightHundred,              --800��
                                d.EightHundredScore,         --800�׵÷�
                                d.EightHundredLevel,         --800�׼���
                                d.EightHundredAddScore,      --800�׼ӷ�
                                d.ThousandRun,               --1000��
                                d.ThousandRunScore,          --1000�׵÷�
                                d.ThousandRunLevel,          --1000�׼���
                                d.ThousandRunAddScore,       --1000�׼ӷ�
                                d.MinSupination,             --1������������
                                d.MinSupinationScore,        --1�������������÷�
                                d.MinSupinationLevel,        --1����������������
                                d.MinSupinationAddScore,     --1�������������ӷ�
                                d.PullUp,                    --��������
                                d.PullUpScore,               --�������ϵ÷�
                                d.PullUpLevel,               --�������ϼ���
                                d.PullUpAddScore,            --�������ϼӷ�
                                d.TestResult,                --���Խ�������⡢ͨ������⣬����
                                d.StudentTrueScore,          --ѧ��������ǳɼ�
                                d.TestType,                  --�������ͣ��������ԡ��������
                                d.CreateTime,                --����ʱ��
                                d.UpdateTime,                --����ʱ��
                                d.Remark                     --��ע
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string innerJoinSql = " INNER JOIN DStudent_Infos" + NK + " i ON d.StudentCode=i.StudentCode ";
            string sqlConditon = " WHERE  d.TestResult='ͨ��' and d.StudentSex=@StudentSex";
            strSql.Append(sqlTableName);
            strSql.Append(innerJoinSql);
            strSql.Append(sqlConditon);
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", studentSex));
            List<StudentScoreExcel> list = GetScoreExcelList(strSql, parameter);
            return list;
        }

        //�Զ����ȡ���ݷ���
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
        /// ��ȡѧ����Ϣ�����Զ��嵼��
        /// </summary>
        /// <param name="NK"></param>
        /// <param name="jqgridparam"></param>
        /// <returns></returns>
        public DataTable StudentOtherAll(string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT   top 1                              
                                i.StudentCode,               --ѧ��ѧ��
                                i.StudentName,               --ѧ������
                                i.StudentSex,                --�Ա� 
                                i.StudentBornDate,           --��������
                                i.StudentHomeAddress,        --ѧ��סַ
                                i.GradeCode,                 --�꼶���
                                i.SchoolName,                --ѧԺ����
                                i.SchoolCode,                --ѧԺ���
                                i.ClassName,                 --�༶����
                                i.ClassCode,                 --�༶���
                                i.NationCode,                --������
                                i.NationName,                --��������
                                i.StudentNative,             --ѧ������
                                i.StudentMoveType,           --�춯����
                                i.StudentIDNumber,           --ѧ�����֤��                                
                                i.StudentPhone,              --ѧ���绰
                                i.StudentIsRegister,         --�Ƿ�ע��
                                d.Heigh,                     --���
                                d.Weight,                    --����
                                d.BMI,                       --����ָ��
                                d.BMIScore,                  --����ָ���÷�
                                d.BMILevel,                  --����ָ������
                                d.Pulmonary,                 --�λ���
                                d.PulmonaryScore,            --�λ����÷�
                                d.PulmonaryLevel,            --�λ�������
                                d.FiftyRun,                  --50����
                                d.FiftyRunScore,             --50���ܵ÷�
                                d.FiftyRunLevel,             --50���ܼ���
                                d.StandJump,                 --������Զ                                
                                d.StandJumpScore,            --������Զ�÷�
                                d.StandJumpLevel,            --������Զ����
                                d.SitAndReach,               --��λ��ǰ��
                                d.SitAndReachScore,          --��λ��ǰ���÷�
                                d.SitAndReachLevel,          --��λ��ǰ������
                                d.EightHundred,              --800��
                                d.EightHundredScore,         --800�׵÷�
                                d.EightHundredLevel,         --800�׼���
                                d.EightHundredAddScore,      --800�׼ӷ�
                                d.ThousandRun,               --1000��
                                d.ThousandRunScore,          --1000�׵÷�
                                d.ThousandRunLevel,          --1000�׼���
                                d.ThousandRunAddScore,       --1000�׼ӷ�
                                d.MinSupination,             --1������������
                                d.MinSupinationScore,        --1�������������÷�
                                d.MinSupinationLevel,        --1����������������
                                d.MinSupinationAddScore,     --1�������������ӷ�
                                d.PullUp,                    --��������
                                d.PullUpScore,               --�������ϵ÷�
                                d.PullUpLevel,               --�������ϼ���
                                d.PullUpAddScore,            --�������ϼӷ�
                                d.TestResult,                --���Խ�������⡢ͨ������⣬����
                                d.StudentTrueScore,          --ѧ��������ǳɼ�
                                d.TestType,                  --�������ͣ��������ԡ��������
                                d.CreateTime,                --����ʱ��
                                d.UpdateTime,                --����ʱ��
                                d.Remark                     --��ע
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string innerJoinSql = " INNER JOIN DStudent_Infos" + NK + " i ON d.StudentCode=i.StudentCode ";
            strSql.Append(sqlTableName);
            strSql.Append(innerJoinSql);
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// �����ӱ�ѧ����
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
        /// �Զ��嵼��ѧ����Ϣ
        /// </summary>
        /// <param name="resultType"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public List<StudentScoreExcel> StudentOtherExport(string resultType, string NK)
        {

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT                                
                                i.StudentCode,               --ѧ��ѧ��
                                i.StudentName,               --ѧ������
                                i.StudentSex,                --�Ա� 
                                i.StudentBornDate,           --��������
                                i.StudentHomeAddress,        --ѧ��סַ
                                i.GradeCode,                 --�꼶���
                                i.SchoolName,                --ѧԺ����
                                i.SchoolCode,                --ѧԺ���
                                i.ClassName,                 --�༶����
                                i.ClassCode,                 --�༶���
                                i.NationCode,                --������
                                i.NationName,                --��������
                                i.StudentNative,             --ѧ������
                                i.StudentMoveType,           --�춯����
                                i.StudentIDNumber,           --ѧ�����֤��                                
                                i.StudentPhone,              --ѧ���绰
                                i.StudentIsRegister,         --�Ƿ�ע��
                                d.Heigh,                     --���
                                d.Weight,                    --����
                                d.BMI,                       --����ָ��
                                d.BMIScore,                  --����ָ���÷�
                                d.BMILevel,                  --����ָ������
                                d.Pulmonary,                 --�λ���
                                d.PulmonaryScore,            --�λ����÷�
                                d.PulmonaryLevel,            --�λ�������
                                d.FiftyRun,                  --50����
                                d.FiftyRunScore,             --50���ܵ÷�
                                d.FiftyRunLevel,             --50���ܼ���
                                d.StandJump,                 --������Զ                                
                                d.StandJumpScore,            --������Զ�÷�
                                d.StandJumpLevel,            --������Զ����
                                d.SitAndReach,               --��λ��ǰ��
                                d.SitAndReachScore,          --��λ��ǰ���÷�
                                d.SitAndReachLevel,          --��λ��ǰ������
                                d.EightHundred,              --800��
                                d.EightHundredScore,         --800�׵÷�
                                d.EightHundredLevel,         --800�׼���
                                d.EightHundredAddScore,      --800�׼ӷ�
                                d.ThousandRun,               --1000��
                                d.ThousandRunScore,          --1000�׵÷�
                                d.ThousandRunLevel,          --1000�׼���
                                d.ThousandRunAddScore,       --1000�׼ӷ�
                                d.MinSupination,             --1������������
                                d.MinSupinationScore,        --1�������������÷�
                                d.MinSupinationLevel,        --1����������������
                                d.MinSupinationAddScore,     --1�������������ӷ�
                                d.PullUp,                    --��������
                                d.PullUpScore,               --�������ϵ÷�
                                d.PullUpLevel,               --�������ϼ���
                                d.PullUpAddScore,            --�������ϼӷ�
                                d.TestResult,                --���Խ�������⡢ͨ������⣬����
                                d.StudentTrueScore,          --ѧ��������ǳɼ�
                                d.TestType,                  --�������ͣ��������ԡ��������
                                d.CreateTime,                --����ʱ��
                                d.UpdateTime,                --����ʱ��
                                d.Remark                     --��ע
                                FROM ");
            string sqlTableName = "DStudent_TestScore" + NK + " d";
            string innerJoinSql = " INNER JOIN DStudent_Infos" + NK + " i ON d.StudentCode=i.StudentCode ";
            strSql.Append(sqlTableName);
            strSql.Append(innerJoinSql);
            if (resultType == "0")
                strSql.Append(" WHERE 1 = 1");
            if (resultType == "ͨ��")
                strSql.Append(" WHERE d.TestResult='ͨ��'");
            if (resultType == "���")
                strSql.Append(" WHERE d.TestResult='���'");
            if (resultType == "����")
                strSql.Append(" WHERE d.TestResult='����'");
            if (resultType == "4")
                strSql.Append(" WHERE d.TestResult=''");
            if (resultType == "����")
                strSql.Append(" WHERE 1 = 1");
            DataTable dt = Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
            List<StudentScoreExcel> resultList = new List<StudentScoreExcel>();
            if (resultType != "����")
            {
                resultList = GetScoreExcelList(strSql, parameter);
            }
            if (resultType == "����")
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
        /// ��ȡѧ�������Ϣ
        /// </summary>
        /// <param name="studentCode">ѧ�����</param>
        /// <param name="NK">���</param>
        /// <returns>ʵ����</returns>
        public DStudent_TestScore GetDStudentTestScoreModel(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_TestScore" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ɾ�������Ϣ
        /// </summary>
        /// <param name="studentCode">ѧ��ѧ��</param> 
        /// <param name="NK">�������</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
        public int DelDStudentTestScore(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("DELETE  DStudent_TestScore" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// ���Ϊ���
        /// </summary>
        /// <param name="studentCode">ѧ��ѧ��</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
        public int MarkFree(string studentCode, string NK)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            return Repository().ExecuteByProc("Proc_MarkFree", parameter.ToArray());
        }

        /// <summary>
        /// ���Ϊ����
        /// </summary>
        /// <param name="studentCode">ѧ��ѧ��</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
        public int MarkCheat(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DStudent_TestScore" + NK + " SET TestResult='����'  WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="studentCode">ѧ������</param>
        /// <param name="testResult">��������</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
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

        #region ��չ����

        /// <summary>
        /// �޸������Ϣ���Ա�
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