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
/// Summary description for DMDemandMaster
/// </summary>
namespace Build.EntityClass
{
    public class DemandMaster
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _DemandID = "@DemandID";
        public static string _DemandSCTId = "@DemandSCTId";
        public static string _DemandDtlId = "@DemandDtlId";
        public static string _DemandDate = "@DemandDate";
        public static string _Stage = "@Stage";
        public static string _StageId = "@StageId";
        public static string _chargeId = "@chargeId";
        public static string _TaxId = "@TaxId"; 
        public static string _PSId = "@PSId";
        public static string _ProjectID = "@ProjectID";
        public static string _TowerName = "@TowerName";
        public static string _CustomerID= "@CustomerID";
        public static string _StageDues = "@StageDues";
        public static string _AmtRecd = "@AmtRecd";
        public static string _Balance = "@Balance";
        public static string _SeviceTax = "@SeviceTax";
        public static string _VatAmount = "@VatAmount";
        public static string _StageDuePercent = "@StageDuePercent";
        public static string _Type = "@Type";
        public static string _DemandStageId = "@DemandStageId";
        public static string _IsChecked = "@IsChecked";
        public static string _Stages = "@Stages";
        public static string _Percentage = "@Percentage";
        public static string _StageName = "@StageName";
        public static string _StageNameNew = "@StageNameNew";
 
        public static string _UpdateDate = "@UpdateDate";
        public static string _DueDate = "@DueDate";
        
        public static string _PaymentType = "@PaymentType";
        public static string _ArchLetter = "@ArchLetter";
        public static string _StagePer = "@StagePer";
       
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _StrCondition = "@StrCond";
        public static string _PSDtlId = "@PSDtlId";
        public static string _BookingId = "@BookingId";
        public static string _CustPaymentScheduleId = "@CustPaymentScheduleId";
        public static string _PaymentScheduleId = "@PaySchId";
        public static string _PaymentDtlsId = "@PaymentDtlsId";
        public static string _FlagForm = "@FlagForm";
        public static string _InterestAmt = "@InterestAmt";
        public static string _TaxTypeid = "@TaxTypeId";
        public static string _PCId = "@PCId";
       
        #endregion

        #region [Defination]

        public long chargeId { get; set; }
        public long TaxId { get; set; }
        public long PaymentSchId { get; set; }
        public long StageId { get; set; }
        public long DemandSCTId { get; set; }
        public bool FlagForm { get; set; }
        public decimal InterestAmt { get; set; }
        public long TaxTypeId { get; set; }
        public long PCId { get; set; }

