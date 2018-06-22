//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2015
// Software Developers @ Learun 2015
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
    /// 加班申请表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2015.07.21 09:59</date>
    /// </author>
    /// </summary>
    [Description("加班申请表")]
    [PrimaryKey("OvertimeId")]
    public class OvertimeRequest : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 加班申请主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班申请主键")]
        public string OvertimeId { get; set; }
        /// <summary>
        /// 加班类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班类型")]
        public string Type { get; set; }
        /// <summary>
        /// 加班日期
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班日期")]
        public string Date { get; set; }
        /// <summary>
        /// 加班开始时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班开始时间")]
        public string StartTime { get; set; }
        /// <summary>
        /// 加班结束时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班结束时间")]
        public string EndTime { get; set; }
        /// <summary>
        /// 加班时长
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班时长")]
        public string Time { get; set; }
        /// <summary>
        /// 加班人部门主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班人部门主键")]
        public string DepartmentId { get; set; }
        /// <summary>
        /// 加班人用户主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("加班人用户主键")]
        public string UserId { get; set; }
        /// <summary>
        /// 申请人部门主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("申请人部门主键")]
        public string CreateDepartmentId { get; set; }
        /// <summary>
        /// 申请人用户主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("申请人用户主键")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("申请时间")]
        public string CreateTime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.OvertimeId = CommonHelper.GetGuid;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateDepartmentId = ManageProvider.Provider.Current().DepartmentId;
            this.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.OvertimeId = KeyValue;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateDepartmentId = ManageProvider.Provider.Current().DepartmentId;
            this.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion
    }
}