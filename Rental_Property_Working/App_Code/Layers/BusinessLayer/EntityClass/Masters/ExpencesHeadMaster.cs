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
    public class ExpencesHeadMaster
    {

        #region Column Constant

        public static string _Action = "@Action";
        public static string _ExpenceId = "@ExpenceId";
        public static string _ExpenceNo = "@ExpenceNo";
        public static string _PropertyId = "@PropertyId";
        public static string _ExpenceDate = "@ExpenceDate";
        public static string _ComplitFlag = "@ComplitFlag";
        public static string _ExpenceDtlsId = "@ExpenceDtlsId";
        public static string _Perticulars = "@Perticulars";
        public static string _Qty = "@Qty";
        public static string _Rate = "@Rate";
        public static string _Amount = "@Amount";       
        public static string _Remark = "@Remark";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _strCond = "@strCond";
        public static string _UpdatedBy = "@UpdatedBy";
        public static string _UpdatedDate = "@UpdatedDate";
        public static string _StrCondition = "@StrCondition";
        public static string _FlagCheck = "@FlagCheck";
        public static string _Status = "@Status";

        #endregion

        #region Column Defination

        public Int32 Action { get; set; }
        public Int32 ExpenceId { get; set; }
        public string ExpenceNo { get; set; }
        public bool FlagCheck { get; set; }
        public Int32 PropertyId { get; set; }
        public DateTime ExpenceDate { get; set; }
        public string ComplitFlag { get; set; }
        public Int32 ExpenceDtlsId { get; set; }
        public string Perticulars { get; set; }       
        public Decimal Rate { get; set; }
        public Decimal Qty { get; set; }     
        public Decimal Amount { get; set; }
        public string Remark { get; set; }
        public Int32 UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public bool IsDeleted { get; set; }
        public string strCond { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string StrCondition { get; set; }
        public string Status { get; set; }

        #endregion

        # region Stored Procedure

        public static string SP_ExpenceHeadMaster = "SP_ExpenceHeadMaster";

        #endregion

        public ExpencesHeadMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}