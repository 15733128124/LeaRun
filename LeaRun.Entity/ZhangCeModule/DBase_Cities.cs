//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2017
// Software Developers @ Learun 2017
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
    /// �������б�
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:12</date>
    /// </author>
    /// </summary>
    [Description("�������б�")]
    [PrimaryKey("ID")]
    public class DBase_Cities : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public int? ID { get; set; }
        /// <summary>
        /// ���б��
        /// </summary>
        /// <returns></returns>
        [DisplayName("���б��")]
        public string CityCode { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string CityName { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public string CreateTime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public string UpdateTime { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ע")]
        public string Remark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        //public override void Create()
        //{
        //    this.ID = CommonHelper.GetGuid;
        //                                    }
        ///// <summary>
        ///// �༭����
        ///// </summary>
        ///// <param name="KeyValue"></param>
        //public override void Modify(string KeyValue)
        //{
        //    this.ID = KeyValue;
        //                                    }
        #endregion
    }
}