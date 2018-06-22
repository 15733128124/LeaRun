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
    /// ���Կ��أ�����ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    [Description("���Կ��أ�����ݽ���")]
    [PrimaryKey("ID")]
    public class DStudent_TestOnOff : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ţ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ţ�������")]
        public int? ID { get; set; }
        /// <summary>
        /// ״̬������ on���ر�off
        /// </summary>
        /// <returns></returns>
        [DisplayName("״̬������ on���ر�off")]
        public string State { get; set; }
        /// <summary>
        /// �������ͣ�����Լ������������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ͣ�����Լ������������")]
        public string TestType { get; set; }
        /// <summary>
        /// �����꼶
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����꼶")]
        public string GradeCode { get; set; }
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