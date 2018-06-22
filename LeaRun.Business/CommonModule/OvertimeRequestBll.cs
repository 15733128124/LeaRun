//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2015
// Software Developers @ Learun 2015
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
    /// 加班申请表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2015.07.21 09:59</date>
    /// </author>
    /// </summary>
    public class OvertimeRequestBll : RepositoryFactory<OvertimeRequest>
    {
        public DataTable GetMemberList(string DepartmentId) {
            StringBuilder sql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            sql.Append(@"SELECT  r.UserId ,				--用户ID
                                 r.RealName             --用户姓名
                            FROM    Base_User r
                            WHERE 1 = 1");
            if (!string.IsNullOrEmpty(DepartmentId))
            {
                sql.Append(" AND r.DepartmentId = @DepartmentId");
                parameter.Add(DbFactory.CreateDbParameter("@DepartmentId", DepartmentId));
            }
            return Repository().FindTableBySql(sql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 成员列表
        /// </summary>
        /// <param name="CompanyId">公司ID</param>
        /// <param name="DepartmentId">部门ID</param>
        /// <param name="ObjectId">对象主键</param>
        /// <param name="Category">对象分类:1-部门2-角色3-岗位4-群组</param>
        /// <returns></returns>
        public DataTable GetList(string CompanyId, string DepartmentId)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    u.UserId ,				--用户ID
                                                u.Account ,				--账户
                                                u.RealName ,			--姓名
                                                u.Code ,				--工号
                                                u.Gender ,				--性别
                                                u.CompanyId ,			--公司ID
                                                u.DepartmentId ,		--部门ID
                                                u.SortCode  			--排序码
                                      FROM      Base_User u
                                    ) T WHERE 1=1");
            if (!string.IsNullOrEmpty(CompanyId))
            {
                strSql.Append(" AND CompanyId = @CompanyId");
                parameter.Add(DbFactory.CreateDbParameter("@CompanyId", CompanyId));
            }
            if (!string.IsNullOrEmpty(DepartmentId))
            {
                strSql.Append(" AND DepartmentId = @DepartmentId");
                parameter.Add(DbFactory.CreateDbParameter("@DepartmentId", DepartmentId));
            }
            
            strSql.Append(" ORDER BY SortCode ASC");
            return Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 加班申请列表
        /// </summary>
        public DataTable GetPageList(string keywords, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT a.OvertimeId,
                                         (select FullName from Base_DataDictionaryDetail where Code=a.Type and DataDictionaryId=
                                            (select DataDictionaryId from Base_DataDictionary where Code='Overtime')) AS Type,
                                         a.Date,a.StartTime,a.EndTime,
                                         (select FullName from Base_DataDictionaryDetail where Code=a.Time and DataDictionaryId=
                                            (select DataDictionaryId from Base_DataDictionary where Code='OvertimeLong')) AS Time,
                                         b.FullName as DepartmentName,c.RealName as UserName,
                                         d.FullName as CreatDepartmentName,e.RealName as CreatUserName,a.CreateTime
                                         from OvertimeRequest a 
                                         inner join Base_Department b on a.DepartmentId=b.DepartmentId
                                         inner join Base_User c on a.UserId=c.UserId
                                         left join Base_Department d on a.CreateDepartmentId=d.DepartmentId
                                         left join Base_User e on a.CreateUserId=e.UserId
                                    ) T WHERE 1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                strSql.Append(@" AND (UserName LIKE @keyword)");
                parameter.Add(DbFactory.CreateDbParameter("@keyword", '%' + keywords + '%'));
            }
            //if (!ManageProvider.Provider.Current().IsSystem)
            //{
            //    strSql.Append(" AND ( UserId IN ( SELECT ResourceId FROM Base_DataScopePermission WHERE");
            //    strSql.Append(" ObjectId IN ('" + ManageProvider.Provider.Current().ObjectId.Replace(",", "','") + "') ");
            //    strSql.Append(" ) )");
            //}
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

    }
}