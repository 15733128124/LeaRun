using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LeaRun.Entity
{
   public class StudentScoreExcel
    {

        #region 获取/设置 字段值
       
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
        /// 身高
        /// </summary>
        /// <returns></returns>
        [DisplayName("身高")]
        public string Heigh { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        /// <returns></returns>
        [DisplayName("体重")]
        public string Weight { get; set; }
        /// <summary>
        /// 身高体重指数
        /// </summary>
        /// <returns></returns>
        [DisplayName("身高体重指数")]
        public string BMI { get; set; }
        /// <summary>
        /// 身高体重指数得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("身高体重指数得分")]
        public string BMIScore { get; set; }
        /// <summary>
        /// 身高体重指数级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("身高体重指数级别")]
        public string BMILevel { get; set; }
        /// <summary>
        /// 肺活量
        /// </summary>
        /// <returns></returns>
        [DisplayName("肺活量")]
        public string Pulmonary { get; set; }
        /// <summary>
        /// 肺活量得分 
        /// </summary>
        /// <returns></returns>
        [DisplayName("肺活量得分 ")]
        public string PulmonaryScore { get; set; }
        /// <summary>
        /// 肺活量级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("肺活量级别")]
        public string PulmonaryLevel { get; set; }
        /// <summary>
        /// 50米跑
        /// </summary>
        /// <returns></returns>
        [DisplayName("50米跑")]
        public string FiftyRun { get; set; }
        /// <summary>
        /// 50米跑得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("50米跑得分")]
        public string FiftyRunScore { get; set; }
        /// <summary>
        /// 50米跑级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("50米跑级别")]
        public string FiftyRunLevel { get; set; }
        /// <summary>
        /// 立定跳远
        /// </summary>
        /// <returns></returns>
        [DisplayName("立定跳远")]
        public string StandJump { get; set; }
        /// <summary>
        /// 立定跳远得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("立定跳远得分")]
        public string StandJumpScore { get; set; }
        /// <summary>
        /// 立定跳远级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("立定跳远级别")]
        public string StandJumpLevel { get; set; }
        /// <summary>
        /// 座位体前屈
        /// </summary>
        /// <returns></returns>
        [DisplayName("座位体前屈")]
        public string SitAndReach { get; set; }
        /// <summary>
        /// 座位体前屈得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("座位体前屈得分")]
        public string SitAndReachScore { get; set; }
        /// <summary>
        /// 座位体前屈级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("座位体前屈级别")]
        public string SitAndReachLevel { get; set; }
        /// <summary>
        /// 800米跑
        /// </summary>
        /// <returns></returns>
        [DisplayName("800米跑")]
        public string EightHundred { get; set; }
        /// <summary>
        /// 800米跑得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("800米跑得分")]
        public string EightHundredScore { get; set; }
        /// <summary>
        /// 800米跑级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("800米跑级别")]
        public string EightHundredLevel { get; set; }
        /// <summary>
        /// 800米跑加分
        /// </summary>
        /// <returns></returns>
        [DisplayName("800米跑加分")]
        public string EightHundredAddScore { get; set; }
        /// <summary>
        /// 1000米跑
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000米跑")]
        public string ThousandRun { get; set; }
        /// <summary>
        /// 1000米跑得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000米跑得分")]
        public string ThousandRunScore { get; set; }
        /// <summary>
        /// 1000米跑级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000米跑级别")]
        public string ThousandRunLevel { get; set; }
        /// <summary>
        /// 1000米跑加分
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000米跑加分")]
        public string ThousandRunAddScore { get; set; }
        /// <summary>
        /// 1分钟仰卧起坐
        /// </summary>
        /// <returns></returns>
        [DisplayName("1分钟仰卧起坐")]
        public string MinSupination { get; set; }
        /// <summary>
        /// 1分钟仰卧起坐得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("1分钟仰卧起坐得分")]
        public string MinSupinationScore { get; set; }
        /// <summary>
        /// 1分钟仰卧起坐级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("1分钟仰卧起坐级别")]
        public string MinSupinationLevel { get; set; }
        /// <summary>
        /// 1分钟仰卧起坐加分
        /// </summary>
        /// <returns></returns>
        [DisplayName("1分钟仰卧起坐加分")]
        public string MinSupinationAddScore { get; set; }
        /// <summary>
        /// 引体向上
        /// </summary>
        /// <returns></returns>
        [DisplayName("引体向上")]
        public string PullUp { get; set; }
        /// <summary>
        /// 引体向上得分
        /// </summary>
        /// <returns></returns>
        [DisplayName("引体向上得分")]
        public string PullUpScore { get; set; }
        /// <summary>
        /// 引体向上级别
        /// </summary>
        /// <returns></returns>
        [DisplayName("引体向上级别")]
        public string PullUpLevel { get; set; }
        /// <summary>
        /// 引体向上加分
        /// </summary>
        /// <returns></returns>
        [DisplayName("引体向上加分")]
        public string PullUpAddScore { get; set; }
        /// <summary>
        /// 测试结果：未测，补测，通过，免测，作弊
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试结果：未测，补测，通过，免测，作弊")]
        public string TestResult { get; set; }
        /// <summary>
        /// 学生最后成绩
        /// </summary>
        /// <returns></returns>
        [DisplayName("学生最后成绩")]
        public string StudentTrueScore { get; set; }
        /// <summary>
        /// 测试类型：补测约考、正常测试
        /// </summary>
        /// <returns></returns>
        [DisplayName("测试类型：补测约考、正常测试")]
        public string TestType { get; set; }
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
