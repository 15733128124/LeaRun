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
    /// �༶������ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:17</date>
    /// </author>
    /// </summary>
    public class DStudent_ClassBll : RepositoryFactory<DStudent_Class>
    {
        /// <summary>
        /// �����꼶��Ų�ѯѧУ����
        /// type:1(��������ѧԺ)2:(�����꼶��ѧԺ)
        /// </summary>
        /// <param name="gradecode">�꼶���</param>
        /// <param name="type"> type:1(��������ѧԺ)2:(�����꼶��ѧԺ)</param>
        /// <param name="NK">���</param>
        /// <returns>���ݼ�</returns>
        public DataTable GetAllSchoolInfoByGradeCode(string gradecode, int type, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            if (type == 1)
            {
                strSql.Append("SELECT DISTINCT SchoolName,SchoolCode FROM DStudent_Class" + NK);
               
            }
            if (type == 2)
            {
                strSql.Append("SELECT DISTINCT SchoolName,SchoolCode FROM  DStudent_Class" + NK + " WHERE  GradeCode=@GradeCode");
                parameter.Add(DbFactory.CreateDbParameter("@GradeCode", gradecode));
            }
            return Repository().FindTableBySql(strSql.ToString(),parameter.ToArray());
        }

        /// <summary>
        /// ����ѧԺ��Ų�ѯ�༶����
        /// type:1(�������а༶)2:(����ѧԺ��༶)
        /// </summary>
        /// <param name="schoolcode">ѧԺ���</param>
        /// <param name="type">type:1(�������а༶)2:(����ѧԺ��༶)</param>
        /// <param name="NK">���</param>
        /// <returns>���ݼ�</returns>
        public DataTable GetAllClassInfoBySchoolCode(string schoolcode, int type, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            if (type == 1)
            {
                strSql.Append("SELECT DISTINCT  ClassName,ClassCode FROM DStudent_Class" + NK);

            }
            if (type == 2)
            {
                strSql.Append("SELECT DISTINCT ClassName,ClassCode FROM  DStudent_Class" + NK + " WHERE  SchoolCode=@SchoolCode");
                parameter.Add(DbFactory.CreateDbParameter("@SchoolCode", schoolcode));
            }
            return Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ��ȡ���а༶��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStudentClassInfoDataTable(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM DStudent_Class" + NK);
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// ��ȡ���а༶��Ϣ
        /// </summary>
        /// <returns></returns>
        public List<DStudent_Class> GetAllStudentClassInfoList(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM DStudent_Class" + NK);
            return Repository().FindListBySql(strSql.ToString());
        }
    }
}