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
/// Summary description for CustomerMaster
/// </summary>
namespace Build.EntityClass
{
    public class CustomerMaster
    {
        # region Column Constant
        public const string _RepCondition = "@RepCondition";
        public const string _Action = "@Action";
        public const string _CustId = "@CustId";
        public const string _Name = "@Name";
        public const string _Address = "@Address";
        public const string _Tel1 = "@Tel1";
        public const string _Tel2 = "@Tel2";
        public const string _Mobile = "@Mobile";
        public const string _Fax = "@Fax";
        public const string _Email = "@Email";
        public const string _PANCardNo = "@PANCardNo";
        public const string _City = "@City";
        public const string _State = "@State";
        public const string _Pin = "@Pin";
        public const string _ContactPerson = "@ContactPerson";
        public const string _Grade = "@Grade";
        public const string _CreditDays = "@CreditDays";
        public const string _VatTinNo = "@VatTinNo";
        public const string _EccNo = "@EccNo";
        public const string _LstNo = "@LstNo";
        public const string _BstNo = "@BstNo";
        public const string _CstNo = "@CstNo";
        public const string _OutStandingLimit = "@OutStandingLimit";
        public const string _WeeklyOff = "@WeeklyOff";
        public const string _ApprovedDate = "@ApprovedDate";
        public const string _Notes = "@Notes";
        public const string _IsProspect = "@IsProspect";
        public const string _Honorific = "@Honorific";
        public const string _Occupation = "@Occupation";
        public const string _PermanantAddress = "@PermanantAddress";
        public const string _DOB = "@DOB";
        public const string _DOSpouse = "@DOSpouse";
        public const string _ResidentialStatus = "@ResidentialStatus";
        public const string _Category = "@Category";
        public const string _PanCardPath = "@PanCardPath";
        public const string _LoginID = "@LoginID";
        public const string _LoginDate = "@LoginDate";

        public const string _CorrespondanceName = "@CorrespondanceName";
        public const string _CorrespondanceContact = "@CorrespondanceContact";
        public const string _CorrespondanceEmail = "@CorrespondanceEmail";
        # endregion
        #region Store Procedure

        public const string PRO_CUSTOMERMASTER = "PRO_CustomerMaster";
        public const string PRO_MIS_BINDCOMBO = "PRO_MIS_BINDCOMBO";
        public const string PRO_MIS_CustomerList = "PRO_MIS_CustomerList";
        #endregion

        #region Property Defination
        private string m_PanCardPath;

        public string PanCardPath
        {
            get { return m_PanCardPath; }
            set { m_PanCardPath = value; }
        }


        private Int32 m_Action;

        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_Category;

        public Int32 Category
        {
            get { return m_Category; }
            set { m_Category = value; }
        }


        private Int32 m_ResidentialStatus;

        public Int32 ResidentialStatus
        {
            get { return m_ResidentialStatus; }
            set { m_ResidentialStatus = value; }
        }

        
        private Int32 m_CustId;

        public Int32 CustId
        {
            get { return m_CustId; }
            set { m_CustId = value; }
        }

        private String m_Name;

        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private String m_Occupation;

        public String Occupation
        {
            get { return m_Occupation; }
            set { m_Occupation = value; }
        }
        private String m_CorrespondanceName;
        public String CorrespondanceName
        {
            get { return m_CorrespondanceName; }
            set { m_CorrespondanceName = value; }
        }
        private String m_CorrespondanceEmail;
        public String CorrespondanceEmail
        {
            get { return m_CorrespondanceEmail; }
            set { m_CorrespondanceEmail = value; }
        }
        private String m_CorrespondanceContact;
        public String CorrespondanceContact
        {
            get { return m_CorrespondanceContact; }
            set { m_CorrespondanceContact = value; }
        }
        private String m_PermanantAddress;

        public String PermanantAddress
        {
            get { return m_PermanantAddress; }
            set { m_PermanantAddress = value; }
        }

        private DateTime m_DOB;

        public DateTime DOB
        {
            get { return m_DOB; }
            set { m_DOB = value; }
        }
        private DateTime m_DOSpouse;

        public DateTime DOSpouse
        {
            get { return m_DOSpouse; }
            set { m_DOSpouse = value; }
        }


        private String m_Address;
        public String Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }

        private String m_Tel1;
        public String Tel1
        {
            get { return m_Tel1; }
            set { m_Tel1 = value; }
        }

        private String m_Tel2;
        public String Tel2
        {
            get { return m_Tel2; }
            set { m_Tel2 = value; }
        }

        private String m_Mobile;

        public String Mobile
        {
            get { return m_Mobile; }
            set { m_Mobile = value; }
        }

        private String m_Fax;

        public String Fax
        {
            get { return m_Fax; }
            set { m_Fax = value; }
        }

        private String m_Email;

        public String Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        private String m_PANCardNo;

        public String PANCardNo
        {
            get { return m_PANCardNo; }
            set { m_PANCardNo = value; }
        }
        private String m_City;

        public String City
        {
            get { return m_City; }
            set { m_City = value; }
        }

        private String m_State;

        public String State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        private String m_Pin;

        public String Pin
        {
            get { return m_Pin; }
            set { m_Pin = value; }
        }

        private String m_ContactPerson;

        public String ContactPerson
        {
            get { return m_ContactPerson; }
            set { m_ContactPerson = value; }
        }

        private String m_Grade;

        public String Grade
        {
            get { return m_Grade; }
            set { m_Grade = value; }
        }

        private String m_CreditDays;

        public String CreditDays
        {
            get { return m_CreditDays; }
            set { m_CreditDays = value; }
        }

        private string m_VatTinNo;

        public string VatTinNo
        {
            get { return m_VatTinNo; }
            set { m_VatTinNo = value; }
        }
        private String m_EccNo;

        public String EccNo
        {
            get { return m_EccNo; }
            set { m_EccNo = value; }
        }

        private String m_LstNo;

        public String LstNo
        {
            get { return m_LstNo; }
            set { m_LstNo = value; }
        }

        private String m_BstNo;

        public String BstNo
        {
            get { return m_BstNo; }
            set { m_BstNo = value; }
        }

        private String m_CstNo;

        public String CstNo
        {
            get { return m_CstNo; }
            set { m_CstNo = value; }
        }

        private String m_OutStandinLimit;

        public String OutStandinLimit
        {
            get { return m_OutStandinLimit; }
            set { m_OutStandinLimit = value; }
        }

        private String m_WeeklyOff;

        public String WeeklyOff
        {
            get { return m_WeeklyOff; }
            set { m_WeeklyOff = value; }
        }

        private DateTime m_ApprovedDate;

        public DateTime ApprovedDate
        {
            get { return m_ApprovedDate; }
            set { m_ApprovedDate = value; }
        }

        private String m_Notes;

        public String Notes
        {
            get { return m_Notes; }
            set { m_Notes = value; }
        }

        private bool m_IsProspect;

        public bool IsProspect
        {
            get { return m_IsProspect; }
            set { m_IsProspect = value; }
        }

        private long m_Honorific;

        public long Honorific
        {
            get { return m_Honorific; }
            set { m_Honorific = value; }
        }
        

        private Int32 m_LoginID;

        public Int32 LoginID
        {
            get { return m_LoginID; }
            set { m_LoginID = value; }
        }

        private DateTime m_LoginDate;

        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }
        #endregion
        public CustomerMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
