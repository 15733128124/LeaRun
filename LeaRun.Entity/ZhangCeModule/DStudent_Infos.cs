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
    /// 学生基本信息表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:19</date>
    /// </author>
    /// </summary>
    [Description("学生基本信息表（随年份建表）")]
    [PrimaryKey("ID")]
    public class DStudent_Infos : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 编号,自增列
        /// </summary>
        /// <returns></returns>
        [DisplayName("编号,自增列")]
        public int? ID { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生编号")]
        public string StudentCode { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生姓名")]
        public string StudentName { get; set; }
        /// <summary>
        /// 学生性别  1:男  2:女
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生性别  1:男  2:女")]
        public string StudentSex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        [DisplayName("出生日期")]
        public string StudentBornDate { get; set; }
        /// <summary>
        /// 学生住址
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生住址")]
        public string StudentHomeAddress { get; set; }
        /// <summary>
        /// 年级编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("年级编号")]
        public string GradeCode { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("学院名称")]
        public string SchoolName { get; set; }
        /// <summary>
        /// 学院编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("学院编号")]
        public string SchoolCode { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("班级名称")]
        public string ClassName { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("班级编号")]
        public string ClassCode { get; set; }
        /// <summary>
        /// 民族编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("民族编号")]
        public string NationCode { get; set; }
        /// <summary>
        /// 民族名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("民族名称")]
        public string NationName { get; set; }
        /// <summary>
        /// 学生籍贯
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生籍贯")]
        public string StudentNative { get; set; }
        /// <summary>
        /// 异动类型
        /// </summary>
        /// <returns></returns>
        [DisplayName("异动类型")]
        public string StudentMoveType { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        [DisplayName("身份证号")]
        public string StudentIDNumber { get; set; }
        /// <summary>
        /// 学生电话
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生电话")]
        public string StudentPhone { get; set; }
        /// <summary>
        /// 是否注册
        /// </summary>
        /// <returns></returns>
        [DisplayName("是否注册")]
        public string StudentIsRegister { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建时间")]
        public string CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("修改时间")]
        public string UpdateTime { get; set; }
        /// <summary>
        /// Remark
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