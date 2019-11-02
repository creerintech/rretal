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
/// Summary description for ProjectwiseTowerwise
/// </summary>
public class ProjectwiseTowerwise
{
    #region[Constants]
    public static string _Action = "@Action";
    public static string _PaymentScheduleId= "@PaymentScheduleId";
    public static string _PaymentTitle = "@PaymentTitle";
    public static string _PaymentDtlsId= "@PaymentDtlsId";
    public static string _ProjectId = "@ProjectId";
    public static string _TowerName = "@TowerName";

    public static string _StageId = "@StageId";
    public static string _Percentage ="@Percentage";
    public static string _DispOrder = "@DispOrder";
    public static string _Flag = "@Flag";

    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
   
    public static string _mode = "@mode";
    public static string _UsedCount = "@UsedCount";
    public static string _searchCondition = "@searchCondition";
    #endregion

    #region[Defination]
    public int Action { get; set; }
    public int PaymentScheduleId { get; set; }
    public string PaymentTitle { get; set; }
    public int PaymentDtlsId { get; set; }
    public int ProjectId { get; set; }
    public string TowerName { get; set; }
    public int StageId { get; set; }
    public decimal Percentage { get; set; }
    public int DispOrder { get; set; }
    public bool Flag { get; set; }
    
    public int UserId { get; set; }
    public DateTime LoginDate { get; set; }
    public bool IsDeleted { get; set; }
   
    public int mode { get; set; }
    public int UsedCount { get; set; }
    public int PCId { get; set; }
    
    public string searchCondition { get; set; }
    #endregion

    #region[StoreProcedures]
    public const string Est_PRO_ProjectwiseTowerwiseStageSetting = "Est_PRO_PaymentScheduleTemplate";
    #endregion

	public ProjectwiseTowerwise()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
