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
    /// 老师测试开关（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:21</date>
    /// </author>
    /// </summary>
    public class DTecher_TestOnOffBll : RepositoryFactory<DTecher_TestOnOff>
    {
        /// <summary>
        /// 添加测试老师的信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int AddDTeacherTestOnOff(DTecher_TestOnOff model, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("INSERT INTO DTecher_TestOnOff"+NK+ " (State,TestType,CreateTime,UpdateTime,Remark) VALUES(@State,@TestType,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@State", model.State));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 根据测试类型修改老师开关状态信息1：开启，0：关闭
        /// </summary>
        /// <param name="model"></param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int UpdDTeacherTestOnOff(DTecher_TestOnOff model, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("UPDATE  DTecher_TestOnOff" + NK + " SET State=@State,CreateTime=@CreateTime,UpdateTime=@UpdateTime,Remark=@Remark WHERE TestType=@TestType");
            parameter.Add(DbFactory.CreateDbParameter("@State", model.State));
            parameter.Add(DbFactory.CreateDbParameter("@TestType", model.TestType));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 查询该条限制信息是否存在
        /// </summary>
        /// <param name="testType">约考测试、补测约考、单元测试</param>
        /// <param name="NK"></param>
        /// <returns></returns>
        public DTecher_TestOnOff GetModelDTeacherTestOnOff(string testType, string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select * from DTecher_TestOnOff" + NK + " WHERE TestType=@TestType");
            parameter.Add(DbFactory.CreateDbParameter("@TestType", testType));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取所有设置老师开关权限的信息
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public List<DTecher_TestOnOff> GetListDTeacherTestOnOff(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select* from DTecher_TestOnOff" + NK);
            return Repository().FindListBySql(strSql.ToString());
        }

    }
}