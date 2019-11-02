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
    public class PropertyMaintenance
    {
    #region Column Constant
     public static string _Action ="@Action";
	 public static string _PropertyMaintenaceId ="@PropertyMaintenaceId";	
	 public static string _PMNo ="@PMNo" ;
	 public static string _PropertyId ="@PropertyId"; 
	 public static string _PMDate ="@PMDate";	
	 public static string _ComplitFlag ="@ComplitFlag"; 
	 public static string _PropertyMaintDtlsId ="@PropertyMaintDtlsId";
	 public static string _TaskType ="@TaskType"; 
	 public static string _TaskDetails="@TaskDetails"; 
	 public static string _Rate ="@Rate";
     public static string _TotalAreaQty = "@TotalAreaQty"; 
	 public static string _AlloatedQty ="@AlloatedQty"; 
	 public static string _TotalAmount ="@TotalAmount";	
     public static string _Remark ="@Remark";	
	 public static string _UserId ="@UserId";
	 public static string _LoginDate ="@LoginDate"; 
	 public static string _IsDeleted ="@IsDeleted";
	 public static string _strCond ="@strCond"; 
	 public static string _UpdatedBy ="@UpdatedBy"; 
	 public static string _UpdatedDate="@UpdatedDate";
     public static string _StrCondition="@StrCondition";
     public static string _FlagCheck = "@FlagCheck";
     public static string _Status = "@Status";
     public static string _MaintenaceType = "@MaintenaceType";
     public static string _UnitNo = "@UnitNo";
     public static string _Expences = "@Expences";
     public static string _Amount = "@Amount";
     public static string _PartyId = "@PartyId";
     public static string _ExpenseHdId = "@ExpenseHdId";
     #endregion

     public Int32 Action {get;set;} 
     public Int32 PropertyMaintenaceId {get;set;} 
     public string PMNo  {get;set;}
     public bool FlagCheck { get; set; }
     public Int32 PropertyId  {get;set;}
     public DateTime PMDate   {get;set;}
     public string ComplitFlag   {get;set;}
     public Int32 PropertyMaintDtlsId   {get;set;}
     public string TaskType   {get;set;}
     public string TaskDetails   {get;set;}
     public Decimal Rate   {get;set;}
     public Decimal TotalAreaQty   {get;set;}
     public Decimal AlloatedQty   {get;set;}
     public Decimal TotalAmount  {get;set;} 
     public string Remark   {get;set;}
     public Int32 UserId   {get;set;}
     public DateTime LoginDate {get;set;}
     public bool IsDeleted { get; set; }
     public string strCond   {get;set;}
     public Int32  UpdatedBy   {get;set;}
     public DateTime UpdatedDate   {get;set;}
     public string StrCondition { get; set; }
     public string Status { get; set; }
     public string MaintenaceType { get; set; }
     public Int32 UnitNo { get; set; }
     public string Expences { get; set; }
     public decimal Amount { get; set; }
     public Int32 PartyId { get; set; }
     public Int32 ExpenseHdId { get; set; }

     # region Stored Procedure
     public static string SP_PropertyMaintenance = "SP_PropertyMaintenance";
    
     #endregion

        public PropertyMaintenance()
        {

        }
    }
}