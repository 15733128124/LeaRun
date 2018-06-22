using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LeaRun.Entity
{
   public class HeBeiStudents
    {

        /// <summary>
        /// 序号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学生来源地
        /// </summary>
        public string StudentAddress { get; set; }
        /// <summary>
        /// 学生性别
        /// </summary>
        public string StudentSex { get; set; }
        /// <summary>
        /// 学生数量
        /// </summary>
        public int StudentCount { get; set; }
        /// <summary>
        /// 优秀率
        /// </summary>
        public float Outstanding { get; set; }
        /// <summary>
        /// 良好率
        /// </summary>
        public float Goodrate { get; set; }
        /// <summary>
        /// 及格率
        /// </summary>
        public float PassRate { get; set; }
        /// <summary>
        /// 总达标率
        /// </summary>
        public float TotalRate { get; set; }
    }
}
