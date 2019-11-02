using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Build.EntityClass
{
    public class FollowUpDetails
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _FollowUpDtlsId = "@FollowUpDtlsId";
        public static string _FollowId = "@FollowId";
        public static string _FollowUpDate = "@FollowUpDate";
        public static string _AddAuth = "@AddAuth";
        public static string _FollowUpId = "@FollowUpId";
        public static string _CallBackDate = "@CallBackDate";
        public static string _Remark = "@Remark";
        public static string _EnquiryId = "@EnquiryId";
        public static string _IsChecked = "@IsChecked";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        public static string _PreRemark = "@PreRemark";
        public static string _EmpId = "@EmpId";
        public static string _CancelFollowUp = "@CancelFollowUp";
        public static string _FromDate = "@FromDate";
        public static string _ToDate = "@ToDate";
        #endregion

        #region Definitions
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        private Int32 m_FollowId;

        public Int32 FollowId
        {
            get { return m_FollowId; }
            set { m_FollowId = value; }
        }
        private Int32 m_FollowUpDtlsId;

        public Int32 FollowUpDtlsId
        {
            get { return m_FollowUpDtlsId; }
            set { m_FollowUpDtlsId = value; }
        }
        private DateTime m_FollowUpDate;

        public DateTime FollowUpDate
        {
            get { return m_FollowUpDate; }
            set { m_FollowUpDate = value; }
        }
        private bool m_IsChecked;
        public bool IsChecked
        {
            get { return m_IsChecked; }
            set { m_IsChecked = value; }
        }
       
        private DateTime m_CallBackDate;

        public DateTime CallBackDate
        {
            get { return m_CallBackDate; }
            set { m_CallBackDate = value; }
        }

        private Int32 m_FollowUpId;

        public Int32 FollowUpId
        {
            get { return m_FollowUpId; }
            set { m_FollowUpId = value; }
        }

        private Int32 m_EnquiryId;

        public Int32 EnquiryId
        {
            get { return m_EnquiryId; }
            set { m_EnquiryId = value; }
        }

        private string m_Remark;

        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }

        private string m_PreRemark;

        public string PreRemark
        {
            get { return m_PreRemark; }
            set { m_PreRemark = value; }
        }
        private Int32 m_UserId;

        public Int32 UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }

        private DateTime m_LoginDate;

        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }

        private bool m_IsDeleted;

        public bool IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }

        private string m_StrCondition;

        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }

        private Int32 m_EmpId;

        public Int32 EmpId
        {
            get { return m_EmpId; }
            set { m_EmpId = value; }
        }

        private bool m_CancelFollowUp;

        public bool CancelFollowUp
        {
            get { return m_CancelFollowUp; }
            set { m_CancelFollowUp = value; }
        }
        #endregion

        # region Stored Procedure
        public static string SP_Enquiry_FollowUp = "SP_Enquiry_FollowUp";
        #endregion
        public FollowUpDetails()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
