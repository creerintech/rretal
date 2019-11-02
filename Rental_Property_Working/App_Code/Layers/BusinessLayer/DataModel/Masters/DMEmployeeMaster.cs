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

using System.Collections.Generic;

using System.Data.SqlClient;
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;


/// <summary>
/// Summary description for DMBrokerMaster
/// </summary>

namespace Build.DataModel
{
    public class DMEmployeeMaster : Utility.Setting
    {
        #region BusinessLogic
        public DataSet GetEmpCode(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 6;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet ChkDuplicate(string Name, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(EmployeeMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(EmployeeMaster._RepCondition, SqlDbType.NVarChar);

                pAction.Value = 7;
                pRepCondition.Value = Name;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, pAction, pRepCondition);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public int InsertEmployee(ref EmployeeMaster Entity_Emp, out string strError)
        {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter PAction = new SqlParameter(EmployeeMaster._Action, SqlDbType.BigInt);
                SqlParameter PCode = new SqlParameter(EmployeeMaster._EmpCode, SqlDbType.NVarChar);
                SqlParameter PName = new SqlParameter(EmployeeMaster._Empname, SqlDbType.NVarChar);
                SqlParameter PAddress = new SqlParameter(EmployeeMaster._EmpAddress, SqlDbType.NVarChar);
                SqlParameter PTel1 = new SqlParameter(EmployeeMaster._tel1, SqlDbType.NVarChar);
                SqlParameter PTel2 = new SqlParameter(EmployeeMaster._tel2, SqlDbType.NVarChar);
                SqlParameter PMobile = new SqlParameter(EmployeeMaster._mobile, SqlDbType.NVarChar);

                SqlParameter PEmail = new SqlParameter(EmployeeMaster._email, SqlDbType.NVarChar);
                SqlParameter PCity = new SqlParameter(EmployeeMaster._city, SqlDbType.NVarChar);
                SqlParameter PState = new SqlParameter(EmployeeMaster._state, SqlDbType.NVarChar);
                SqlParameter PPin = new SqlParameter(EmployeeMaster._pin, SqlDbType.NVarChar);
                SqlParameter PDoB = new SqlParameter(EmployeeMaster._dob, SqlDbType.DateTime);
                SqlParameter PDoJ = new SqlParameter(EmployeeMaster._Employedon, SqlDbType.DateTime);
                SqlParameter PNotes = new SqlParameter(CustomerMaster._Notes, SqlDbType.NVarChar);
                SqlParameter PLoginID = new SqlParameter(CustomerMaster._LoginID, SqlDbType.BigInt);
                SqlParameter PLoginDate = new SqlParameter(CustomerMaster._LoginDate, SqlDbType.DateTime);

                PAction.Value = 1;
                PCode.Value = Entity_Emp.EmpCode;
                PName.Value = Entity_Emp.Empname; ;
                PAddress.Value = Entity_Emp.EmpAddress;
                PTel1.Value = Entity_Emp.Tel1;
                PTel2.Value = Entity_Emp.Tel2;
                PMobile.Value = Entity_Emp.Mobile;

                PEmail.Value = Entity_Emp.Email;
                PCity.Value = Entity_Emp.City;
                PState.Value = Entity_Emp.State;
                PPin.Value = Entity_Emp.Pin;

                PDoB.Value = Entity_Emp.Dob;
                PDoJ.Value = Entity_Emp.Employedon;
                PNotes.Value = Entity_Emp.Notes;
                PLoginID.Value = Entity_Emp.LoginID;
                PLoginDate.Value = Entity_Emp.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { PAction, PCode, PName, PAddress, PTel1, PTel2, PMobile, PEmail, PCity, PState, PPin, PDoB, PDoJ, PNotes, PLoginID, PLoginDate };
                Open(Setting.CONNECTION_STRING);

                BeginTransaction();
                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, ParamArray);

                if (InsertRow != 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return InsertRow;
        }

        public int UpdateEmployee(ref EmployeeMaster Entity_Emp, out string strError)
        {
            int UpdateRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter PAction = new SqlParameter(EmployeeMaster._Action, SqlDbType.BigInt);
                SqlParameter PEmpId = new SqlParameter(EmployeeMaster._EmpID, SqlDbType.BigInt);
                SqlParameter PCode = new SqlParameter(EmployeeMaster._EmpCode, SqlDbType.NVarChar);
                SqlParameter PName = new SqlParameter(EmployeeMaster._Empname, SqlDbType.NVarChar);
                SqlParameter PAddress = new SqlParameter(EmployeeMaster._EmpAddress, SqlDbType.NVarChar);
                SqlParameter PTel1 = new SqlParameter(EmployeeMaster._tel1, SqlDbType.NVarChar);
                SqlParameter PTel2 = new SqlParameter(EmployeeMaster._tel2, SqlDbType.NVarChar);
                SqlParameter PMobile = new SqlParameter(EmployeeMaster._mobile, SqlDbType.NVarChar);

                SqlParameter PEmail = new SqlParameter(EmployeeMaster._email, SqlDbType.NVarChar);
                SqlParameter PCity = new SqlParameter(EmployeeMaster._city, SqlDbType.NVarChar);
                SqlParameter PState = new SqlParameter(EmployeeMaster._state, SqlDbType.NVarChar);
                SqlParameter PPin = new SqlParameter(EmployeeMaster._pin, SqlDbType.NVarChar);
                SqlParameter PDoB = new SqlParameter(EmployeeMaster._dob, SqlDbType.DateTime);
                SqlParameter PDoJ = new SqlParameter(EmployeeMaster._Employedon, SqlDbType.DateTime);
                SqlParameter PNotes = new SqlParameter(CustomerMaster._Notes, SqlDbType.NVarChar);
                SqlParameter PLoginID = new SqlParameter(CustomerMaster._LoginID, SqlDbType.BigInt);
                SqlParameter PLoginDate = new SqlParameter(CustomerMaster._LoginDate, SqlDbType.DateTime);

                PAction.Value = 2;
                PEmpId.Value = Entity_Emp.EmpID;
                PCode.Value = Entity_Emp.EmpCode;
                PName.Value = Entity_Emp.Empname; ;
                PAddress.Value = Entity_Emp.EmpAddress;
                PTel1.Value = Entity_Emp.Tel1;
                PTel2.Value = Entity_Emp.Tel2;
                PMobile.Value = Entity_Emp.Mobile;

                PEmail.Value = Entity_Emp.Email;
                PCity.Value = Entity_Emp.City;
                PState.Value = Entity_Emp.State;
                PPin.Value = Entity_Emp.Pin;

                PDoB.Value = Entity_Emp.Dob;
                PDoJ.Value = Entity_Emp.Employedon;
                PNotes.Value = Entity_Emp.Notes;
                PLoginID.Value = Entity_Emp.LoginID;
                PLoginDate.Value = Entity_Emp.LoginDate;

                SqlParameter[] ParamArray = new SqlParameter[] { PAction, PEmpId, PCode, PName, PAddress, PTel1, PTel2, PMobile, PEmail, PCity, PState, PPin, PDoB, PDoJ, PNotes, PLoginID, PLoginDate };
                Open(Setting.CONNECTION_STRING);
                BeginTransaction();
                UpdateRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, ParamArray);

                if (UpdateRow != 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return UpdateRow;
        }

        public int DeleteEmployee(ref EmployeeMaster Entity_Emp, out string strError)
        {
            int DeleteRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter PAction = new SqlParameter(EmployeeMaster._Action, SqlDbType.BigInt);
                SqlParameter PEmpId = new SqlParameter(EmployeeMaster._EmpID, SqlDbType.BigInt);
                SqlParameter PLoginID = new SqlParameter(EmployeeMaster._LoginID, SqlDbType.BigInt);
                SqlParameter PLoginDate = new SqlParameter(EmployeeMaster._LoginDate, SqlDbType.DateTime);

                PAction.Value = 3;
                PEmpId.Value = Entity_Emp.EmpID;
                PLoginID.Value = Entity_Emp.LoginID;
                PLoginDate.Value = Entity_Emp.LoginDate;
                SqlParameter[] ParamArray = new SqlParameter[] { PAction, PEmpId, PLoginID, PLoginDate };
                Open(Setting.CONNECTION_STRING);
                BeginTransaction();
                DeleteRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, ParamArray);

                if (DeleteRow != 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DeleteRow;
        }

        public DataSet GetEmployee(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter(EmployeeMaster._Action, SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter(EmployeeMaster._RepCondition, SqlDbType.NVarChar);
                MAction.Value = 4;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, MAction, MRepCondition);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetEmployeeForEdit(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter PAction = new SqlParameter(EmployeeMaster._Action, SqlDbType.BigInt);
                SqlParameter PCustID = new SqlParameter(EmployeeMaster._EmpID, SqlDbType.BigInt);
                PAction.Value = 5;
                PCustID.Value = ID;

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, PAction, PCustID);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public string[] GetSuggestedRecord(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter(CustomerMaster._Action, SqlDbType.VarChar);
                SqlParameter MRepCondition = new SqlParameter(CustomerMaster._RepCondition, SqlDbType.NVarChar);

                MAction.Value = 4;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(Setting.CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, EmployeeMaster.PRO_EMPLOYEEMASTER, oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(), dr[1].ToString());
                        SearchList.Add(ListItem);
                    }
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return SearchList.ToArray();
        }

        public DataSet FillCombo(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 7;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, CustomerMaster.PRO_CUSTOMERMASTER, pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetRecordForReport(string StrCondition, out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pStrCond = new SqlParameter(CustomerMaster._RepCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
                pStrCond.Value = StrCondition;

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, CustomerMaster.PRO_CUSTOMERMASTER, pAction, pStrCond);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        #endregion
        public DMEmployeeMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
