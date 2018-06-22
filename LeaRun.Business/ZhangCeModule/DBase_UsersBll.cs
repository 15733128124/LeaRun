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
    /// ѧ���û���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:13</date>
    /// </author>
    /// </summary>
    public class DBase_UsersBll : RepositoryFactory<DBase_Users>
    {
        #region ѧ��

        /// <summary>
        /// ���ѧ����¼�û�
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public int AddDBase_User(string userCode, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"INSERT INTO  DBase_Users([UserName],[UserCode],[UserPassword],[UserLeavel],[CreateTime],[UpdateTime],[Remark],[UserState]) 
                            VALUES(@UserName,@UserCode,@UserPassword,@UserLeavel,@CreateTime,@UpdateTime,@Remark,@UserState)");
            parameter.Add(DbFactory.CreateDbParameter("@UserName", userCode));
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", userCode));
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", userPassword));
            parameter.Add(DbFactory.CreateDbParameter("@UserLeavel", "2"));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", System.DateTime.Now.ToString()));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", System.DateTime.Now.ToString()));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", ""));
            parameter.Add(DbFactory.CreateDbParameter("@UserState", "0"));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
        /// <summary>
        /// �޸�ѧ������
        /// </summary>
        /// <param name="userPassword">������</param>
        /// <param name="userCode">ѧ��ѧ��</param>
        /// <returns></returns>
        public int UpdDBase_UsersPwd(string userCode, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DBase_Users SET UserPassword=@UserPassword,UpdateTime=@UpdateTime WHERE UserCode=@UserCode and UserLeavel='2'");
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", userPassword));
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", userCode));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", System.DateTime.Now));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        #endregion


        #region ����
        /// <summary>
        /// �޸Ŀ�������:userLeavel=3
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userPassword"></param>
        /// <param name="oldNKMark"></param>
        /// <returns></returns>
        public int UpdDNKKouLing(string userCode, string userPassword, string oldNKMark)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DBase_Users SET UserPassword=@UserPassword,UpdateTime=@UpdateTime WHERE UserCode=@UserCode And UserPassword=@oldNKMark and UserLeavel='3'");
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", userPassword));
            parameter.Add(DbFactory.CreateDbParameter("@oldNKMark", oldNKMark));
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", userCode));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", System.DateTime.Now));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
        /// <summary>
        /// �����˻��Ƿ���������Ȩ��
        /// </summary>
        /// <param name="account">�˻�</param>
        /// <param name="kouLing">����</param>
        /// <returns></returns>
        public int CheckNKKouLing(string account, string kouLing)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT COUNT(*) from DBase_Users where UserLeavel='3' AND UserCode=@UserCode AND  UserPassword=@UserPassword");
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", account));
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", kouLing));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ����Ա���ÿ���
        /// </summary>
        /// <param name="account"></param>
        /// <param name="kouLing"></param>
        /// <returns></returns>
        public int AdminResetKouLing(string account, string kouLing)
        {
            DelKouLing();//��ɾ���������ӿ���
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"INSERT INTO  DBase_Users([UserName],[UserCode],[UserPassword],[UserLeavel],[CreateTime],[UpdateTime],[Remark],[UserState]) 
                            VALUES(@UserName,@UserCode,@UserPassword,@UserLeavel,@CreateTime,@UpdateTime,@Remark,@UserState)");
            parameter.Add(DbFactory.CreateDbParameter("@UserName", account));
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", account));
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", kouLing));
            parameter.Add(DbFactory.CreateDbParameter("@UserLeavel", "3"));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", System.DateTime.Now.ToString()));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", System.DateTime.Now.ToString()));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", ""));
            parameter.Add(DbFactory.CreateDbParameter("@UserState", "0"));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        //ɾ������
        private int DelKouLing()
        {

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"delete  DBase_Users where UserLeavel='3'");
            return Repository().ExecuteBySql(strSql);
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <returns></returns>
        public DBase_Users GetKouLingModel()
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * from DBase_Users where UserLeavel='3'");
            return Repository().FindEntityBySql(strSql.ToString());
        }

        #endregion


        #region ��ʦ

        /// <summary>
        /// �����ʦ��Ϣ
        /// </summary>
        /// <param name="userCode">��ʦ���ţ�����</param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public int AddDBase_UserTeacher(string userName, string userCode, string userPassword)
        {
            int n = 0;
            if (FindUserCodeRepeat(userCode) <= 0)
            {
                StringBuilder strSql = new StringBuilder();
                List<DbParameter> parameter = new List<DbParameter>();
                strSql.Append(@"INSERT INTO  DBase_Users([UserName],[UserCode],[UserPassword],[UserLeavel],[CreateTime],[UpdateTime],[Remark],[UserState]) 
                            VALUES(@UserName,@UserCode,@UserPassword,@UserLeavel,@CreateTime,@UpdateTime,@Remark,@UserState)");
                parameter.Add(DbFactory.CreateDbParameter("@UserName", userName));
                parameter.Add(DbFactory.CreateDbParameter("@UserCode", userCode));
                parameter.Add(DbFactory.CreateDbParameter("@UserPassword", userPassword));
                parameter.Add(DbFactory.CreateDbParameter("@UserLeavel", "1"));
                parameter.Add(DbFactory.CreateDbParameter("@CreateTime", System.DateTime.Now.ToString()));
                parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", System.DateTime.Now.ToString()));
                parameter.Add(DbFactory.CreateDbParameter("@Remark", ""));
                parameter.Add(DbFactory.CreateDbParameter("@UserState", "0"));
                n = Repository().ExecuteBySql(strSql, parameter.ToArray());
            }
            return n;
        }


        /// <summary>
        /// �޸���ʦ������Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdDBase_UserTeacber(DBase_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"UPDATE  DBase_Users SET [UserName]=@UserName,[UserCode]=@UserCode,[UserPassword]=@UserPassword,[UserLeavel]=@UserLeavel,[CreateTime]=@CreateTime,[UpdateTime]=@UpdateTime,[Remark]=@Remark,[UserState]=@UserState
                           WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", model.ID));
            parameter.Add(DbFactory.CreateDbParameter("@UserName", model.UserName));
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", model.UserCode));
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", model.UserPassword));
            parameter.Add(DbFactory.CreateDbParameter("@UserLeavel", model.UserLeavel));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            parameter.Add(DbFactory.CreateDbParameter("@UserState", model.UserState));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// ��ȡ���е���ʦ��Ϣ
        /// </summary>
        /// <param name="keyvalue"></param>
        /// <param name="jqgridparam"></param>
        /// <returns></returns>
        public DataTable GetTeacherPageList(string keyvalue, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT *  FROM DBase_Users d WHERE UserLeavel='1'");
            if (!string.IsNullOrEmpty(keyvalue))
            {
                strSql.Append(@" AND d.UserCode LIKE @keyvalue ");
                parameter.Add(DbFactory.CreateDbParameter("@keyvalue", '%' + keyvalue + '%'));
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// ��ѯ�����Ƿ���ڸ���ʦ����
        /// </summary>
        /// <param name="userCode">��ʦ����</param>
        /// <returns></returns>
        public int FindUserCodeRepeat(string userCode)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT COUNT(*) from DBase_Users where UserLeavel='1' AND UserCode=@UserCode");
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", userCode));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ��ȡ��ʦ����
        /// </summary>
        /// <returns>list����</returns>
        public List<DBase_Users> GetTeacherName()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM DBase_Users WHERE UserLeavel='1'");
            return Repository().FindListBySql(strSql.ToString());

        }

        /// <summary>
        /// ��ʦ��¼
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public DBase_Users TeacherLogin(string userName, string userPwd)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * from DBase_Users where UserLeavel='1' AND UserCode=@UserCode AND  UserPassword=@UserPassword");
            parameter.Add(DbFactory.CreateDbParameter("@UserCode", userName));
            parameter.Add(DbFactory.CreateDbParameter("@UserPassword", userPwd));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }


        #endregion

        /// <summary>
        /// ����ID��ȡ��Ϣ
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DBase_Users GetBaseInfoByID(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * from DBase_Users where ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", ID));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DelTeacherMessage(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("Delete DBase_Users where ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", ID));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }


    }
}