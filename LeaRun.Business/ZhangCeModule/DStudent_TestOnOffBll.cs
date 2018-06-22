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
    /// 测试开关（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    public class DStudent_TestOnOffBll : RepositoryFactory<DStudent_TestOnOff>
    {
        /// <summary>
        /// 添加测试学生的信息
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
        /// 根据测试类型修改学生开关状态信息1：开启，0：关闭
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
        ///// 查询该条限制信息是否存在
        ///// </summary>
        ///// <param name="testType">约考测试、补测约考、单元测试</param>
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
        /// 如果测试类型为：40（不限）查询是否初始化权限,不等于4是未初始化权限
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
        /// 初始化学生权限如果返回值为：4 则初始化成功
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
        /// 获取所有设置学生开关权限的信息
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