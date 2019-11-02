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
    public class BookingMaster
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _BookingId = "@BookingId";
        public static string _BookingNo = "@BookingNo";

        public static string _OldPCId = "@OldPCId";       
        public static string _OldBuilding = "@OldBuilding";
        public static string _OldPCDetailId = "@OldPCDetailId";
        public static string _OldCustId = "@OldCustId";
        public static string _OldAreaInSqft = "@OldAreaInSqft";
        public static string _OldRateperSqft = "@OldRateperSqft";
        public static string _OldBrokerId = "@OldBrokerId";

        public static string _PCId = "@PCId";
        public static string _EmpID = "@EmpID";
        public static string _Building = "@Building";
        public static string _PCDetailId = "@PCDetailId";
        public static string _BookingDate = "@BookingDate";
        public static string _IsEnquired = "@IsEnquired";
        public static string _CustId = "@CustId";
        public static string _Applicant2CustId = "@Applicant2CustId";
        public static string _Applicant3CustId = "@Applicant3CustId";

        public static string _Applicant1 = "@Applicant1";
        public static string _Applicant2 = "@Applicant2";
        public static string _Applicant3 = "@Applicant3";
        public static string _Age1 = "@Age1";
        public static string _Age2 = "@Age2";
        public static string _Age3 = "@Age3";
        public static string _CorrAddress = "@CorrAddress";
        public static string _Occupation = "@Occupation";
        public static string _CompanyName = "@CompanyName";
        public static string _PerAddress = "@PerAddress";
        public static string _TelO = "@TelO";
        public static string _TelR = "@TelR";
        public static string _Mobile = "@Mobile";
        public static string _Fax = "@Fax";
        public static string _Email = "@Email";
        public static string _DOB = "@DOB";
        public static string _DOBSpouse = "@DOBSpouse";
        public static string _EarnMoney = "@EarnMoney";
        public static string _ParkingTypeId = "@ParkingTypeId";
        public static string _Parking = "@Parking";
        public static string _ParkingConfigDtlsId = "@ParkingConfigDtlsId";
        public static string _NewsTOI = "@NewsTOI";
        public static string _NewsSakal = "@NewsSakal";
        public static string _NewsOther = "@NewsOther";
        public static string _ModeOfBooking = "@ModeOfBooking";
        public static string _OtherDtls = "OtherDtls";
        public static string _BrokerId = "@BrokerId";
        public static string _BrokerAmountCalculateOn = "@BrokerAmountCalculateOn";
        public static string _BrokerAmount = "@BrokerAmount";

        public static string _ReferenceName = "@ReferenceName";
        public static string _Exihibition = "@Exihibition";
        public static string _Hoarding = "@Hoarding";
        public static string _FriendName = "@FriendName";
        
        public static string _AmountReq = "@AmountReq";
        public static string _LoanRequired = "@LoanRequired";
        public static string _Institute = "@Institute";
        public static string _AgentId = "@AgentId";
        public static string _BankEmailId = "@BankEmailId";
        public static string _BankLoanDate = "@BankLoanDate";
        public static string _ActualBankLoanDate = "@ActualBankLoanDate";
        public static string _Comments = "@Comments";

        public static string _IsTransfer = "@IsTransfer";
        public static string _TransferDate = "@TransferDate";


        public static string _CommitedDate = "@CommitedDate";
        public static string _AreaInSqft = "@AreaInSqft";
        public static string _RateperSqft = "@RateperSqft";
        public static string _DevelopmentCharges = "@DevelopmentCharges";
        public static string _TotalFlatAmount = "@TotalFlatAmount";
        public static string _Garden = "@Garden";
        public static string _OpenTerrace = "@OpenTerrace";
        public static string _OtherCharges = "@OtherCharges";
        public static string _GrandAmount = "@GrandAmount";
        public static string _InterestRate = "@InterestRate";
        public static string _GracePeriod = "@GracePeriod";
        public static string _ActualDateOfAgreement="@ActualDateOfAgreement";
        public static string _CancelFlag = "@CancelFlag";

        public static string _BankAccountId = "@BankAccountId";
        public static string _InterestCalculation = "@InterestCalculation";
        public static string _TDSApply="@TDSApply";
        public static string _TDSPercentage="@TDSPercentage";
        public static string _TDSAmount = "TDSAmount";
        public static string _ChequeNo = "@ChequeNo";
        public static string _BankId = "@BankId";
        public static string _Branch = "@Branch";
        public static string _ReceiptNo = "@ReceiptNo";
        public static string _ReceiptDate = "@ReceiptDate";
        public static string _PaymentSchedule = "@PaymentSchedule";           
        
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";

         public static string _Occupation2="@Occupation2";
         public static string _Schedule="@Schedule";
         public static string _ApplicantPanNo2="@ApplicantPanNo2";
         public static string _ResidentialStatus = "@ResidentialStatus";
         
         public static string _ImagePath = "@ImagePath";
         public static string _DocImagePath = "@DocImagePath";
         public static string _DocumentImgId = "@DocumentImgId";
         public static string _FlatLayoutImgId = "@FlatLayoutImgId";

        public static string _Title = "@Title";
        public static string _Description = "@Description";
        public static string _TermId = "@TermId";

        public static string _BookingChargeDtlsId = "@BookingChargeDtlsId";
        //public static string _ChargeId = "@ChargeId";
        //public static string _Amount = "@Amount";

        public static string _BookingChargeId = "@BookingChargeId";
        public static string _FormatId = "@FormatId";
        public static string _AmountType = "@AmountType";
        public static string _ChargeAmount = "@ChargeAmount";
        public static string _ChargeFormatId = "@ChargeFormatId";
        public static string _ChargeFlag = "@ChargeFlag";

        public static string _Mobile2="@Mobile2";
        public static string _EmailId2="@EmailId2";
        public static string _PreferentialAllotmentCharges="@PreferentialAllotmentCharges";
        public static string _IncidentalCharges="@IncidentalCharges";
        public static string _Remark = "@Remark";

        public static string _Occupation3 = "@Occupation3";
        public static string _Applicant2Mobile = "@Applicant2Mobile";
        public static string _Applicant3Mobile = "@Applicant3Mobile";
        public static string _EmailId3 = "@EmailId3";
        public static string _ApplicantPanNo1 = "@ApplicantPanNo1";       
        public static string _ApplicantPanNo3 = "@ApplicantPanNo3";
        public static string _Applicant2DOB = "@Applicant2DOB";
        public static string _Applicant3DOB = "@Applicant3DOB";

        public static string _PaymentScheduleId = "@PaymentScheduleId";
        public static string _StageId = "@StageId ";
        public static string _DueDateId = "@DueDateId ";
        public static string _Percentage = "@Percentage";
        public static string _BookingDueDate = "@BookingDueDate";

        public static string _PCTemplate ="@PCTemplate"; 
        public static string _CollectionFor="@CollectionFor";
        public static string _Value="@Value";
        public static string _ChargeId="@ChargeId";
        public static string _ChargeAmt="@ChargeAmt";
        public static string _Type="@Type";
        public static string _TaxId="@TaxId";
        public static string _TaxTypeId="@TaxTypeId";
        public static string _TaxFormatId="@TaxFormatId";
        public static string _Amount="@Amount";
        public static string _IncludeIn = "@IncludeIn";
        public static string _TaxValue = "@TaxValue";
        public static string _TaxDtlId = "@TaxDtlId";
        public static string _Booking_TaxDtlsId = "@Booking_TaxDtlsId";
        public static string _ParkingSubTypeId = "@ParkingSubTypeId";

        public static string _RegistrationNo = "@RegistrationNo";
        public static string _RegistrationDate = "@RegistrationDate";
        public static string _RegistrationLocation = "@RegistrationLocation";
        public static string _RegistrationRemark = "@RegistrationRemark";
        public static string _RegImagePath = "@RegImagePath";
        public static string _SanctionLetterPath = "@SanctionLetterPath";

        public static string _BookingTaxDueDate = "@BookingTaxDueDate";

        public static string _ParkingGroupId = "@ParkingGroupId";
        public static string _Lock = "@Lock";

        public static string _BookingChargesDueDate = "@BookingChargesDueDate";

      
        #endregion

        #region[Defination]
        public long Applicant2CustId { get; set; }
        public long Applicant3CustId { get; set; }

        private DateTime m_BookingChargesDueDate;
        public DateTime BookingChargesDueDate
        {
            get { return m_BookingChargesDueDate; }
            set { m_BookingChargesDueDate = value; }
        }

        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private DateTime m_BookingDueDate;
        public DateTime BookingDueDate
        {
            get { return m_BookingDueDate; }
            set { m_BookingDueDate = value; }
        }

        private Int32 m_Booking_TaxDtlsId;

        public Int32 Booking_TaxDtlsId
        {
            get { return m_Booking_TaxDtlsId; }
            set { m_Booking_TaxDtlsId = value; }
        }

        private Int32 m_BookingId;
        public Int32 BookingId
        {
            get { return m_BookingId; }
            set { m_BookingId = value; }
        }

        private string m_BookingNo;
        public string BookingNo
        {
            get { return m_BookingNo; }
            set { m_BookingNo = value; }
        }


        private DateTime m_BookingDate;
        public DateTime BookingDate
        {
            get { return m_BookingDate; }
            set { m_BookingDate = value; }
        }
        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }

        private Int32 m_PCId;
        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }
        
        private string m_Building;
        public string Building
        {
            get { return m_Building; }
            set { m_Building = value; }
        }

        private Int32 m_PCDetailId;
        public Int32 PCDetailId
        {
            get { return m_PCDetailId; }
            set { m_PCDetailId = value; }
        }

        private bool m_IsEnquired;
        public bool IsEnquired
        {
            get { return m_IsEnquired; }
            set { m_IsEnquired = value; }
        }



        private Int32 m_CustId;
        public Int32 CustId
        {
            get { return m_CustId; }
            set { m_CustId = value; }
        }

        private string m_Applicant1;
        public string Applicant1
        {
            get { return m_Applicant1; }
            set { m_Applicant1 = value; }
        }

        private string m_Applicant2;
        public string Applicant2
        {
            get { return m_Applicant2; }
            set { m_Applicant2 = value; }
        }

        private string m_Applicant3;
        public string Applicant3
        {
            get { return m_Applicant3; }
            set { m_Applicant3 = value; }
        }

        private Int32 m_Age1;
        public Int32 Age1
        {
            get { return m_Age1; }
            set { m_Age1 = value; }
        }

        private Int32 m_Age2;
        public Int32 Age2
        {
            get { return m_Age2; }
            set { m_Age2 = value; }
        }

        private Int32 m_Age3;
        public Int32 Age3
        {
            get { return m_Age3; }
            set { m_Age3 = value; }
        }

        private string m_CorrAddress;
        public string CorrAddress
        {
            get { return m_CorrAddress; }
            set { m_CorrAddress = value; }
        }

        private string m_Occupation;
        public string Occupation
        {
            get { return m_Occupation; }
            set { m_Occupation = value; }
        }

        private string m_CompanyName;
        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }

        private string m_PerAddress;
        public string PerAddress
        {
            get { return m_PerAddress; }
            set { m_PerAddress = value; }
        }

        private string m_TelO;
        public string TelO
        {
            get { return m_TelO; }
            set { m_TelO = value; }
        }

        private string m_TelR;
        public string TelR
        {
            get { return m_TelR; }
            set { m_TelR = value; }
        }

        private string m_Mobile;

        public string Mobile
        {
            get { return m_Mobile; }
            set { m_Mobile = value; }
        }

        private string m_Fax;
        public string Fax
        {
            get { return m_Fax; }
            set { m_Fax = value; }
        }

        private string m_Email;
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        private DateTime m_DOB;
        public DateTime DOB
        {
            get { return m_DOB; }
            set { m_DOB = value; }
        }

        private DateTime m_DOBSpouse;
        public DateTime DOBSpouse
        {
            get { return m_DOBSpouse; }
            set { m_DOBSpouse = value; }
        }

        private decimal m_EarnMoney;
        public decimal EarnMoney
        {
            get { return m_EarnMoney; }
            set { m_EarnMoney = value; }
        }

        private Int32 m_Parking;
        public Int32 Parking
        {
            get { return m_Parking; }
            set { m_Parking = value; }
        }

        private Int32 m_ParkingTypeId;
        public Int32 ParkingTypeId
        {
            get { return m_ParkingTypeId; }
            set { m_ParkingTypeId = value; }
        }

        private Int32 m_ParkingSubTypeId;
        public Int32 ParkingSubTypeId
        {
            get { return m_ParkingSubTypeId; }
            set { m_ParkingSubTypeId = value; }
        }


        private Int32 m_ParkingConfigDtlsId;

        public Int32 ParkingConfigDtlsId
        {
            get { return m_ParkingConfigDtlsId; }
            set { m_ParkingConfigDtlsId = value; }
        }
       

        private bool m_NewsTOI;
        public bool NewsTOI
        {
            get { return m_NewsTOI; }
            set { m_NewsTOI = value; }
        }

        private bool m_NewsSakal;
        public bool NewsSakal
        {
            get { return m_NewsSakal; }
            set { m_NewsSakal = value; }
        }

        private bool m_NewsOther;
        public bool NewsOther
        {
            get { return m_NewsOther; }
            set { m_NewsOther = value; }
        }

        private Int32 m_ModeOfBooking;
        public Int32 ModeOfBooking
        {
            get { return m_ModeOfBooking; }
            set { m_ModeOfBooking = value; }
        }

        private string m_OtherDtls;
        public string OtherDtls
        {
            get { return m_OtherDtls; }
            set { m_OtherDtls = value; }
        }

        private Int32 m_BrokerId;
        public Int32 BrokerId
        {
            get { return m_BrokerId; }
            set { m_BrokerId = value; }
        }
        private decimal m_BrokerAmountCalculateOn;

        public decimal BrokerAmountCalculateOn
        {
            get { return m_BrokerAmountCalculateOn; }
            set { m_BrokerAmountCalculateOn = value; }
        }
        private decimal m_BrokerAmount;

        public decimal BrokerAmount
        {
            get { return m_BrokerAmount; }
            set { m_BrokerAmount = value; }
        }
        private string m_ReferenceName;
        public string ReferenceName
        {
            get { return m_ReferenceName; }
            set { m_ReferenceName = value; }
        }

        private string m_Exihibition;
        public string Exihibition
        {
            get { return m_Exihibition; }
            set { m_Exihibition = value; }
        }

        private string m_Hoarding;
        public string Hoarding
        {
            get { return m_Hoarding; }
            set { m_Hoarding = value; }
        }

        private string m_FriendName;
        public string FriendName
        {
            get { return m_FriendName; }
            set { m_FriendName = value; }
        }

        private decimal m_AmountReq;
        public decimal AmountReq
        {
            get { return m_AmountReq; }
            set { m_AmountReq = value; }
        }

        private Int32 m_LoanRequired;
        public Int32 LoanRequired
        {
            get { return m_LoanRequired; }
            set { m_LoanRequired = value; }
        }

        private Int32 m_Institute;
        public Int32 Institute
        {
            get { return m_Institute; }
            set { m_Institute = value; }
        }

        private Int32 m_AgentId;

        public Int32 AgentId
        {
            get { return m_AgentId; }
            set { m_AgentId = value; }
        }
       


        private string m_BankEmailId;

        public string BankEmailId
        {
            get { return m_BankEmailId; }
            set { m_BankEmailId = value; }
        }

        private DateTime m_BankLoanDate;

        public DateTime BankLoanDate
        {
            get { return m_BankLoanDate; }
            set { m_BankLoanDate = value; }
        }
        private DateTime m_ActualBankLoanDate;

        public DateTime ActualBankLoanDate
        {
            get { return m_ActualBankLoanDate; }
            set { m_ActualBankLoanDate = value; }
        }
        private string m_Comments;

        public string Comments
        {
            get { return m_Comments; }
            set { m_Comments = value; }
        }

        private DateTime m_CommitedDate;
        public DateTime CommitedDate
        {
            get { return m_CommitedDate; }
            set { m_CommitedDate = value; }
        }

        private decimal m_AreaInSqft;
        public decimal AreaInSqft
        {
            get { return m_AreaInSqft; }
            set { m_AreaInSqft = value; }
        }

        private decimal m_RateperSqft;
        public decimal RateperSqft
        {
            get { return m_RateperSqft; }
            set { m_RateperSqft = value; }
        }

        private decimal DevelopmentCharges;
        public decimal DevelopmentCharges1
        {
            get { return DevelopmentCharges; }
            set { DevelopmentCharges = value; }
        }
        private decimal m_OpenTerrace;

        public decimal OpenTerrace
        {
            get { return m_OpenTerrace; }
            set { m_OpenTerrace = value; }
        }
        private decimal m_Garden;

        public decimal Garden
        {
            get { return m_Garden; }
            set { m_Garden = value; }
        }
        private decimal m_TotalFlatAmount;
        public decimal TotalFlatAmount
        {
            get { return m_TotalFlatAmount; }
            set { m_TotalFlatAmount = value; }
        }
        private decimal m_OtherCharges;

        public decimal OtherCharges
        {
            get { return m_OtherCharges; }
            set { m_OtherCharges = value; }
        }

        private decimal m_GrandAmount;
        public decimal GrandAmount
        {
            get { return m_GrandAmount; }
            set { m_GrandAmount = value; }
        }

        private DateTime m_ActualDateOfAgreement;

        public DateTime ActualDateOfAgreement
        {
            get { return m_ActualDateOfAgreement; }
            set { m_ActualDateOfAgreement = value; }
        }

        private bool m_CancelFlag;
        public bool CancelFlag
        {
            get { return m_CancelFlag; }
            set { m_CancelFlag = value; }
        }

        private decimal m_InterestRate;
        public decimal InterestRate
        {
            get { return m_InterestRate; }
            set { m_InterestRate = value; }
        }

        private decimal m_GracePeriod;
        public decimal GracePeriod
        {
            get { return m_GracePeriod; }
            set { m_GracePeriod = value; }
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

        private Int32 m_OldBookingId;

        public Int32 OldBookingId
        {
            get { return m_OldBookingId; }
            set { m_OldBookingId = value; }
        }

        private bool m_IsTransfer;

        public bool IsTransfer
        {
            get { return m_IsTransfer; }
            set { m_IsTransfer = value; }
        }
        private DateTime m_TransferDate;

        public DateTime TransferDate
        {
            get { return m_TransferDate; }
            set { m_TransferDate = value; }
        }

        private string m_StrCondition;
        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }
     
        private Int32 m_BankAccountId;
        public Int32 BankAccountId
        {
            get { return m_BankAccountId; }
            set { m_BankAccountId = value; }
        }
        private Int32 m_ResidentialStatus;

        public Int32 ResidentialStatus
        {
            get { return m_ResidentialStatus; }
            set { m_ResidentialStatus = value; }
        }
        private string m_Occupation2;

        public string Occupation2
        {
            get { return m_Occupation2; }
            set { m_Occupation2 = value; }
        }
        private Int32 m_Schedule;

        public Int32 Schedule
        {
            get { return m_Schedule; }
            set { m_Schedule = value; }
        }

        //public string Schedule
        //{
        //    get { return m_Schedule; }
        //    set { m_Schedule = value; }
        //}
        private string m_ApplicantPanNo2;

        public string ApplicantPanNo2
        {
            get { return m_ApplicantPanNo2; }
            set { m_ApplicantPanNo2 = value; }
        }

        private string m_ImagePath;

        public string ImagePath
        {
            get { return m_ImagePath; }
            set { m_ImagePath = value; }
        }

        private string m_DocImagePath;

        public string DocImagePath
        {
            get { return m_DocImagePath; }
            set { m_DocImagePath = value; }
        }

        private int DocumentImgId;

        public int DocumentImgId1
        {
            get { return DocumentImgId; }
            set { DocumentImgId = value; }
        }

        private int FlatLayoutImgId;

        public int FlatLayoutImgId1
        {
            get { return FlatLayoutImgId; }
            set { FlatLayoutImgId = value; }
        }

        private string m_Title;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private string m_Description;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        private int m_TermId;

        public int TermId
        {
            get { return m_TermId; }
            set { m_TermId = value; }
        }

        //private Int32 m_ChargeId;

        //public Int32 ChargeId
        //{
        //    get { return m_ChargeId; }
        //    set { m_ChargeId = value; }
        //}
        //private decimal m_Amount;

        //public decimal Amount
        //{
        //    get { return m_Amount; }
        //    set { m_Amount = value; }
        //}

        private Int32 m_FormatId;

        public Int32 FormatId
        {
            get { return m_FormatId; }
            set { m_FormatId = value; }
        }
        private decimal m_AmountType;

        public decimal AmountType
        {
            get { return m_AmountType; }
            set { m_AmountType = value; }
        }
        private decimal m_ChargeAmount;

        public decimal ChargeAmount
        {
            get { return m_ChargeAmount; }
            set { m_ChargeAmount = value; }
        }

        private Int32 m_ChargeFormatId;

        public Int32 ChargeFormatId
        {
            get { return m_ChargeFormatId; }
            set { m_ChargeFormatId = value; }
        }
        private string m_ChargeFlag;

        public string ChargeFlag
        {
            get { return m_ChargeFlag; }
            set { m_ChargeFlag = value; }
        }

        private Int32 m_InterestCalculation;

        public Int32 InterestCalculation
        {
            get { return m_InterestCalculation; }
            set { m_InterestCalculation = value; }
        }

        private Int32 m_TDSApply;

        public Int32 TDSApply
        {
            get { return m_TDSApply; }
            set { m_TDSApply = value; }
        }
        private decimal m_TDSPercentage;

        public decimal TDSPercentage
        {
            get { return m_TDSPercentage; }
            set { m_TDSPercentage = value; }
        }
        private decimal m_TDSAmount;

        public decimal TDSAmount
        {
            get { return m_TDSAmount; }
            set { m_TDSAmount = value; }
        }

        private string m_Mobile2;

        public string Mobile2
        {
            get { return m_Mobile2; }
            set { m_Mobile2 = value; }
        }
        private string m_EmailId2;

        public string EmailId2
        {
            get { return m_EmailId2; }
            set { m_EmailId2 = value; }
        }
        private decimal m_PreferentialAllotmentCharges;

        public decimal PreferentialAllotmentCharges
        {
            get { return m_PreferentialAllotmentCharges; }
            set { m_PreferentialAllotmentCharges = value; }
        }
        private decimal m_IncidentalCharges;

        public decimal IncidentalCharges
        {
            get { return m_IncidentalCharges; }
            set { m_IncidentalCharges = value; }
        }
        private string m_Remark;

        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }

        private string m_Occupation3;

        public string Occupation3
        {
            get { return m_Occupation3; }
            set { m_Occupation3 = value; }
        }

        private string m_Applicant2Mobile;

        public string Applicant2Mobile
        {
            get { return m_Applicant2Mobile; }
            set { m_Applicant2Mobile = value; }
        }

        private string m_Applicant3Mobile;

        public string Applicant3Mobile
        {
            get { return m_Applicant3Mobile; }
            set { m_Applicant3Mobile = value; }
        }

        private string m_EmailId3;

        public string EmailId3
        {
            get { return m_EmailId3; }
            set { m_EmailId3 = value; }
        }

        private string m_ApplicantPanNo1;

        public string ApplicantPanNo1
        {
            get { return m_ApplicantPanNo1; }
            set { m_ApplicantPanNo1 = value; }
        }

        private string m_ApplicantPanNo3;

        public string ApplicantPanNo3
        {
            get { return m_ApplicantPanNo3; }
            set { m_ApplicantPanNo3 = value; }
        }

        private DateTime m_Applicant2DOB;

        public DateTime Applicant2DOB
        {
            get { return m_Applicant2DOB; }
            set { m_Applicant2DOB = value; }
        }

        private DateTime m_Applicant3DOB;

        public DateTime Applicant3DOB
        {
            get { return m_Applicant3DOB; }
            set { m_Applicant3DOB = value; }
        }


        private Int32 m_PaymentScheduleId;

        public Int32 PaymentScheduleId
        {
            get { return m_PaymentScheduleId; }
            set { m_PaymentScheduleId = value; }
        }
        private Int32 m_StageId;

        public Int32 StageId
        {
            get { return m_StageId; }
            set { m_StageId = value; }
        }

        private Int32 m_DueDateId;
        public Int32 DueDateId
        {
            get { return m_DueDateId; }
            set { m_DueDateId = value; }
        }

        private decimal m_Percentage;

        public decimal Percentage
        {
            get { return m_Percentage; }
            set { m_Percentage = value; }
        }

        private Int32 m_PCTemplate;

        public Int32 PCTemplate
        {
            get { return m_PCTemplate; }
            set { m_PCTemplate = value; }
        }
        private Int32 m_CollectionFor;

        public Int32 CollectionFor
        {
            get { return m_CollectionFor; }
            set { m_CollectionFor = value; }
        }
        private Decimal m_Value;

        public Decimal Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
        private Int32 m_ChargeId;

        public Int32 ChargeId
        {
            get { return m_ChargeId; }
            set { m_ChargeId = value; }
        }
        private Decimal m_ChargeAmt;

        public Decimal ChargeAmt
        {
            get { return m_ChargeAmt; }
            set { m_ChargeAmt = value; }
        }
        private Int32 m_Type;

        public Int32 Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
        private Int32 m_TaxId;

        public Int32 TaxId
        {
            get { return m_TaxId; }
            set { m_TaxId = value; }
        }
        private Int32 m_TaxTypeId;

        public Int32 TaxTypeId
        {
            get { return m_TaxTypeId; }
            set { m_TaxTypeId = value; }
        }
        private Int32 m_TaxFormatId;

        public Int32 TaxFormatId
        {
            get { return m_TaxFormatId; }
            set { m_TaxFormatId = value; }
        }
        private Decimal m_Amount;

        public Decimal Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }
        private Int32 m_IncludeIn;

        public Int32 IncludeIn
        {
            get { return m_IncludeIn; }
            set { m_IncludeIn = value; }
        }
        private Decimal m_TaxValue;

        public Decimal TaxValue
        {
            get { return m_TaxValue; }
            set { m_TaxValue = value; }
        }

        private Int32 m_TaxDtlId;

        public Int32 TaxDtlId
        {
            get { return m_TaxDtlId; }
            set { m_TaxDtlId = value; }
        }

        private string m_RegistrationNo;

        public string RegistrationNo
        {
            get { return m_RegistrationNo; }
            set { m_RegistrationNo = value; }
        }

        private DateTime m_RegistrationDate;
        public DateTime RegistrationDate
        {
            get { return m_RegistrationDate; }
            set { m_RegistrationDate = value; }
        }

        private DateTime m_BookingTaxDueDate;

        public DateTime BookingTaxDueDate
        {
            get { return m_BookingTaxDueDate; }
            set { m_BookingTaxDueDate = value; }
        }

        private string m_RegistrationRemark;

        public string RegistrationRemark
        {
            get { return m_RegistrationRemark; }
            set { m_RegistrationRemark = value; }
        }

        private string m_RegImagePath;

        public string RegImagePath
        {
            get { return m_RegImagePath; }
            set { m_RegImagePath = value; }
        }

        private string m_SanctionLetterPath;

        public string SanctionLetterPath
        {
            get { return m_SanctionLetterPath; }
            set { m_SanctionLetterPath = value; }
        }

        private string m_RegistrationLocation;

        public string RegistrationLocation
        {
            get { return m_RegistrationLocation; }
            set { m_RegistrationLocation = value; }
        }

        private Int32 m_ParkingGroupId;
        public Int32 ParkingGroupId
        {
            get { return m_ParkingGroupId; }
            set { m_ParkingGroupId = value; }
        }

        private bool m_Lock;

        public bool Lock
        {
            get { return m_Lock; }
            set { m_Lock = value; }
        }

        private Int32 m_OldPCId;
        public Int32 OldPCId
        {
            get { return m_OldPCId; }
            set { m_OldPCId = value; }
        }

        private string m_OldBuilding;
        public string OldBuilding
        {
            get { return m_OldBuilding; }
            set { m_OldBuilding = value; }
        }

        private Int32 m_OldPCDetailId;
        public Int32 OldPCDetailId
        {
            get { return m_OldPCDetailId; }
            set { m_OldPCDetailId = value; }
        }


        private Int32 m_OldCustId;
        public Int32 OldCustId
        {
            get { return m_OldCustId; }
            set { m_OldCustId = value; }
        }

        private decimal m_OldAreaInSqft;
        public decimal OldAreaInSqft
        {
            get { return m_OldAreaInSqft; }
            set { m_OldAreaInSqft = value; }
        }

        private decimal m_OldRateperSqft;
        public decimal OldRateperSqft
        {
            get { return m_OldRateperSqft; }
            set { m_OldRateperSqft = value; }
        }


        private Int32 m_OldBrokerId;
        public Int32 OldBrokerId
        {
            get { return m_OldBrokerId; }
            set { m_OldBrokerId = value; }
        }

        #endregion

        #region Not Used Entity

        private decimal m_MSEBCharges;

        public decimal MSEBCharges
        {
            get { return m_MSEBCharges; }
            set { m_MSEBCharges = value; }
        }
        private decimal m_SocietyCharges;

        public decimal SocietyCharges
        {
            get { return m_SocietyCharges; }
            set { m_SocietyCharges = value; }
        }
        private decimal m_MaintainanceCharges;

        public decimal MaintainanceCharges
        {
            get { return m_MaintainanceCharges; }
            set { m_MaintainanceCharges = value; }
        }
        private decimal m_StampDutyChages;

        public decimal StampDutyChages
        {
            get { return m_StampDutyChages; }
            set { m_StampDutyChages = value; }
        }
        private decimal m_RegistrationCharges;

        public decimal RegistrationCharges
        {
            get { return m_RegistrationCharges; }
            set { m_RegistrationCharges = value; }
        }
        private decimal m_LegalFeesCharges;

        public decimal LegalFeesCharges
        {
            get { return m_LegalFeesCharges; }
            set { m_LegalFeesCharges = value; }
        }
        private decimal m_ServiceTaxOnAVCharges;

        public decimal ServiceTaxOnAVCharges
        {
            get { return m_ServiceTaxOnAVCharges; }
            set { m_ServiceTaxOnAVCharges = value; }
        }
        private decimal m_VatCharges;

        public decimal VatCharges
        {
            get { return m_VatCharges; }
            set { m_VatCharges = value; }
        }
     
        private string m_PaymentSchedule;
        public string PaymentSchedule
        {
            get { return m_PaymentSchedule; }
            set { m_PaymentSchedule = value; }
        }

        private bool m_BookingModeBroker;
        public bool BookingModeBroker
        {
            get { return m_BookingModeBroker; }
            set { m_BookingModeBroker = value; }
        }

        private bool m_BookingModeReference;
        public bool BookingModeReference
        {
            get { return m_BookingModeReference; }
            set { m_BookingModeReference = value; }
        }

        private bool m_BookingModeWalking;
        public bool BookingModeWalking
        {
            get { return m_BookingModeWalking; }
            set { m_BookingModeWalking = value; }
        }

        private string m_BrokerRefName;
        public string BrokerRefName
        {
            get { return m_BrokerRefName; }
            set { m_BrokerRefName = value; }
        }

       

        private string m_ClientName;
        public string ClientName
        {
            get { return m_ClientName; }
            set { m_ClientName = value; }
        }
        #endregion

        #region[procedure]
        public static string SP_BookingFormMaster_Part1 = "SP_BookingFormMaster_Part1";
        public static string SP_BookingFormMaster_Part2 = "SP_BookingFormMaster_Part2";
        public static string SP_BookingFormMaster_Part3 = "SP_BookingFormMaster_Part3";
        public static string SP_InventoryOfUnits = "SP_InventoryOfUnits";
        public static string SP_Print = "SP_Print";
        #endregion

        public BookingMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}