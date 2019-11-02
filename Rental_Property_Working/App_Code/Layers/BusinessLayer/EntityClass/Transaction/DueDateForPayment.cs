using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for DueDateForPayment
/// </summary>
public class DueDateForPayment
{

     #region[Constants]
    public static string _Action = "@Action";
    public static string _DueDateId = "@DueDateId";
    public static string _ProjectId = "@ProjectId";
    public static string _TowerName = "@TowerName";
    public static string _PaymentScheduleId = "@PaymentScheduleId";
    public static string _DueDateDtlsId = "@DueDateDtlsId";
    public static string _Percentage = "@Percentage";
    public static string _DueDate = "@DueDate";
    public static string _GracePeriod = "@GracePeriod";
    public static string _InterestRate = "@InterestRate";
    public static string _StageId = "@StageId";
    public static string _PCDetailId = "@PCDetailId";
    public static string _BookingId = "@BookingId";
    public static string _StageDueDateId = "@StageDueDateId";
    public static string _CustomerId = "@CustomerId";
  
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";

    public static string _mode = "@mode";
    public static string _UsedCount = "@UsedCount";
    public static string _searchCondition = "@searchCondition";
    #endregion

    #region[Definations]
    public Int32 Action { get; set; }
    public Int32 DueDateId { get; set; }
    public Int32 ProjectId { get; set; }
    public string TowerName { get; set; }
    public Int32 PaymentScheduleId { get; set; }
    public Int32 DueDateDtlsId { get; set; }
    public Decimal Percentage { get; set; }
    public DateTime DueDate { get; set; }
    public Int32 GracePeriod { get; set; }
    public Decimal InterestRate { get; set; }
    public Int32 StageId { get; set; }
    public Int32 PCDetailId { get; set; }
    public Int32 BookingId { get; set; }
    public Int32 StageDueDateId { get; set; }
    public Int32 CustomerId { get; set; } 

    public Int32 UserId { get; set; }
    public DateTime LoginDate { get; set; }
    public bool IsDeleted { get; set; }
    public string StrCond { get; set; }

    #endregion

    #region[StoreProcedures]
    public const string SP_DueDateForPayment = "SP_DueDateForPayment";

    public const string SP_DueDate = "SP_DueDate";

    public const string SP_DueDate_I = "SP_DueDate_I";
    #endregion

	public DueDateForPayment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}