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

public class CityMaster
{
    #region Constants
    public static string _Action = "@Action";
    public static string _CityId = "@CityId";
    public static string _City = "@City";
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

    private Int32 m_CityId;

    public Int32 CityId
    {
        get { return m_CityId; }
        set { m_CityId = value; }
    }

    private string m_City;

    public string City
    {
        get { return m_City; }
        set { m_City = value; }
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
    public static string SP_CityMaster = "SP_CityMaster";
    #endregion

    public CityMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
