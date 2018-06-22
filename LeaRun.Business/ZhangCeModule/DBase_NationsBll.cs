//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2017
// Software Developers @ Learun 2017
//=====================================================================================

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
    /// 民族表
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.01 14:59</date>
    /// </author>
    /// </summary>
    public class DBase_NationsBll : RepositoryFactory<DBase_Nations>
    {
        /// <summary>
        /// 获取民族名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetNationList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT 
                                d.ID,                       --Id,主键
                                d.NationCode,               --民族编号
                                d.NationName,               --民族名称
                                d.CreateTime,               --创建时间
                                d.UpdateTime,               --更新时间
                                d.Remark                    --备注
                                FROM DBase_Nations d");

            return Repository().FindTableBySql(strSql.ToString());
        }
    }
}