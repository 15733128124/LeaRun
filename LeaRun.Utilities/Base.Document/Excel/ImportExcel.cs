using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LeaRun.Utilities
{
    /// <summary>
    /// 导入Excel帮助类
    /// </summary>
    public class ImportExcel
    {
        /// <summary>
        /// Excel检查版本
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string ConnectionString(string fileName)
        {
            bool isExcel2003 = fileName.EndsWith(".xls");
            string connectionString = string.Format(
                isExcel2003
                    ? "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;"
                    : "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\"",
                fileName);
            return connectionString;
        }
        /// <summary>
        /// Excel导入数据源
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string sheet, string filename)
        {
            OleDbConnection myConn = new OleDbConnection(ConnectionString(filename));
            try
            {
                DataSet ds;
                string strCom = " SELECT * FROM [Sheet1$]";
                myConn.Open();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
                ds = new DataSet();
                myCommand.Fill(ds);
                myConn.Close();
                return ds.Tables[0];
            }
            catch (Exception)
            {
                myConn.Close();
                myConn.Dispose();
                throw;
            }
        }

        #region Excel导入操作
        /// <summary>
        /// 将本地的EXCEL上传到服务器，进行导入处理
        /// </summary>
        /// <param name="inputfile">html中File控件名称</param>
        /// <param name="UpLoadFilePath">要上传文件的物理路径</param>
        /// <returns>成功上传后返回上传文件的路径</returns>
        public static string UpLoadXls(HttpPostedFileBase inputfile, string UpLoadFilePath)
        {
            string orifilename = string.Empty;
            string uploadfilepath = string.Empty;
            string modifyfilename = string.Empty;
            string fileExtend = "";//文件扩展名
            int fileSize = 0;//文件大小
            try
            {
                if (inputfile.ContentLength != 0)
                {
                    //得到文件的大小
                    fileSize = inputfile.ContentLength;
                    if (fileSize == 0)
                    {
                        throw new Exception("导入的Excel文件大小为0，请检查是否正确！");
                    }
                    //得到扩展名
                    fileExtend = inputfile.FileName.Substring(inputfile.FileName.LastIndexOf(".") + 1);
                    if (fileExtend.ToLower() != "xls" & fileExtend.ToLower() != "xlsx")
                    {
                        throw new Exception("你选择的文件格式不正确，只能导入EXCEL文件！");
                    }
                    //路径
                    uploadfilepath = UpLoadFilePath;
                    //新文件名
                    modifyfilename = System.Guid.NewGuid().ToString();
                    modifyfilename += "." + inputfile.FileName.Substring(inputfile.FileName.LastIndexOf(".") + 1);
                    //判断是否有该目录
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(uploadfilepath);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }

                    orifilename = uploadfilepath + "\\" + modifyfilename;
                    //System.IO.DirectoryInfo p = new System.IO.DirectoryInfo(orifilename);
                    //if (p.Exists)
                    //{
                    //    p.Delete();
                    //}
                    inputfile.SaveAs(orifilename);
                }
                else
                {
                    throw new Exception("请选择要导入的Excel文件!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orifilename;
        }

        /// <summary>
        /// 获取到EXCEL中数据集
        /// </summary>
        /// <param name="fileName">excel文件所在的物理路径</param>
        /// <returns></returns>
        public static DataSet ImportXlsToData(string fileName)
        {
            DataSet ds = new DataSet();
            try
            {
                string connStr = string.Empty;
                bool isExcel2003 = fileName.EndsWith(".xls");
                if (isExcel2003)
                {
                    connStr = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + fileName + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
                }
                else
                {
                    connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "data source=" + fileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
                }
                OleDbConnection conn = new OleDbConnection(connStr);
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var tableName = dt.Rows[0][2].ToString().Trim();
                var strsql = string.Format("Select * from [{0}]", tableName);
                OleDbDataAdapter oda = new OleDbDataAdapter(strsql, conn);

                oda.Fill(ds);
                conn.Close();
                File.Delete(fileName);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
        #endregion
    }
}
