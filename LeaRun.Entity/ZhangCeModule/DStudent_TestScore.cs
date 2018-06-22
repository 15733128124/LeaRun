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
    /// ѧ���ɼ����Ա�����ݽ���
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2017.10.26 10:41</date>
    /// </author>
    /// </summary>
    [Description("ѧ���ɼ����Ա�����ݽ���")]
    [PrimaryKey("ID")]
    public class DStudent_TestScore : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ţ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ţ�������")]
        public int? ID { get; set; }
        /// <summary>
        ///ѧ��ѧ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ��ѧ��")]
        public string StudentCode { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ������")]
        public string StudentName { get; set; }
        /// <summary>
        /// ѧ���Ա� 1���� 2��Ů
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ���Ա� 1���� 2��Ů")]
        public string StudentSex { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("���")]
        public string Heigh { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Weight { get; set; }
        /// <summary>
        /// �������ָ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ָ��")]
        public string BMI { get; set; }
        /// <summary>
        /// �������ָ���÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ָ���÷�")]
        public string BMIScore { get; set; }
        /// <summary>
        /// �������ָ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ָ������")]
        public string BMILevel { get; set; }
        /// <summary>
        /// �λ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�λ���")]
        public string Pulmonary { get; set; }
        /// <summary>
        /// �λ����÷� 
        /// </summary>
        /// <returns></returns>
        [DisplayName("�λ����÷� ")]
        public string PulmonaryScore { get; set; }
        /// <summary>
        /// �λ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�λ�������")]
        public string PulmonaryLevel { get; set; }
        /// <summary>
        /// 50����
        /// </summary>
        /// <returns></returns>
        [DisplayName("50����")]
        public string FiftyRun { get; set; }
        /// <summary>
        /// 50���ܵ÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("50���ܵ÷�")]
        public string FiftyRunScore { get; set; }
        /// <summary>
        /// 50���ܼ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("50���ܼ���")]
        public string FiftyRunLevel { get; set; }
        /// <summary>
        /// ������Զ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Զ")]
        public string StandJump { get; set; }
        /// <summary>
        /// ������Զ�÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Զ�÷�")]
        public string StandJumpScore { get; set; }
        /// <summary>
        /// ������Զ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Զ����")]
        public string StandJumpLevel { get; set; }
        /// <summary>
        /// ��λ��ǰ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��λ��ǰ��")]
        public string SitAndReach { get; set; }
        /// <summary>
        /// ��λ��ǰ���÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("��λ��ǰ���÷�")]
        public string SitAndReachScore { get; set; }
        /// <summary>
        /// ��λ��ǰ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��λ��ǰ������")]
        public string SitAndReachLevel { get; set; }
        /// <summary>
        /// 800����
        /// </summary>
        /// <returns></returns>
        [DisplayName("800����")]
        public string EightHundred { get; set; }
        /// <summary>
        /// 800���ܵ÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("800���ܵ÷�")]
        public string EightHundredScore { get; set; }
        /// <summary>
        /// 800���ܼ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("800���ܼ���")]
        public string EightHundredLevel { get; set; }
        /// <summary>
        /// 800���ܼӷ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("800���ܼӷ�")]
        public string EightHundredAddScore { get; set; }
        /// <summary>
        /// 1000����
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000����")]
        public string ThousandRun { get; set; }
        /// <summary>
        /// 1000���ܵ÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000���ܵ÷�")]
        public string ThousandRunScore { get; set; }
        /// <summary>
        /// 1000���ܼ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000���ܼ���")]
        public string ThousandRunLevel { get; set; }
        /// <summary>
        /// 1000���ܼӷ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("1000���ܼӷ�")]
        public string ThousandRunAddScore { get; set; }
        /// <summary>
        /// 1������������
        /// </summary>
        /// <returns></returns>
        [DisplayName("1������������")]
        public string MinSupination { get; set; }
        /// <summary>
        /// 1�������������÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("1�������������÷�")]
        public string MinSupinationScore { get; set; }
        /// <summary>
        /// 1����������������
        /// </summary>
        /// <returns></returns>
        [DisplayName("1����������������")]
        public string MinSupinationLevel { get; set; }
        /// <summary>
        /// 1�������������ӷ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("1�������������ӷ�")]
        public string MinSupinationAddScore { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string PullUp { get; set; }
        /// <summary>
        /// �������ϵ÷�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ϵ÷�")]
        public string PullUpScore { get; set; }
        /// <summary>
        /// �������ϼ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ϼ���")]
        public string PullUpLevel { get; set; }
        /// <summary>
        /// �������ϼӷ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ϼӷ�")]
        public string PullUpAddScore { get; set; }
        /// <summary>
        /// ���Խ����δ�⣬���⣬ͨ������⣬����
        /// </summary>
        /// <returns></returns>
        [DisplayName("���Խ����δ�⣬���⣬ͨ������⣬����")]
        public string TestResult { get; set; }
        /// <summary>
        /// ѧ�����ɼ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("ѧ�����ɼ�")]
        public string StudentTrueScore { get; set; }
        /// <summary>
        /// �������ͣ�����Լ������������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ͣ�����Լ������������")]
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