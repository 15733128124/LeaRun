using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace LeaRun.Business
{
    public class DBase_NKBll : RepositoryFactory<DBase_NK>
    {
        /// <summary>
        /// 根据年库查询库中是否有该年库
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int FindCountDBaseNK(int NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select Count(NK) from DBase_NK where NK=@NK");
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 添加创建的年库信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDBaseNK(DBase_NK model)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("insert into DBase_NK(NK,CreateTime,CreateUser,Remark) values(@NK,@CreateTime,@CreateUser,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@NK", model.NK));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@CreateUser", model.CreateUser));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            if (Repository().ExecuteBySql(strSql, parameter.ToArray()) > 0)
                return CreateDBaseNK(model.NK.ToString());
            else
                return 0;

        }

        /// <summary>
        /// 创建年库各个表
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public int CreateDBaseNK(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            DbParameter result = DbFactory.CreateDbOutParameter("@Result", 4);
            parameter.Add(result);
            Repository().ExecuteByProc("Proc_CreateDBaseNK", parameter.ToArray());
            return Convert.ToInt32(result.Value);
        }

        /// <summary>
        /// 删除年库
        /// </summary>
        /// <param name="NK">年库信息</param>
        /// <returns></returns>
        public int DelDBaseNK(string NK)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@NK", NK));
            DbParameter result = DbFactory.CreateDbOutParameter("@Result", 4);
            parameter.Add(result);
            Repository().ExecuteByProc("Proc_DelDBaseNK", parameter.ToArray());
            return Convert.ToInt32(result.Value);

        }

        /// <summary>
        /// 获取所有年库信息
        /// </summary>
        /// <returns>list集合</returns>
        public List<DBase_NK> GetListDBaseNK()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  *  FROM DBase_NK");
            return Repository().FindListBySql(strSql.ToString());

        }

    }
}
