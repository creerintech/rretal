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

public class LocationMaster
{

    #region Constants
    public static string _Action = "@Action";
    public static string _LocationId = "@LocationId";
    public static string _CityId = "@CityId";
    public static string _LocationName = "@LocationName";
    public static string _LoginId = "@LoginId";
    public static string _LoginDate = "@LoginDate";
    public static string _StrCondition = "@strCond";
    #endregion

    #region Definition
    private Int32 m_Action;

    public Int32 Action
    {
        get { return m_Action; }
        set { m_Action = value; }
    }

    private Int32 m_LocationId;

    public Int32 LocationId
    {
        get { return m_LocationId; }
        set { m_LocationId = value; }
    }

    private Int32 m_CityId;

    public Int32 CityId
    {
        get { return m_CityId; }
        set { m_CityId = value; }
    }


    private string m_LocationName;

    public string LocationName
    {
        get { return m_LocationName; }
        set { m_LocationName = value; }
    }   

    private Int32 m_LoginId;

    public Int32 LoginId
    {
        get { return m_LoginId; }
        set { m_LoginId = value; }
    }

    private DateTime m_LoginDate;

    public DateTime LoginDate
    {
        get { return m_LoginDate; }
        set { m_LoginDate = value; }
    }

    private string m_StrCondition;
    public string StrCondition
    {
        get { return m_StrCondition; }
        set { m_StrCondition = value; }
    }


    #endregion

    #region Procedure
    public static string SP_LocationMaster = "SP_LocationMaster";
    #endregion
    public LocationMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
