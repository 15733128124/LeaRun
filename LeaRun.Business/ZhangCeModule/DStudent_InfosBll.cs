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
    /// ѧ��������Ϣ������ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:19</date>
    /// </author>
    /// </summary>
    public class DStudent_InfosBll : RepositoryFactory<DStudent_Infos>
    {

        /// <summary>
        /// ѧ����Ϣ
        /// </summary>
        /// <param name="keyvalue">�ؼ�������</param>
        /// <param name="NK">���</param>
        /// <param name="jqgridparam">JqGrid����</param>
        /// <returns>���ݼ�</returns>
        public DataTable GetDStudentInfosList(string keyvalue, string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                        --Id,����
                                d.StudentCode,               --ѧ��ѧ��
                                d.StudentName,               --ѧ������
                                d.StudentSex,                --�Ա�
                                d.StudentBornDate,           --��������
                                d.StudentHomeAddress,        --ѧ��סַ
                                d.GradeCode,                 --�꼶���
                                d.SchoolName,                --ѧԺ����
                                d.SchoolCode,                --ѧԺ���
                                d.ClassName,                 --�༶����
                                d.ClassCode,                 --�༶���
                                d.NationCode,                --������
                                d.NationName,                --��������
                                d.StudentNative,             --ѧ������
                                d.StudentMoveType,           --�춯����
                                d.StudentIDNumber,           --ѧ�����֤��                                
                                d.StudentPhone,              --ѧ���绰
                                d.StudentIsRegister,         --�Ƿ�ע��
                                d.CreateTime,                --����ʱ��
                                d.UpdateTime,                --����ʱ��
                                d.Remark                     --��ע
                                FROM ");
            string sqlTableName = "DStudent_Infos" + NK + " d";
            string sqlConditon = " WHERE 1=1";
            strSql.Append(sqlTableName);
            strSql.Append(sqlConditon);
            if (!string.IsNullOrEmpty(keyvalue))
            {
                strSql.Append(@" AND d.StudentCode LIKE @keyvalue");
                parameter.Add(DbFactory.CreateDbParameter("@keyvalue", '%' + keyvalue + '%'));
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }

        /// <summary>
        /// ���ѧ����Ϣ
        /// </summary>
        /// <param name="model">ѧ��ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns></returns>
        public int AddDStudentInfo(DStudent_Infos model, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "INSERT INTO DStudent_Infos" + NK;
            strSql.Append(insertTable);
            strSql.Append(@"(StudentCode,StudentName,StudentSex,StudentBornDate,StudentHomeAddress,GradeCode,
            SchoolName,SchoolCode,ClassName,ClassCode,NationCode,NationName,StudentNative,StudentMoveType,StudentIDNumber,StudentPhone,StudentIsRegister,CreateTime,UpdateTime,Remark)
            VALUES(@StudentCode,@StudentName,@StudentSex,@StudentBornDate,@StudentHomeAddress,@GradeCode,
            @SchoolName,@SchoolCode,@ClassName,@ClassCode ,@NationCode,@NationName,@StudentNative,@StudentMoveType,
            @StudentIDNumber,@StudentPhone,@StudentIsRegister,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@StudentName", model.StudentName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@StudentBornDate", model.StudentBornDate));
            parameter.Add(DbFactory.CreateDbParameter("@StudentHomeAddress", model.StudentHomeAddress));
            parameter.Add(DbFactory.CreateDbParameter("@GradeCode", model.GradeCode));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolName", model.SchoolName));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolCode", model.SchoolCode));
            parameter.Add(DbFactory.CreateDbParameter("@ClassName", model.ClassName));
            parameter.Add(DbFactory.CreateDbParameter("@ClassCode", model.ClassCode));
            parameter.Add(DbFactory.CreateDbParameter("@NationCode", model.NationCode));
            parameter.Add(DbFactory.CreateDbParameter("@NationName", model.NationName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentNative", model.StudentNative));
            parameter.Add(DbFactory.CreateDbParameter("@StudentMoveType", model.StudentMoveType));
            parameter.Add(DbFactory.CreateDbParameter("@StudentIDNumber", model.StudentIDNumber));
            parameter.Add(DbFactory.CreateDbParameter("@StudentPhone", model.StudentPhone));
            parameter.Add(DbFactory.CreateDbParameter("@StudentIsRegister", model.StudentIsRegister));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
        /// <summary>
        /// �޸�ѧ����Ϣ
        /// </summary>
        /// <param name="model">ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns>����ֵ >0 �ɹ�</returns>
        public int UpdDStudentInfo(DStudent_Infos model, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            string insertTable = "UPDATE DStudent_Infos" + NK;
            strSql.Append(insertTable);
            strSql.Append(@" SET StudentName=@StudentName,StudentSex=@StudentSex,StudentBornDate=@StudentBornDate,StudentHomeAddress=@StudentHomeAddress,GradeCode=@GradeCode,
            SchoolName=@SchoolName,SchoolCode=@SchoolCode,ClassName=@ClassName,ClassCode=@ClassCode,NationCode=@NationCode,NationName=@NationName,StudentNative=@StudentNative,
            StudentMoveType=@StudentMoveType,StudentIDNumber=@StudentIDNumber,StudentPhone=@StudentPhone,StudentIsRegister=@StudentIsRegister,
            UpdateTime=@UpdateTime,Remark=@Remark WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@StudentName", model.StudentName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@StudentBornDate", model.StudentBornDate));
            parameter.Add(DbFactory.CreateDbParameter("@StudentHomeAddress", model.StudentHomeAddress));
            parameter.Add(DbFactory.CreateDbParameter("@GradeCode", model.GradeCode));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolName", model.SchoolName));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolCode", model.SchoolCode));
            parameter.Add(DbFactory.CreateDbParameter("@ClassName", model.ClassName));
            parameter.Add(DbFactory.CreateDbParameter("@ClassCode", model.ClassCode));
            parameter.Add(DbFactory.CreateDbParameter("@NationCode", model.NationCode));
            parameter.Add(DbFactory.CreateDbParameter("@NationName", model.NationName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentNative", model.StudentNative));
            parameter.Add(DbFactory.CreateDbParameter("@StudentMoveType", model.StudentMoveType));
            parameter.Add(DbFactory.CreateDbParameter("@StudentIDNumber", model.StudentIDNumber));
            parameter.Add(DbFactory.CreateDbParameter("@StudentPhone", model.StudentPhone));
            parameter.Add(DbFactory.CreateDbParameter("@StudentIsRegister", model.StudentIsRegister));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// �����Ϣ�Ƿ����
        /// </summary>
        /// <returns></returns>
        public int CheckStudentInfoRepeat(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT COUNT(*) FROM ");
            string checkTable = "DStudent_Infos" + NK;
            strSql.Append(checkTable);
            strSql.Append(@" WHERE StudentCode=@StudentCode");
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ��ȡѧ��model
        /// </summary>
        /// <param name="studentCode"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public DStudent_Infos GetDStudentInfosModel(string studentCode, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_Infos" + NK + " WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ɾ��ѧ��
        /// </summary>
        /// <param name="id">����</param> 
        /// <param name="NK">�������</param>
        /// <returns>��ֵ>0�ɹ���=0ʧ��</returns>
        public int DelDStudentInfos(int id,string NK)
        {
            DStudent_TestScoreBll tsBll = new DStudent_TestScoreBll();
            tsBll.DeleteStudentTestScoreByStudentCode(GetDStudentInfosModelById(id,NK).StudentCode, NK);
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("DELETE  DStudent_Infos" + NK + " WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());

        }

        /// <summary>
        /// ����ID��ȡʵ����
        /// </summary>
        /// <param name="Id">ID</param>
        /// <param name="NK">���</param>
        /// <returns></returns>
        public DStudent_Infos GetDStudentInfosModelById(int id, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM DStudent_Infos" + NK + " WHERE ID=@ID");
            parameter.Add(DbFactory.CreateDbParameter("@ID", id));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="model">ʵ����</param>
        /// <param name="NK">���</param>
        /// <returns></returns>
        public int AddDStudentImport(DStudent_Infos model, string NK)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@StudentName", model.StudentName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentSex", model.StudentSex));
            parameter.Add(DbFactory.CreateDbParameter("@StudentBornDate", model.StudentBornDate));
            parameter.Add(DbFactory.CreateDbParameter("@StudentHomeAddress", model.StudentHomeAddress));
            parameter.Add(DbFactory.CreateDbParameter("@GradeCode", model.GradeCode));
            parameter.Add(DbFactory.CreateDbParameter("@SchoolName", model.SchoolName));
           // parameter.Add(DbFactory.CreateDbParameter("@SchoolCode", model.SchoolCode));
            parameter.Add(DbFactory.CreateDbParameter("@ClassName", model.ClassName));
            //parameter.Add(DbFactory.CreateDbParameter("@ClassCode", model.ClassCode));
           // parameter.Add(DbFactory.CreateDbParameter("@NationCode", model.NationCode));
            parameter.Add(DbFactory.CreateDbParameter("@NationName", model.NationName));
            parameter.Add(DbFactory.CreateDbParameter("@StudentNative", model.StudentNative));
            parameter.Add(DbFactory.CreateDbParameter("@StudentMoveType", model.StudentMoveType));
            parameter.Add(DbFactory.CreateDbParameter("@StudentIDNumber", model.StudentIDNumber));
            parameter.Add(DbFactory.CreateDbParameter("@StudentPhone", model.StudentPhone));
            parameter.Add(DbFactory.CreateDbParameter("@StudentIsRegister", model.StudentIsRegister));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime",System.DateTime.Now.ToString()));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", System.DateTime.Now.ToString()));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", ""));
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            DbParameter result = DbFactory.CreateDbOutParameter("@Result", 4);
            parameter.Add(result);
            Repository().ExecuteByProc("Proc_AddDStudentInfoImport", parameter.ToArray());
            return Convert.ToInt32(result.Value);
        }

        /// <summary>
        /// ���ѧ��������Ϣ�������û����༶�ϱ�
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int DelStudentInfoAll(string NK)
        {
            List<DbParameter> parameter = new List<DbParameter>();           
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            DbParameter result = DbFactory.CreateDbOutParameter("@Result", 4);
            parameter.Add(result);
            Repository().ExecuteByProc("Proc_DelDStudentInfoAll", parameter.ToArray());
            return Convert.ToInt32(result.Value);
        }
    }
}