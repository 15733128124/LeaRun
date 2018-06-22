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
    /// �Ӱ������
    /// <author>
    ///		<name>Mr.HuoXiangSheng</name>
    ///		<date>2015.07.21 09:59</date>
    /// </author>
    /// </summary>
    [Description("�Ӱ������")]
    [PrimaryKey("OvertimeId")]
    public class OvertimeRequest : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// �Ӱ���������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ���������")]
        public string OvertimeId { get; set; }
        /// <summary>
        /// �Ӱ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ�����")]
        public string Type { get; set; }
        /// <summary>
        /// �Ӱ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ�����")]
        public string Date { get; set; }
        /// <summary>
        /// �Ӱ࿪ʼʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ࿪ʼʱ��")]
        public string StartTime { get; set; }
        /// <summary>
        /// �Ӱ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ����ʱ��")]
        public string EndTime { get; set; }
        /// <summary>
        /// �Ӱ�ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ�ʱ��")]
        public string Time { get; set; }
        /// <summary>
        /// �Ӱ��˲�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ��˲�������")]
        public string DepartmentId { get; set; }
        /// <summary>
        /// �Ӱ����û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ӱ����û�����")]
        public string UserId { get; set; }
        /// <summary>
        /// �����˲�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����˲�������")]
        public string CreateDepartmentId { get; set; }
        /// <summary>
        /// �������û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������û�����")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public string CreateTime { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.OvertimeId = CommonHelper.GetGuid;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateDepartmentId = ManageProvider.Provider.Current().DepartmentId;
            this.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.OvertimeId = KeyValue;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateDepartmentId = ManageProvider.Provider.Current().DepartmentId;
            this.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion
    }
}