using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeaRun.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// token身份令牌
        /// </summary>
        public string token { get; set; }
    }
}
