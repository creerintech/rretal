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
    public class PaymentFollowUp
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _PayFollowUpId = "@PayFollowUpId";
        public static string _PayFollowUpDtlsId = "@PayFollowUpDtlsId";
        public static string _PSdtlId = "@PSdtlId";
        public static string _FollowUpDate = "@FollowUpDate";
        public static string _AddAuth = "@AddAuth";
        public static string _FollowUpId = "@FollowUpId";
        public static string _CallBackDate = "@CallBackDate";
        public static string _Remark = "@Remark";
        public static string _BookingId = "@BookingId";
        public static string _IsChecked = "@IsChecked";
        public static string _Flag = "@Flag";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        public static string _PreRemark = "@PreRemark";
        public static string _CommentByAdmin = "@CommentByAdmin";
        public static string _EmpId = "@EmpId";

        public static string _TobePaid = "@TobePaid";
        public static string _Received = "@Received";
        public static string _OutstandingAmt = "@OutstandingAmt";

        public static string _TotalFlatAmount = "@TotalFlatAmount";
        public static string _DueWithSrvTax = "@DueWithSrvTax";
        public static string _RcvdWithSrvTax = "@RcvdWithSrvTax";
        public static string _BalWithSrvTax = "@BalWithSrvTax ";
        public static string _TowerName = "@Building";
        public static string _PCId = "@PCId";
        public static string _Date = "@Date";
        #endregion

        #region Definitions
        private Int32 m_Action;
        public string TowerName { get; set; }
        public string Date { get; set; }
        public long PCId{ get; set; }
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_PayFollowUpId;

        public Int32 PayFollowUpId
        {
            get { return m_PayFollowUpId; }
            set { m_PayFollowUpId = value; }
        }

        private Int32 m_PayFollowUpDtlsId;

        public Int32 PayFollowUpDtlsId
        {
            get { return m_PayFollowUpDtlsId; }
            set { m_PayFollowUpDtlsId = value; }
        }

        private DateTime m_FollowUpDate;

        public DateTime FollowUpDate
        {
            get { return m_FollowUpDate; }
            set { m_FollowUpDate = value; }
        }

        private bool m_Flag;

        public bool Flag
        {
            get { return m_Flag; }
            set { m_Flag = value; }
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


        private string m_CommentByAdmin;

        public string CommentByAdmin
        {
            get { return m_CommentByAdmin; }
            set { m_CommentByAdmin = value; }
        }

        private Int32 m_PSdtlId;

        public Int32 PSdtlId
        {
            get { return m_PSdtlId; }
            set { m_PSdtlId = value; }
        }

        private decimal m_OutstandingAmt;

        public decimal OutstandingAmt
        {
            get { return m_OutstandingAmt; }
            set { m_OutstandingAmt = value; }
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
        private decimal m_TobePaid;

        public decimal TobePaid
        {
            get { return m_TobePaid; }
            set { m_TobePaid = value; }
        }
        private decimal m_Received;

        public decimal Received
        {
            get { return m_Received; }
            set { m_Received = value; }
        }


        public decimal BalWithSrvTax { get; set; }
        public decimal TotalFlatAmount { get; set; }
        public decimal DueWithSrvTax { get; set; }
        public decimal RcvdWithSrvTax { get; set; }

       

        #endregion

        # region Stored Procedure
        public static string SP_Payment_FollowUp = "SP_Payment_FollowUp";
        #endregion

        public PaymentFollowUp()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
