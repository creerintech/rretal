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

namespace Build.DataModel
{
    public class DMDashboard : Utility.Setting
    {
          public DataSet FillCombo(int EmpId, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FlatLayout._Action, SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);

                pAction.Value = 2;
                pEmpID.Value = EmpId;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure,"SP_DashBoardMaster", pAction, pEmpID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

          public int InsertRecord(ref FlatLayout Entity_Call, out string StrError)
          {
              int iInsert = 0;
              StrError = string.Empty;
              try
              {
                  SqlParameter pAction = new SqlParameter(FlatLayout._Action, SqlDbType.BigInt);
                  SqlParameter pPCId = new SqlParameter(FlatLayout._PCId, SqlDbType.BigInt);
                 
                  SqlParameter pCreatedBy = new SqlParameter(FlatLayout._UserId, SqlDbType.BigInt);
                  SqlParameter pCreatedDate = new SqlParameter(FlatLayout._LoginDate, SqlDbType.DateTime);

                  pAction.Value = 1;
                  pPCId.Value = Entity_Call.PCId;
                 
                  pCreatedBy.Value = Entity_Call.UserId;
                  pCreatedDate.Value = Entity_Call.LoginDate;

                  SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pCreatedBy, pCreatedDate };

                  Open(CONNECTION_STRING);
                  BeginTransaction();
                  iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DashBoardMaster", param);
                  if (iInsert > 0)
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
                  RollBackTransaction();
                  StrError = ex.Message;
              }
              finally
              {
                  Close();
              }
              return iInsert;
          }

          public int DeleteRecord()
          {
              int iInsert = 0;
            
              try
              {
                  SqlParameter pAction = new SqlParameter(FlatLayout._Action, SqlDbType.BigInt);
                 
                  pAction.Value = 4;
                                   
                  Open(CONNECTION_STRING);
                  BeginTransaction();
                  iInsert = SQLHelper.ExecuteNonQuerySingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DashBoardMaster", pAction);
                  if (iInsert > 0)
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
                  RollBackTransaction();
                  
              }
              finally
              {
                  Close();
              }
              return iInsert;
          }

          public DataSet GetList(string RepCondition, out string StrError)
          {
              StrError = string.Empty;

              DataSet DS = new DataSet();

              try
              {
                  SqlParameter pAction = new SqlParameter(FlatLayout._Action, SqlDbType.BigInt);
                  SqlParameter PrepCondition = new SqlParameter(FlatLayout._StrCondition, SqlDbType.NVarChar);

                  pAction.Value = 3;
                  PrepCondition.Value = RepCondition;

                  Open(CONNECTION_STRING);

                  DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure,"SP_DashBoardMaster", pAction, PrepCondition);


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

          public DataSet GetDashBoard(string RepCondition, out string StrError)
          {
              StrError = string.Empty;

              DataSet DS = new DataSet();

              try
              {
                  SqlParameter pAction = new SqlParameter(FlatLayout._Action, SqlDbType.BigInt);
                  SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                  pAction.Value = 1;
                  PrepCondition.Value = RepCondition;

                  Open(CONNECTION_STRING);

                  DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyDashBoard", pAction, PrepCondition);


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
        public DMDashboard()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string[] GetSuggestedRecordForProperty(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 2;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyDashBoard", oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(), dr[0].ToString());
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
    }
}
