using LeaRun.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LeaRun.Entity
{
    /// <summary>
    /// 基本城市表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2018.5.12 10:12</date>
    /// </author>
    /// </summary>
    [Description("基本城市表")]
    [PrimaryKey("ID")]
    public  class DBase_NK:BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public int? ID { get; set; }
        /// <summary>
        /// 年库
        /// </summary>
        /// <returns></returns>
        [DisplayName("年库")]
        public int NK { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public string CreateTime{ get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建人")]
        public string CreateUser { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("备注")]
        public string Remark { get; set; }
        #endregion
    }
}
