//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2017
// Software Developers @ Learun 2017
//=====================================================================================

using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// 学生分配
    /// <author>
    ///		<name>Mr.Huo</name>
    ///		<date>2017.11.13 09:07</date>
    /// </author>
    /// </summary>
    public class DStudent_TestAllotBll : RepositoryFactory<DStudent_TestAllot>
    {
        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="sqlWhere">条件</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功</returns>
        public int AddDStudentTestAllot(string sqlWhere, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            string insertTable = "INSERT INTO DStudent_TestAllot" + NK;
            strSql.Append(insertTable);
            strSql.Append(@"(TestSetID,TestGroup,GroupCount,BeginPraDate,BeginWeek,BeginPraTime,TestTeacher,Remark)");
            strSql.Append(sqlWhere);
            return Repository().ExecuteBySql(strSql);
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="TestSetID">测试设置ID</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功</returns>
        public int DelDStudentTestAllotByTestSetID(int testSetID, string NK)
        {
            StringBuilder strUpdTestSql = new StringBuilder();
            List<DbParameter> parameterTest = new List<DbParameter>();
            strUpdTestSql.Append("UPDATE DStudent_Test" + NK + " SET TestTeacher='',TestGroup='',TestGroupCode='' WHERE TestSetID=@TestSetID");
            parameterTest.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            try
            {
                int isOk = Repository().ExecuteBySql(strUpdTestSql, parameterTest.ToArray());
            }
            catch
            {
                return 0;
            }

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("DELETE  DStudent_TestAllot" + NK + " WHERE TestSetID=@TestSetID");
            parameter.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());


        }

        /// <summary>
        /// 检查是否已经分组
        /// </summary>
        /// <param name="studentCode"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int CheckDStudentTestAllotRepeat(string testSetID, string NK)
        {

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT COUNT(*) FROM  DStudent_TestAllot" + NK + " WHERE TestSetID=@TestSetID");
            parameter.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 根据测试设置的id查询学生分配信息
        /// </summary>
        /// <param name="testSetID">测试设置ID</param>
        /// <param name="NK">年库</param>
        /// <returns>List集合</returns>
        public List<DStudent_TestAllot> GetDStudentTestAllotListByTestSetID(string testSetID, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM " + "DStudent_TestAllot" + NK);
            string sqlConditon = " WHERE TestSetID=@TestSetID";
            strSql.Append(sqlConditon);
            parameter.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            return Repository().FindListBySql(strSql.ToString(), parameter.ToArray());
        }
        
        /// <summary>
        /// 学生分组
        /// </summary>
        /// <param name="testSetID">测试设置ID</param>
        /// <param name="testGroup">所属组</param>
        /// <param name="groupCount">所属序号</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功</returns>
        public int AllotGroup(int testSetID, string testGroup, int testGroupCode, string NK)
        {
            StringBuilder strUpdTestSql = new StringBuilder();
            List<DbParameter> parameterTest = new List<DbParameter>();
            strUpdTestSql.Append("UPDATE dbo.DStudent_Test" + NK + " SET TestGroup=@TestGroup,TestGroupCode=@TestGroupCode WHERE TestSetID=@TestSetID AND ID in (SELECT TOP 1 ID FROM DStudent_Test" + NK + " WHERE TestGroup='' and TestSetID=@TestSetID)");
            parameterTest.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            parameterTest.Add(DbFactory.CreateDbParameter("@TestGroup", testGroup));
            parameterTest.Add(DbFactory.CreateDbParameter("@TestGroupCode", testGroupCode));
            return Repository().ExecuteBySql(strUpdTestSql, parameterTest.ToArray());

        }
        /// <summary>
        /// 给学生分配老师
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="testTeacher">测试老师</param>
        /// <param name="NK">年库</param>
        /// <returns>数值>0成功</returns>
        public int AllotTeacher(int testSetID, string testGroup, int groupCount, string testTeacher, string NK)
        {
            StringBuilder strUpdTestAllotSql = new StringBuilder();
            List<DbParameter> parameterTestAllot = new List<DbParameter>();
            strUpdTestAllotSql.Append("UPDATE dbo.DStudent_TestAllot" + NK + " SET TestTeacher=@TestTeacher WHERE TestSetID=@TestSetID and TestGroup=@TestGroup and GroupCount=@GroupCount");
            parameterTestAllot.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            parameterTestAllot.Add(DbFactory.CreateDbParameter("@TestTeacher", testTeacher));
            parameterTestAllot.Add(DbFactory.CreateDbParameter("@TestGroup", testGroup));
            parameterTestAllot.Add(DbFactory.CreateDbParameter("@GroupCount", groupCount));
            StringBuilder strUpdTestSql = new StringBuilder();
            List<DbParameter> parameterTest = new List<DbParameter>();
            strUpdTestSql.Append("UPDATE dbo.DStudent_Test" + NK + " SET TestTeacher=@TestTeacher WHERE TestSetID=@TestSetID and TestGroup=@TestGroup");
            parameterTest.Add(DbFactory.CreateDbParameter("@TestSetID", testSetID));
            parameterTest.Add(DbFactory.CreateDbParameter("@TestTeacher", testTeacher));
            parameterTest.Add(DbFactory.CreateDbParameter("@TestGroup", testGroup));
            Repository().ExecuteBySql(strUpdTestSql, parameterTest.ToArray());
            return Repository().ExecuteBySql(strUpdTestAllotSql, parameterTestAllot.ToArray());
        }
    }
}