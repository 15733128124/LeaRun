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
    /// �����
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.01 14:59</date>
    /// </author>
    /// </summary>
    public class DBase_NationsBll : RepositoryFactory<DBase_Nations>
    {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public DataTable GetNationList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT 
                                d.ID,                       --Id,����
                                d.NationCode,               --������
                                d.NationName,               --��������
                                d.CreateTime,               --����ʱ��
                                d.UpdateTime,               --����ʱ��
                                d.Remark                    --��ע
                                FROM DBase_Nations d");

            return Repository().FindTableBySql(strSql.ToString());
        }
    }
}