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
    /// 班级表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:17</date>
    /// </author>
    /// </summary>
    public class DStudent_ClassBll : RepositoryFactory<DStudent_Class>
    {
        /// <summary>
        /// 根据年级编号查询学校名称
        /// type:1(查找所有学院)2:(根据年级查学院)
        /// </summary>
        /// <param name="gradecode">年级编号</param>
        /// <param name="type"> type:1(查找所有学院)2:(根据年级查学院)</param>
        /// <param name="NK">年库</param>
        /// <returns>数据集</returns>
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
        /// 根据学院编号查询班级名称
        /// type:1(查找所有班级)2:(根据学院查班级)
        /// </summary>
        /// <param name="schoolcode">学院编号</param>
        /// <param name="type">type:1(查找所有班级)2:(根据学院查班级)</param>
        /// <param name="NK">年库</param>
        /// <returns>数据集</returns>
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
        /// 获取所有班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStudentClassInfoDataTable(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM DStudent_Class" + NK);
            return Repository().FindTableBySql(strSql.ToString());
        }

        /// <summary>
        /// 获取所有班级信息
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