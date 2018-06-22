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
    /// ѧ���������ñ�����ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    public class DStudent_TestSetBll : RepositoryFactory<DStudent_TestSet>
    {
        /// <summary>
        /// ��ȡ����������Ϣ
        /// </summary>
        /// <param name="testBeginDate">���Կ�ʼ����</param>
        /// <param name="studentSex">ѧ���Ա� ��1��Ů2</param>
        /// <param name="testBeginTime">���Կ�ʼʱ��</param>
        /// <param name="allotState">����״̬</param>
        /// <param name="testLimit">��������</param>
        /// <param name="NK">���</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <param name="testType">��������</param>
        /// <returns></returns>
        public DataTable GetDStudentInfosList(string testBeginDate, string studentSex, string testBeginTime, string allotState, string testLimit, string NK, ref JqGridParam jqgridparam,string testType)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                         --Id,����
                                d.TestBeginDate,              --��ʼ����
                                d.TestBeginWeek,              --��ʼ����
                                d.TestAddress,                --���Ե�ַ
                                d.StudentSex,                 --ѧ���Ա�
                                d.TestStudentCount,           --��������
                                d.TestBeginTime,              --��ʼ����ʱ��
                                d.TestStudentOkCount,         --��Լ����
                                d.TestStudentNoCount,         --δԼ����
                                d.AllotState,                 --����״̬
                                d.TestLimit,                  --�������ƴ�һ����������������ģ����⣨ȫ���ɲμӣ�
                                d.TestType,                   --�������ͣ�Լ�����ԡ���Ԫ���ԡ�����Լ��
                                d.CreateTime,                 --����ʱ��
                                d.UpdateTime,                 --����ʱ��
                                d.Remark                      --��ע
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
        /// ����id��ȡ������Ϣʵ����
        /// </summary>
        /// <param name="id">id����</param>
        /// <returns>ʵ����</returns>
        public DStudent_TestSet GetDStudentTestSetModel(int id,string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_TestSet" + NK + " WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ��Ӳ���������Ϣ
        /// </summary>
        /// <param name="model">��������ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns>����ֵ>0 �ɹ� </returns>
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
        /// �޸Ĳ���������Ϣ
        /// </summary>
        /// <param name="model">��������ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns>����ֵ>0 �ɹ� </returns>
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
        /// ���·���״̬
        /// </summary>
        /// <param name="state">״̬</param>
        /// <param name="NK">���</param>
        /// <returns>��ֵ>0�ɹ�</returns>
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
        /// ɾ��ѧ��������Ϣ
        /// </summary>
        /// <param name="id">id����</param>
        /// <param name="NK">���</param>
        /// <returns>����ֵ>0 �ɹ� </returns>
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