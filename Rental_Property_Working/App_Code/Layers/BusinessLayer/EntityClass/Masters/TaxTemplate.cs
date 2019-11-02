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

    public class TaxTemplate
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _TaxId = "@TaxId";
        public static string _PCId = "@PCId";
      
        //Dtails
        public static string _TaxDtlId = "@TaxDtlId";
        public static string _TaxTypeId = "@TaxTypeId";
        public static string _ApplicableDate = "@ApplicableDate";
        public static string _TaxName = "@TaxName";
        public static string _Percentage = "@Percentage";
        public static string _ChargeId = "@ChargeId";
        public static string _TaxAmount = "@TaxAmount";
        public static string _Type = "@Type";
        public static string _TaxFormatId = "@TaxFormatId";
        public static string _DateFlag = "@DateFlag";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        public static string _TaxApplicable= "@IncludeIn";
        public static string _USedCount= "@UsedCount";
        public static string _FromAmt = "@FromAmt";
        public static string _ToAmt = "@ToAmt";
        public static string _DisplayName = "@DisplayName";
        #endregion

        #region Definitions
        public int TaxApplicable { get; set; }
        public long UsedCount { get; set; }
        public decimal FromAmt { get; set; }
        public decimal ToAmt { get; set; }
        public string DisplayName { get; set; }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private long m_TaxId;

        public long TaxId
        {
            get { return m_TaxId; }
            set { m_TaxId = value; }
        }

        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }
        private Int32 m_TaxDtlId;

        public Int32 TaxDtlId
        {
            get { return m_TaxDtlId; }
            set { m_TaxDtlId = value; }
        }
        private Int32 m_TaxTypeId;

        public Int32 TaxTypeId
        {
            get { return m_TaxTypeId; }
            set { m_TaxTypeId = value; }
        }
        private long m_TaxFormatId;

        public long TaxFormatId
        {
            get { return m_TaxFormatId; }
            set { m_TaxFormatId = value; }
        }

        private DateTime m_ApplicableDate;

        public DateTime ApplicableDate
        {
            get { return m_ApplicableDate; }
            set { m_ApplicableDate = value; }
        }

        private string m_TaxName;

        public string TaxName
        {
            get { return m_TaxName; }
            set { m_TaxName = value; }
        }
        private decimal m_Percentage;

        public decimal Percentage
        {
            get { return m_Percentage; }
            set { m_Percentage = value; }
        }

        private long m_ChargeId;

        public long ChargeId
        {
            get { return m_ChargeId; }
            set { m_ChargeId = value; }
        }
        private decimal m_TaxAmount;

        public decimal TaxAmount
        {
            get { return m_TaxAmount; }
            set { m_TaxAmount = value; }
        }
        private Int32 m_Type;

        public Int32 Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        

        
        private bool m_DateFlag;
        public bool DateFlag
        {
            get { return m_DateFlag; }
            set { m_DateFlag = value; }
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

        #endregion

        # region Stored Procedure
        public static string SP_TaxTemplate = "SP_TaxTemplate";
        #endregion
        public TaxTemplate()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
