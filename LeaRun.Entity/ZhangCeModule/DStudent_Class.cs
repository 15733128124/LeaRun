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
    /// 班级表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:17</date>
    /// </author>
    /// </summary>
    [Description("班级表（随年份建表）")]
    [PrimaryKey("ID")]
    public class DStudent_Class : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 编号，自增列
        /// </summary>
        /// <returns></returns>
        [DisplayName("编号，自增列")]
        public int? ID { get; set; }
        /// <summary>
        /// 年级编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("年级编号")]
        public string GradeCode { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("学院编号")]
        public string SchoolCode { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("学院名称")]
        public string SchoolName { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("班级编号")]
        public string ClassCode { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("班级名称")]
        public string ClassName { get; set; }
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