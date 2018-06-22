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
    /// 学生测试设置表（随年份建表）
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    [Description("学生测试设置表（随年份建表）")]
    [PrimaryKey("ID")]
    public class DStudent_TestSet : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 编号，自增列
        /// </summary>
        /// <returns></returns>
        [DisplayName("编号，自增列")]
        public int? ID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("开始时间")]
        public string TestBeginDate { get; set; }
        /// <summary>
        /// 开始星期
        /// </summary>
        /// <returns></returns>
        [DisplayName("开始星期")]
        public string TestBeginWeek { get; set; }
        /// <summary>
        /// 测试地点
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试地点")]
        public string TestAddress { get; set; }
        /// <summary>
        /// 学生性别  1：男  2：女
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生性别  1：男  2：女")]
        public string StudentSex { get; set; }
        /// <summary>
        /// 测试学生数量
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试学生数量")]
        public string TestStudentCount { get; set; }
        /// <summary>
        /// 测试开始时段
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试开始时段")]
        public string TestBeginTime { get; set; }
        /// <summary>
        /// 已约测试学生数量
        /// </summary>
        /// <returns></returns>
        [DisplayName("已约测试学生数量")]
        public string TestStudentOkCount { get; set; }
        /// <summary>
        /// 未约测试学生数量
        /// </summary>
        /// <returns></returns>
        [DisplayName("未约测试学生数量")]
        public string TestStudentNoCount { get; set; }
        /// <summary>
        /// 分配状态
        /// </summary>
        /// <returns></returns>
        [DisplayName("未约测试学生数量")]
        public string AllotState { get; set; }

        /// <summary>
        /// 测试限制大一，大二，大三，大四，补测（全部可参加）
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试限制")]
        public string TestLimit { get; set; }

        /// <summary>
        /// 测试类型：约考测试、单元测试、补测约考
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试类型：约考测试、单元测试、补测约考")]
        public string TestType { get; set; }
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