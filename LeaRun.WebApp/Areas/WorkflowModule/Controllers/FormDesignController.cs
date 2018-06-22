using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.WorkflowModule.Controllers
{
    /// <summary>
    /// 表单设计器控制器
    /// </summary>
    public class FormDesignController : Controller
    {
        /// <summary>
        /// 表单设计器
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 标签
        /// </summary>
        /// <returns></returns>
        public ActionResult Label()
        {
            return View();
        }
        /// <summary>
        /// 超连接
        /// </summary>
        /// <returns></returns>
        public ActionResult HyperLink()
        {
            return View();
        }
        /// <summary>
        /// 单行文本框
        /// </summary>
        /// <returns></returns>
        public ActionResult Text()
        {
            return View();
        }
        /// <summary>
        /// 多行文本框
        /// </summary>
        /// <returns></returns>
        public ActionResult Textarea()
        {
            return View();
        }
        /// <summary>
        /// 下拉框(枚举)
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectEnum()
        {
            return View();
        }
        /// <summary>
        /// 下拉框(表/视图)
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectTable()
        {
            return View();
        }
        /// <summary>
        /// 日期框
        /// </summary>
        /// <returns></returns>
        public ActionResult DateTimeBox()
        {
            return View();
        }
        /// <summary>
        /// 单选框
        /// </summary>
        /// <returns></returns>
        public ActionResult Radio()
        {
            return View();
        }
        /// <summary>
        /// 多选框
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckBox()
        {
            return View();
        }
    }
}
