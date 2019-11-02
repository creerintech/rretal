﻿using System;
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
    public class TermsConditions
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _TermsID = "@TermsID";
        public static string _Title = "@Title";
        public static string _TermsCondition = "@TermsCondition";


        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        #endregion

        #region Definitions
        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_TermsID;

        public Int32 TermsID
        {
            get { return m_TermsID; }
            set { m_TermsID = value; }
        }
        private string m_Title;

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        private string m_TermsCondition;

        public string TermsCondition
        {
            get { return m_TermsCondition; }
            set { m_TermsCondition = value; }
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

        private string m_StrCondition;

        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }
        #endregion

        # region Stored Procedure
        public static string SP_TermsConditions = "SP_TermsConditions";
        #endregion
        public TermsConditions()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
