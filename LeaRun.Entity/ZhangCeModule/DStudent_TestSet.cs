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
    /// ѧ���������ñ�����ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:20</date>
    /// </author>
    /// </summary>
    [Description("ѧ���������ñ�����ݽ���")]
    [PrimaryKey("ID")]
    public class DStudent_TestSet : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ţ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ţ�������")]
        public int? ID { get; set; }
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʼʱ��")]
        public string TestBeginDate { get; set; }
        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʼ����")]
        public string TestBeginWeek { get; set; }
        /// <summary>
        /// ���Եص�
        /// </summary>
        /// <returns></returns>
        [DisplayName("���Եص�")]
        public string TestAddress { get; set; }
        /// <summary>
        /// ѧ���Ա�  1����  2��Ů
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ���Ա�  1����  2��Ů")]
        public string StudentSex { get; set; }
        /// <summary>
        /// ����ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ѧ������")]
        public string TestStudentCount { get; set; }
        /// <summary>
        /// ���Կ�ʼʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("���Կ�ʼʱ��")]
        public string TestBeginTime { get; set; }
        /// <summary>
        /// ��Լ����ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Լ����ѧ������")]
        public string TestStudentOkCount { get; set; }
        /// <summary>
        /// δԼ����ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("δԼ����ѧ������")]
        public string TestStudentNoCount { get; set; }
        /// <summary>
        /// ����״̬
        /// </summary>
        /// <returns></returns>
        [DisplayName("δԼ����ѧ������")]
        public string AllotState { get; set; }

        /// <summary>
        /// �������ƴ�һ����������������ģ����⣨ȫ���ɲμӣ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string TestLimit { get; set; }

        /// <summary>
        /// �������ͣ�Լ�����ԡ���Ԫ���ԡ�����Լ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ͣ�Լ�����ԡ���Ԫ���ԡ�����Լ��")]
        public string TestType { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public string CreateTime { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸�ʱ��")]
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