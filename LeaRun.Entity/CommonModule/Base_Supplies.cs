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
    /// ��Ӧ�̱�
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2015.07.20 15:11</date>
    /// </author>
    /// </summary>
    [Description("��Ӧ�̱�")]
    [PrimaryKey("SupplierId")]
    public class Base_Supplies : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��Ӧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӧ������")]
        public string SupplierId { get; set; }
        /// <summary>
        /// ��Ӧ�̱���
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӧ�̱���")]
        public string Code { get; set; }
        /// <summary>
        /// ��Ӧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӧ������")]
        public string FullName { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [DisplayName("�绰")]
        public string Telephone { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Fax { get; set; }
        /// <summary>
        /// ���㷽ʽ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���㷽ʽ")]
        public string AccountsMethod { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ϵ��")]
        public string LinkMan { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string LeadingOfficialId { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ַ")]
        public string Address { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.SupplierId = CommonHelper.GetGuid;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.SupplierId = KeyValue;
                                            }
        #endregion
    }
}