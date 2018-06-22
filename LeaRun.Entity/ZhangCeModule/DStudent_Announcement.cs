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
    /// 学生公告表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:05</date>
    /// </author>
    /// </summary>
    [Description("学生公告表（随年份建表）")]
    [PrimaryKey("ID")]
    public class DStudent_Announcement : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 主键自增列ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("主键自增列ID")]
        public int? ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <returns></returns>
        [DisplayName("标题")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <returns></returns>
        [DisplayName("内容")]
        public string Content { get; set; }
        /// <summary>
        /// 状态是否开启
        /// </summary>
        /// <returns></returns>
        [DisplayName("状态是否开启")]
        public string ContentState { get; set; }
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