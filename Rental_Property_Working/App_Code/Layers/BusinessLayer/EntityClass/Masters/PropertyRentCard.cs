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
/// Summary description for PropertyRentCard
/// </summary>
public class PropertyRentCard
{
    #region[constants]
    public static string _Action = "@Action";
    public static string _PropertyRentCardId = "@PropertyRentCardId";
    public static string _PropertyId = "@PropertyId";
    public static string _PartyId = "@PartyId";
    public static string _PCNo = "@PCNo";
    public static string _PropertyName = "@PropertyName";
    public static string _UnitNo = "@UnitNo";
    public static string _UnitArea = "@UnitArea";
    public static string _Rent = "@Rent";
    public static string _PropertyAddress = "@PropertyAddress";    
    public static string _FlatTypeId = "@FlatTypeId";
    public static string _SqFt = "@SqFt";  
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _StrCondition = "@StrCond";
    public static string _FlagCheck = "@FlagCheck";
    public static string _Status = "@Status";
    public static string _RemaingAmount = "@RemaingAmount";
    public static string _ProRentDtlsId = "@ProRentDtlsId";
    public static string _FromDate = "@FromDate";
    public static string _ToDate = "@ToDate";
    public static string _CompanyId = "@CompanyId";
    public static string _RentalAmt = "@RentalAmt";
    public static string _CollectedDate = "@CollectedDate";
    public static string _Remark = "@Remark";

    public static string _PropertyTaxAmt = "@PropertyTaxAmt";
    public static string _SocietyMaintenaceAmt = "@SocietyMaintenaceAmt";
    public static string _DepositAmt = "@DepositAmt";
    public static string _FlagReceiptType = "@FlagReceiptType";


    public static string _GSTPerDetails = "@GSTPerDetails";
    public static string _GSTAmt = "@GSTAmt";
    public static string _Amount = "@Amount";
    public static string _TaxTemplateID = "@TaxTemplateID";

    public static string _FortheMonthYear = "@FortheMonthYear";
    public static string _ReceiptVoucherId = "@ReceiptVoucherId";
    public static string _IsGenerated = "@IsGenerated";
    public static string _RentalAmount = "@RentalAmount";
    #region Defination

    public string FortheMonthYear { get; set; }
    public Int32 ReceiptVoucherId { get; set; }
    public bool IsGenerated { get; set; }
    public Decimal RentalAmount { get; set; }
    public Decimal RemaingAmount { get; set; }
    public Decimal GSTPerDetails { get; set; }
    public Decimal GSTAmt { get; set; }
    public Decimal Amount { get; set; }
    public Int32 Action { get; set; }
    public Int32 PropertyRentCardId { get; set; }
    public   Int32 PropertyId { get; set; }
    public Int32 PartyId { get; set; }
    public  string PCNo { get; set; }
    public  string PropertyName{ get; set; }
    public  string UnitNo { get; set; }
    public  Decimal UnitArea { get; set; }
    public  decimal Rent{ get; set; }
    public  string PropertyAddress { get; set; }
    public  Int32 FlatTypeId { get; set; }
    public  Decimal SqFt { get; set; }
    public  Int32 UserId{ get; set; }
    public  DateTime LoginDate { get; set; }
    public  bool IsDeleted { get; set; }
    public  string StrCondition { get; set; }
    public  Decimal PropertyTaxAmt{ get; set; }
    public Decimal SocietyMaintenaceAmt { get; set; }
    public Decimal DepositAmt { get; set; }
    public bool FlagCheck { get; set; }
    public string Status { get; set; }
    public  Int32 ProRentDtlsId { get; set; }
    public  DateTime FromDate { get; set; }
    public  DateTime ToDate { get; set; }
    public  Int32 CompanyId { get; set; }
    public  decimal RentalAmt { get; set; }
    public  DateTime CollectedDate { get; set; }
    public string Remark { get; set; }
    public bool FlagReceiptType { get; set; }
    public Int32 TaxTemplateID { get; set; }
    #endregion


    #region[procedure]
    public static string SP_PropertyRentalCard = "SP_PropertyRentalCard"; 
    #endregion
    #endregion

    public PropertyRentCard()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
