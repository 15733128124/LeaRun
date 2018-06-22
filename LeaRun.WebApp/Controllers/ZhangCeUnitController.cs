using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Controllers
{
    public class ZhangCeUnitController : Controller
    {
        DBase_UsersBll bUsersBll = new DBase_UsersBll();
        DBase_NKBll bNKBll = new DBase_NKBll();


        #region  初始化测试老师名单
        /// <summary>
        /// 导入老师后台首页
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult ZhangCeTeacherImportIndex()
        {
            ViewBag.Account = ManageProvider.Provider.Current().Account + "（" + ManageProvider.Provider.Current().UserName + "）";
            return View();
        }

        //老师工号导入
        [LoginAuthorize]
        public ActionResult TeacherInfoImport()
        {
            return View();
        }

        //导入老师信息
        public JsonResult TeacherInfoImportData()
        {
            DirFileHelper.ClearDirectory("/Areas/ZhangCeModule/UploadFile");
            string filePath = "";

            //文件大小不为0
            HttpPostedFileBase fileData = HttpContext.Request.Files[0];
            //保存成自己的文件全路径,newfile就是你上传后保存的文件,
            //服务器上的UpLoadFile文件夹必须有读写权限　
            filePath = ImportExcel.UpLoadXls(fileData, Server.MapPath("~/Areas/ZhangCeModule/UploadFile/" + fileData.FileName));

            #region 将服务器上的excel数据导出成数据集,添加入库

            DataTable xmlDate = ImportExcel.ImportXlsToData(filePath).Tables[0];

            string returnMsg = AddExcelData(xmlDate, CookieHelper.GetCookie("NK"));

            #endregion

            return Json(new { Msg = returnMsg });
        }

        //错误信息展示
        public string ErrorMsgTitle(int rowindex, string cloumn)
        {
            return "第" + rowindex + "条数据[" + cloumn + "]";
        }



        /// <summary>
        /// 添加Excel的数据
        /// </summary>
        /// <param name="xmlDate"></param>
        private string AddExcelData(DataTable xmlDate, string NK)
        {
            string errorMsg = "";
            int errorcount = 0;//错误的个数
            int sumcount = xmlDate.Rows.Count;//导入数据的总个数
            int rowindex = 1;//行标
            string comname = string.Empty;
            int i = 1;
            string userName = "";
            string userCode = "";
            foreach (DataRow excelRow in xmlDate.Rows)
            {

                bool flg = true;//可添加入库的标识
                rowindex++;
                try
                {


                    userName = excelRow[0].ToString().Trim();
                    /**************老师姓名**********/
                    int userNameLength = excelRow[0].ToString().Trim().Length;
                    comname = excelRow[0].ToString().Trim();
                    if (userNameLength > 0 && userNameLength <= 100)
                    {
                        userName = excelRow[0].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败\r\n";
                        flg = false;
                    }

                    /**************老师代号**********/
                    int userCodeLength = excelRow[1].ToString().Trim().Length;
                    if (userCodeLength > 0 & userCodeLength <= 100)
                    {
                        userCode = excelRow[1].ToString().Trim();
                    }
                    else
                    {
                        if (flg)
                            errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "为空,或者长度超过100个字符),添加失败\r\n";
                        flg = false;
                    }

                }

                catch (Exception ex)
                {
                    if (flg)
                        errorcount++;
                    errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + ",添加失败;失败原因:" + ex.Message + "<br/>";
                    flg = false;
                }


                if (flg)
                {
                    int result = 1;
                    try
                    {
                        //导入信息返回的结果
                        result = bUsersBll.AddDBase_UserTeacher(userName, userCode, DESEncrypt.Encrypt(userCode));
                        if (result <= 0)
                        {
                            if (flg)
                                errorcount++;
                            errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "添加失败(原因:数据库已存在!)" + "<br/>";
                        }
                    }
                    catch (Exception ex)
                    {
                        errorcount++;
                        errorMsg = errorMsg + ErrorMsgTitle(rowindex, comname) + "添加失败;失败原因:" + ex.Message + "<br/>";
                    }
                }

                i++;

            }



            string importMsg = "共导入【" + sumcount + "】条记录<br/>" +
                            "导入成功【" + (sumcount - errorcount) + "】条记录<br/>" +
                            "导入失败【" + (errorcount) + "】条记录<br/>";

            return importMsg + "<br><div style='color:blue' id='errorMsg'>" + errorMsg + "</div>";


        }

        //返回一个下载路径
        public FileResult GetExcelFile()
        {
            FilePathResult file = new FilePathResult("~/Areas/ZhangCeModule/ExcelFiles/教师信息模版.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = "教师信息模版.xlsx";
            return file;
        }

        #endregion


        #region 年库的创建与删除
        /// <summary>
        /// 年库的创建和删除视图
        /// </summary>
        /// <returns></returns>
        [LoginAuthorize]
        public ActionResult CreateNKAndDelFrom()
        {
            DBase_NKBll nkBll = new DBase_NKBll();
            List<DBase_NK> List = nkBll.GetListDBaseNK();
            ViewBag.Account = ManageProvider.Provider.Current().Account + "（" + ManageProvider.Provider.Current().UserName + "）";
            return View(List);
        }

        /// <summary>
        /// 检查口令是否正确
        /// </summary>
        /// <returns></returns>
        public JsonResult CheckNKKouLing(string kouLing)
        {
            return Json(new { IsOk = bUsersBll.CheckNKKouLing(ManageProvider.Provider.Current().Account, DESEncrypt.Encrypt(kouLing)) > 0 ? true : false });
        }

        /// <summary>
        /// 创建年库
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public JsonResult CreateNK(string NK)
        {
            if (CommonHelper.IsInt(NK))
            {
                if (bNKBll.FindCountDBaseNK(Convert.ToInt32(NK)) > 0)
                {
                    return Json(new { IsOk = "-1", Msg = "该年库已经存在，不能重复创建！" });
                }
                else
                {
                    int n = 0;
                    n = bNKBll.AddDBaseNK(new DBase_NK { NK = Convert.ToInt32(NK), CreateTime = System.DateTime.Now.ToString(), CreateUser = ManageProvider.Provider.Current().Account, Remark = "" });
                    return Json(new { IsOk = n.ToString(), Msg = "" });
                }
            }
            else
            {
                return Json(new { IsOk = "-2", Msg = "不合法！创建失败！" });
            }

        }

        /// <summary>
        /// 删除年库
        /// </summary>
        /// <param name="NK"></param>
        /// <returns></returns>
        public JsonResult DelNK(string NK)
        {
            if (CommonHelper.IsInt(NK))
            {
                if (bNKBll.FindCountDBaseNK(Convert.ToInt32(NK)) > 0)
                {
                    int n = 0;
                    n = bNKBll.DelDBaseNK(NK);
                    return Json(new { IsOk = n.ToString(), Msg = "" });
                }
                else
                {
                    return Json(new { IsOk = "-1", Msg = "该年库在不存在，不用删除！" });
                }
            }
            else
            {
                return Json(new { IsOk = "-2", Msg = "不合法！删除失败！" });
            }
        }

        public JsonResult UpdNKKouLing(string updNKMark, string oldNKMark)
        {
            return Json(new { IsOk = bUsersBll.UpdDNKKouLing(ManageProvider.Provider.Current().Account, DESEncrypt.Encrypt(updNKMark), DESEncrypt.Encrypt(oldNKMark)) > 0 ? true : false });
        }
        #endregion


        #region 数据库的备份与恢复

        //数据库的备份与恢复
        public ActionResult ZhangCeBackUpFrom()
        {
            ViewBag.Account = ManageProvider.Provider.Current().Account + "（" + ManageProvider.Provider.Current().UserName + "）";
            //获取backup文件下的所有备份文件
            return View(GetBackFiles());
        }

        //备份
        public JsonResult ZhangCeBackUp()
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                string ConnectionStringBackUp = ConfigurationManager.AppSettings["SqlConnctionString"].ToString();
                string DataBaseName = ConfigurationManager.AppSettings["SqlName"].ToString();
                SqlConnection myConBackUp = new SqlConnection(ConnectionStringBackUp);
                System.Threading.Thread.Sleep(500);
                myConBackUp.Open();
                string severpath = Server.MapPath("~/backup");
                //备份数据库的名
                string backName = "\\" + DateTime.Now.ToShortDateString().Replace("/", "-") + " " + DateTime.Now.Hour.ToString() +
                "：" + DateTime.Now.Minute.ToString() + "：" + DateTime.Now.Second.ToString() + " " + DataBaseName + ".bak'";
                string SqlIns = "use master;backup database [" + DataBaseName + "] to disk='" + severpath + backName;
                SqlCommand commandBackUp = new SqlCommand();
                commandBackUp.CommandText = SqlIns;
                commandBackUp.Connection = myConBackUp;
                commandBackUp.ExecuteNonQuery();
                return Json(new { IsOk = true, Msg = "数据库" + DataBaseName + "备份成功！" });

            }
            catch (Exception ex)
            {
                return Json(new { IsOk = false, Msg = "数据库备份失败！" });
            }

        }


        //还原确保master  中有p_killspid 存储过程
        public JsonResult ZhangCeRecover(string dataBaseRsource)
        {

            try
            {
                string ConnectionStringRecover = ConfigurationManager.AppSettings["SqlConnctionString"].ToString();
                string DataBaseName = ConfigurationManager.AppSettings["SqlName"].ToString();
                SqlConnection myConRecover = new SqlConnection(ConnectionStringRecover);
                myConRecover.Open();
                string serverpath = Server.MapPath("~/backup");
                string SqlIns = "use master;exec p_killspid '" + DataBaseName + "';restore database [" + DataBaseName + "] from disk='" + serverpath + "\\" + dataBaseRsource + "' WITH REPLACE;";

                SqlCommand commandRecover = new SqlCommand(SqlIns, myConRecover);               
                commandRecover.ExecuteNonQuery();
                commandRecover.Dispose();
                myConRecover.Close();
                myConRecover.Dispose();
                SqlConnection.ClearAllPools();
                return Json(new { IsOk = true, Msg = "数据库" + DataBaseName + "还原成功！" });

            }
            catch (Exception ex)
            {
                return Json(new { IsOk = false, Msg = "数据库备份失败！" });
            }

        }

        //删除备份
        public JsonResult ZhangCeBackUpDel(string dataBaseRsource)
        {
            string serverpath = Server.MapPath("~/backup") + "\\" + dataBaseRsource;
            System.IO.File.Delete(serverpath);
            return Json(new { IsOk = true, Msg = "删除"+dataBaseRsource+"备份成功！" });
        }

        //获取backup文件中所有文件
        private List<BaseFile> GetBackFiles()
        {
            List<BaseFile> list = new List<BaseFile>();
            string severpath = HttpContext.Server.MapPath("~/backup");
            //获取backup文件夹中的所有文件
            string[] files = System.IO.Directory.GetFiles(severpath);
            for (int i = 0; i < files.Length; i++)
            {
                BaseFile model = new BaseFile();
                int loc = 0;
                string file = files[i];
                for (int j = 0; j < file.Length; j++)
                {
                    if (file[j].ToString() == "\\")
                    {
                        loc = j + 1;
                    }
                }
                files[i] = file.Substring(loc, file.Length - loc);
                model.FileName = i.ToString();
                model.FileValue = files[i];
                list.Add(model);
            }
            return list;
        }

        //查询备份数量
        public JsonResult GetBackFileCount()
        {
            string severpath = HttpContext.Server.MapPath("~/backup");
            //获取backup文件夹中的所有文件
            string[] files = System.IO.Directory.GetFiles(severpath);
            return Json(new { IsOk = files.Length >= 10 ? true : false });
        }
        #endregion


        #region 学生跨年库调整

        //学生跨年库视图
        public ActionResult StudentGoNKFrom()
        {
            return View();
        }

       

        #endregion
    }

}



