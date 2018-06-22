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
    /// ѧ���û���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:13</date>
    /// </author>
    /// </summary>
    [Description("ѧ���û���")]
    [PrimaryKey("ID")]
    public class DBase_Users : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ���,������
        /// </summary>
        /// <returns></returns>
        [DisplayName("���,������")]
        public int? ID { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�û�����")]
        public string UserName { get; set; }
        /// <summary>
        /// �û���ţ�Ĭ��ѧ�ţ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�û���ţ�Ĭ��ѧ�ţ�")]
        public string UserCode { get; set; }
        /// <summary>
        /// ����:�״�123456
        /// </summary>
        /// <returns></returns>
        [DisplayName("����:�״�123456")]
        public string UserPassword { get; set; }
        /// <summary>
        /// �û����� 1:��ʦ,2:ѧ��,
        /// </summary>
        /// <returns></returns>
        [DisplayName("�û����� 1:��ʦ,2:ѧ��,")]
        public string UserLeavel { get; set; }
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
        /// <summary>
        /// 1:�ѵ�¼,0:δ��¼  ��ֻ����ʦʵ�ֵ����¼��
        /// </summary>
        /// <returns></returns>
        [DisplayName("1:�ѵ�¼,0:δ��¼  ��ֻ����ʦʵ�ֵ����¼��")]
        public string UserState { get; set; }
        #endregion

        #region ��չ����
        ///// <summary>
        ///// ��������
        ///// </summary>
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