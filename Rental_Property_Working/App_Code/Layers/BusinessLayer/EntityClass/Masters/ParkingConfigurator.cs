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
/// Summary description for ParkingConfigurator
/// </summary>
/// 
public class ParkingConfigurator
{
    #region[Constants]
      public static string _Action="@Action";
      public static string _ParkingConfigId = "@ParkingConfigId";
      public static string _ProjectId = "@ProjectId";
      public static string _ParkingTypeId = "@ParkingTypeId";
      public static string _ParkingSubTypeId = "@ParkingSubTypeId";
      public static string _Numbering = "@Numbering";
      public static string _NoOfPark = "@NoOfPark";
      public static string _TotalNoOfPark = "@TotalNoOfParking";


      public static string _ParkingConfigDtlsId = "@ParkingConfigDtlsId";
      public static string _TowerName = "@TowerName";
      public static string _ParkingNoAllotment = "@ParkingNoAllotment";
      public static string _RangeNo = "@RangeNo";

      public static string _UserId = "@UserId";
      public static string _LoginDate = "@LoginDate";
      public static string _IsDeleted = "@IsDeleted";

      public static string _mode = "@mode";
      public static string _UsedCount = "@UsedCount";
      public static string _searchCondition = "@searchCondition";
    #endregion
       
    #region[Definations]
      public Int32 Action { get; set; }
      public Int32 ParkingConfigId { get; set; }
      public Int32 ProjectId { get; set; }
      public Int32 ParkingTypeId { get; set; }
      public Int32 ParkingSubTypeId { get; set; }
      public Boolean Numbering { get; set; }
      public Int32 NoOfPark { get; set; }
      public Int32 TotalNoOfPark { get; set; }

      public Int32 ParkingConfigDtlsId { get; set; }
      public string TowerName { get; set; }
      public string ParkingNoAllotment { get; set; }
      public Int32 RangeNo { get; set; }

      public Int32 UserId { get; set; }
      public DateTime LoginDate { get; set; }
      public bool IsDeleted { get; set; }
      public string StrCond { get; set; }
     
    #endregion

    #region[StoreProcedures]
      public const string Est_PRO_ParkingConfiguration = "Est_PRO_ParkingConfigurationNew";
    #endregion

    public ParkingConfigurator()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
