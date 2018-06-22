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
    /// ѧ������
    /// <author>
    ///		<name>Mr.Huo</name>
    ///		<date>2017.11.13 09:07</date>
    /// </author>
    /// </summary>
    public class DStudent_TestAllotBll : RepositoryFactory<DStudent_TestAllot>
    {
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="sqlWhere">����</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ�</returns>
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
        /// ɾ������
        /// </summary>
        /// <param name="TestSetID">��������ID</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ�</returns>
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
        /// ����Ƿ��Ѿ�����
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
        /// ���ݲ������õ�id��ѯѧ��������Ϣ
        /// </summary>
        /// <param name="testSetID">��������ID</param>
        /// <param name="NK">���</param>
        /// <returns>List����</returns>
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
        /// ѧ������
        /// </summary>
        /// <param name="testSetID">��������ID</param>
        /// <param name="testGroup">������</param>
        /// <param name="groupCount">�������</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ�</returns>
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
        /// ��ѧ��������ʦ
        /// </summary>
        /// <param name="id">����</param>
        /// <param name="testTeacher">������ʦ</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ�</returns>
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