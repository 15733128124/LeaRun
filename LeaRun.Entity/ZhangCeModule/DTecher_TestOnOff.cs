//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2017
// Software Developers @ Learun 2017
//=====================================================================================

using LeaRun.DataAccess.Attributes;
using LeaRun.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaRun.Entity
{
    /// <summary>
    /// 老师测试开关（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:21</date>
    /// </author>
    /// </summary>
    [Description("老师测试开关（随年份建表）")]
    [PrimaryKey("ID")]
    public class DTecher_TestOnOff : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 编号，自增列
        /// </summary>
        /// <returns></returns>
        [DisplayName("编号，自增列")]
        public int? ID { get; set; }
        /// <summary>
        /// 状态：开启 on，关闭off
        /// </summary>
        /// <returns></returns>
        [DisplayName("状态：开启 on，关闭off")]
        public string State { get; set; }
        /// <summary>
        /// 测试类型：补测约考、正常测试
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试类型：补测约考、正常测试")]
        public string TestType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public string CreateTime { get; set; }
        /// <summary>
        /// 更改时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("更改时间")]
        public string UpdateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("备注")]
        public string Remark { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        //public override void Create()
        //{
        //    this.ID = CommonHelper.GetGuid;
        //                                    }
        ///// <summary>
        ///// 编辑调用
        ///// </summary>
        ///// <param name="KeyValue"></param>
        //public override void Modify(string KeyValue)
        //{
        //    this.ID = KeyValue;
        //                                    }
        #endregion
    }
}