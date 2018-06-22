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
    /// ѧ��������Ϣ������ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:19</date>
    /// </author>
    /// </summary>
    [Description("ѧ��������Ϣ������ݽ���")]
    [PrimaryKey("ID")]
    public class DStudent_Infos : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ���,������
        /// </summary>
        /// <returns></returns>
        [DisplayName("���,������")]
        public int? ID { get; set; }
        /// <summary>
        /// ѧ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ�����")]
        public string StudentCode { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ������")]
        public string StudentName { get; set; }
        /// <summary>
        /// ѧ���Ա�  1:��  2:Ů
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ���Ա�  1:��  2:Ů")]
        public string StudentSex { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string StudentBornDate { get; set; }
        /// <summary>
        /// ѧ��סַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ��סַ")]
        public string StudentHomeAddress { get; set; }
        /// <summary>
        /// �꼶���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�꼶���")]
        public string GradeCode { get; set; }
        /// <summary>
        /// ѧԺ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧԺ����")]
        public string SchoolName { get; set; }
        /// <summary>
        /// ѧԺ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧԺ���")]
        public string SchoolCode { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�༶����")]
        public string ClassName { get; set; }
        /// <summary>
        /// �༶���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�༶���")]
        public string ClassCode { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string NationCode { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string NationName { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ������")]
        public string StudentNative { get; set; }
        /// <summary>
        /// �춯����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�춯����")]
        public string StudentMoveType { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        [DisplayName("���֤��")]
        public string StudentIDNumber { get; set; }
        /// <summary>
        /// ѧ���绰
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ���绰")]
        public string StudentPhone { get; set; }
        /// <summary>
        /// �Ƿ�ע��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ�ע��")]
        public string StudentIsRegister { get; set; }
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
        /// Remark
        /// </summary>
        /// <returns></returns>
        [DisplayName("Remark")]
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