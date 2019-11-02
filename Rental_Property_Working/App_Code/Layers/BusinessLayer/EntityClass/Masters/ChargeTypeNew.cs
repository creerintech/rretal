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
/// Summary description for ChargeTypeNew
/// </summary>
public class ChargeTypeNew
{
    #region Column Constant
    public static string _Action = "@Action";
    public static string _ChargeId = "@ChargeId";
    public static string _Amount = "@Amount";
    public static string _ChargeName = "@ChargeName";
    public static string _Type = "@Type";
    public static string _DisplayName = "@DisplayName";

    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _StrCondition = "@StrCond";
    public static string _ChargeGroupId = "@ChargeGroupId";
    public static string _ForParking = "@ForParking";
    #endregion

    #region Definations
    public long ChargeGroupId { get; set; }
    public bool ForParking { get; set; }

    private Int32 m_Action;
    public Int32 Action
    {
        get { return m_Action; }
        set { m_Action = value; }
    }

    private Int32 m_ChargeId;
    public Int32 ChargeId
    {
        get { return m_ChargeId; }
        set { m_ChargeId = value; }
    }

   

    private Decimal m_Amount;

    public Decimal Amount
    {
        get { return m_Amount; }
        set { m_Amount = value; }
    }

    private string m_ChargeName;

    public string ChargeName
    {
        get { return m_ChargeName; }
        set { m_ChargeName = value; }
    }

    private Int32 m_Type;

    public Int32 Type
    {
        get { return m_Type; }
        set { m_Type = value; }
    }

    private string m_DisplayName;

    public string DisplayName
    {
        get { return m_DisplayName; }
        set { m_DisplayName = value; }
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

    private string m_StrCond;

    public string StrCond
    {
        get { return m_StrCond; }
        set { m_StrCond = value; }
    }
    #endregion

    #region Stored Proc
    public static string SP_ChargeTypeNew = "SP_ChargeTypeNew";
    #endregion
	public ChargeTypeNew()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
