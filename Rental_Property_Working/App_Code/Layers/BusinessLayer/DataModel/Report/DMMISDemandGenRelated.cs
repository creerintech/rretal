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
    public class DMMISDemandGenRelated:Utility.Setting
    {
        public DataSet FillComboReport(int EmpID, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);

                pAction.Value = 1;
                pEmpID.Value = EmpID;
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure,"MIS_DemandMaster", pAction, pEmpID);


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

        public DataSet FillTowerCombo(int ProjId, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pProjectID = new SqlParameter("@ProjectID", SqlDbType.BigInt);

                pAction.Value = 2;
                pProjectID.Value = ProjId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DemandMaster", pAction, pProjectID);


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

        public DataSet FillStageCombo(int ProjectID, string strBuildingNo, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pProjectID = new SqlParameter("@ProjectID", SqlDbType.BigInt);
                SqlParameter pTowerName = new SqlParameter("@TowerName", SqlDbType.NVarChar);


                pAction.Value = 3;
                pProjectID.Value = ProjectID;
                pTowerName.Value = strBuildingNo;

                SqlParameter[] Param = new SqlParameter[] { pAction, pProjectID, pTowerName };
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DemandMaster", Param);


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

        public DataSet GetDemandLetterReport(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@StrCondition", SqlDbType.NVarChar);
               
                    MAction.Value = 4;
              
                
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_DemandMaster", MAction, MRepCondition);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        #region WIP Update History MIS
        public DataSet FillCombo(int EmpID, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pEmpID = new SqlParameter("@EmpID", SqlDbType.BigInt);
                pAction.Value = 1;// 5;
                pEmpID.Value = EmpID;
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_WIPUpdateHistory", pAction, pEmpID);


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

        public DataSet FillBuildingCombo(int PCId, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pProjectID = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 2;
                pProjectID.Value = PCId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_WIPUpdateHistory", pAction, pProjectID);


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

        public DataSet FillFlatCombo(int PCId, string Building, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pProjectID = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                pAction.Value = 3;
                pProjectID.Value = PCId;
                pBuilding.Value = Building;

                SqlParameter[] param = { pAction, pProjectID, pBuilding };
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_WIPUpdateHistory", param);


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

        public DataSet GetWIPHistoryReport(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@StrCondition", SqlDbType.NVarChar);
                MAction.Value = 4;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_WIPUpdateHistory", MAction, MRepCondition);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        #endregion

        public DMMISDemandGenRelated()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
