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
    /// ѧ��Լ�����Ա�
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.15 11:42</date>
    /// </author>
    /// </summary>
    public class DStudent_TestBll : RepositoryFactory<DStudent_Test>
    {


        public DataTable GetDStudentTestList(string schoolName, string className,
            string testTeacher, string testType, string testBeginDate, string studentCode, string gradeCode, string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                         --Id,����
                                d.StudentCode,                --ѧ��ѧ��
                                d.GradeCode,                  --�꼶���
                                d.SchoolCode,                 --ѧԺ���
                                d.SchoolName,                 --ѧԺ����
                                d.ClassCode,                  --�༶���
                                d.ClassName,                  --�༶����
                                d.TestSetID,                  --����ID
                                d.StudentName,                --ѧ������
                                d.StudentSex,                 --ѧ���Ա�
                                d.TestTeacher,                --������ʦ
                                d.TestAddress,                --���Ե�ַ
                                d.BeginPraDate,               --��ʼ��������
                                d.BeginWeek,                  --��ʼ��������
                                d.BeginPraTime,               --��ʼ����ʱ��
                                d.ApplyFor,                   --�Ƿ���Ч
                                d.TestGroup,                  --������
                                d.TestGroupCode,              --���Ժ�
                                d.TestType,                   --��������
                                d.CreateTime,                 --����ʱ��
                                d.UpdateTime,                 --����ʱ��
                                d.Remark                     --��ע
                                FROM ");
            string sqlTableName = "DStudent_TestLog" + NK + " d";
            string sqlConditon = " WHERE 1=1";
            strSql.Append(sqlTableName);
            strSql.Append(sqlConditon);
            if (!string.IsNullOrEmpty(schoolName))
            {
                strSql.Append(@" AND d.schoolName=@SchoolName");
                parameter.Add(DbFactory.CreateDbParameter("@SchoolName", schoolName));
            }

            if (!string.IsNullOrEmpty(className))
            {
                strSql.Append(@" AND d.className=@ClassName");
                parameter.Add(DbFactory.CreateDbParameter("@ClassName", className));
            }
            if (!string.IsNullOrEmpty(testType))
            {
                strSql.Append(@" AND d.TestType=@TestType");
                parameter.Add(DbFactory.CreateDbParameter("@TestType", testType));
            }
            if (!string.IsNullOrEmpty(testTeacher))
            {
                strSql.Append(@" AND d.TestTeacher=@TestTeacher");
                parameter.Add(DbFactory.CreateDbParameter("@TestTeacher", testTeacher));
            }
            if (!string.IsNullOrEmpty(testBeginDate))
            {
                strSql.Append(@" AND d.BeginPraDate=@BeginPraDate");
                parameter.Add(DbFactory.CreateDbParameter("@BeginPraDate", testBeginDate));
            }
            if (!string.IsNullOrEmpty(studentCode))
            {
                strSql.Append(@" AND d.studentCode=@StudentCode");
                parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            }
            if (!string.IsNullOrEmpty(gradeCode))
            {
                strSql.Append(@" AND d.gradeCode=@GradeCode");
                parameter.Add(DbFactory.CreateDbParameter("@GradeCode", gradeCode));
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// ����Ա���Լ��
        /// </summary>
        /// <param name="model"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int AddDStudentTestAdmin(DStudent_Test model, string NK)
        {

            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@GradeCode", model.GradeCode));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolCode", model.SchoolCode));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolName", model.SchoolName));
            parameter.Add(DbFactory.CreateDbParameter("@ClassCode", model.ClassCode));
            parameter.Add(DbFactory.CreateDbParameter("@ClassName", model.ClassName));
            parameter.Add(DbFactory.CreateDbParameter("@TestSetID", model.TestSetID));
            parameter.Add(DbFactory.CreateDbParameter("@StudentName", model.StudentName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@TestTeacher", model.TestTeacher));
            parameter.Add(DbFactory.CreateDbParameter("@TestAddress", model.TestAddress));
            parameter.Add(DbFactory.CreateDbParameter("@BeginPraDate", model.BeginPraDate));
            parameter.Add(DbFactory.CreateDbParameter("@BeginWeek", model.BeginWeek));
            parameter.Add(DbFactory.CreateDbParameter("@BeginPraTime", model.BeginPraTime));
            parameter.Add(DbFactory.CreateDbParameter("@ApplyFor", model.ApplyFor));
            parameter.Add(DbFactory.CreateDbParameter("@TestGroup", model.TestGroup));
            parameter.Add(DbFactory.CreateDbParameter("@TestGroupCode", model.TestGroupCode));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            DbParameter result = DbFactory.CreateDbOutParameter("@Result", 4);
            parameter.Add(result);
            Repository().ExecuteByProc("Proc_AddDStudentTestAdmin", parameter.ToArray());
            return Convert.ToInt32(result.Value);

        }

        /// <summary>
        ///  ��ȡѧ��Լ�����Ե���Ϣ
        /// </summary>
        /// <param name="testSetID">��������ID</param>
        /// <param name="studentCode">ѧ��ѧ��</param>
        /// <param name="testType">��������</param>
        /// <param name="NK">���</param>
        /// <returns>ѧ��������Ϣʵ����</returns>
        public DStudent_Test GetDStudentTestModel(string studentCode, string testType, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_Test" + NK + " WHERE TestType=@TestType and StudentCode=@StudentCode and ApplyFor='1'");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", testType));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ȡ��Լ������
        /// </summary>
        /// <param name="studentCode">ѧ��ѧ��</param>
        /// <param name="testSetID">��������ID</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ�</returns>
        public int DeleteTestStudent(string studentCode, string testSetID, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE DStudent_Test" + NK + " SET ApplyFor='2'  WHERE TestSetID=@TestSetID and StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            parameter.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }



        /// <summary>
        /// ���Ѳ���ļ�¼��ӵ���¼����
        /// </summary>
        /// <param name="testSetId"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int InsertDStudentTestLog(string sqlWhere, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"INSERT INTO DStudent_TestLog" + NK + @"(StudentCode,GradeCode,SchoolCode,SchoolName,ClassCode,ClassName,TestSetID,
                            StudentName,StudentSex,TestTeacher,TestAddress,BeginPraDate,BeginWeek,
                            BeginPraTime,ApplyFor,TestGroup,TestGroupCode,TestType,CreateTime,UpdateTime,Remark)");
            strSql.Append(@" SELECT StudentCode,GradeCode,SchoolCode,SchoolName,ClassCode,ClassName,TestSetID,
                            StudentName,StudentSex,TestTeacher,TestAddress,BeginPraDate,BeginWeek,
                            BeginPraTime,ApplyFor,TestGroup,TestGroupCode,TestType,CreateTime,UpdateTime,Remark");
            strSql.Append(" FROM DStudent_Test" + NK + "  WHERE ApplyFor='1' ");
            strSql.Append(sqlWhere);
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// ����ѧ�������Ϣ
        /// </summary>
        /// <returns></returns>
        public List<DStudent_Test> TestStudentExport(string sqlWere, string schoolName, string className,
            string testTeacher, string studentSex, string testBeginDate, string studentCode, string gradeCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT " + sqlWere + "  FROM DStudent_TestLog" + NK + " d WHERE 1=1");
            if (!string.IsNullOrEmpty(schoolName))
            {
                strSql.Append(@" AND d.schoolName=@SchoolName");
                parameter.Add(DbFactory.CreateDbParameter("@SchoolName", schoolName));
            }

            if (!string.IsNullOrEmpty(className))
            {
                strSql.Append(@" AND d.className=@ClassName");
                parameter.Add(DbFactory.CreateDbParameter("@ClassName", className));
            }
            if (!string.IsNullOrEmpty(studentSex))
            {
                strSql.Append(@" AND d.StudentSex=@StudentSex");
                parameter.Add(DbFactory.CreateDbParameter("@StudentSex", studentSex));
            }
            if (!string.IsNullOrEmpty(testTeacher))
            {
                strSql.Append(@" AND d.testTeacher=@TestTeacher");
                parameter.Add(DbFactory.CreateDbParameter("@TestTeacher", testTeacher));
            }
            if (!string.IsNullOrEmpty(testBeginDate))
            {
                strSql.Append(@" AND d.BeginPraDate=@BeginPraDate");
                parameter.Add(DbFactory.CreateDbParameter("@BeginPraDate", testBeginDate));
            }
            if (!string.IsNullOrEmpty(studentCode))
            {
                strSql.Append(@" AND d.studentCode=@StudentCode");
                parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            }
            if (!string.IsNullOrEmpty(gradeCode))
            {
                strSql.Append(@" AND d.gradeCode=@GradeCode");
                parameter.Add(DbFactory.CreateDbParameter("@GradeCode", gradeCode));
            }
            return Repository().FindListBySql(strSql.ToString(), parameter.ToArray());
        }

    }
}