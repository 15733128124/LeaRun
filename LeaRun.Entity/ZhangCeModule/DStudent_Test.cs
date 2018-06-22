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
    /// ѧ�����Ա�����ݽ���
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.15 11:42</date>
    /// </author>
    /// </summary>
    [Description("ѧ�����Ա�����ݽ���")]
    [PrimaryKey("ID")]
    public class DStudent_Test : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// Id����
        /// </summary>
        /// <returns></returns>
        [DisplayName("Id����")]
        public int? ID { get; set; }
        /// <summary>
        /// ѧ��ѧ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ��ѧ��")]
        public string StudentCode { get; set; }
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
        /// ��������ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������ID")]
        public int TestSetID { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ������")]
        public string StudentName { get; set; }
        /// <summary>
        /// ѧ���Ա�
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ���Ա�")]
        public string StudentSex { get; set; }
        /// <summary>
        /// ������ʦ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������ʦ")]
        public string TestTeacher { get; set; }
        /// <summary>
        /// ���Ե�ַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���Ե�ַ")]
        public string TestAddress { get; set; }
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʼ��������")]
        public string BeginPraDate { get; set; }
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʼ��������")]
        public string BeginWeek { get; set; }
        /// <summary>
        /// ��ʼ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʼ����ʱ��")]
        public string BeginPraTime { get; set; }
        /// <summary>
        /// �Ƿ���Ч 1:��Ч��2����Ч
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ���Ч")]
        public string ApplyFor { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string TestGroup { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������")]
        public string TestGroupCode { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string TestType { get; set; }
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