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
/// Summary description for PCTemplate
/// </summary>
public class PCTemplate
{

    #region Column Constant
    public static string _Action = "@Action";
    public static string _ChargeId = "@ChargeId";
    public static string _ProjectId = "@ProjectId";
    public static string _FlatTypeId = "@FlatTypeId";
    public static string _Value = "@Value";
    public static string _CollectionFor = "@CollectionFor";
    public static string _PCTemplateId = "@PCTemplateId";
    public static string _ApplicableDate = "@ApplicableDate";
    public static string _ProjectStageId = "@ProjectStageId";
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _StrCondition = "@StrCond";
    #endregion

    #region Definations
    private Int32 m_Action;
    public Int32 Action
    {
        get { return m_Action; }
        set { m_Action = value; }
    }

    private Int32 m_PCTemplateId;
    public Int32 PCTemplateId
    {
        get { return m_PCTemplateId; }
        set { m_PCTemplateId = value; }
    }


    private Int32 m_ChargeId;
    public Int32 ChargeId
    {
        get { return m_ChargeId; }
        set { m_ChargeId = value; }
    }

    private Int32 m_ProjectId;

    public Int32 ProjectId
    {
        get { return m_ProjectId; }
        set { m_ProjectId = value; }
    }

    private Decimal m_Value;

    public Decimal Value
    {
        get { return m_Value; }
        set { m_Value = value; }
    }

    private Decimal m_CollectionFor;

    public Decimal CollectionFor
    {
        get { return m_CollectionFor; }
        set { m_CollectionFor = value; }
    }

    private Int32 m_FlatTypeId;

    public Int32 FlatTypeId
    {
        get { return m_FlatTypeId; }
        set { m_FlatTypeId = value; }
    }

    private Int32 m_ProjectStageId;

    public Int32 ProjectStageId
    {
        get { return m_ProjectStageId; }
        set { m_ProjectStageId = value; }
    }

    private DateTime m_ApplicableDate;

    public DateTime ApplicableDate
    {
        get { return m_ApplicableDate; }
        set { m_ApplicableDate = value; }
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
    public static string SP_PCTemplate = "SP_PCTemplate";
    public static string SP_PCTemplate_Part1 = "SP_PCTemplate_Part1";
    #endregion

	public PCTemplate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
