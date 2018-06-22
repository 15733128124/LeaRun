using LeaRun.Business;
using LeaRun.DataAccess.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;
using LeaRun.Cache;

namespace LeaRun.WebApi.Controllers
{
    [RoutePrefix("api/TeacherLogin")]
    public class TeacherLoginController : ApiController
    {
        [HttpPost]
        [Route("api/TeacherLogin/TeacherLogin")]
        public string TeacherLogin()
        {
            object userName = System.Web.HttpContext.Current.Request["username"];
            object userPwd = System.Web.HttpContext.Current.Request["userpwd"];
            string token = "";
            //实例化
            DBase_UsersBll buBLL = new DBase_UsersBll();
            //判断用户是否存在
            if (buBLL.TeacherLogin(userName.ToString(), DESEncrypt.Encrypt(userPwd.ToString())).UserCode != null)
            {
                string result = string.Format("{0}|{1}|", userName, userPwd);
                token = DESEncrypt.AESEncrypt(result);
                //把令牌存入缓存
                CacheHelper.Insert(result, userName.ToString());
                return "{\"code\":\"3\",\"msg\":\"登录成功！\",\"data\":{\"username\":\"" + userName + "\",\"usercode\":\"" + userPwd + "\",\"token\":\"" + token + "\"}}";
            }
            else
            {
                //程序错误
                return "{\"code\":\"0\"," + "\"msg\":\"用户不存在！登录失败！\"}";
            }
        }
    }
}
