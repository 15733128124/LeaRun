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
    /// ѧ�����������ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:05</date>
    /// </author>
    /// </summary>
    public class DStudent_AnnouncementBll : RepositoryFactory<DStudent_Announcement>
    {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="keyvalue">�ؼ�������</param>
        /// <param name="jqgridparam">JqGrid����</param>
        /// <returns>���ݼ�</returns>
        public DataTable GetAnnouncementPageList(string keyvalue, ref JqGridParam jqgridparam)
        {           
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                        --Id,����
                                d.Title,                     --����
                                d.Content,                   --����
                                d.ContentState,              --״̬
                                d.CreateTime,                --����ʱ��
                                d.UpdateTime,                --����ʱ��
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
        /// ��ӹ���
        /// </summary>
        /// <param name="model">����ʵ����</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
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
        /// �޸Ĺ���
        /// </summary>
        /// <param name="model">����ʵ����</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>      
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
        /// �޸Ĺ���
        /// </summary>
        /// <param name="id">id����</param>
        /// <returns>����ʵ����</returns>
        public DStudent_Announcement GetAnnouncementModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_Announcement  WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));           
            return Repository().FindEntityBySql(strSql.ToString(),parameter.ToArray());
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="id">id����</param> 
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
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