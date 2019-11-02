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

    public class ProspectCustomer
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _EmpID = "@EmpID";
        public static string _EnquiryId = "@EnquiryId";
        public static string _EnquiryNo= "@EnquiryNo";
        public static string _SiteId = "@SiteId";
        public static string _EnquiryDate= "@EnquiryDate";
        public static string _Building = "@Building";
        public static string _PCDetailId = "@PCDetailId";
        public static string _TimeIn= "@TimeIn";
        public static string _TimeOut= "@TimeOut";
        public static string _CustId = "@CustId";
        public static string _Flag = "@Flag";
        public const string _IsInterested = "@IsInterested";
        public static string _CustomerName= "@CustomerName";
        public static string _MobNo = "@MobNo";
        public static string _Address= "@Address";
        public static string _ResPhNo="@ResPhNo";
        public static string _Occupation="@Occupation";
        public static string _OffPhNo="@OffPhNo";
        public static string _EmailId="@EmailId";
        public static string _FaxNo="@FaxNo";
        public static string _NewsTOI="@NewsTOI";
        public static string _NewsSakal="@NewsSakal";
        public static string _NewsOther="@NewsOther";
        public static string _NewsDNA = "@NewsDNA";
        public static string _OtherDtls = "@OtherDtls";
        public static string _NewsType = "@NewsType";
        public static string _Exihibition="@Exihibition";
        public static string _Hoarding="@Hoarding";
        public static string _FriendName="@FriendName";
        public static string _BrokerId = "@BrokerId";
        public static string _ClientName="@ClientName";
        public static string _ReferrenceName="@ReferrenceName";
        public static string _PropFlat="@PropFlat";
        public static string _PropBungalow="@PropBungalow";
        public static string _PropShop="@PropShop";
        public static string _PropDuplex="@PropDuplex";
        public static string _FlatType="@FlatType";
        public static string _Location="@Location";
        public static string _Budget="@Budget";
        public static string _PossessionId="@PossessionId";
        public static string _LoanReq="@LoanReq";
        public static string _Institution="@Institution";
        public static string _PaySchedule="@PaySchedule";
        public static string _PayDownPay="@PayDownPay";
        public static string _BlockStatus = "@BlockStatus";
        public static string _BlockSpanDate = "@BlockSpanDate";
        public static string _BlockRemark = "@BlockRemark";
        public static string _FollowUpStatus = "@FollowUpStatus";
        public static string _FollowUpDate = "@FollowUpDate";
        public static string _CustomerType = "@CustomerType";
        public static string _Remark = "@Remark";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@strCond";
        public static string _BrokerCheck = "@BrokerCheck";
        #endregion

        #region Definitions

        private Boolean m_BrokerCheck;

        public Boolean BrokerCheck
        {
            get { return m_BrokerCheck; }
            set { m_BrokerCheck = value; }
        }

        private Int32 m_Flag;

        public Int32 Flag
        {
            get { return m_Flag; }
            set { m_Flag = value; }
        }
        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }
        private Int32 m_EnquiryId;

        public Int32 EnquiryId
        {
            get { return m_EnquiryId; }
            set { m_EnquiryId = value; }
        }


        private string m_EnquiryNo;

        public string EnquiryNo
        {
            get { return m_EnquiryNo; }
            set { m_EnquiryNo = value; }
        }

        private Int32 m_SiteId;

        public Int32 SiteId
        {
            get { return m_SiteId; }
            set { m_SiteId = value; }
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

       

        private DateTime m_EnquiryDate;

        public DateTime EnquiryDate
        {
            get { return m_EnquiryDate; }
            set { m_EnquiryDate = value; }
        }

        private DateTime m_TimeIn;

        public DateTime TimeIn
        {
            get { return m_TimeIn; }
            set { m_TimeIn = value; }
        }

        private DateTime m_TimeOut;

        public DateTime TimeOut
        {
            get { return m_TimeOut; }
            set { m_TimeOut = value; }
        }

        private Int32 m_CustId;

        public Int32 CustId
        {
            get { return m_CustId; }
            set { m_CustId = value; }
        }
        
        private string m_CustomerName;

        public string CustomerName
        {
            get { return m_CustomerName; }
            set { m_CustomerName = value; }
        }
        private string m_MobNo;

        public string MobNo
        {
            get { return m_MobNo; }
            set { m_MobNo = value; }
        }
        private string m_Address;

        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        private string m_ResPhNo;

        public string ResPhNo
        {
            get { return m_ResPhNo; }
            set { m_ResPhNo = value; }
        }
        private string m_Occupation;

        public string Occupation
        {
            get { return m_Occupation; }
            set { m_Occupation = value; }
        }
        private string m_OffPhNo;

        public string OffPhNo
        {
            get { return m_OffPhNo; }
            set { m_OffPhNo = value; }
        }
        private string m_EmailId;

        public string EmailId
        {
            get { return m_EmailId; }
            set { m_EmailId = value; }
        }
        private string m_FaxNo;

        public string FaxNo
        {
            get { return m_FaxNo; }
            set { m_FaxNo = value; }
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

        private bool m_NewsDNA;

        public bool NewsDNA
        {
            get { return m_NewsDNA; }
            set { m_NewsDNA = value; }
        }

        private bool m_NewsOther;

        public bool NewsOther
        {
            get { return m_NewsOther; }
            set { m_NewsOther = value; }
        }
        private string m_OtherDtls;

        public string OtherDtls
        {
            get { return m_OtherDtls; }
            set { m_OtherDtls = value; }
        }

        private Int32 m_NewsType;

        public Int32 NewsType
        {
            get { return m_NewsType; }
            set { m_NewsType = value; }
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
        //private string m_BrokerName;

        //public string BrokerName
        //{
        //    get { return m_BrokerName; }
        //    set { m_BrokerName = value; }
        //}

        private Int32 m_BrokerId;

        public Int32 BrokerId
        {
            get { return m_BrokerId; }
            set { m_BrokerId = value; }
        }
        private string m_ClientName;

        public string ClientName
        {
            get { return m_ClientName; }
            set { m_ClientName = value; }
        }
        private string m_ReferrenceName;

        public string ReferrenceName
        {
            get { return m_ReferrenceName; }
            set { m_ReferrenceName = value; }
        }
        private bool m_PropFlat;

        public bool PropFlat
        {
            get { return m_PropFlat; }
            set { m_PropFlat = value; }
        }
        private bool m_PropBungalow;

        public bool PropBungalow
        {
            get { return m_PropBungalow; }
            set { m_PropBungalow = value; }
        }
        private bool m_PropShop;

        public bool PropShop
        {
            get { return m_PropShop; }
            set { m_PropShop = value; }
        }
        private bool m_PropDuplex;

        public bool PropDuplex
        {
            get { return m_PropDuplex; }
            set { m_PropDuplex = value; }
        }
        private Int32 m_FlatType;

        public Int32 FlatType
        {
            get { return m_FlatType; }
            set { m_FlatType = value; }
        }
        private string m_Location;

        public string Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        private string m_Budget;

        public string Budget
        {
            get { return m_Budget; }
            set { m_Budget = value; }
        }

      
        private Int32 m_PossessionId;

        public Int32 PossessionId
        {
            get { return m_PossessionId; }
            set { m_PossessionId = value; }
        }
        private bool m_LoanReq;

        public bool LoanReq
        {
            get { return m_LoanReq; }
            set { m_LoanReq = value; }
        }
        private string m_Institution;

        public string Institution
        {
            get { return m_Institution; }
            set { m_Institution = value; }
        }
        private bool m_PaySchedule;

        public bool PaySchedule
        {
            get { return m_PaySchedule; }
            set { m_PaySchedule = value; }
        }
        private bool m_PayDownPay;

        public bool PayDownPay
        {
            get { return m_PayDownPay; }
            set { m_PayDownPay = value; }
        }
        private Int32 m_BlockStatus;

        public Int32 BlockStatus
        {
            get { return m_BlockStatus; }
            set { m_BlockStatus = value; }
        }
        private DateTime m_BlockSpanDate;

        public DateTime BlockSpanDate
        {
            get { return m_BlockSpanDate; }
            set { m_BlockSpanDate = value; }
        }
        private string m_BlockRemark;

        public string BlockRemark
        {
            get { return m_BlockRemark; }
            set { m_BlockRemark = value; }
        }
        private Int32 m_FollowUpStatus;

        public Int32 FollowUpStatus
        {
            get { return m_FollowUpStatus; }
            set { m_FollowUpStatus = value; }
        }
        private DateTime m_FollowUpDate;

        public DateTime FollowUpDate
        {
            get { return m_FollowUpDate; }
            set { m_FollowUpDate = value; }
        }
        private string m_Remark;

        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }
        private bool m_IsInterested;

        public bool IsInterested
        {
            get { return m_IsInterested; }
            set { m_IsInterested = value; }
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

        private Int32 m_CustomerType;

        public Int32 CustomerType
        {
            get { return m_CustomerType; }
            set { m_CustomerType = value; }
        }
        #endregion

        # region Stored Procedure
        public static string SP_EnquiryMaster = "SP_EnquiryMaster";
        public static string SP_Print = "SP_Print";
        public static string SP_EnquiryMaster_Part1 = "SP_EnquiryMaster_Part1";
        public static string SP_EnquiryMaster_Part2 = "SP_EnquiryMaster_Part2";
        #endregion
       

        public ProspectCustomer()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
