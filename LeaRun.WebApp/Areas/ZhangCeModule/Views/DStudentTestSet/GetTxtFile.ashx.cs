using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LeaRun.WebApp.Areas.ZhangCeModule.Views.DStudentTestSet
{
    /// <summary>
    /// GetTxtFile 的摘要说明
    /// </summary>
    public class GetTxtFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            FileStream fs = new FileStream("E:\\SD.txt", FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes("ok\r\nno");
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}