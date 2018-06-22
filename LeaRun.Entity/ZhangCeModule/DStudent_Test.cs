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
    /// 学生测试表（随年份建表）
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.15 11:42</date>
    /// </author>
    /// </summary>
    [Description("学生测试表（随年份建表）")]
    [PrimaryKey("ID")]
    public class DStudent_Test : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// Id主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("Id主键")]
        public int? ID { get; set; }
        /// <summary>
        /// 学生学号
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生学号")]
        public string StudentCode { get; set; }
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
        /// 测试设置ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试设置ID")]
        public int TestSetID { get; set; }
        /// <summary>
        /// 学生名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生名称")]
        public string StudentName { get; set; }
        /// <summary>
        /// 学生性别
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生性别")]
        public string StudentSex { get; set; }
        /// <summary>
        /// 测试老师
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试老师")]
        public string TestTeacher { get; set; }
        /// <summary>
        /// 测试地址
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试地址")]
        public string TestAddress { get; set; }
        /// <summary>
        /// 开始测试日期
        /// </summary>
        /// <returns></returns>
        [DisplayName("开始测试日期")]
        public string BeginPraDate { get; set; }
        /// <summary>
        /// 开始测试星期
        /// </summary>
        /// <returns></returns>
        [DisplayName("开始测试星期")]
        public string BeginWeek { get; set; }
        /// <summary>
        /// 开始测试时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("开始测试时间")]
        public string BeginPraTime { get; set; }
        /// <summary>
        /// 是否有效 1:有效，2：无效
        /// </summary>
        /// <returns></returns>
        [DisplayName("是否有效")]
        public string ApplyFor { get; set; }
        /// <summary>
        /// 测试组
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试组")]
        public string TestGroup { get; set; }
        /// <summary>
        /// 测试序号
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试序号")]
        public string TestGroupCode { get; set; }
        /// <summary>
        /// 测试类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试类型")]
        public string TestType { get; set; }
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