using LeaRun.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LeaRun.WebApi.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TeacherLoginAttribute: AuthorizationFilterAttribute
    {
       /// <summary>
       /// 重写用户权限验证方法
       /// </summary>
       /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            BaseController controller = actionContext.ControllerContext.Controller as BaseController;
            object token = System.Web.HttpContext.Current.Request["token"];
            if (token == null)
            {
                NoAuthor(actionContext);
            }
            else
            {
                string errorMess = string.Empty;             
                //if (CacheHelper.Get(token.ToString())!=null)
                //{
                //}
                //else
                //{
                   
                //}

            }
        }

        private static void NoAuthor(HttpActionContext actionContext)
        {
            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            response.Content = new StringContent(Json.Encode("{\"code\":\"-1\"," + "\"msg\":\"已经过期！请重新登录\"}"), Encoding.UTF8, "application/json");
        }
    }
}