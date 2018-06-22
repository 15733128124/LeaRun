
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    public class DStudent_FinshSchoolTestBll : RepositoryFactory<DStudent_FinshSchoolTest>
    {
        /// <summary>
        /// 添加学生毕业成绩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDStudentFinshSchoolTest(DStudent_FinshSchoolTest model)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"INSERT INTO DStudent_FinshSchoolTest (StudentCode,BigOne,BigTwo,BigThree,BigFour,FinshTest,FinshYear,CreateTime,UpdateTime,Remark) 
                                   VALUES(@StudentCode,@BigOne,@BigTwo,@BigThree,@BigFour,@FinshTest,@FinshYear,@CreateTime,@UpdateTime,@Remark)");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@BigOne", model.BigOne));
            parameter.Add(DbFactory.CreateDbParameter("@BigTwo", model.BigTwo));
            parameter.Add(DbFactory.CreateDbParameter("@BigThree", model.BigThree));
            parameter.Add(DbFactory.CreateDbParameter("@BigFour", model.BigFour));
            parameter.Add(DbFactory.CreateDbParameter("@FinshTest", model.FinshTest));
            parameter.Add(DbFactory.CreateDbParameter("@FinshYear", model.FinshYear));
            parameter.Add(DbFactory.CreateDbParameter("@CreateTime", model.CreateTime));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }

        /// <summary>
        /// 根据学号查重
        /// </summary>
        /// <param name="studentCode"></param>
        /// <returns></returns>
        public int DStudentFinshSchoolTestCheckReapt(string studentCode)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT COUNT(StudentCode) from DStudent_FinshSchoolTest WHERE StudentCode=@StudentCode");
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", studentCode));
            return Repository().FindCountBySql(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 修改学生毕业成绩记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="gradeCode"></param>
        /// <returns></returns>
        public int UpdDStudentFinshSchoolTest(DStudent_FinshSchoolTest model, string gradeCode)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@StudentCode", model.StudentCode));
            parameter.Add(DbFactory.CreateDbParameter("@FinshTest", model.FinshTest));
            parameter.Add(DbFactory.CreateDbParameter("@FinshYear", model.FinshYear));
            parameter.Add(DbFactory.CreateDbParameter("@UpdateTime", model.UpdateTime));
            parameter.Add(DbFactory.CreateDbParameter("@Remark", model.Remark));
            string strGrade = "";
            if (gradeCode == "41")
            { strGrade = "BigOne=@BigOne"; parameter.Add(DbFactory.CreateDbParameter("@BigOne", model.BigOne)); }
            if (gradeCode == "42")
            { strGrade = "BigtTwo=@BigtTwo"; parameter.Add(DbFactory.CreateDbParameter("@BigtTwo", model.BigTwo)); }
            if (gradeCode == "43")
            { strGrade = "BigThree=@BigThree"; parameter.Add(DbFactory.CreateDbParameter("@BigThree", model.BigThree)); }
            if (gradeCode == "44")
            { strGrade = "BigFour=@BigFour"; parameter.Add(DbFactory.CreateDbParameter("@BigFour", model.BigFour)); }
            strSql.Append(@"UPDATE DStudent_FinshSchoolTest SET " + strGrade + ",FinshTest=@FinshTest,FinshYear=@FinshYear,UpdateTime=@UpdateTime,Remark=@Remark WHERE StudentCode=@StudentCode");
            return Repository().ExecuteBySql(strSql, parameter.ToArray());
        }
    }
}
