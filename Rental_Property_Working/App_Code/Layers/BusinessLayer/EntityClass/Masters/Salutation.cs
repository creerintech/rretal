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


    public class SalutationMaster
    {
        #region Constants
        public static string _Action = "@Action";
        public static string _SalutationId = "@SalutationId";
        public static string _Salutation = "@Salutation";
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

        private Int32 m_SalutationId;

        public Int32 SalutationId
        {
            get { return m_SalutationId; }
            set { m_SalutationId = value; }
        }

        private string m_Salutation;

        public string Salutation
        {
            get { return m_Salutation; }
            set { m_Salutation = value; }
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
        public static string SP_SalutationMaster = "SP_SalutationMaster";
        #endregion
        public SalutationMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
