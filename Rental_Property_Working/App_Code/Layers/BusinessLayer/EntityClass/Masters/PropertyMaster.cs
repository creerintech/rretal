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
    public class PropertyMaster
    {

        #region Column Constant
        public static string _Action = "@Action";
        public static string _Property = "@Property";
        public static string _PropertyId = "@PropertyId";
        public static string _PropertyAddress = "@PropertyAddress";
        public static string _CompanyId = "@CompanyId";
        public static string _PropertyDetlsId = "@PropertyDetlsId";

        public static string _FlatTypeId = "@FlatTypeId";
        public static string _UnitNo = "@UnitNo";
        public static string _UnitArea = "@UnitArea";
        public static string _PropertyTaxAmt = "@PropertyTaxAmt";
        public static string _SocietyMaintenaceAmt = "@SocietyMaintenaceAmt";
        public static string _PropertyTypeId = "@PropertyTypeId";
        public static string _CityId = "@CityId";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
          public static string _PropertyExpenseId= "@PropertyExpenseId";
             public static string _ExpenseHdId= "@ExpenseHdId";
             public static string _Amount= "@Amount";
             public static string _PropertySubTypeId = "@PropertySubTypeId";
             public static string _LocationId = "@LocationId";
        #endregion

        public Int32 Action { get ; set ;}
        public string Property { get; set; }
        public Int32 PropertyId { get; set; }

        public Int32 PropertySubTypeId { get; set; }

        public Int32 LocationId { get; set; }

        public string PropertyAddress { get; set; }
        public Int32 CompanyId { get; set; }
        public Int32 PropertyDetlsId { get; set; }

        public Int32 FlatTypeId { get; set; }
        public string UnitNo { get; set; }
        public decimal UnitArea { get; set; }
        public decimal PropertyTaxAmt { get; set; }
        public decimal SocietyMaintenaceAmt { get; set; }
        public Int32 PropertyTypeId{ get; set; }
        public Int32 CityId { get; set; }
        public Int32 UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public bool IsDeleted  { get ; set ;}
        public string StrCondition { get ; set ;}

        public Int32 PropertyExpenseId{ get; set; }
        public Int32 ExpenseHdId{ get; set; }
        public decimal Amount { get; set; }

        # region Stored Procedure
        public static string SP_PropertyMaster = "SP_PropertyMaster";
        #endregion

        public PropertyMaster()
        {

        }
    }
}
