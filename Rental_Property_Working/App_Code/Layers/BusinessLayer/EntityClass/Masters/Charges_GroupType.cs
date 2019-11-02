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
/// Summary description for Charges_GroupType
/// </summary>
public class Charges_GroupType
{

    #region Column Constant
    public static string _Action = "@Action";
    public static string _GroupId = "@GroupId";
    public static string _Name = "@GroupName";
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _StrCondition = "@StrCond";
    #endregion

    #region Definations
    public long Action { get; set; }
    public long GroupId { get; set; }
    public string GroupName { get; set; }
    public long UserId { get; set; }
    public string LoginDate { get; set; }
    public string SearchCond { get; set; }
    #endregion
    #region Stored Proc
    public static string SP_ChargeGroupType = "SP_Charges_Group_Type_I";
    #endregion
	public Charges_GroupType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
