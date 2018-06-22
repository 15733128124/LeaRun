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
    /// 学生公告表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:05</date>
    /// </author>
    /// </summary>
    public class DStudent_AnnouncementBll : RepositoryFactory<DStudent_Announcement>
    {
        /// <summary>
        /// 获取公告内容
        /// </summary>
        /// <param name="keyvalue">关键字条件</param>
        /// <param name="jqgridparam">JqGrid参数</param>
        /// <returns>数据集</returns>
        public DataTable GetAnnouncementPageList(string keyvalue, ref JqGridParam jqgridparam)
        {           
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                        --Id,主键
                                d.Title,                     --标题
                                d.Content,                   --内容
                                d.ContentState,              --状态
                                d.CreateTime,                --创建时间
                                d.UpdateTime,                --更新时间
                                d.Remark
                                FROM ");
            string sqlTableName = "DStudent_Announcement  d";
            string sqlConditon = " WHERE 1=1";
            strSql.Append(sqlTableName);
            strSql.Append(sqlConditon);
            if (!string.IsNullOrEmpty(keyvalue))
            {
                strSql.Append(@" AND (d.Title LIKE @keyvalue or d.Content LIKE @keyvalue)");
                parameter.Add(DbFactory.CreateDbParameter("@keyvalue", '%' + keyvalue + '%'));
            }        
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="model">公告实体类</param>
        /// <returns>数值>0成功，=0失败</returns>
        public int AddAnnouncement(DStudent_Announcement model)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("INSERT INTO DStudent_Announcement(Title,Content,ContentState,CreateTime,UpdateTime,Remark) VALUES(@Title,@Content,@ContentState,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@Title", model.Title));
            parameter.Add(DbFactory.CreateDbParameter("@Content", model.Content));
            parameter.Add(DbFactory.CreateDbParameter("@ContentState", model.ContentState));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 修改公告
        /// </summary>
        /// <param name="model">公告实体类</param>
        /// <returns>数值>0成功，=0失败</returns>      
        public int UpdAnnouncement(DStudent_Announcement model)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DStudent_Announcement  SET Title=@Title,Content=@Content,UpdateTime=@UpdateTime WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", model.ID));
            parameter.Add(DbFactory.CreateDbParameter("@Title", model.Title));
            parameter.Add(DbFactory.CreateDbParameter("@Content", model.Content));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));    
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 修改公告
        /// </summary>
        /// <param name="id">id主键</param>
        /// <returns>公告实体类</returns>
        public DStudent_Announcement GetAnnouncementModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_Announcement  WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));           
            return Repository().FindEntityBySql(strSql.ToString(),parameter.ToArray());
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="id">id主键</param> 
        /// <returns>数值>0成功，=0失败</returns>
        public int DelAnnoucement(int id )
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("DELETE  DStudent_Announcement  WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
             
    }
}