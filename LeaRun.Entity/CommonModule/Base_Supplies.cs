//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2015
// Software Developers @ Learun 2015
//=====================================================================================

using LeaRun.DataAccess.Attributes;
using LeaRun.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaRun.Entity
{
    /// <summary>
    /// 供应商表
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2015.07.20 15:11</date>
    /// </author>
    /// </summary>
    [Description("供应商表")]
    [PrimaryKey("SupplierId")]
    public class Base_Supplies : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 供应商主键
        /// </summary>
        /// <returns></returns>
        [DisplayName("供应商主键")]
        public string SupplierId { get; set; }
        /// <summary>
        /// 供应商编码
        /// </summary>
        /// <returns></returns>
        [DisplayName("供应商编码")]
        public string Code { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("供应商名称")]
        public string FullName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [DisplayName("电话")]
        public string Telephone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        /// <returns></returns>
        [DisplayName("传真")]
        public string Fax { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        /// <returns></returns>
        [DisplayName("结算方式")]
        public string AccountsMethod { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <returns></returns>
        [DisplayName("联系人")]
        public string LinkMan { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        /// <returns></returns>
        [DisplayName("负责人")]
        public string LeadingOfficialId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        [DisplayName("地址")]
        public string Address { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.SupplierId = CommonHelper.GetGuid;
                                            }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.SupplierId = KeyValue;
                                            }
        #endregion
    }
}