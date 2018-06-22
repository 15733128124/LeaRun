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
    /// 学生测试设置表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    public class DStudent_TestSetBll : RepositoryFactory<DStudent_TestSet>
    {
        /// <summary>
        /// 获取测试设置信息
        /// </summary>
        /// <param name="testBeginDate">测试开始日期</param>
        /// <param name="studentSex">学生性别 男1，女2</param>
        /// <param name="testBeginTime">测试开始时间</param>
        /// <param name="allotState">测试状态</param>
        /// <param name="testLimit">测试限制</param>
        /// <param name="NK">年库</param>
        /// <param name="jqgridparam">分页参数</param>
        /// <param name="testType">测试类型</param>
        /// <returns></returns>
        public DataTable GetDStudentInfosList(string testBeginDate, string studentSex, string testBeginTime, string allotState, string testLimit, string NK, ref JqGridParam jqgridparam,string testType)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                         --Id,主键
                                d.TestBeginDate,              --开始日期
                                d.TestBeginWeek,              --开始星期
                                d.TestAddress,                --测试地址
                                d.StudentSex,                 --学生性别
                                d.TestStudentCount,           --测试人数
                                d.TestBeginTime,              --开始测试时段
                                d.TestStudentOkCount,         --已约人数
                                d.TestStudentNoCount,         --未约人数
                                d.AllotState,                 --分配状态
                                d.TestLimit,                  --测试限制大一，大二，大三，大四，补测（全部可参加）
                                d.TestType,                   --测试类型：约考测试、单元测试、补测约考
                                d.CreateTime,                 --创建时间
                                d.UpdateTime,                 --更新时间
                                d.Remark                      --备注
                                FROM ");
            string sqlTableName = "DStudent_TestSet" + NK + " d";
            string sqlConditon = " WHERE 1=1";
            strSql.Append(sqlTableName);
            strSql.Append(sqlConditon);
            if (!string.IsNullOrEmpty(testType))
            {
                strSql.Append(@" AND d.TestType=@TestType");
                parameter.Add(DbFactory.CreateDbParameter("@TestType", testType));
            }
           
            if (!string.IsNullOrEmpty(testBeginDate))
            {
                strSql.Append(@" AND d.TestBeginDate=@TestBeginDate");
                parameter.Add(DbFactory.CreateDbParameter("@TestBeginDate", testBeginDate));
            }
            if (!string.IsNullOrEmpty(studentSex))
            {
                strSql.Append(@" AND d.StudentSex=@StudentSex");
                parameter.Add(DbFactory.CreateDbParameter("@StudentSex", studentSex));
            }
            if (!string.IsNullOrEmpty(testBeginTime))
            {
                strSql.Append(@" AND d.TestBeginTime=@TestBeginTime");
                parameter.Add(DbFactory.CreateDbParameter("@TestBeginTime", testBeginTime));
            }
            if (!string.IsNullOrEmpty(allotState))
            {
                strSql.Append(@" AND d.AllotState=@AllotState");
                parameter.Add(DbFactory.CreateDbParameter("@AllotState", allotState));
            }
            if (!string.IsNullOrEmpty(testLimit))
            {
                strSql.Append(@" AND d.TestLimit=@TestLimit");
                parameter.Add(DbFactory.CreateDbParameter("@TestLimit", testLimit));
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// 根据id获取测试信息实体类
        /// </summary>
        /// <param name="id">id主键</param>
        /// <returns>实体类</returns>
        public DStudent_TestSet GetDStudentTestSetModel(int id,string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_TestSet" + NK + " WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 添加测试设置信息
        /// </summary>
        /// <param name="model">测试设置实体类</param>
        /// <param name="NK">年库</param>
        /// <returns>返回值>0 成功 </returns>
        public int AddDStudentTestSet(DStudent_TestSet model,string NK)
        {

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "INSERT INTO DStudent_TestSet" + NK;
            strSql.Append(insertTable);
            strSql.Append(@"(TestBeginDate,TestBeginWeek,TestAddress,StudentSex,TestStudentCount,TestBeginTime,
            TestStudentOkCount,TestStudentNoCount,AllotState,TestLimit,TestType,CreateTime,UpdateTime,Remark)
            VALUES(@TestBeginDate,@TestBeginWeek,@TestAddress,@StudentSex,@TestStudentCount,@TestBeginTime,
            @TestStudentOkCount,@TestStudentNoCount,@AllotState,@TestLimit,@TestType,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@TestBeginDate", model.TestBeginDate));
            parameter.Add(DbFactory.CreateDbParameter("@TestBeginWeek", model.TestBeginWeek));
            parameter.Add(DbFactory.CreateDbParameter("@TestAddress", model.TestAddress));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@TestStudentCount", model.TestStudentCount));
            parameter.Add(DbFactory.CreateDbParameter("@TestBeginTime", model.TestBeginTime));
            parameter.Add(DbFactory.CreateDbParameter("@TestStudentOkCount", model.TestStudentOkCount));
            parameter.Add(DbFactory.CreateDbParameter("@TestStudentNoCount", model.TestStudentNoCount));
            parameter.Add(DbFactory.CreateDbParameter("@AllotState", model.AllotState));
            parameter.Add(DbFactory.CreateDbParameter("@TestLimit", model.TestLimit));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 修改测试设置信息
        /// </summary>
        /// <param name="model">测试设置实体类</param>
        /// <param name="NK">年库</param>
        /// <returns>返回值>0 成功 </returns>
        public int UpdDStudentTestSet(DStudent_TestSet model, string NK)
        {

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "UPDATE DStudent_TestSet" + NK;
            strSql.Append(insertTable);
            strSql.Append(@" SET TestBeginDate=@TestBeginDate,TestBeginWeek=TestBeginWeek,TestAddress=@TestAddress,StudentSex=@StudentSex,TestStudentCount=@TestStudentCount,TestBeginTime=@TestBeginTime,
            TestStudentOkCount=@TestStudentOkCount,TestStudentNoCount=@TestStudentNoCount,AllotState=@AllotState,TestLimit=@TestLimit,TestType=@TestType,UpdateTime=@UpdateTime,Remark=@Remark WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@TestBeginDate", model.TestBeginDate));
            parameter.Add(DbFactory.CreateDbParameter("@TestBeginWeek", model.TestBeginWeek));
            parameter.Add(DbFactory.CreateDbParameter("@TestAddress", model.TestAddress));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@TestStudentCount", model.TestStudentCount));
            parameter.Add(DbFactory.CreateDbParameter("@TestBeginTime", model.TestBeginTime));
            parameter.Add(DbFactory.CreateDbParameter("@TestStudentOkCount", model.TestStudentOkCount));
            parameter.Add(DbFactory.CreateDbParameter("@TestStudentNoCount", model.TestStudentNoCount));
            parameter.Add(DbFactory.CreateDbParameter("@AllotState", model.AllotState));
            parameter.Add(DbFactory.CreateDbParameter("@TestLimit", model.TestLimit));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            parameter.Add(DbFactory.CreateDbParameter("@ID", model.ID));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 更新分配状态
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功</returns>
        public int UpdDStudentTestSetState(string state,int testSetID,string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "UPDATE DStudent_TestSet" + NK;
            strSql.Append(insertTable);
            strSql.Append(@" SET AllotState=@AllotState WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@AllotState", state));
            parameter.Add(DbFactory.CreateDbParameter("@ID", testSetID));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
       

        /// <summary>
        /// 删除学生测试信息
        /// </summary>
        /// <param name="id">id主键</param>
        /// <param name="NK">年库</param>
        /// <returns>返回值>0 成功 </returns>
        public int DelDStudentTestScore(int id, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            List<DbParameter> parameter1 = new List<DbParameter>();
            List<DbParameter> parameter2 = new List<DbParameter>();

            strSql1.Append(" DELETE  DStudent_TestAllot" + NK + " WHERE TestSetID=@ID ");
            parameter1.Add(DbFactory.CreateDbParameter("@ID", id));
            Repository().ExecuteBySql(strSql1, parameter1.ToArray());

            strSql2.Append(" DELETE  DStudent_Test" + NK + " WHERE TestSetID=@ID ");
            parameter2.Add(DbFactory.CreateDbParameter("@ID", id));
            Repository().ExecuteBySql(strSql2, parameter2.ToArray());


            strSql.Append(" DELETE  DStudent_TestSet" + NK + " WHERE ID=@ID ");
            parameter.Add(DbFactory.CreateDbParameter("@ID",id));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
    }
}