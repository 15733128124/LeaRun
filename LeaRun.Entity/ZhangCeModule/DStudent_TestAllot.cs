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
    /// DStudent_TestAllot
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.13 09:07</date>
    /// </author>
    /// </summary>
    [Description("DStudent_TestAllot")]
    [PrimaryKey("ID")]
    public class DStudent_TestAllot : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ID")]
        public int? ID { get; set; }
        /// <summary>
        /// ��������ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("TestSetID")]
        public int? TestSetID { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("TestGroup")]
        public string TestGroup { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("GroupCount")]
        public int? GroupCount { get; set; }
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("BeginPraDate")]
        public string BeginPraDate { get; set; }
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("BeginWeek")]
        public string BeginWeek { get; set; }
        /// <summary>
        /// ��ʼ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("BeginPraTime")]
        public string BeginPraTime { get; set; }
        /// <summary>
        /// ������ʦ
        /// </summary>
        /// <returns></returns>
        [DisplayName("TestTeacher")]
        public string TestTeacher { get; set; }
        /// <summary>
        /// ��ע
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