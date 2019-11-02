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
    public class PropertyPartyMaster
    {


        #region Column Constant
        public static string _Action = "@Action";
        public static string _PartyName = "@PartyName";
        public static string _PartyId = "@PartyId";              	
        public static string _PartyAddress = "@PartyAddress";
        public static string _PTelNo = "@PTelNo";
        public static string _PmobileNo = "@PmobileNo";
        public static string _PEmailId = "@PEmailId";
        public static string _PWebsite = "@PWebsite";
        public static string _ContPerName = "@ContPerName";
        public static string _ContPerAddress  = "@ContPerAddress";
        public static string _CTelNo= "@CTelNo";
        public static string _CMobileNo = "@CMobileNo";
        public static string _CEmailId= "@CEmailId";
        public static string _CAdharCardNo= "@CAdharCardNo";
        public static string _GSTNo= "@GSTNo";
        public static string _PANNO = "@PANNO";
        public static string _Note= "@Note";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        #endregion


        #region Column Defination
        public Int32 Action { get; set; }
        public string PartyName { get; set; }
        public Int32 PartyId { get; set; }
        public string PartyAddress { get; set; }
        public string PTelNo { get; set; }
        public string PmobileNo { get; set; }
        public  string PEmailId  { get; set; }
        public string PWebsite { get; set; }
        public string ContPerName { get; set; }
        public string ContPerAddress { get; set; }
        public string CTelNo { get; set; }
        public string CMobileNo { get; set; }
        public string CEmailId { get; set; }
        public string CAdharCardNo { get; set; }
        public string GSTNo { get; set; }
        public string PANNO { get; set; }
        public string Note { get; set; }
        public Int32 UserId { get; set; }
        public  DateTime LoginDate { get; set; }
        public  bool IsDeleted { get; set; }
        public  string StrCondition { get; set; }
        #endregion


        # region Stored Procedure
        public static string SP_PartyMaster = "SP_PartyMaster";
        #endregion

        public PropertyPartyMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}