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
    /// 学生用户表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:13</date>
    /// </author>
    /// </summary>
    [Description("学生用户表")]
    [PrimaryKey("ID")]
    public class DBase_Users : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 编号,自增列
        /// </summary>
        /// <returns></returns>
        [DisplayName("编号,自增列")]
        public int? ID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        /// <returns></returns>
        [DisplayName("用户姓名")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户编号（默认学号）
        /// </summary>
        /// <returns></returns>
        [DisplayName("用户编号（默认学号）")]
        public string UserCode { get; set; }
        /// <summary>
        /// 密码:首次123456
        /// </summary>
        /// <returns></returns>
        [DisplayName("密码:首次123456")]
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户级别 1:老师,2:学生,
        /// </summary>
        /// <returns></returns>
        [DisplayName("用户级别 1:老师,2:学生,")]
        public string UserLeavel { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public string CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("更新时间")]
        public string UpdateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [DisplayName("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 1:已登录,0:未登录  （只是老师实现单点登录）
        /// </summary>
        /// <returns></returns>
        [DisplayName("1:已登录,0:未登录  （只是老师实现单点登录）")]
        public string UserState { get; set; }
        #endregion

        #region 扩展操作
        ///// <summary>
        ///// 新增调用
        ///// </summary>
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