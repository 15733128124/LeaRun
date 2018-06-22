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
    /// 学生基本信息表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:19</date>
    /// </author>
    /// </summary>
    public class DStudent_InfosBll : RepositoryFactory<DStudent_Infos>
    {

        /// <summary>
        /// 学生信息
        /// </summary>
        /// <param name="keyvalue">关键字条件</param>
        /// <param name="NK">年库</param>
        /// <param name="jqgridparam">JqGrid参数</param>
        /// <returns>数据集</returns>
        public DataTable GetDStudentInfosList(string keyvalue, string NK, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT 
                                d.ID,                        --Id,主键
                                d.StudentCode,               --学生学号
                                d.StudentName,               --学生姓名
                                d.StudentSex,                --性别
                                d.StudentBornDate,           --出生日期
                                d.StudentHomeAddress,        --学生住址
                                d.GradeCode,                 --年级编号
                                d.SchoolName,                --学院名称
                                d.SchoolCode,                --学院编号
                                d.ClassName,                 --班级名称
                                d.ClassCode,                 --班级编号
                                d.NationCode,                --民族编号
                                d.NationName,                --民族名称
                                d.StudentNative,             --学生籍贯
                                d.StudentMoveType,           --异动类型
                                d.StudentIDNumber,           --学生身份证号                                
                                d.StudentPhone,              --学生电话
                                d.StudentIsRegister,         --是否注册
                                d.CreateTime,                --创建时间
                                d.UpdateTime,                --更新时间
                                d.Remark                     --备注
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
        /// 添加学生信息
        /// </summary>
        /// <param name="model">学生实体类</param>
        /// <param name="NK">年库</param>
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
        /// 修改学生信息
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="NK">年库</param>
        /// <returns>返回值 >0 成功</returns>
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
        /// 检查信息是否存在
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
        /// 获取学生model
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
        /// 删除学生
        /// </summary>
        /// <param name="id">主键</param> 
        /// <param name="NK">所属年份</param>
        /// <returns>数值>0成功，=0失败</returns>
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
        /// 根据ID获取实体类
        /// </summary>
        /// <param name="Id">ID</param>
        /// <param name="NK">年库</param>
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
        /// 导入
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="NK">年库</param>
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
        /// 清空学生基本信息，包括用户，班级上报
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