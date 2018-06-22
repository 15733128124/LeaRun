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
    /// 基本城市表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:12</date>
    /// </author>
    /// </summary>
    [Description("基本城市表")]
    [PrimaryKey("ID")]
    public class DBase_Cities : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public int? ID { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("城市编号")]
        public string CityCode { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("城市名称")]
        public string CityName { get; set; }
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