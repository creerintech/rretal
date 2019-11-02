using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for LoanDFollowUp
/// </summary>
/// 
namespace Build.EntityClass
{
    public class LoanDFollowUp
    {

        #region Column Constant
        public static string _Action = "@Action";
        public static string _LoanDFollowUpDtlsId = "@LoanDFollowUpDtlsId";
        public static string _LoanDFollowUpId = "@LoanDFollowUpId";
        public static string _LoanDFollowUpDate = "@LoanDFollowUpDate";
        public static string _AddAuth = "@AddAuth";
        //public static string _FollowUpId = "@FollowUpId";
        public static string _CallBackDate = "@CallBackDate";
        public static string _Remark = "@Remark";
        public static string _BookingId = "@BookingId";
        public static string _IsChecked = "@IsChecked";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        public static string _PreRemark = "@PreRemark";
        public static string _EmpId = "@EmpId";
        public static string _FollowUpRegisterId = "@FollowUpRegistredId";
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
        private Int32 m_LoanDFollowUpId;

        public Int32 LoanDFollowUpId
        {
            get { return m_LoanDFollowUpId; }
            set { m_LoanDFollowUpId = value; }
        }
        private Int32 m_LoanDFollowUpDtlsId;

        public Int32 LoanDFollowUpDtlsId
        {
            get { return m_LoanDFollowUpDtlsId; }
            set { m_LoanDFollowUpDtlsId = value; }
        }
        private DateTime m_LoanDFollowUpDate;

        public DateTime LoanDFollowUpDate
        {
            get { return m_LoanDFollowUpDate; }
            set { m_LoanDFollowUpDate = value; }
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

        private Int32 m_BookingId;

        public Int32 BookingId
        {
            get { return m_BookingId; }
            set { m_BookingId = value; }
        }

        private Int32 m_FollowUpRegisterId;

        public Int32 FollowUpRegisterId
        {
            get { return m_FollowUpRegisterId; }
            set { m_FollowUpRegisterId = value; }
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
        public static string SP_LoanD_FollowUp = "SP_LoanD_FollowUp";
        #endregion


        public LoanDFollowUp()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}