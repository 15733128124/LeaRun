using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LeaRun.Utilities
{
    /// <summary>
    /// 导出Excel帮助类
    /// </summary>
    public class DeriveExcel
    {
        /// <summary>
        /// IList导出Excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">集合</param>
        /// <param name="DataColumn">字段</param>
        /// <param name="fileName"></param>
        public static void ListToExcel<T>(IList list, string[] DataColumn, string fileName)
        {
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.Charset = "Utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName + ".xls", System.Text.Encoding.UTF8));
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            sbHtml.AppendLine("<table cellspacing=\"0\" cellpadding=\"5\" rules=\"all\" border=\"1\">");
            //写出列名
            sbHtml.AppendLine("<tr style=\"background-color: #FFE88C;font-weight: bold; white-space: nowrap;\">");
            foreach (string item in DataColumn)
            {
                string[] stritem = item.Split(':');
                sbHtml.AppendLine("<td>" + stritem[0] + "</td>");
            }
            sbHtml.AppendLine("</tr>");
            //写数据
            foreach (T entity in list)
            {
                Hashtable ht = HashtableHelper.GetModelToHashtable<T>(entity);
                sbHtml.Append("<tr>");
                foreach (string item in DataColumn)
                {
                    string[] stritem = item.Split(':');
                    sbHtml.Append("<td>").Append(ht[stritem[1]]).Append("</td>");
                }
                sbHtml.AppendLine("</tr>");
            }
            sbHtml.AppendLine("</table>");
            HttpContext.Current.Response.Write(sbHtml.ToString());
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// DataTable导出Excel
        /// </summary>
        /// <param name="data">集合</param>
        /// <param name="DataColumn">字段</param>
        /// <param name="fileName">文件名称</param>
        public static void DataTableToExcel(DataTable data, string[] DataColumn, string fileName)
        {
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.Charset = "Utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName + ".xls", System.Text.Encoding.UTF8));
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            sbHtml.AppendLine("<table cellspacing=\"0\" cellpadding=\"5\" rules=\"all\" border=\"1\">");
            //写出列名
            sbHtml.AppendLine("<tr style=\"background-color: #FFE88C;font-weight: bold; white-space: nowrap;\">");
            foreach (string item in DataColumn)
            {
                sbHtml.AppendLine("<td>" + item + "</td>");
            }
            sbHtml.AppendLine("</tr>");
            //写数据
            foreach (DataRow row in data.Rows)
            {
                sbHtml.Append("<tr>");
                foreach (string item in DataColumn)
                {
                    sbHtml.Append("<td>").Append(row[item]).Append("</td>");
                }
                sbHtml.AppendLine("</tr>");
            }
            sbHtml.AppendLine("</table>");
            HttpContext.Current.Response.Write(sbHtml.ToString());
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// Table标签导出Excel
        /// </summary>
        /// <param name="sbHtml">html标签</param>
        /// <param name="fileName">文件名</param>
        public static void HtmlToExcel(StringBuilder sbHtml, string fileName)
        {
            if (sbHtml.Length > 0)
            {
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.Charset = "Utf-8";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName + ".xls", System.Text.Encoding.UTF8));
                HttpContext.Current.Response.Write(sbHtml.ToString());
                HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// JqGrid导出Excel
        /// </summary>
        /// <param name="JsonColumn">表头</param>
        /// <param name="JsonData">数据</param>
        /// <param name="ExportField">导出字段</param>
        /// <param name="fileName">文件名</param>
        public static void JqGridToExcel(string JsonColumn, string JsonData, string ExportField, string fileName)
        {
            List<JqGridColumn> ListColumn = JsonConvert.DeserializeObject<List<JqGridColumn>>(JsonColumn);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.Charset = "Utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName + ".xls", System.Text.Encoding.UTF8));
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            sbHtml.AppendLine("<table cellspacing=\"0\" cellpadding=\"5\" rules=\"all\" border=\"1\">");
            //写出列名
            sbHtml.AppendLine("<tr style=\"background-color: #FFE88C;font-weight: bold; white-space: nowrap;\">");
            string[] FieldInfo = ExportField.Split(',');
            foreach (string item in FieldInfo)
            {
                IList list = ListColumn.FindAll(t => t.name == item);
                foreach (JqGridColumn jqgridcolumn in list)
                {
                    if (jqgridcolumn.hidden.ToLower() == "false" && jqgridcolumn.label != null)
                    {
                        sbHtml.AppendLine("<td style=\"width:" + jqgridcolumn.width + "px;text-align:" + jqgridcolumn.align + "\">" + jqgridcolumn.label + "</td>");
                    }
                }
            }
            sbHtml.AppendLine("</tr>");
            //写数据
            DataTable dt = JsonData.JsonToDataTable();
            foreach (DataRow row in dt.Rows)
            {
                sbHtml.Append("<tr>");
                foreach (string item in FieldInfo)
                {
                    IList list = ListColumn.FindAll(t => t.name == item);
                    foreach (JqGridColumn jqgridcolumn in list)
                    {
                        if (jqgridcolumn.hidden.ToLower() == "false" && jqgridcolumn.label != null)
                        {
                            object text = row[jqgridcolumn.name];
                            sbHtml.Append("<td style=\"width:" + jqgridcolumn.width + "px;text-align:" + jqgridcolumn.align + "\">").Append(text).Append("</td>");
                        }
                    }
                }
                sbHtml.AppendLine("</tr>");
            }
            sbHtml.AppendLine("</table>");
            HttpContext.Current.Response.Write(sbHtml.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 实体类集合导出到Excle2003
        /// </summary>
        /// <param name="cellHeard">单元头的Key和Value：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="enList">数据源</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns>文件的下载地址</returns>
        public static string ListToExcel2003(Dictionary<string, string> cellHeard, IList tmList, string sheetName)
        {
            try
            {
                string fileName = sheetName + ".xls"; // 文件名称
                string urlPath = "Areas/ZhangCeModule/UploadFile/" + fileName; // 文件下载的URL地址，供给前台下载
                string filePath = HttpContext.Current.Server.MapPath("\\" + urlPath); // 文件路径

                // 1.检测是否存在文件夹，若不存在就建立个文件夹
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                // 2.解析单元格头部，设置单元头的中文名称
                HSSFWorkbook workbook = new HSSFWorkbook(); // 工作簿
                ISheet sheet = workbook.CreateSheet(sheetName); // 工作表
                IRow row = sheet.CreateRow(0);
                List<string> keys = cellHeard.Keys.ToList();
                for (int i = 0; i < keys.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(cellHeard[keys[i]]); // 列名为Key的值
                }

                // 3.List对象的值赋值到Excel的单元格里
                int rowIndex = 1; // 从第二行开始赋值(第一行已设置为单元头)
                foreach (var en in tmList)
                {
                    IRow rowTmp = sheet.CreateRow(rowIndex);
                    for (int i = 0; i < keys.Count; i++) // 根据指定的属性名称，获取对象指定属性的值
                    {
                        string cellValue = ""; // 单元格的值
                        object properotyValue = null; // 属性的值
                        System.Reflection.PropertyInfo properotyInfo = null; // 属性的信息
                        // 3.2 若不是子类的属性，直接根据属性名称获取对象对应的属性
                        properotyInfo = en.GetType().GetProperty(keys[i]);
                        if (properotyInfo != null)
                        {
                            properotyValue = properotyInfo.GetValue(en, null);
                        }

                        // 3.3 属性值经过转换赋值给单元格值
                        if (properotyValue != null)
                        {
                            cellValue = properotyValue.ToString();
                            // 3.3.1 对时间初始值赋值为空
                            if (cellValue.Trim() == "0001/1/1 0:00:00" || cellValue.Trim() == "0001/1/1 23:59:59")
                            {
                                cellValue = "";
                            }
                        }

                        // 3.4 填充到Excel的单元格里
                        rowTmp.CreateCell(i).SetCellValue(cellValue);
                    }
                    rowIndex++;
                }

                // 4.生成文件
                FileStream file = new FileStream(filePath, FileMode.Create);
                workbook.Write(file);
                file.Close();

                // 5.返回下载路径
                return urlPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>  
        /// 将DataTable导出到Excel  
        /// </summary>  
        /// <param name="htmlTable">html表格内容</param>   
        /// <param name="fileName">仅文件名（非路径）</param>   
        /// <returns>返回Excel文件绝对路径</returns>  
        public static string ExportHtmlTableToExcel(string htmlTable, string fileName)
        {
            string result;
            try
            {
                #region 第一步：将HtmlTable转换为DataTable
                htmlTable = htmlTable.Replace("\"", "'");
                var trReg = new Regex(pattern: @"(?<=(<[t|T][r|R]))[\s\S]*?(?=(</[t|T][r|R]>))");
                var trMatchCollection = trReg.Matches(htmlTable);
                DataTable dt = new DataTable("data");
                for (int i = 0; i < trMatchCollection.Count; i++)
                {
                    var row = "<tr " + trMatchCollection[i].ToString().Trim() + "</tr>";
                    var tdReg = new Regex(pattern: @"(?<=(<[t|T][d|D|h|H]))[\s\S]*?(?=(</[t|T][d|D|h|H]>))");
                    var tdMatchCollection = tdReg.Matches(row);
                    if (i == 0)
                    {
                        foreach (var rd in tdMatchCollection)
                        {
                            var tdValue = RemoveHtml("<td " + rd.ToString().Trim() + "</td>");
                            DataColumn dc = new DataColumn(tdValue);
                            dt.Columns.Add(dc);
                        }
                    }
                    if (i > 0)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < tdMatchCollection.Count; j++)
                        {
                            var tdValue = RemoveHtml("<td " + tdMatchCollection[j].ToString().Trim() + "</td>");
                            dr[j] = tdValue;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                #endregion


                #region 第二步：将DataTable导出到Excel
                result = ExportDataSetToExcel(dt, fileName);
                #endregion
            }
            catch (Exception ex)
            {
                result = "err_" + ex.Message;
            }
            return result;
        }


        /// <summary>  
        /// 将DataTable导出到Excel  
        /// </summary>  
        /// <param name="dt">DataTable</param>   
        /// <param name="fileName">仅文件名（非路径）</param>   
        /// <returns>返回Excel文件绝对路径</returns>  
        public static string ExportDataSetToExcel(DataTable dt, string fileName)
        {
            #region 表头
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ISheet hssfSheet = hssfworkbook.CreateSheet(fileName); // 工作表

            hssfSheet.DefaultColumnWidth = 13;
            hssfSheet.SetColumnWidth(0, 25 * 256);
            hssfSheet.SetColumnWidth(3, 20 * 256);
            // 表头  
            IRow tagRow = hssfSheet.CreateRow(0);
            tagRow.Height = 22 * 20;


            // 标题样式  
            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;


            int colIndex;
            for (colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                tagRow.CreateCell(colIndex).SetCellValue(dt.Columns[colIndex].ColumnName);
                tagRow.GetCell(colIndex).CellStyle = cellStyle;
            }
            #endregion
            #region 表数据
            // 表数据    
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                DataRow dr = dt.Rows[k];
                IRow row = hssfSheet.CreateRow(k + 1);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dr[i].ToString());
                    row.GetCell(i).CellStyle = cellStyle;
                }
                //合并单元格
                if ((k + 1) % 2 == 0 && k != 0)
                {
                    CellRangeAddress region = new CellRangeAddress(k, k + 1, 0, 0);
                    hssfSheet.AddMergedRegion(region);
                    CellRangeAddress region2 = new CellRangeAddress(k, k + 1, 1, 1);
                    hssfSheet.AddMergedRegion(region2);
                    CellRangeAddress region3 = new CellRangeAddress(k, k + 1, 7, 7);
                    hssfSheet.AddMergedRegion(region3);
                }

            }

            #endregion
            string urlPath = "Areas/ZhangCeModule/UploadFile/" + fileName +".xls"; // 文件下载的URL地址，供给前台下载
            string filePath = HttpContext.Current.Server.MapPath("\\" + urlPath); // 文件路径

            FileStream file = new FileStream(filePath, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
            // 返回下载路径
            return urlPath;

        }




        /// <summary>  
        ///     去除HTML标记  
        /// </summary>  
        /// <param name="htmlstring"></param>  
        /// <returns>已经去除后的文字</returns>  
        public static string RemoveHtml(string htmlstring)
        {
            //删除脚本      
            htmlstring =
                Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>",
                              "", RegexOptions.IgnoreCase);
            //删除HTML      
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);


            htmlstring = htmlstring.Replace("<", "");
            htmlstring = htmlstring.Replace(">", "");
            htmlstring = htmlstring.Replace("\r\n", "");
            return htmlstring;
        }

    }
}
