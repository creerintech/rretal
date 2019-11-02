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


public class PropertyType
{
    #region Constants
    public static string _Action = "@Action";
    public static string _PropertyTypeId = "@PropertyTypeId";
    public static string _PropertyTypeDesc = "@PropertyTypeDesc";
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

    private Int32 m_PropertyTypeId;

    public Int32 PropertyTypeId
    {
        get { return m_PropertyTypeId; }
        set { m_PropertyTypeId = value; }
    }


    private string m_PropertyTypeDesc;

    public string PropertyTypeDesc
    {
        get { return m_PropertyTypeDesc; }
        set { m_PropertyTypeDesc = value; }
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
    public static string SP_PropertyTypeMaster = "SP_PropertyTypeMaster";
    #endregion

    public PropertyType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
