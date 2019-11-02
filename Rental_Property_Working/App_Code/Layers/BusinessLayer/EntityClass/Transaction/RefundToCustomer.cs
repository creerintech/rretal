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
/// Summary description for RefundToCustomer
/// </summary>
public class RefundToCustomer
{
    #region [Constants]

    public const string _Action = "@Action";
    public const string _RefundId = "@RefundId";
    public const string _RefundDate = "@RefundDate";
    public const string _ProjectId = "@ProjectId";
    public const string _BookingId = "@BookingId";
    public const string _TowerName = "@TowerName";
    public const string _CustomerId = "@CustomerId";
    public const string _ExcessAmount = "@ExcessAmount";
    public const string _AlreadyRefundedAmt = "@AlreadyRefundedAmt";
    public const string _AmtToBeRefunded = "@AmtToBeRefunded";

    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _StrCondition = "@RepCondition";
    //----------After adding payment details
    public static string _PayModeTypeId = "@PayModeTypeId";
    private string m_ChequeDDNO;
    public static string _ChequeDDDate = "@ChequeDDDate";
    public static string _PaymentMode = "@PaymentMode";
    #endregion

    #region [Defination]

    public Int32 RefundId { get; set; }
    public DateTime RefundDate { get; set; }
    public Int32 ProjectId { get; set; }
    public Int32 BookingId { get; set; }
    public string TowerName { get; set; }
    public Int32 CustomerId { get; set; }
    public decimal ExcessAmount { get; set; }
    public decimal AlreadyRefundedAmt { get; set; }
    public decimal AmtToBeRefunded { get; set; }
    public Int32 UserId { get; set; }
    public DateTime LoginDate { get; set; }
    public Int32 IsDeleted { get; set; }
    public string StrCondition { get; set; }

    //-------------After Adding payments details
    public string RTGSTranNo { get; set; }
    private char m_PaymentMode;
    public char PaymentMode
    {
        get { return m_PaymentMode; }
        set { m_PaymentMode = value; }
    }
    public string ChequeDDNO
    {
        get { return m_ChequeDDNO; }
        set { m_ChequeDDNO = value; }
    }
    private DateTime m_ChequeDDDate;

    public DateTime ChequeDDDate
    {
        get { return m_ChequeDDDate; }
        set { m_ChequeDDDate = value; }
    }
    private Int32 m_BankId;

    public Int32 BankId
    {
        get { return m_BankId; }
        set { m_BankId = value; }
    }
    private string m_BranchName;

    public string BranchName
    {
        get { return m_BranchName; }
        set { m_BranchName = value; }
    }

    private string m_BankName;

    public string BankName
    {
        get { return m_BankName; }
        set { m_BankName = value; }
    }
    private Boolean m_PayModeFlag;

    public Boolean PayModeFlag
    {
        get { return m_PayModeFlag; }
        set { m_PayModeFlag = value; }
    }
    private string m_DraweeBankName;

    public string DraweeBankName
    {
        get { return m_DraweeBankName; }
        set { m_DraweeBankName = value; }
    }
    #endregion

    #region[StoreProcedure]
    public static string SP_RefundToCustomer = "SP_RefundToCustomer";
    #endregion



    public RefundToCustomer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
