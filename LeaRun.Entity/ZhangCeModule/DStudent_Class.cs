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
    /// �༶������ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:17</date>
    /// </author>
    /// </summary>
    [Description("�༶������ݽ���")]
    [PrimaryKey("ID")]
    public class DStudent_Class : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ţ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ţ�������")]
        public int? ID { get; set; }
        /// <summary>
        /// �꼶���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�꼶���")]
        public string GradeCode { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧԺ���")]
        public string SchoolCode { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧԺ����")]
        public string SchoolName { get; set; }
        /// <summary>
        /// �༶���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�༶���")]
        public string ClassCode { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�༶����")]
        public string ClassName { get; set; }
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