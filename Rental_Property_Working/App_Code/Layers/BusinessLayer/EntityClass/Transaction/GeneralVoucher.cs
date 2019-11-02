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

/// <summary>
/// Summary description for GeneralVoucher
/// </summary>

namespace Build.EntityClass
{
    [Serializable()]
    public class GeneralVoucher
    {
        # region Column Constant
        public const string _RepCondition = "@RepCondition";
        public const string _Action = "@Action";
        public const string _VoucherNo = "@VoucherNo";
        public const string _VoucherDebit = "@VoucherDebit";
        public const string _VoucherAmount = "@VoucherAmount";
        public const string _TransId = "@TransId";
        public const string _VoucherDate = "@VoucherDate";
        public const string _CustLedgerID = "@CustLedgerID";
        public const string _CustId = "@CustId";
        public const string _TopartyId = "@TopartyId";

        public const string _Narration = "@Narration";
        public const string _VoucherId = "@VoucherId";
        public const string _LoginDate = "@LoginDate";
        public const string _LoginID = "@LoginID";
        
        # endregion

        #region property defination   

        private Int32 m_VoucherDebit;
        public Int32 VoucherDebit
        {
            get { return m_VoucherDebit; }
            set { m_VoucherDebit = value; }
        }

        private Decimal m_VoucherAmount;
        public Decimal VoucherAmount
        {
            get { return m_VoucherAmount; }
            set { m_VoucherAmount = value; }
        }
        private Int32 m_TransId;
        public Int32 TransId
        {
            get { return m_TransId; }
            set { m_TransId = value; }
        }
        
        private Int32 m_CustLedgerID;
        public Int32 CustLedgerID
        {
            get { return m_CustLedgerID; }
            set { m_CustLedgerID = value; }
        }
        
        private String m_Narration;
        public String Narration
        {
            get { return m_Narration; }
            set { m_Narration = value; }
        }
        
        private Int32 m_VoucherId;

        public Int32 VoucherId
        {
            get { return m_VoucherId; }
            set { m_VoucherId = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
               
        private String m_VoucherNo;

        public String VoucherNo
        {
            get { return m_VoucherNo; }
            set { m_VoucherNo = value; }
        }

        private DateTime m_VoucherDate;

        public DateTime VoucherDate
        {
            get { return m_VoucherDate; }
            set { m_VoucherDate = value; }
        }
                

        private Int32 m_CustId;
        public Int32 CustId
        {
            get { return m_CustId; }
            set { m_CustId = value;}
        }

        private Int32 m_TopartyId;
         public Int32 TopartyId
        {
            get { return m_TopartyId; }
            set { m_TopartyId = value; }
        }
    
      

        private DateTime m_LoginDate;
        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }

        private Int32 m_LoginID;
        public Int32 LoginID
        {
            get { return m_LoginID; }
            set { m_LoginID = value; }
        }
        #endregion

        #region Store Procedure
        public const string SP_JournalVoucher = "SP_JournalVoucher";
        #endregion
        public GeneralVoucher()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
