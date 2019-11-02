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
/// Summary description for ParkingAllotment
/// </summary>
public class ParkingAllotment
{

    #region[Constants]
    public static string _Action = "@Action";
    public static string _ParkingAllotmentId = "@ParkingAllotmentId";
    public static string _ProjectId = "@ProjectId";
    public static string _TowerName = "@TowerName";
    public static string _CustomerId = "@CustomerId";
    public static string _BookingId = "@BookingId";
    public static string _ParkingGroupId = "@ParkingGroupId";
    public static string _ParkingTypeId = "@ParkingTypeId";
    public static string _ParkingSubTypeId = "@ParkingSubTypeId";
    public static string _ParkingNo = "@ParkingNo";
    public static string _ParkingAllotmentDtlsId = "@ParkingAllotmentDtlsId";
    public static string _ParkingConfigDtlsId = "@ParkingConfigDtlsId";
  
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";

    public static string _mode = "@mode";
    public static string _UsedCount = "@UsedCount";
    public static string _searchCondition = "@searchCondition";
    #endregion

    #region[Definations]
    public Int32 Action { get; set; }
    public Int32 ParkingAllotmentId { get; set; }
    public Int32 ProjectId { get; set; }
    public string TowerName { get; set; }
    public Int32 CustomerId { get; set; }
    public Int32 BookingId { get; set; }
    public Int32 ParkingGroupId { get; set; }
    public Int32 ParkingAllotmentDtlsId { get; set; }
    public Int32 ParkingTypeId { get; set; }
    public Int32 ParkingSubTypeId { get; set; }
    public Int32 ParkingNo { get; set; }
    public Int32 ParkingConfigDtlsId { get; set; }
  
    public Int32 UserId { get; set; }
    public DateTime LoginDate { get; set; }
    public bool IsDeleted { get; set; }
    public string StrCond { get; set; }

    #endregion

    #region[StoreProcedures]
    public const string SP_ParkingAllotment = "Est_PRO_ParkingAllotment";
    #endregion


	public ParkingAllotment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}