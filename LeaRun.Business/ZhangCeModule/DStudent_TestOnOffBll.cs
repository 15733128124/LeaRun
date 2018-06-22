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
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ���Կ��أ�����ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    public class DStudent_TestOnOffBll : RepositoryFactory<DStudent_TestOnOff>
    {
        /// <summary>
        /// ��Ӳ���ѧ������Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int AddDStudentTestOnOff(DStudent_TestOnOff model, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("INSERT INTO DStudent_TestOnOff" + NK + " (State,TestType,GradeCode,CreateTime,UpdateTime,Remark) VALUES(@State,@TestType,@GradeCode,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@State", model.State));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@GradeCode", model.GradeCode));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// ���ݲ��������޸�ѧ������״̬��Ϣ1��������0���ر�
        /// </summary>
        /// <param name="model"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int UpdDStudentTestOnOff(DStudent_TestOnOff model, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DStudent_TestOnOff" + NK + " SET State=@State,CreateTime=@CreateTime,UpdateTime=@UpdateTime,Remark=@Remark WHERE TestType=@TestType ");
            if (model.GradeCode != "40")
            {
                strSql.Append("and GradeCode = @GradeCode");
                parameter.Add(DbFactory.CreateDbParameter("@GradeCode", model.GradeCode));
            }
            parameter.Add(DbFactory.CreateDbParameter("@State", model.State));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        ///// <summary>
        ///// ��ѯ����������Ϣ�Ƿ����
        ///// </summary>
        ///// <param name="testType">Լ�����ԡ�����Լ������Ԫ����</param>
        ///// <param name="NK"></param>
        ///// <returns></returns>
        //public DStudent_TestOnOff GetModelDStudentTestOnOff(string testType, string gradeCode, string NK)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    List<DbParameter> parameter = new List<DbParameter>();
        //    strSql.Append("select * from DStudent_TestOnOff" + NK + " WHERE TestType=@TestType");
        //    strSql.Append(" and GradeCode=@GradeCode");
        //    parameter.Add(DbFactory.CreateDbParameter("@GradeCode", gradeCode));
        //    parameter.Add(DbFactory.CreateDbParameter("@TestType", testType));
        //    return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        //}

        /// <summary>
        /// �����������Ϊ��40�����ޣ���ѯ�Ƿ��ʼ��Ȩ��,������4��δ��ʼ��Ȩ��
        /// </summary>
        /// <param name="testType"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int SelectCountStudentTestOnOff(string testType, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select Count(*) from DStudent_TestOnOff" + NK + " WHERE TestType=@TestType");
            parameter.Add(DbFactory.CreateDbParameter("@TestType", testType));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());

        }

        /// <summary>
        /// ��ʼ��ѧ��Ȩ���������ֵΪ��4 ���ʼ���ɹ�
        /// </summary>
        /// <param name="testType"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int UnitStudentTestLimit(string testType,string NK)
        {
            int m = 0;
            for (int i = 41; i < 45; i++)
            {
                if (AddDStudentTestOnOff(new DStudent_TestOnOff
                {
                    State = "0",
                    TestType = testType,
                    GradeCode = i.ToString(),
                    CreateTime = System.DateTime.Now.ToString(),
                    UpdateTime = System.DateTime.Now.ToString(),
                    Remark = ""
                }, NK) > 0)
                {
                    m = m + 1;
                    continue;
                }
            }
            return m;
        }

        /// <summary>
        /// ��ȡ��������ѧ������Ȩ�޵���Ϣ
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public List<DStudent_TestOnOff> GetListDStudentTestOnOff(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select* from DStudent_TestOnOff" + NK+" order by gradecode");
            return Repository().FindListBySql(strSql.ToString());
        }
    }
}