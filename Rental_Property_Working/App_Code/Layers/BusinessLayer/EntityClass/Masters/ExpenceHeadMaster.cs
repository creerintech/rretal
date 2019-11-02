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

namespace Build.EntityClass
{
public class ExpenceHeadMaster
{

     #region[constants]
      public static string _Action = "@Action";
      public static string _ExpenceId = "@ExpenceId";
      public static string _ExpenceNo = "@ExpenceNo";
      public static string _ExpenceDate = "@ExpenceDate";
      public static string _PropertyId = "@PropertyId";
      public static string _CreatedBy = "@CreatedBy";
      public static string _CreatedDate = "@CreatedDate";
      public static string _UpdatedBy = "@UpdatedBy";
      public static string _UpdatedDate = "@UpdatedDate";
      public static string _DeletedBy = "@DeletedBy";
      public static string _DeletedDate = "@DeletedDate";
      public static string _Isdeleted = "@Isdeleted";
     #endregion

        public Int32 ExpenceId{get;set;}
        public string ExpenceNo { get;set;}
        public DateTime ExpenceDate {get;set;}
        public Int32 PropertyId {get;set;}
        public Int32 CreatedBy{get; set;}
        public DateTime CreatedDate{get;set;}
        public Int32 UpdatedBy{get;set;}
        public DateTime UpdatedDate{get;set;}
        public Int32 DeletedBy{get;set;}
        public DateTime DeletedDate{get;set;}
        public bool Isdeleted { get; set; }

        #region[procedure]
        public static string SP_AminityMaster = "SP_AminityMaster";
        #endregion
    
    public ExpenceHeadMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
}