        private Int32 m_PaymentDtlsId;
        public Int32 PaymentDtlsId
        {
            get { return m_PaymentDtlsId; }
            set { m_PaymentDtlsId = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_DemandID;
        public Int32 DemandID
        {
          get { return m_DemandID; }
          set { m_DemandID = value; }
        }
        
        private DateTime m_DemandDate;
        public DateTime DemandDate
        {
            get { return m_DemandDate; }
            set { m_DemandDate = value; }
        }

        private string m_Stage;

        public string Stage
        {
            get { return m_Stage; }
            set { m_Stage = value; }
        }

        private Int32 m_PSId;

        public Int32 PSId
        {
            get { return m_PSId; }
            set { m_PSId = value; }
        }
        private Int32 m_ProjectID;

        public Int32 ProjectID
        {
            get { return m_ProjectID; }
            set { m_ProjectID = value; }
        }
        private String m_TowerName;

        public String TowerName
        {
            get { return m_TowerName; }
            set { m_TowerName = value; }
        }

        private Int32 m_PSDtlId;

        public Int32 PSDtlId
        {
            get { return m_PSDtlId; }
            set { m_PSDtlId = value; }
        }
        
        private Int32 m_CustomerID;

        public Int32 CustomerID
        {
            get { return m_CustomerID; }
            set { m_CustomerID = value; }
        }
        private Decimal m_StageDues;

        public Decimal StageDues
        {
            get { return m_StageDues; }
            set { m_StageDues = value; }
        }
        private Decimal m_AmtRecd;

        public Decimal AmtRecd
        {
            get { return m_AmtRecd; }
            set { m_AmtRecd = value; }
        }
        private Decimal m_Balance;

        public Decimal Balance
        {
            get { return m_Balance; }
            set { m_Balance = value; }
        }
        private Decimal m_SeviceTax;

        public Decimal SeviceTax
        {
            get { return m_SeviceTax; }
            set { m_SeviceTax = value; }
        }
        private Decimal m_VatAmount;

        public Decimal VatAmount
        {
            get { return m_VatAmount; }
            set { m_VatAmount = value; }
        }


        private Decimal m_StageDuePercent;
        public Decimal StageDuePercent
        {
            get { return m_StageDuePercent; }
            set { m_StageDuePercent = value; }
        }


        private Int32 m_Type;
        public Int32 Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        private Int32 m_DemandStageId;
        public Int32 DemandStageId
        {
            get { return m_DemandStageId; }
            set { m_DemandStageId = value; }
        }

        private bool m_IsChecked;
        public bool IsChecked
        {
            get { return m_IsChecked; }
            set { m_IsChecked = value; }
        }

        private string m_Stages;
        public string Stages
        {
            get { return m_Stages; }
            set { m_Stages = value; }
        }

        private decimal m_Percentage;
        public decimal Percentage
        {
            get { return m_Percentage; }
            set { m_Percentage = value; }
        }

        private String m_StageName;
        public String StageName
        {
            get { return m_StageName; }
            set { m_StageName = value; }
        }

        private String m_StageNameNew;
        public String StageNameNew
        {
            get { return m_StageNameNew; }
            set { m_StageNameNew = value; }
        }
        

        private DateTime m_UpdateDate;
        public DateTime UpdateDate
        {
            get { return m_UpdateDate; }
            set { m_UpdateDate = value; }
        }

        private DateTime m_DueDate;
        public DateTime DueDate
        {
            get { return m_DueDate; }
            set { m_DueDate = value; }
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
        private String m_StrCond;
        public String StrCond
        {
            get { return m_StrCond; }
            set { m_StrCond = value; }
        }

        private Int32 m_PaymentType;
        public Int32 PaymentType
        {
            get { return m_PaymentType; }
            set { m_PaymentType = value; }
        }

        private String m_ArchLetter;
        public String ArchLetter
        {
            get { return m_ArchLetter; }
            set { m_ArchLetter = value; }
        }
        private Decimal m_StagePer;
        public Decimal StagePer
        {
            get { return m_StagePer; }
            set { m_StagePer = value; }
        }
        private Int32 m_DemandDtlId;
        public Int32 DemandDtlId
        {
            get { return m_DemandDtlId; }
            set { m_DemandDtlId = value; }
        }
        private Int32 m_BookingId;

        public Int32 BookingId
        {
            get { return m_BookingId; }
            set { m_BookingId = value; }
        }
        private Int32 m_CustPaymentScheduleId;

        public Int32 CustPaymentScheduleId
        {
            get { return m_CustPaymentScheduleId; }
            set { m_CustPaymentScheduleId = value; }
        }

        #endregion

        #region [Stored Proc]
         public static string SP_DemandMaster = "SP_DemandMaster_I";
         public static string SP_DemandMaster1 = "SP_DemandMaster_II";
         public static string SP_DemandMaster3 = "SP_DemandMaster_III";
         public static string SP_Print = "SP_Print";
         public static string SP_EmailDemandLetter = "SP_EmailDemandLetter";
         public static string SP_PrintDemandLetter = "SP_PrintDemandLetter";
         public static string SP_NewDemandLetter = "SP_NewDemandLetter";
        
        #endregion
        public DemandMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}