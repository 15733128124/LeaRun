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
    /// 学生约考测试表
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
                                d.ID,                         --Id,主键
                                d.StudentCode,                --学生学号
                                d.GradeCode,                  --年级编号
                                d.SchoolCode,                 --学院编号
                                d.SchoolName,                 --学院名称
                                d.ClassCode,                  --班级编号
                                d.ClassName,                  --班级名称
                                d.TestSetID,                  --测试ID
                                d.StudentName,                --学生姓名
                                d.StudentSex,                 --学生性别
                                d.TestTeacher,                --测试老师
                                d.TestAddress,                --测试地址
                                d.BeginPraDate,               --开始测试日期
                                d.BeginWeek,                  --开始测试星期
                                d.BeginPraTime,               --开始测试时间
                                d.ApplyFor,                   --是否有效
                                d.TestGroup,                  --测试组
                                d.TestGroupCode,              --测试号
                                d.TestType,                   --测试类型
                                d.CreateTime,                 --创建时间
                                d.UpdateTime,                 --更新时间
                                d.Remark                     --备注
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
        /// 管理员添加约考
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
        ///  获取学生约考测试的信息
        /// </summary>
        /// <param name="testSetID">测试设置ID</param>
        /// <param name="studentCode">学生学号</param>
        /// <param name="testType">测试类型</param>
        /// <param name="NK">年库</param>
        /// <returns>学生测试信息实体类</returns>
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
        /// 取消约考测试
        /// </summary>
        /// <param name="studentCode">学生学号</param>
        /// <param name="testSetID">测试设置ID</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功</returns>
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
        /// 把已测完的记录添加到记录表中
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
        /// 导出学生体侧信息
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