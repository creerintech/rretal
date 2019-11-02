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
/// Summary description for PaymentSchedule
/// </summary>
namespace Build.EntityClass
{
    public class PaymentSchedule
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _PSId = "@PSId";
        public static string _PCId = "@PCId";
        public static string _TowerName = "@TowerName";
        public static string _FlatTypeId = "@FlatTypeId";
        public static string _SqrFt = "@SqrFt";
        public static string _Amount = "@Amount";
        public static string _GrandTotal = "@GrandTotal";
   
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        
        //PaymentSchedule dtls
        public static string _PSdtlId = "@PSdtlId";
        public static string _PaymentSchedules = "@PaymentSchedule";
        public static string _Percentage = "@Percentage";
        public static string _Amnt = "@Amnt";
        
        //Payment Charges Type
        public static string _PSchargeId = "@PSchargeId";
        public static string _Type = "@Type";
        public static string _Charge = "@Charge";
        public static string _ChargeAmount = "@ChargeAmount";

        public static string _PCDetailId = "@PCDetailId";
        #endregion

        #region [Defination]

        private Int32 m_Action;

        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        private Int32 m_PSId;

        public Int32 PSId
        {
            get { return m_PSId; }
            set { m_PSId = value; }
        }
        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }
        private string m_TowerName;

        public string TowerName
        {
            get { return m_TowerName; }
            set { m_TowerName = value; }
        }
        private Int32 m_FlatTypeId;

        public Int32 FlatTypeId
        {
            get { return m_FlatTypeId; }
            set { m_FlatTypeId = value; }
        }
        private string m_SqrFt;

        public string SqrFt
        {
            get { return m_SqrFt; }
            set { m_SqrFt = value; }
        }
        private decimal m_Amount;

        public decimal Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }
        private decimal m_GrandTotal;

        public decimal GrandTotal
        {
            get { return m_GrandTotal; }
            set { m_GrandTotal = value; }
        }
        private Int32 m_UserId;

        public Int32 UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }
        private DateTime m_LoginDate;

        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }
        private bool m_IsDeleted;

        public bool IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }
        private string m_StrCond;

        public string StrCond
        {
            get { return m_StrCond; }
            set { m_StrCond = value; }
        }
        //Payment Sch Details

        private int m_PSdtlId;

        public int PSdtlId
        {
            get { return m_PSdtlId; }
            set { m_PSdtlId = value; }
        }
        private string m_PaymentSchedules;

        public string PaymentSchedules
        {
            get { return m_PaymentSchedules; }
            set { m_PaymentSchedules = value; }
        }

     
        private decimal m_Percentage;

        public decimal Percentage
        {
            get { return m_Percentage; }
            set { m_Percentage = value; }
        }
        private decimal m_Amnt;

        public decimal Amnt
        {
            get { return m_Amnt; }
            set { m_Amnt = value; }
        }

        //payment Charge Type
        private int m_PSchargeId;

        public int PSchargeId
        {
            get { return m_PSchargeId; }
            set { m_PSchargeId = value; }
        }

        private string m_Charge;

        public string Charge
        {
            get { return m_Charge; }
            set { m_Charge = value; }
        }

        private int m_Type;

        public int Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
        private decimal m_ChargeAmount;

        public decimal ChargeAmount
        {
            get { return m_ChargeAmount; }
            set { m_ChargeAmount = value; }
        }
        private Int32 m_PCDetailId;

        public Int32 PCDetailId
        {
            get { return m_PCDetailId; }
            set { m_PCDetailId = value; }
        }
        #endregion

        #region Srored Proc
        public static string SP_PaymentSchedule = "SP_PaymentSchedule";
        public static string SP_PaymentSchedule1 = "SP_PaymentSchedule1";
        public static string SP_PaymentScheduleStages = "SP_PaymentScheduleStages";
        #endregion
        public PaymentSchedule()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
