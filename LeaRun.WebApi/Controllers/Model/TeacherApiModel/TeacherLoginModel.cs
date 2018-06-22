using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaRun.WebApi.Controllers
{
    public class TeacherLoginModel:BaseModel
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string userpwd { get; set; }

        /// <summary>
        /// 返回一个model的实体类
        /// </summary>
        /// <returns></returns>
        public TeacherLoginModel ToTeacherModel()
        {
            TeacherLoginModel model = new TeacherLoginModel();
            model.token = base.token;
            model.username = this.username;
            model.userpwd = this.userpwd;
            return model;
        }
    }
}