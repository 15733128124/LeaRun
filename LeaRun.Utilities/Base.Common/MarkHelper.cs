using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Utilities
{
    /// <summary>
    /// 掌测公用方法
    /// </summary>
    public class MarkHelper
    {
       

        #region 学生毕业成绩评分
        /// <summary>
        /// 学生毕业成绩评分
        /// </summary>
        /// <param name="BigOne">大一成绩</param>
        /// <param name="BigTwo">大二成绩</param>
        /// <param name="BigThree">大三成绩</param>
        /// <param name="BigFour">大四成绩</param>
        /// <returns></returns>
        public static string FinshTest(string BigOne,string BigTwo,string BigThree,string BigFour)
        {
            double finshTest = ((Convert.ToDouble(BigOne=BigOne==""?"0":BigOne) + 
                Convert.ToDouble(BigTwo=BigTwo==""?"0":BigTwo) + Convert.ToDouble(BigThree=BigThree==""?"0":BigThree) / 3.0)
                + Convert.ToDouble(BigFour=BigFour==""?"0":BigFour))/2.0;
            return finshTest.ToString();
        }
        #endregion

        #region 体重指数评分
        /// <summary>
        /// 体重指数
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static string BMI(float height, float weight)
        {
            if (height == -1)
            {
                return "";
            }
            else
            {
                if (height != -1 && weight != -1)
                {
                    return (Convert.ToDouble(weight / Math.Pow((height / 100), 2))).ToString();
                }
                else
                {
                    return "0";
                }
            }
        }

        /// <summary>
        /// 根据体重指数算得分
        /// </summary>
        /// <param name="BMI"></param>
        /// <returns></returns>
        public static string BMIScore(double BMI, string StudentSex)
        {

            string BMIScore = "";
            if (StudentSex == "1")
            {
                if (BMI >= 17.9 && BMI <= 23.9)
                {
                    BMIScore = "100";
                }
                else if (BMI > 0 && BMI < 17.9 || BMI > 23.9 && BMI <= 27.9)
                {
                    BMIScore = "80";
                }
                else if (BMI > 27.9)
                {
                    BMIScore = "60";
                }
                else
                {
                    BMIScore = "0";
                }
            }
            if (StudentSex == "2")
            {
                if (BMI >= 17.2 && BMI <= 23.9)
                {
                    BMIScore = "100";
                }
                else if (BMI > 0 && BMI < 17.2 || BMI > 23.9 && BMI <= 27.9)
                {
                    BMIScore = "80";
                }
                else if (BMI > 27.9)
                {
                    BMIScore = "60";
                }
                else
                {
                    BMIScore = "0";
                }
            }
            return BMIScore;
        }

        /// <summary>
        /// 根据体重指数算等级
        /// </summary>
        /// <param name="BMI"></param>
        /// <returns></returns>
        public static string BMILevel(float BMI, string StudentSex)
        {
            string BMILevel = "";
            if (StudentSex == "1")
            {
                if (BMI >= 17.9 && BMI <= 23.9)
                {
                    BMILevel = "正常";
                }
                else if (BMI < 17.9 && BMI > 0)
                {
                    BMILevel = "低体重";
                }
                else if (BMI > 23.9 && BMI <= 27.9)
                {
                    BMILevel = "超重";
                }
                else if (BMI > 27.9)
                {
                    BMILevel = "肥胖";
                }
                else
                {
                    BMILevel = "";
                }
            }
            if (StudentSex == "2")
            {
                if (BMI >= 17.2 && BMI <= 23.9)
                {
                    BMILevel = "正常";
                }
                else if (BMI < 17.2 && BMI > 0)
                {
                    BMILevel = "低体重";
                }
                else if (BMI > 23.9 && BMI <= 27.9)
                {
                    BMILevel = "超重";
                }
                else if (BMI >= 27.9)
                {
                    BMILevel = "肥胖";
                }
                else
                {
                    BMILevel = "";
                }
            }
            return BMILevel;
        }
        #endregion

        #region 根据分数算等级 优秀：（90-100）良好：（80-90）及格：（60-80）不及格（60以下）

        /// <summary>
        /// 根据分数算等级 优秀：（90-100）良好：（80-90）及格：（60-80）不及格（60以下）
        /// 适用于（肺活量、50米跑、坐位体前屈、立定跳远、引体向上、一分钟仰卧起坐、1000米跑、800米跑）
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static string Level(int score)
        {
            string level = "";
            if (score >= 90 && score <= 100)
            {
                level = "优秀";
            }
            if (score >= 80 && score < 90)
            {
                level = "良好";
            }
            if (score >= 60 && score < 80)
            {
                level = "及格";
            }
            if (score > 0 && score < 60)
            {
                level = "不及格";
            }
            if (score == 0)
            {
                level = "";
            }
            return level;
        }

        #endregion

        #region 肺活量单项评分

        /// <summary>
        /// 肺活量得分
        /// </summary>
        /// <param name="Pulmonary"></param>
        /// <param name="studentSex"></param>
        /// <returns></returns>
        public static string PulmonaryScore(int Pulmonary, string studentSex, string gradeCode)
        {
            int PulmonaryScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {
                if (studentSex == "1")
                {
                    if (Pulmonary >= 5040)
                        PulmonaryScore = 100;
                    if (Pulmonary >= 4920 && Pulmonary < 5040)
                        PulmonaryScore = 95;
                    if (Pulmonary >= 4800 && Pulmonary < 4920)
                        PulmonaryScore = 90;
                    if (Pulmonary >= 4550 && Pulmonary < 4800)
                        PulmonaryScore = 85;
                    if (Pulmonary >= 4300 && Pulmonary < 4550)
                        PulmonaryScore = 80;
                    if (Pulmonary >= 4180 && Pulmonary < 4300)
                        PulmonaryScore = 78;
                    if (Pulmonary >= 4060 && Pulmonary < 4180)
                        PulmonaryScore = 76;
                    if (Pulmonary >= 3940 && Pulmonary < 4060)
                        PulmonaryScore = 74;
                    if (Pulmonary >= 3820 && Pulmonary < 3940)
                        PulmonaryScore = 72;
                    if (Pulmonary >= 3700 && Pulmonary < 3820)
                        PulmonaryScore = 70;
                    if (Pulmonary >= 3580 && Pulmonary < 3700)
                        PulmonaryScore = 68;
                    if (Pulmonary >= 3460 && Pulmonary < 3580)
                        PulmonaryScore = 66;
                    if (Pulmonary >= 3340 && Pulmonary < 3460)
                        PulmonaryScore = 64;
                    if (Pulmonary >= 3220 && Pulmonary < 3340)
                        PulmonaryScore = 62;
                    if (Pulmonary >= 3100 && Pulmonary < 3220)
                        PulmonaryScore = 60;
                    if (Pulmonary >= 2940 && Pulmonary < 3100)
                        PulmonaryScore = 50;
                    if (Pulmonary >= 2780 && Pulmonary < 2940)
                        PulmonaryScore = 40;
                    if (Pulmonary >= 2620 && Pulmonary < 2780)
                        PulmonaryScore = 30;
                    if (Pulmonary >= 2400 && Pulmonary < 2620)
                        PulmonaryScore = 20;
                    if (Pulmonary >= 2300 && Pulmonary < 2460)
                        PulmonaryScore = 10;

                }
                if (studentSex == "2")
                {
                    if (Pulmonary >= 3400)
                        PulmonaryScore = 100;
                    if (Pulmonary >= 3350 && Pulmonary < 3400)
                        PulmonaryScore = 95;
                    if (Pulmonary >= 3300 && Pulmonary < 3350)
                        PulmonaryScore = 90;
                    if (Pulmonary >= 3150 && Pulmonary < 3300)
                        PulmonaryScore = 85;
                    if (Pulmonary >= 3000 && Pulmonary < 3150)
                        PulmonaryScore = 80;
                    if (Pulmonary >= 2900 && Pulmonary < 3000)
                        PulmonaryScore = 78;
                    if (Pulmonary >= 2800 && Pulmonary < 2900)
                        PulmonaryScore = 76;
                    if (Pulmonary >= 2700 && Pulmonary < 2800)
                        PulmonaryScore = 74;
                    if (Pulmonary >= 2600 && Pulmonary < 2700)
                        PulmonaryScore = 72;
                    if (Pulmonary >= 2500 && Pulmonary < 2600)
                        PulmonaryScore = 70;
                    if (Pulmonary >= 2400 && Pulmonary < 2500)
                        PulmonaryScore = 68;
                    if (Pulmonary >= 2300 && Pulmonary < 2400)
                        PulmonaryScore = 66;
                    if (Pulmonary >= 2200 && Pulmonary < 2300)
                        PulmonaryScore = 64;
                    if (Pulmonary >= 2100 && Pulmonary < 2200)
                        PulmonaryScore = 62;
                    if (Pulmonary >= 2000 && Pulmonary < 2100)
                        PulmonaryScore = 60;
                    if (Pulmonary >= 1960 && Pulmonary < 2000)
                        PulmonaryScore = 50;
                    if (Pulmonary >= 1920 && Pulmonary < 1960)
                        PulmonaryScore = 40;
                    if (Pulmonary >= 1880 && Pulmonary < 1920)
                        PulmonaryScore = 30;
                    if (Pulmonary >= 1840 && Pulmonary < 1880)
                        PulmonaryScore = 20;
                    if (Pulmonary >= 1800 && Pulmonary < 1840)
                        PulmonaryScore = 10;
                }
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (studentSex == "1")
                {
                    if (Pulmonary >= 5140)
                        PulmonaryScore = 100;
                    if (Pulmonary >= 5020 && Pulmonary < 5140)
                        PulmonaryScore = 95;
                    if (Pulmonary >= 4900 && Pulmonary < 5020)
                        PulmonaryScore = 90;
                    if (Pulmonary >= 4650 && Pulmonary < 4900)
                        PulmonaryScore = 85;
                    if (Pulmonary >= 4400 && Pulmonary < 4650)
                        PulmonaryScore = 80;
                    if (Pulmonary >= 4280 && Pulmonary < 4400)
                        PulmonaryScore = 78;
                    if (Pulmonary >= 4160 && Pulmonary < 4280)
                        PulmonaryScore = 76;
                    if (Pulmonary >= 4040 && Pulmonary < 4160)
                        PulmonaryScore = 74;
                    if (Pulmonary >= 3920 && Pulmonary < 4040)
                        PulmonaryScore = 72;
                    if (Pulmonary >= 3800 && Pulmonary < 3920)
                        PulmonaryScore = 70;
                    if (Pulmonary >= 3680 && Pulmonary < 3800)
                        PulmonaryScore = 68;
                    if (Pulmonary >= 3560 && Pulmonary < 3680)
                        PulmonaryScore = 66;
                    if (Pulmonary >= 3440 && Pulmonary < 3560)
                        PulmonaryScore = 64;
                    if (Pulmonary >= 3320 && Pulmonary < 3440)
                        PulmonaryScore = 62;
                    if (Pulmonary >= 3200 && Pulmonary < 3320)
                        PulmonaryScore = 60;
                    if (Pulmonary >= 3030 && Pulmonary < 3200)
                        PulmonaryScore = 50;
                    if (Pulmonary >= 2860 && Pulmonary < 3030)
                        PulmonaryScore = 40;
                    if (Pulmonary >= 2690 && Pulmonary < 2860)
                        PulmonaryScore = 30;
                    if (Pulmonary >= 2520 && Pulmonary < 2690)
                        PulmonaryScore = 20;
                    if (Pulmonary >= 2350 && Pulmonary < 2500)
                        PulmonaryScore = 10;

                }
                if (studentSex == "2")
                {
                    if (Pulmonary >= 3450)
                        PulmonaryScore = 100;
                    if (Pulmonary >= 3400 && Pulmonary < 3450)
                        PulmonaryScore = 95;
                    if (Pulmonary >= 3350 && Pulmonary < 3400)
                        PulmonaryScore = 90;
                    if (Pulmonary >= 3200 && Pulmonary < 3350)
                        PulmonaryScore = 85;
                    if (Pulmonary >= 3050 && Pulmonary < 3200)
                        PulmonaryScore = 80;
                    if (Pulmonary >= 2950 && Pulmonary < 3050)
                        PulmonaryScore = 78;
                    if (Pulmonary >= 2850 && Pulmonary < 2950)
                        PulmonaryScore = 76;
                    if (Pulmonary >= 2750 && Pulmonary < 2850)
                        PulmonaryScore = 74;
                    if (Pulmonary >= 2650 && Pulmonary < 2750)
                        PulmonaryScore = 72;
                    if (Pulmonary >= 2550 && Pulmonary < 2650)
                        PulmonaryScore = 70;
                    if (Pulmonary >= 2450 && Pulmonary < 2550)
                        PulmonaryScore = 68;
                    if (Pulmonary >= 2350 && Pulmonary < 2450)
                        PulmonaryScore = 66;
                    if (Pulmonary >= 2250 && Pulmonary < 2350)
                        PulmonaryScore = 64;
                    if (Pulmonary >= 2150 && Pulmonary < 2250)
                        PulmonaryScore = 62;
                    if (Pulmonary >= 2050 && Pulmonary < 2150)
                        PulmonaryScore = 60;
                    if (Pulmonary >= 2010 && Pulmonary < 2050)
                        PulmonaryScore = 50;
                    if (Pulmonary >= 1970 && Pulmonary < 2010)
                        PulmonaryScore = 40;
                    if (Pulmonary >= 1930 && Pulmonary < 1970)
                        PulmonaryScore = 30;
                    if (Pulmonary >= 1890 && Pulmonary < 1930)
                        PulmonaryScore = 20;
                    if (Pulmonary >= 1850 && Pulmonary < 1890)
                        PulmonaryScore = 10;
                }

            }
            return PulmonaryScore.ToString();
        }


        #endregion

        #region 50米跑单项得分
        /// <summary>
        /// 50米跑单项得分
        /// </summary>
        /// <param name="fiftyRun"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string FiftyRunScore(double fiftyRun, string studentSex, string gradeCode)
        {
            int FiftyRunScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {
                if (studentSex == "1")
                {
                    if (fiftyRun > 0 && fiftyRun <= 6.7)
                        FiftyRunScore = 100;
                    if (fiftyRun > 6.7 && fiftyRun <= 6.8)
                        FiftyRunScore = 95;
                    if (fiftyRun > 6.8 && fiftyRun <= 6.9)
                        FiftyRunScore = 90;
                    if (fiftyRun > 6.9 && fiftyRun <= 7.0)
                        FiftyRunScore = 85;
                    if (fiftyRun > 7.0 && fiftyRun <= 7.1)
                        FiftyRunScore = 80;
                    if (fiftyRun > 7.1 && fiftyRun <= 7.3)
                        FiftyRunScore = 78;
                    if (fiftyRun > 7.3 && fiftyRun <= 7.5)
                        FiftyRunScore = 76;
                    if (fiftyRun > 7.5 && fiftyRun <= 7.7)
                        FiftyRunScore = 74;
                    if (fiftyRun > 7.7 && fiftyRun <= 7.9)
                        FiftyRunScore = 72;
                    if (fiftyRun > 7.9 && fiftyRun <= 8.1)
                        FiftyRunScore = 70;
                    if (fiftyRun > 8.1 && fiftyRun <= 8.3)
                        FiftyRunScore = 68;
                    if (fiftyRun > 8.3 && fiftyRun <= 8.5)
                        FiftyRunScore = 66;
                    if (fiftyRun > 8.5 && fiftyRun <= 8.7)
                        FiftyRunScore = 64;
                    if (fiftyRun > 8.7 && fiftyRun <= 8.9)
                        FiftyRunScore = 62;
                    if (fiftyRun > 8.9 && fiftyRun <= 9.1)
                        FiftyRunScore = 60;
                    if (fiftyRun > 9.1 && fiftyRun <= 9.3)
                        FiftyRunScore = 50;
                    if (fiftyRun > 9.3 && fiftyRun <= 9.5)
                        FiftyRunScore = 40;
                    if (fiftyRun > 9.5 && fiftyRun <= 9.7)
                        FiftyRunScore = 30;
                    if (fiftyRun > 9.7 && fiftyRun <= 9.9)
                        FiftyRunScore = 20;
                    if (fiftyRun > 9.9 && fiftyRun <= 10.1)
                        FiftyRunScore = 10;
                    if (fiftyRun > 10.1)
                        FiftyRunScore = 0;
                }
                if (studentSex == "2")
                {
                    if (fiftyRun > 0 && fiftyRun <= 7.5)
                        FiftyRunScore = 100;
                    if (fiftyRun > 7.5 && fiftyRun <= 7.6)
                        FiftyRunScore = 95;
                    if (fiftyRun > 7.6 && fiftyRun <= 7.7)
                        FiftyRunScore = 90;
                    if (fiftyRun > 7.7 && fiftyRun <= 8.0)
                        FiftyRunScore = 85;
                    if (fiftyRun > 8.0 && fiftyRun <= 8.3)
                        FiftyRunScore = 80;
                    if (fiftyRun > 8.3 && fiftyRun <= 8.5)
                        FiftyRunScore = 78;
                    if (fiftyRun > 8.5 && fiftyRun <= 8.7)
                        FiftyRunScore = 76;
                    if (fiftyRun > 8.7 && fiftyRun <= 8.9)
                        FiftyRunScore = 74;
                    if (fiftyRun > 8.9 && fiftyRun <= 9.1)
                        FiftyRunScore = 72;
                    if (fiftyRun > 9.1 && fiftyRun <= 9.3)
                        FiftyRunScore = 70;
                    if (fiftyRun > 9.3 && fiftyRun <= 9.5)
                        FiftyRunScore = 68;
                    if (fiftyRun > 9.5 && fiftyRun <= 9.7)
                        FiftyRunScore = 66;
                    if (fiftyRun > 9.7 && fiftyRun <= 9.9)
                        FiftyRunScore = 64;
                    if (fiftyRun > 9.9 && fiftyRun <= 10.1)
                        FiftyRunScore = 62;
                    if (fiftyRun > 10.1 && fiftyRun <= 10.3)
                        FiftyRunScore = 60;
                    if (fiftyRun > 10.3 && fiftyRun <= 10.5)
                        FiftyRunScore = 50;
                    if (fiftyRun > 10.5 && fiftyRun <= 10.7)
                        FiftyRunScore = 40;
                    if (fiftyRun > 10.7 && fiftyRun <= 10.9)
                        FiftyRunScore = 30;
                    if (fiftyRun > 10.9 && fiftyRun <= 11.1)
                        FiftyRunScore = 20;
                    if (fiftyRun > 11.1 && fiftyRun <= 11.3)
                        FiftyRunScore = 10;
                    if (fiftyRun > 11.3)
                        FiftyRunScore = 0;
                }
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (studentSex == "1")
                {
                    if (fiftyRun > 0 && fiftyRun <= 6.6)
                        FiftyRunScore = 100;
                    if (fiftyRun > 6.6 && fiftyRun <= 6.7)
                        FiftyRunScore = 95;
                    if (fiftyRun > 6.7 && fiftyRun <= 6.8)
                        FiftyRunScore = 90;
                    if (fiftyRun > 6.8 && fiftyRun <= 6.9)
                        FiftyRunScore = 85;
                    if (fiftyRun > 6.9 && fiftyRun <= 7.0)
                        FiftyRunScore = 80;
                    if (fiftyRun > 7.0 && fiftyRun <= 7.2)
                        FiftyRunScore = 78;
                    if (fiftyRun > 7.2 && fiftyRun <= 7.4)
                        FiftyRunScore = 76;
                    if (fiftyRun > 7.4 && fiftyRun <= 7.6)
                        FiftyRunScore = 74;
                    if (fiftyRun > 7.6 && fiftyRun <= 7.8)
                        FiftyRunScore = 72;
                    if (fiftyRun > 7.8 && fiftyRun <= 8.0)
                        FiftyRunScore = 70;
                    if (fiftyRun > 8.0 && fiftyRun <= 8.2)
                        FiftyRunScore = 68;
                    if (fiftyRun > 8.2 && fiftyRun <= 8.4)
                        FiftyRunScore = 66;
                    if (fiftyRun > 8.4 && fiftyRun <= 8.6)
                        FiftyRunScore = 64;
                    if (fiftyRun > 8.6 && fiftyRun <= 8.8)
                        FiftyRunScore = 62;
                    if (fiftyRun > 8.8 && fiftyRun <= 9.0)
                        FiftyRunScore = 60;
                    if (fiftyRun > 9.0 && fiftyRun <= 9.2)
                        FiftyRunScore = 50;
                    if (fiftyRun > 9.2 && fiftyRun <= 9.4)
                        FiftyRunScore = 40;
                    if (fiftyRun > 9.4 && fiftyRun <= 9.6)
                        FiftyRunScore = 30;
                    if (fiftyRun > 9.6 && fiftyRun <= 9.8)
                        FiftyRunScore = 20;
                    if (fiftyRun > 9.8 && fiftyRun <= 10.1)
                        FiftyRunScore = 10;
                    if (fiftyRun > 10.1)
                        FiftyRunScore = 0;
                }
                if (studentSex == "2")
                {
                    if (fiftyRun > 0 && fiftyRun <= 7.4)
                        FiftyRunScore = 100;
                    if (fiftyRun > 7.4 && fiftyRun <= 7.5)
                        FiftyRunScore = 95;
                    if (fiftyRun > 7.5 && fiftyRun <= 7.6)
                        FiftyRunScore = 90;
                    if (fiftyRun > 7.6 && fiftyRun <= 7.9)
                        FiftyRunScore = 85;
                    if (fiftyRun > 7.9 && fiftyRun <= 8.2)
                        FiftyRunScore = 80;
                    if (fiftyRun > 8.2 && fiftyRun <= 8.4)
                        FiftyRunScore = 78;
                    if (fiftyRun > 8.4 && fiftyRun <= 8.6)
                        FiftyRunScore = 76;
                    if (fiftyRun > 8.6 && fiftyRun <= 8.8)
                        FiftyRunScore = 74;
                    if (fiftyRun > 8.8 && fiftyRun <= 9.0)
                        FiftyRunScore = 72;
                    if (fiftyRun > 9.0 && fiftyRun <= 9.2)
                        FiftyRunScore = 70;
                    if (fiftyRun > 9.2 && fiftyRun <= 9.4)
                        FiftyRunScore = 68;
                    if (fiftyRun > 9.4 && fiftyRun <= 9.6)
                        FiftyRunScore = 66;
                    if (fiftyRun > 9.6 && fiftyRun <= 9.8)
                        FiftyRunScore = 64;
                    if (fiftyRun > 9.8 && fiftyRun <= 10.0)
                        FiftyRunScore = 62;
                    if (fiftyRun > 10.0 && fiftyRun <= 10.2)
                        FiftyRunScore = 60;
                    if (fiftyRun > 10.2 && fiftyRun <= 10.4)
                        FiftyRunScore = 50;
                    if (fiftyRun > 10.4 && fiftyRun <= 10.6)
                        FiftyRunScore = 40;
                    if (fiftyRun > 10.6 && fiftyRun <= 10.8)
                        FiftyRunScore = 30;
                    if (fiftyRun > 10.8 && fiftyRun <= 11.0)
                        FiftyRunScore = 20;
                    if (fiftyRun > 11.1 && fiftyRun <= 11.3)
                        FiftyRunScore = 10;
                    if (fiftyRun > 11.3)
                        FiftyRunScore = 0;

                }
            }
            return FiftyRunScore.ToString();

        }
        #endregion

        #region 坐位体前屈单项评分
        /// <summary>
        /// 坐位体前屈得分
        /// </summary>
        /// <param name="sitAndReach"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string SitAndReachScore(double sitAndReach, string studentSex, string gradeCode)
        {
            int SitAndReachScore = 0;

            if (gradeCode == "41" || gradeCode == "42")
            {
                if (studentSex == "1")
                {
                    if (sitAndReach < 1000 && sitAndReach >= 24.9)
                        SitAndReachScore = 100;
                    if (sitAndReach >= 23.1 && sitAndReach < 24.9)
                        SitAndReachScore = 95;
                    if (sitAndReach >= 21.3 && sitAndReach < 23.1)
                        SitAndReachScore = 90;
                    if (sitAndReach >= 19.5 && sitAndReach < 21.3)
                        SitAndReachScore = 85;
                    if (sitAndReach >= 17.7 && sitAndReach < 19.5)
                        SitAndReachScore = 80;
                    if (sitAndReach >= 16.3 && sitAndReach < 17.7)
                        SitAndReachScore = 78;
                    if (sitAndReach >= 14.9 && sitAndReach < 16.3)
                        SitAndReachScore = 76;
                    if (sitAndReach >= 13.5 && sitAndReach < 14.9)
                        SitAndReachScore = 74;
                    if (sitAndReach >= 12.1 && sitAndReach < 13.5)
                        SitAndReachScore = 72;
                    if (sitAndReach >= 10.7 && sitAndReach < 12.1)
                        SitAndReachScore = 70;
                    if (sitAndReach >= 9.3 && sitAndReach < 10.7)
                        SitAndReachScore = 68;
                    if (sitAndReach >= 7.9 && sitAndReach < 9.3)
                        SitAndReachScore = 66;
                    if (sitAndReach >= 6.5 && sitAndReach < 7.9)
                        SitAndReachScore = 64;
                    if (sitAndReach >= 5.1 && sitAndReach < 6.5)
                        SitAndReachScore = 62;
                    if (sitAndReach >= 3.7 && sitAndReach < 5.1)
                        SitAndReachScore = 60;
                    if (sitAndReach >= 2.7 && sitAndReach < 3.7)
                        SitAndReachScore = 50;
                    if (sitAndReach >= 1.7 && sitAndReach < 2.7)
                        SitAndReachScore = 40;
                    if (sitAndReach >= 0.7 && sitAndReach < 1.7)
                        SitAndReachScore = 30;
                    if (sitAndReach >= -0.3 && sitAndReach < 0.7)
                        SitAndReachScore = 20;
                    if (sitAndReach < -0.3 && sitAndReach >= -1.3)
                        SitAndReachScore = 10;
                    if (sitAndReach > -1000 && sitAndReach < -1.3)
                        SitAndReachScore = 0;
                }
                if (studentSex == "2")
                {
                    if (sitAndReach < 1000 && sitAndReach >= 25.8)
                        SitAndReachScore = 100;
                    if (sitAndReach >= 24.0 && sitAndReach < 25.8)
                        SitAndReachScore = 95;
                    if (sitAndReach >= 22.2 && sitAndReach < 24.0)
                        SitAndReachScore = 90;
                    if (sitAndReach >= 20.6 && sitAndReach < 22.2)
                        SitAndReachScore = 85;
                    if (sitAndReach >= 19.0 && sitAndReach < 20.6)
                        SitAndReachScore = 80;
                    if (sitAndReach >= 17.7 && sitAndReach < 19.0)
                        SitAndReachScore = 78;
                    if (sitAndReach >= 16.4 && sitAndReach < 17.7)
                        SitAndReachScore = 76;
                    if (sitAndReach >= 15.1 && sitAndReach < 16.4)
                        SitAndReachScore = 74;
                    if (sitAndReach >= 13.8 && sitAndReach < 15.1)
                        SitAndReachScore = 72;
                    if (sitAndReach >= 12.5 && sitAndReach < 13.8)
                        SitAndReachScore = 70;
                    if (sitAndReach >= 11.2 && sitAndReach < 12.5)
                        SitAndReachScore = 68;
                    if (sitAndReach >= 9.9 && sitAndReach < 11.2)
                        SitAndReachScore = 66;
                    if (sitAndReach >= 8.6 && sitAndReach < 9.9)
                        SitAndReachScore = 64;
                    if (sitAndReach >= 7.3 && sitAndReach < 8.6)
                        SitAndReachScore = 62;
                    if (sitAndReach >= 6.0 && sitAndReach < 7.3)
                        SitAndReachScore = 60;
                    if (sitAndReach >= 5.2 && sitAndReach < 6.0)
                        SitAndReachScore = 50;
                    if (sitAndReach >= 4.4 && sitAndReach < 5.2)
                        SitAndReachScore = 40;
                    if (sitAndReach >= 3.6 && sitAndReach < 4.4)
                        SitAndReachScore = 30;
                    if (sitAndReach >= 2.8 && sitAndReach < 3.6)
                        SitAndReachScore = 20;
                    if (sitAndReach < 2.8 && sitAndReach >= 2.0)
                        SitAndReachScore = 10;
                    if (sitAndReach > -1000 && sitAndReach < 2.0)
                        SitAndReachScore = 0;
                }
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (studentSex == "1")
                {
                    if (sitAndReach < 1000 && sitAndReach >= 25.1)
                        SitAndReachScore = 100;
                    if (sitAndReach >= 23.3 && sitAndReach < 25.1)
                        SitAndReachScore = 95;
                    if (sitAndReach >= 21.5 && sitAndReach < 23.3)
                        SitAndReachScore = 90;
                    if (sitAndReach >= 19.9 && sitAndReach < 21.5)
                        SitAndReachScore = 85;
                    if (sitAndReach >= 18.2 && sitAndReach < 19.9)
                        SitAndReachScore = 80;
                    if (sitAndReach >= 16.8 && sitAndReach < 18.2)
                        SitAndReachScore = 78;
                    if (sitAndReach >= 15.4 && sitAndReach < 16.8)
                        SitAndReachScore = 76;
                    if (sitAndReach >= 14.0 && sitAndReach < 15.4)
                        SitAndReachScore = 74;
                    if (sitAndReach >= 12.6 && sitAndReach < 14.0)
                        SitAndReachScore = 72;
                    if (sitAndReach >= 11.2 && sitAndReach < 12.6)
                        SitAndReachScore = 70;
                    if (sitAndReach >= 9.8 && sitAndReach < 11.2)
                        SitAndReachScore = 68;
                    if (sitAndReach >= 8.4 && sitAndReach < 9.8)
                        SitAndReachScore = 66;
                    if (sitAndReach >= 7.0 && sitAndReach < 8.4)
                        SitAndReachScore = 64;
                    if (sitAndReach >= 5.6 && sitAndReach < 7.0)
                        SitAndReachScore = 62;
                    if (sitAndReach >= 4.2 && sitAndReach < 5.6)
                        SitAndReachScore = 60;
                    if (sitAndReach >= 3.2 && sitAndReach < 4.2)
                        SitAndReachScore = 50;
                    if (sitAndReach >= 2.2 && sitAndReach < 3.2)
                        SitAndReachScore = 40;
                    if (sitAndReach >= 1.2 && sitAndReach < 2.2)
                        SitAndReachScore = 30;
                    if (sitAndReach >= 0.2 && sitAndReach < 1.2)
                        SitAndReachScore = 20;
                    if (sitAndReach < 0.2 && sitAndReach >= -0.8)
                        SitAndReachScore = 10;
                    if (sitAndReach > -1000 && sitAndReach < -0.8)
                        SitAndReachScore = 0;
                }
                if (studentSex == "2")
                {
                    if (sitAndReach < 1000 && sitAndReach >= 26.3)
                        SitAndReachScore = 100;
                    if (sitAndReach >= 24.4 && sitAndReach < 26.3)
                        SitAndReachScore = 95;
                    if (sitAndReach >= 22.4 && sitAndReach < 24.4)
                        SitAndReachScore = 90;
                    if (sitAndReach >= 21.0 && sitAndReach < 22.4)
                        SitAndReachScore = 85;
                    if (sitAndReach >= 19.5 && sitAndReach < 21.0)
                        SitAndReachScore = 80;
                    if (sitAndReach >= 18.2 && sitAndReach < 19.5)
                        SitAndReachScore = 78;
                    if (sitAndReach >= 16.9 && sitAndReach < 18.2)
                        SitAndReachScore = 76;
                    if (sitAndReach >= 15.6 && sitAndReach < 16.9)
                        SitAndReachScore = 74;
                    if (sitAndReach >= 14.3 && sitAndReach < 15.6)
                        SitAndReachScore = 72;
                    if (sitAndReach >= 13.0 && sitAndReach < 14.3)
                        SitAndReachScore = 70;
                    if (sitAndReach >= 11.7 && sitAndReach < 13.0)
                        SitAndReachScore = 68;
                    if (sitAndReach >= 10.4 && sitAndReach < 11.7)
                        SitAndReachScore = 66;
                    if (sitAndReach >= 9.1 && sitAndReach < 10.4)
                        SitAndReachScore = 64;
                    if (sitAndReach >= 7.8 && sitAndReach < 9.1)
                        SitAndReachScore = 62;
                    if (sitAndReach >= 6.5 && sitAndReach < 7.8)
                        SitAndReachScore = 60;
                    if (sitAndReach >= 5.7 && sitAndReach < 6.5)
                        SitAndReachScore = 50;
                    if (sitAndReach >= 4.9 && sitAndReach < 5.7)
                        SitAndReachScore = 40;
                    if (sitAndReach >= 4.1 && sitAndReach < 4.9)
                        SitAndReachScore = 30;
                    if (sitAndReach >= 3.3 && sitAndReach < 4.1)
                        SitAndReachScore = 20;
                    if (sitAndReach < 3.3 && sitAndReach >= 2.5)
                        SitAndReachScore = 10;
                    if (sitAndReach > -1000 && sitAndReach < 2.5)
                        SitAndReachScore = 0;
                }
            }
            return SitAndReachScore.ToString();

        }
        #endregion

        #region 立定跳远单项评分
        /// <summary>
        /// 立定跳远得分
        /// </summary>
        /// <param name="standJump"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string StandJumpScore(int standJump, string studentSex, string gradeCode)
        {
            int StandJumpScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {
                if (studentSex == "1")
                {
                    if (standJump >= 273)
                        StandJumpScore = 100;
                    if (standJump >= 268 && standJump < 273)
                        StandJumpScore = 95;
                    if (standJump >= 263 && standJump < 268)
                        StandJumpScore = 90;
                    if (standJump >= 256 && standJump < 263)
                        StandJumpScore = 85;
                    if (standJump >= 248 && standJump < 256)
                        StandJumpScore = 80;
                    if (standJump >= 244 && standJump < 248)
                        StandJumpScore = 78;
                    if (standJump >= 240 && standJump < 244)
                        StandJumpScore = 76;
                    if (standJump >= 236 && standJump < 240)
                        StandJumpScore = 74;
                    if (standJump >= 232 && standJump < 236)
                        StandJumpScore = 72;
                    if (standJump >= 228 && standJump < 232)
                        StandJumpScore = 70;
                    if (standJump >= 224 && standJump < 228)
                        StandJumpScore = 68;
                    if (standJump >= 220 && standJump < 224)
                        StandJumpScore = 66;
                    if (standJump >= 216 && standJump < 220)
                        StandJumpScore = 64;
                    if (standJump >= 212 && standJump < 216)
                        StandJumpScore = 62;
                    if (standJump >= 208 && standJump < 212)
                        StandJumpScore = 60;
                    if (standJump >= 203 && standJump < 208)
                        StandJumpScore = 50;
                    if (standJump >= 198 && standJump < 203)
                        StandJumpScore = 40;
                    if (standJump >= 193 && standJump < 198)
                        StandJumpScore = 30;
                    if (standJump >= 188 && standJump < 193)
                        StandJumpScore = 20;
                    if (standJump >= 183 && standJump < 188)
                        StandJumpScore = 10;
                    if (standJump < 183)
                        StandJumpScore = 0;
                }
                if (studentSex == "2")
                {
                    if (standJump >= 207)
                        StandJumpScore = 100;
                    if (standJump >= 201 && standJump < 207)
                        StandJumpScore = 95;
                    if (standJump >= 195 && standJump < 201)
                        StandJumpScore = 90;
                    if (standJump >= 188 && standJump < 195)
                        StandJumpScore = 85;
                    if (standJump >= 181 && standJump < 188)
                        StandJumpScore = 80;
                    if (standJump >= 178 && standJump < 181)
                        StandJumpScore = 78;
                    if (standJump >= 175 && standJump < 178)
                        StandJumpScore = 76;
                    if (standJump >= 172 && standJump < 175)
                        StandJumpScore = 74;
                    if (standJump >= 169 && standJump < 172)
                        StandJumpScore = 72;
                    if (standJump >= 166 && standJump < 169)
                        StandJumpScore = 70;
                    if (standJump >= 163 && standJump < 166)
                        StandJumpScore = 68;
                    if (standJump >= 160 && standJump < 163)
                        StandJumpScore = 66;
                    if (standJump >= 157 && standJump < 160)
                        StandJumpScore = 64;
                    if (standJump >= 154 && standJump < 157)
                        StandJumpScore = 62;
                    if (standJump >= 151 && standJump < 154)
                        StandJumpScore = 60;
                    if (standJump >= 146 && standJump < 151)
                        StandJumpScore = 50;
                    if (standJump >= 141 && standJump < 146)
                        StandJumpScore = 40;
                    if (standJump >= 136 && standJump < 141)
                        StandJumpScore = 30;
                    if (standJump >= 131 && standJump < 136)
                        StandJumpScore = 20;
                    if (standJump >= 126 && standJump < 131)
                        StandJumpScore = 10;
                    if (standJump < 126)
                        StandJumpScore = 0;
                }
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (studentSex == "1")
                {
                    if (standJump >= 275)
                        StandJumpScore = 100;
                    if (standJump >= 270 && standJump < 275)
                        StandJumpScore = 95;
                    if (standJump >= 265 && standJump < 270)
                        StandJumpScore = 90;
                    if (standJump >= 258 && standJump < 265)
                        StandJumpScore = 85;
                    if (standJump >= 250 && standJump < 258)
                        StandJumpScore = 80;
                    if (standJump >= 246 && standJump < 250)
                        StandJumpScore = 78;
                    if (standJump >= 242 && standJump < 246)
                        StandJumpScore = 76;
                    if (standJump >= 238 && standJump < 242)
                        StandJumpScore = 74;
                    if (standJump >= 234 && standJump < 238)
                        StandJumpScore = 72;
                    if (standJump >= 230 && standJump < 234)
                        StandJumpScore = 70;
                    if (standJump >= 226 && standJump < 230)
                        StandJumpScore = 68;
                    if (standJump >= 222 && standJump < 226)
                        StandJumpScore = 66;
                    if (standJump >= 218 && standJump < 222)
                        StandJumpScore = 64;
                    if (standJump >= 214 && standJump < 218)
                        StandJumpScore = 62;
                    if (standJump >= 210 && standJump < 214)
                        StandJumpScore = 60;
                    if (standJump >= 203 && standJump < 210)
                        StandJumpScore = 50;
                    if (standJump >= 200 && standJump < 205)
                        StandJumpScore = 40;
                    if (standJump >= 195 && standJump < 200)
                        StandJumpScore = 30;
                    if (standJump >= 190 && standJump < 195)
                        StandJumpScore = 20;
                    if (standJump >= 185 && standJump < 190)
                        StandJumpScore = 10;
                    if (standJump < 185)
                        StandJumpScore = 0;
                }
                if (studentSex == "2")
                {
                    if (standJump >= 208)
                        StandJumpScore = 100;
                    if (standJump >= 202 && standJump < 208)
                        StandJumpScore = 95;
                    if (standJump >= 196 && standJump < 202)
                        StandJumpScore = 90;
                    if (standJump >= 189 && standJump < 196)
                        StandJumpScore = 85;
                    if (standJump >= 182 && standJump < 189)
                        StandJumpScore = 80;
                    if (standJump >= 179 && standJump < 182)
                        StandJumpScore = 78;
                    if (standJump >= 176 && standJump < 179)
                        StandJumpScore = 76;
                    if (standJump >= 173 && standJump < 176)
                        StandJumpScore = 74;
                    if (standJump >= 170 && standJump < 173)
                        StandJumpScore = 72;
                    if (standJump >= 167 && standJump < 170)
                        StandJumpScore = 70;
                    if (standJump >= 164 && standJump < 167)
                        StandJumpScore = 68;
                    if (standJump >= 161 && standJump < 164)
                        StandJumpScore = 66;
                    if (standJump >= 158 && standJump < 161)
                        StandJumpScore = 64;
                    if (standJump >= 155 && standJump < 158)
                        StandJumpScore = 62;
                    if (standJump >= 152 && standJump < 155)
                        StandJumpScore = 60;
                    if (standJump >= 147 && standJump < 152)
                        StandJumpScore = 50;
                    if (standJump >= 142 && standJump < 147)
                        StandJumpScore = 40;
                    if (standJump >= 137 && standJump < 142)
                        StandJumpScore = 30;
                    if (standJump >= 132 && standJump < 137)
                        StandJumpScore = 20;
                    if (standJump >= 127 && standJump < 132)
                        StandJumpScore = 10;
                    if (standJump < 127)
                        StandJumpScore = 0;
                }
            }
            return StandJumpScore.ToString();

        }
        #endregion

        #region （男生）引体向上单项评分

        /// <summary>
        /// (男生)引体向上得分
        /// </summary>
        /// <param name="pullUp"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string PullUpScore(int pullUp, string studentSex, string gradeCode)
        {
            int PullUpScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {
                if (pullUp >= 0 && pullUp < 5)
                    PullUpScore = 0;
                if (pullUp == 5)
                    PullUpScore = 10;
                if (pullUp == 6)
                    PullUpScore = 20;
                if (pullUp == 7)
                    PullUpScore = 30;
                if (pullUp == 8)
                    PullUpScore = 40;
                if (pullUp == 9)
                    PullUpScore = 50;
                if (pullUp == 10)
                    PullUpScore = 60;
                if (pullUp == 11)
                    PullUpScore = 64;
                if (pullUp == 12)
                    PullUpScore = 68;
                if (pullUp == 13)
                    PullUpScore = 72;
                if (pullUp == 14)
                    PullUpScore = 76;
                if (pullUp == 15)
                    PullUpScore = 80;
                if (pullUp == 16)
                    PullUpScore = 85;
                if (pullUp == 17)
                    PullUpScore = 90;
                if (pullUp == 18)
                    PullUpScore = 95;
                if (pullUp == 19)
                    PullUpScore = 100;
                if (pullUp > 19 && pullUp < 30)
                    PullUpScore = 100 + (pullUp - 19);
                if (pullUp >= 30)
                    PullUpScore = 110;
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (pullUp >= 0 && pullUp < 6)
                    PullUpScore = 0;
                if (pullUp == 6)
                    PullUpScore = 10;
                if (pullUp == 7)
                    PullUpScore = 20;
                if (pullUp == 8)
                    PullUpScore = 30;
                if (pullUp == 9)
                    PullUpScore = 40;
                if (pullUp == 10)
                    PullUpScore = 50;
                if (pullUp == 11)
                    PullUpScore = 60;
                if (pullUp == 12)
                    PullUpScore = 64;
                if (pullUp == 13)
                    PullUpScore = 68;
                if (pullUp == 14)
                    PullUpScore = 72;
                if (pullUp == 15)
                    PullUpScore = 76;
                if (pullUp == 16)
                    PullUpScore = 80;
                if (pullUp == 17)
                    PullUpScore = 85;
                if (pullUp == 18)
                    PullUpScore = 90;
                if (pullUp == 19)
                    PullUpScore = 95;
                if (pullUp == 20)
                    PullUpScore = 100;
                if (pullUp > 20 && pullUp < 31)
                    PullUpScore = 100 + (pullUp - 19);
                if (pullUp >= 31)
                    PullUpScore = 110;
            }
            return PullUpScore.ToString();

        }
        #endregion

        #region （女生）一分钟仰卧起坐单项评分
        /// <summary>
        /// (女生)一分钟仰卧起坐得分
        /// </summary>
        /// <param name="minSupination"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string MinSupinationScore(int minSupination, string studentSex, string gradeCode)
        {
            int MinSupinationScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {
                if (minSupination > 69)
                    MinSupinationScore = 110;
                if (minSupination > 62 && minSupination <= 69)
                    MinSupinationScore = (minSupination - 62) + 103;
                if (minSupination > 60 && minSupination <= 62)
                    MinSupinationScore = 103;
                if (minSupination > 58 && minSupination <= 60)
                    MinSupinationScore = 102;
                if (minSupination > 56 && minSupination <= 58)
                    MinSupinationScore = 101;
                if (minSupination == 56)
                    MinSupinationScore = 100;
                if (minSupination >= 54 && minSupination < 56)
                    MinSupinationScore = 95;
                if (minSupination >= 52 && minSupination < 54)
                    MinSupinationScore = 90;
                if (minSupination >= 49 && minSupination < 52)
                    MinSupinationScore = 85;
                if (minSupination >= 46 && minSupination < 49)
                    MinSupinationScore = 80;
                if (minSupination >= 44 && minSupination < 46)
                    MinSupinationScore = 78;
                if (minSupination >= 42 && minSupination < 44)
                    MinSupinationScore = 76;
                if (minSupination >= 40 && minSupination < 42)
                    MinSupinationScore = 74;
                if (minSupination >= 38 && minSupination < 40)
                    MinSupinationScore = 72;
                if (minSupination >= 36 && minSupination < 38)
                    MinSupinationScore = 70;
                if (minSupination >= 34 && minSupination < 36)
                    MinSupinationScore = 68;
                if (minSupination >= 32 && minSupination < 34)
                    MinSupinationScore = 66;
                if (minSupination >= 30 && minSupination < 32)
                    MinSupinationScore = 64;
                if (minSupination >= 28 && minSupination < 30)
                    MinSupinationScore = 62;
                if (minSupination >= 26 && minSupination < 28)
                    MinSupinationScore = 60;
                if (minSupination >= 24 && minSupination < 26)
                    MinSupinationScore = 50;
                if (minSupination >= 22 && minSupination < 24)
                    MinSupinationScore = 40;
                if (minSupination >= 20 && minSupination < 22)
                    MinSupinationScore = 30;
                if (minSupination >= 18 && minSupination < 20)
                    MinSupinationScore = 20;
                if (minSupination >= 16 && minSupination < 18)
                    MinSupinationScore = 10;
                if (minSupination >= 0 && minSupination < 16)
                    MinSupinationScore = 0;
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (minSupination > 70)
                    MinSupinationScore = 110;
                if (minSupination > 63 && minSupination <= 70)
                    MinSupinationScore = (minSupination - 63) + 103;
                if (minSupination > 61 && minSupination <= 63)
                    MinSupinationScore = 103;
                if (minSupination > 59 && minSupination <= 61)
                    MinSupinationScore = 102;
                if (minSupination > 57 && minSupination <= 59)
                    MinSupinationScore = 101;
                if (minSupination == 57)
                    MinSupinationScore = 100;
                if (minSupination >= 55 && minSupination < 57)
                    MinSupinationScore = 95;
                if (minSupination >= 53 && minSupination < 55)
                    MinSupinationScore = 90;
                if (minSupination >= 50 && minSupination < 53)
                    MinSupinationScore = 85;
                if (minSupination >= 47 && minSupination < 50)
                    MinSupinationScore = 80;
                if (minSupination >= 45 && minSupination < 47)
                    MinSupinationScore = 78;
                if (minSupination >= 43 && minSupination < 45)
                    MinSupinationScore = 76;
                if (minSupination >= 41 && minSupination < 43)
                    MinSupinationScore = 74;
                if (minSupination >= 39 && minSupination < 41)
                    MinSupinationScore = 72;
                if (minSupination >= 37 && minSupination < 39)
                    MinSupinationScore = 70;
                if (minSupination >= 35 && minSupination < 37)
                    MinSupinationScore = 68;
                if (minSupination >= 33 && minSupination < 35)
                    MinSupinationScore = 66;
                if (minSupination >= 31 && minSupination < 33)
                    MinSupinationScore = 64;
                if (minSupination >= 29 && minSupination < 31)
                    MinSupinationScore = 62;
                if (minSupination >= 27 && minSupination < 29)
                    MinSupinationScore = 60;
                if (minSupination >= 25 && minSupination < 27)
                    MinSupinationScore = 50;
                if (minSupination >= 23 && minSupination < 25)
                    MinSupinationScore = 40;
                if (minSupination >= 21 && minSupination < 23)
                    MinSupinationScore = 30;
                if (minSupination >= 19 && minSupination < 21)
                    MinSupinationScore = 20;
                if (minSupination >= 17 && minSupination < 19)
                    MinSupinationScore = 10;
                if (minSupination >= 0 && minSupination < 17)
                    MinSupinationScore = 0;
            }
            return MinSupinationScore.ToString();

        }
        #endregion

        #region 分钟转换秒
        /// <summary>
        /// 分钟转换秒
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int MinToSec(int m)
        {
            int second = 0;
            if (m != 0)
            {
                if (m.ToString().Length <= 2)
                {
                    second = m;
                }
                if (m.ToString().Length == 3)
                {
                    string f = m.ToString().Substring(0, 1);
                    string s = m.ToString().Substring(1, m.ToString().Length - 1);
                    second = Convert.ToInt32(f) * 60 + Convert.ToInt32(s);
                }
                if (m.ToString().Length > 3)
                {
                    string f = m.ToString().Substring(0, 2);
                    string s = m.ToString().Substring(2, m.ToString().Length - 2);
                    second = Convert.ToInt32(f) * 60 + Convert.ToInt32(s);
                }
                return second;
            }
            else
            {
                return second;
            }
        }
        #endregion

        #region 分钟转换数字
        /// <summary>
        /// 分钟转换秒
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int FenToNum(string m)
        {
            return Convert.ToInt32(m.Trim().Substring(0, m.Trim().Length - 3) + m.Trim().Substring(m.Trim().Length - 2, 2));
        }
        #endregion

        #region （男生）1000米跑单项评分

        /// <summary>
        /// 男生1000米跑得分
        /// </summary>
        /// <param name="thousandRun"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string ThousandRunScore(int thousandRun, string studentSex, string gradeCode)
        {
            int thousandRunS = MinToSec(thousandRun);
            int ThousandRunScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {
                if (thousandRunS > 0 && thousandRunS <= 162)
                    ThousandRunScore = 110;
                if (thousandRunS > 162 && thousandRunS <= 165)
                    ThousandRunScore = 109;
                if (thousandRunS > 165 && thousandRunS <= 168)
                    ThousandRunScore = 108;
                if (thousandRunS > 168 && thousandRunS <= 171)
                    ThousandRunScore = 107;
                if (thousandRunS > 171 && thousandRunS <= 174)
                    ThousandRunScore = 106;
                if (thousandRunS > 174 && thousandRunS <= 177)
                    ThousandRunScore = 105;
                if (thousandRunS > 177 && thousandRunS <= 181)
                    ThousandRunScore = 104;
                if (thousandRunS > 181 && thousandRunS <= 185)
                    ThousandRunScore = 103;
                if (thousandRunS > 185 && thousandRunS <= 189)
                    ThousandRunScore = 102;
                if (thousandRunS > 189 && thousandRunS <= 193)
                    ThousandRunScore = 101;
                if (thousandRunS > 193 && thousandRunS <= 197)
                    ThousandRunScore = 100;
                if (thousandRunS > 197 && thousandRunS <= 202)
                    ThousandRunScore = 95;
                if (thousandRunS > 202 && thousandRunS <= 207)
                    ThousandRunScore = 90;
                if (thousandRunS > 207 && thousandRunS <= 214)
                    ThousandRunScore = 85;
                if (thousandRunS > 214 && thousandRunS <= 222)
                    ThousandRunScore = 80;
                if (thousandRunS > 222 && thousandRunS <= 227)
                    ThousandRunScore = 78;
                if (thousandRunS > 227 && thousandRunS <= 232)
                    ThousandRunScore = 76;
                if (thousandRunS > 232 && thousandRunS <= 237)
                    ThousandRunScore = 74;
                if (thousandRunS > 237 && thousandRunS <= 242)
                    ThousandRunScore = 72;
                if (thousandRunS > 242 && thousandRunS <= 247)
                    ThousandRunScore = 70;
                if (thousandRunS > 247 && thousandRunS <= 252)
                    ThousandRunScore = 68;
                if (thousandRunS > 252 && thousandRunS <= 257)
                    ThousandRunScore = 66;
                if (thousandRunS > 257 && thousandRunS <= 262)
                    ThousandRunScore = 64;
                if (thousandRunS > 262 && thousandRunS <= 267)
                    ThousandRunScore = 62;
                if (thousandRunS > 267 && thousandRunS <= 272)
                    ThousandRunScore = 60;
                if (thousandRunS > 272 && thousandRunS <= 292)
                    ThousandRunScore = 50;
                if (thousandRunS > 292 && thousandRunS <= 312)
                    ThousandRunScore = 40;
                if (thousandRunS > 312 && thousandRunS <= 332)
                    ThousandRunScore = 30;
                if (thousandRunS > 332 && thousandRunS <= 352)
                    ThousandRunScore = 20;
                if (thousandRunS > 352 && thousandRunS <= 382)
                    ThousandRunScore = 10;
            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (thousandRunS > 0 && thousandRunS <= 160)
                    ThousandRunScore = 110;
                if (thousandRunS > 160 && thousandRunS <= 163)
                    ThousandRunScore = 109;
                if (thousandRunS > 163 && thousandRunS <= 166)
                    ThousandRunScore = 108;
                if (thousandRunS > 166 && thousandRunS <= 169)
                    ThousandRunScore = 107;
                if (thousandRunS > 169 && thousandRunS <= 172)
                    ThousandRunScore = 106;
                if (thousandRunS > 172 && thousandRunS <= 175)
                    ThousandRunScore = 105;
                if (thousandRunS > 175 && thousandRunS <= 179)
                    ThousandRunScore = 104;
                if (thousandRunS > 179 && thousandRunS <= 183)
                    ThousandRunScore = 103;
                if (thousandRunS > 183 && thousandRunS <= 187)
                    ThousandRunScore = 102;
                if (thousandRunS > 187 && thousandRunS <= 191)
                    ThousandRunScore = 101;
                if (thousandRunS > 191 && thousandRunS <= 195)
                    ThousandRunScore = 100;
                if (thousandRunS > 195 && thousandRunS <= 200)
                    ThousandRunScore = 95;
                if (thousandRunS > 200 && thousandRunS <= 205)
                    ThousandRunScore = 90;
                if (thousandRunS > 205 && thousandRunS <= 212)
                    ThousandRunScore = 85;
                if (thousandRunS > 212 && thousandRunS <= 220)
                    ThousandRunScore = 80;
                if (thousandRunS > 220 && thousandRunS <= 225)
                    ThousandRunScore = 78;
                if (thousandRunS > 225 && thousandRunS <= 230)
                    ThousandRunScore = 76;
                if (thousandRunS > 230 && thousandRunS <= 235)
                    ThousandRunScore = 74;
                if (thousandRunS > 235 && thousandRunS <= 240)
                    ThousandRunScore = 72;
                if (thousandRunS > 240 && thousandRunS <= 245)
                    ThousandRunScore = 70;
                if (thousandRunS > 245 && thousandRunS <= 250)
                    ThousandRunScore = 68;
                if (thousandRunS > 250 && thousandRunS <= 255)
                    ThousandRunScore = 66;
                if (thousandRunS > 255 && thousandRunS <= 260)
                    ThousandRunScore = 64;
                if (thousandRunS > 260 && thousandRunS <= 265)
                    ThousandRunScore = 62;
                if (thousandRunS > 265 && thousandRunS <= 270)
                    ThousandRunScore = 60;
                if (thousandRunS > 270 && thousandRunS <= 290)
                    ThousandRunScore = 50;
                if (thousandRunS > 290 && thousandRunS <= 310)
                    ThousandRunScore = 40;
                if (thousandRunS > 310 && thousandRunS <= 330)
                    ThousandRunScore = 30;
                if (thousandRunS > 330 && thousandRunS <= 350)
                    ThousandRunScore = 20;
                if (thousandRunS > 350 && thousandRunS <= 380)
                    ThousandRunScore = 10;
            }
            return ThousandRunScore.ToString();

        }
        #endregion

        #region （女生）800米跑单项评分

        /// <summary>
        /// (女生)800米跑得分
        /// </summary>
        /// <param name="eightHundred"></param>
        /// <param name="studentSex"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public static string EightHundredScore(int eightHundred, string studentSex, string gradeCode)
        {
            int eightHundredS = MinToSec(eightHundred);
            int EightHundredScore = 0;
            if (gradeCode == "41" || gradeCode == "42")
            {

                if (eightHundredS > 0 && eightHundredS <= 148)
                    EightHundredScore = 110;
                if (eightHundredS > 148 && eightHundredS <= 153)
                    EightHundredScore = 109;
                if (eightHundredS > 153 && eightHundredS <= 158)
                    EightHundredScore = 108;
                if (eightHundredS > 158 && eightHundredS <= 163)
                    EightHundredScore = 107;
                if (eightHundredS > 163 && eightHundredS <= 168)
                    EightHundredScore = 106;
                if (eightHundredS > 168 && eightHundredS <= 173)
                    EightHundredScore = 105;
                if (eightHundredS > 173 && eightHundredS <= 178)
                    EightHundredScore = 104;
                if (eightHundredS > 178 && eightHundredS <= 183)
                    EightHundredScore = 103;
                if (eightHundredS > 183 && eightHundredS <= 188)
                    EightHundredScore = 102;
                if (eightHundredS > 188 && eightHundredS <= 193)
                    EightHundredScore = 101;
                if (eightHundredS > 193 && eightHundredS <= 198)
                    EightHundredScore = 100;
                if (eightHundredS > 198 && eightHundredS <= 204)
                    EightHundredScore = 95;
                if (eightHundredS > 204 && eightHundredS <= 210)
                    EightHundredScore = 90;
                if (eightHundredS > 210 && eightHundredS <= 217)
                    EightHundredScore = 85;
                if (eightHundredS > 217 && eightHundredS <= 224)
                    EightHundredScore = 80;
                if (eightHundredS > 224 && eightHundredS <= 229)
                    EightHundredScore = 78;
                if (eightHundredS > 229 && eightHundredS <= 234)
                    EightHundredScore = 76;
                if (eightHundredS > 234 && eightHundredS <= 239)
                    EightHundredScore = 74;
                if (eightHundredS > 239 && eightHundredS <= 244)
                    EightHundredScore = 72;
                if (eightHundredS > 244 && eightHundredS <= 249)
                    EightHundredScore = 70;
                if (eightHundredS > 249 && eightHundredS <= 254)
                    EightHundredScore = 68;
                if (eightHundredS > 254 && eightHundredS <= 259)
                    EightHundredScore = 66;
                if (eightHundredS > 259 && eightHundredS <= 264)
                    EightHundredScore = 64;
                if (eightHundredS > 264 && eightHundredS <= 269)
                    EightHundredScore = 62;
                if (eightHundredS > 269 && eightHundredS <= 274)
                    EightHundredScore = 60;
                if (eightHundredS > 274 && eightHundredS <= 284)
                    EightHundredScore = 50;
                if (eightHundredS > 284 && eightHundredS <= 294)
                    EightHundredScore = 40;
                if (eightHundredS > 294 && eightHundredS <= 304)
                    EightHundredScore = 30;
                if (eightHundredS > 304 && eightHundredS <= 314)
                    EightHundredScore = 20;
                if (eightHundredS > 314 && eightHundredS <= 324)
                    EightHundredScore = 10;

            }
            if (gradeCode == "43" || gradeCode == "44")
            {
                if (eightHundredS > 0 && eightHundredS <= 146)
                    EightHundredScore = 110;
                if (eightHundredS > 146 && eightHundredS <= 151)
                    EightHundredScore = 109;
                if (eightHundredS > 151 && eightHundredS <= 156)
                    EightHundredScore = 108;
                if (eightHundredS > 156 && eightHundredS <= 161)
                    EightHundredScore = 107;
                if (eightHundredS > 161 && eightHundredS <= 166)
                    EightHundredScore = 106;
                if (eightHundredS > 166 && eightHundredS <= 171)
                    EightHundredScore = 105;
                if (eightHundredS > 171 && eightHundredS <= 176)
                    EightHundredScore = 104;
                if (eightHundredS > 176 && eightHundredS <= 181)
                    EightHundredScore = 103;
                if (eightHundredS > 181 && eightHundredS <= 186)
                    EightHundredScore = 102;
                if (eightHundredS > 186 && eightHundredS <= 191)
                    EightHundredScore = 101;
                if (eightHundredS > 191 && eightHundredS <= 196)
                    EightHundredScore = 100;
                if (eightHundredS > 196 && eightHundredS <= 202)
                    EightHundredScore = 95;
                if (eightHundredS > 202 && eightHundredS <= 208)
                    EightHundredScore = 90;
                if (eightHundredS > 208 && eightHundredS <= 215)
                    EightHundredScore = 85;
                if (eightHundredS > 215 && eightHundredS <= 222)
                    EightHundredScore = 80;
                if (eightHundredS > 222 && eightHundredS <= 227)
                    EightHundredScore = 78;
                if (eightHundredS > 227 && eightHundredS <= 232)
                    EightHundredScore = 76;
                if (eightHundredS > 232 && eightHundredS <= 237)
                    EightHundredScore = 74;
                if (eightHundredS > 237 && eightHundredS <= 242)
                    EightHundredScore = 72;
                if (eightHundredS > 242 && eightHundredS <= 247)
                    EightHundredScore = 70;
                if (eightHundredS > 247 && eightHundredS <= 252)
                    EightHundredScore = 68;
                if (eightHundredS > 252 && eightHundredS <= 257)
                    EightHundredScore = 66;
                if (eightHundredS > 257 && eightHundredS <= 262)
                    EightHundredScore = 64;
                if (eightHundredS > 262 && eightHundredS <= 267)
                    EightHundredScore = 62;
                if (eightHundredS > 267 && eightHundredS <= 272)
                    EightHundredScore = 60;
                if (eightHundredS > 272 && eightHundredS <= 282)
                    EightHundredScore = 50;
                if (eightHundredS > 282 && eightHundredS <= 292)
                    EightHundredScore = 40;
                if (eightHundredS > 292 && eightHundredS <= 302)
                    EightHundredScore = 30;
                if (eightHundredS > 302 && eightHundredS <= 312)
                    EightHundredScore = 20;
                if (eightHundredS > 312 && eightHundredS <= 322)
                    EightHundredScore = 10;
            }
            return EightHundredScore.ToString();

        }
        #endregion

    }
}