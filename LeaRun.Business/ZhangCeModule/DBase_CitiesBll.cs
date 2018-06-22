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
    /// 基本城市表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:12</date>
    /// </author>
    /// </summary>
    public class DBase_CitiesBll : RepositoryFactory<DBase_Cities>
    {
        /// <summary>
        /// 根据citycode查询所在地市
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetCityNameByCityCode(string cityCode)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select * from Base_Cities where CityCode=@CityCode");
            parameter.Add(DbFactory.CreateDbParameter("@CityCode", cityCode));
            return Repository().FindEntityBySql(strSql.ToString(), parameter.ToArray()).CityName;      
                }
    }
}