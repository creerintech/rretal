﻿using System;
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

/// <summary>
/// Summary description for ExpenseOutstandingRecipt
/// </summary>
/// 

namespace Build.EntityClass
{
    public class ExpenseOutstandingRecipt
    {


        #region[constants]
        public static string _Action = "@Action";
        public static string _ReceiptExpOutId = "@ReceiptExpOutId";
        public static string _ReceiptNo = "@ReceiptNo";
        public static string _ReceiptDate = "@ReceiptDate";

        public static string _PartyId = "@PartyId";
        public static string _PropertyId = "@PropertyId";
        public static string _ExpenseHdId = "@ExpenseHdId";
        public static string _UnitNo = "@UnitNo";

        public static string _ForTheMonth = "@ForTheMonth";

        public static string _VoucherAmt = "@VoucherAmt";



        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";


        public static string _Narration = "@Narration";
        public static string _FortheMonthYear = "@FortheMonthYear";


        #endregion

        #region[Defination]

        private string m_Tower;
        public decimal VoucherAmt { get; set; }
        public Int32 ExpenseHdId { get; set; }
        public string FortheMonthYear { get; set; }

        private string m_Narration;

        public string Narration
        {
            get { return m_Narration; }
            set { m_Narration = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_ReceiptExpOutId;

        public Int32 ReceiptExpOutId
        {
            get { return m_ReceiptExpOutId; }
            set { m_ReceiptExpOutId = value; }
        }

        private string m_ReceiptNo;

        public string ReceiptNo
        {
            get { return m_ReceiptNo; }
            set { m_ReceiptNo = value; }
        }

        private DateTime m_ReceiptDate;

        public DateTime ReceiptDate
        {
            get { return m_ReceiptDate; }
            set { m_ReceiptDate = value; }
        }


        private Int32 m_PartyId;

        public Int32 PartyId
        {
            get { return m_PartyId; }
            set { m_PartyId = value; }
        }

        private Int32 m_PropertyId;
        public Int32 PropertyId
        {
            get { return m_PropertyId; }
            set { m_PropertyId = value; }
        }


        private string m_UnitNo;

        public string UnitNo
        {
            get { return m_UnitNo; }
            set { m_UnitNo = value; }
        }

        private DateTime m_ForTheMonth;

        public DateTime ForTheMonth
        {
            get { return m_ForTheMonth; }
            set { m_ForTheMonth = value; }
        }


        private Int32 m_UserId;
        public Int32 UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }

        private DateTime m_LoginDate;
        public string UpdatedOn { get; set; }

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





        #endregion

        #region[procedure]
        public static string SP_Receipt_ExpenseOutstatnding = "dbo.SP_Receipt_ExpenseOutstatnding";
     
        public static string SP_Print = "SP_Print";
        #endregion

        public ExpenseOutstandingRecipt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}