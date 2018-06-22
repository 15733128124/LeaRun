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
    /// DStudent_TestAllot
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.13 09:07</date>
    /// </author>
    /// </summary>
    [Description("DStudent_TestAllot")]
    [PrimaryKey("ID")]
    public class DStudent_TestAllot : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public int? ID { get; set; }
        /// <summary>
        /// 测试设置ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("TestSetID")]
        public int? TestSetID { get; set; }
        /// <summary>
        /// 所属组
        /// </summary>
        /// <returns></returns>
        [DisplayName("TestGroup")]
        public string TestGroup { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        /// <returns></returns>
        [DisplayName("GroupCount")]
        public int? GroupCount { get; set; }
        /// <summary>
        /// 开始测试日期
        /// </summary>
        /// <returns></returns>
        [DisplayName("BeginPraDate")]
        public string BeginPraDate { get; set; }
        /// <summary>
        /// 开始测试星期
        /// </summary>
        /// <returns></returns>
        [DisplayName("BeginWeek")]
        public string BeginWeek { get; set; }
        /// <summary>
        /// 开始测试时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("BeginPraTime")]
        public string BeginPraTime { get; set; }
        /// <summary>
        /// 测试老师
        /// </summary>
        /// <returns></returns>
        [DisplayName("TestTeacher")]
        public string TestTeacher { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("Remark")]
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