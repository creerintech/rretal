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
/// Summary description for BrokerMaster
/// </summary>

namespace Build.EntityClass
{
    public class EmployeeMaster
    {
        # region Column Constant

        public const string _Action = "@Action";
        public const string _EmpCode = "@EmpCode";
        public const string _EmpID = "@EmpID";
        public const string _Empname = "@Empname";
        public const string _EmpAddress = "@EmpAddress";
        public const string _EmployeeId = "@EmployeeId";

        public const string _tel1 = "@tel1";
        public const string _tel2 = "@tel2";
        public const string _mobile = "@mobile";

        public const string _email = "@email";
        public const string _city = "@city";
        public const string _state = "@state";
        public const string _pin = "@pin";
        public const string _notes = "@notes";
        public const string _Employedon = "@Employedon";
        public const string _dob = "@dob";

        public const string _LoginID = "@LoginID";
        public const string _LoginDate = "@LoginDate";
        public const string _RepCondition = "@RepCondition";
        # endregion

        #region Store Procedure

        public const string PRO_EMPLOYEEMASTER = "SP_EmployeeMaster";

        #endregion

        #region Property Defination
        private Int32 m_Action;

        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private string m_EmpCode;

        public string EmpCode
        {
            get { return m_EmpCode; }
            set { m_EmpCode = value; }
        }

        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }

        private string m_Empname;

        public string Empname
        {
            get { return m_Empname; }
            set { m_Empname = value; }
        }

        private string m_EmpAddress;

        public string EmpAddress
        {
            get { return m_EmpAddress; }
            set { m_EmpAddress = value; }
        }


        private string m_tel1;

        public string Tel1
        {
            get { return m_tel1; }
            set { m_tel1 = value; }
        }

        private string m_tel2;

        public string Tel2
        {
            get { return m_tel2; }
            set { m_tel2 = value; }
        }

        private string m_mobile;

        public string Mobile
        {
            get { return m_mobile; }
            set { m_mobile = value; }
        }

        private string m_email;

        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        private string m_city;

        public string City
        {
            get { return m_city; }
            set { m_city = value; }
        }

        private string m_state;

        public string State
        {
            get { return m_state; }
            set { m_state = value; }
        }

        private string m_pin;

        public string Pin
        {
            get { return m_pin; }
            set { m_pin = value; }
        }

        private string m_notes;

        public string Notes
        {
            get { return m_notes; }
            set { m_notes = value; }
        }

        private DateTime m_Employedon;

        public DateTime Employedon
        {
            get { return m_Employedon; }
            set { m_Employedon = value; }
        }

        private DateTime m_dob;

        public DateTime Dob
        {
            get { return m_dob; }
            set { m_dob = value; }
        }

        private string m_RepCondition;

        public string RepCondition
        {
            get { return m_RepCondition; }
            set { m_RepCondition = value; }
        }
        private Int32 m_LoginID;

        public Int32 LoginID
        {
            get { return m_LoginID; }
            set { m_LoginID = value; }
        }

        private DateTime m_LoginDate;

        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }
        #endregion
        public EmployeeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
