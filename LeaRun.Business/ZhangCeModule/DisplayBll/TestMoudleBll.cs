using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace LeaRun.Business
{
    public class TestMoudleBll: RepositoryFactory<TestMoudle>
    {
        /// <summary>
        /// 获取测试模板所有的基础信息
        /// </summary>
        /// <returns></returns>
        public List<TestMoudle> GetTestMoudleAllInfo(string NK)
        {
            DStudent_ClassBll scBll = new DStudent_ClassBll();
            string[] items = { "身高", "体重", "肺活量", "50米跑", "立定跳远", "坐位体前屈", "1000米跑", "引体向上", "800米跑", "一分钟仰卧起坐" };
            string[] itemsM = { "身高体重测试仪", "身高体重测试仪", "肺活量测试仪", "秒表", "立定跳远测试仪", "坐位体前屈测试仪", "秒表", "单杠", "秒表", "海绵垫" };
            List<TestMoudle> testMouldeList = new List<TestMoudle>();
            DataTable dt = scBll.GetAllStudentClassInfoDataTable(CookieHelper.GetCookie("NK"));
            ArrayList teacherArray = GetTestTeacher();           
            foreach (DataRow row in dt.Rows)
            {
                int[] a = GetRandom(teacherArray.Count);
                for (int i = 0; i < 10; i++)
                {
                    TestMoudle tm = new TestMoudle();
                    tm.GradeCode = row["GradeCode"].ToString();
                    tm.ClassCode = row["ClassCode"].ToString();
                    tm.ClassName = row["ClassName"].ToString();
                    tm.ItemName = items[i];
                    tm.TestTeacher = teacherArray.ToArray().GetValue(a[i]).ToString();
                    tm.TestTime = "";
                    tm.TestAddress = "田径场";
                    tm.TestMaterial = itemsM[i];
                    tm.TestType = "1";
                    testMouldeList.Add(tm);
                }

            }
            return testMouldeList;
        }

        //获取测老师
        private ArrayList GetTestTeacher()
        {
            ArrayList teacherList = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT UserName from DBase_Users where UserLeavel='1'");
            DataTable dt = Repository().FindTableBySql(strSql.ToString());
           
            foreach (DataRow row in dt.Rows)
            {
                teacherList.Add(row["UserName"].ToString());
            }
            return teacherList;         
        }


        //获取10个随即数字
        public int[] GetRandom(int count)
        {
            
            Random ran = new Random(Guid.NewGuid().GetHashCode());//定义随机数对象
           
            int[] a = new int[10];//定义数组
            bool boo = true;//设置开关
            for (int i = 0; i < 10; i++)
            {
                int n = ran.Next(count);//定义随机数的范围
                for (int j = 0; j < i; j++)
                {
                    if (count <= 10)
                    {
                        boo = true;
                    }
                    else
                    {
                        if (a[j] == n)
                        {
                            boo = false;
                            break;//当前数跟前面的数一样则断开循环
                        }
                        else
                        {
                            boo = true;
                        }
                    }
                }
                if (boo)
                {
                    a[i] = n;//赋值当前数为n
                }
                else
                {

                    i--;//当前数相等时下标-1
                }
                
            }           
            return a;
        }
  
    }
}
