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
/// Summary description for ExpenseRegister
/// </summary>
/// 
namespace Build.EntityClass
{

    public class ExpenseRegister
    {

        #region Column Constant

        public static string _Action = "@Action";
        public static string _ExpregId = "@ExpregId";
        public static string _ExpRegNo = "@ExpRegNo";
        public static string _ExpenseHdId = "@ExpenseHdId";
        public static string _PropertyId = "@PropertyId";
        public static string _UnitNo = "@UnitNo";
        public static string _ExpenceRegDate = "@ExpenceRegDate";
        public static string _ComplitFlag = "@ComplitFlag";
        public static string _ExpRegdtlsId = "@ExpRegdtlsId";
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
        public Int32 ExpregId { get; set; }
        public string UnitNo { get; set; }
        public Int32 PropertyId { get; set; }
        public string ExpRegNo { get; set; }
        public bool FlagCheck { get; set; }
        public Int32 ExpenseHdId { get; set; }
        public DateTime ExpenceRegDate { get; set; }
        public string ComplitFlag { get; set; }
        public Int32 ExpRegdtlsId { get; set; }
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

        public static string SP_ExpenceRegisterMaster = "SP_ExpenceRegisterMaster";

        #endregion




        public ExpenseRegister()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}