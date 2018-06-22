using LeaRun.DataAccess.Attributes;
using LeaRun.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaRun.Entity
{
    [Description("学生毕业成绩记录表")]
    [PrimaryKey("ID")]
    public class DStudent_FinshSchoolTest : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public int? ID { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生学号")]
        public string StudentCode { get; set; }
        /// <summary>
        /// 大一成绩
        /// </summary>
        /// <returns></returns>
        [DisplayName("大一成绩")]
        public string BigOne { get; set; }
        /// <summary>
        /// 大二成绩
        /// </summary>
        /// <returns></returns>
        [DisplayName("大二成绩")]
        public string BigTwo { get; set; }
        /// <summary>
        /// 大三成绩
        /// </summary>
        /// <returns></returns>
        [DisplayName("大三成绩")]
        public string BigThree { get; set; }
        /// <summary>
        /// 大四成绩
        /// </summary>
        /// <returns></returns>
        [DisplayName("大四成绩")]
        public string BigFour { get; set; }
        /// <summary>
        /// 毕业成绩
        /// </summary>
        /// <returns></returns>
        [DisplayName("毕业成绩")]
        public string FinshTest { get; set; }
        /// <summary>
        /// 毕业年份
        /// </summary>
        /// <returns></returns>
        [DisplayName("毕业年份")]
        public string FinshYear { get; set; }
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
    }
}
