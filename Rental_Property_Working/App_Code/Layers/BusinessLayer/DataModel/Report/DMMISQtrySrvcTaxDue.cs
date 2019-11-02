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
/// Summary description for DMMISQtrySrvcTaxDue
/// </summary>

namespace Build.DataModel
{
    public class DMMISQtrySrvcTaxDue : Utility.Setting
    {
        public DataSet getDataForGrid(long BookingId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter MBookingId = new SqlParameter("@BookingId", SqlDbType.BigInt);
                //SqlParameter MShedule = new SqlParameter("@schedule", SqlDbType.BigInt);
                //SqlParameter MPCDId = new SqlParameter("@PCId", SqlDbType.BigInt);
                //SqlParameter MBuilding = new SqlParameter("@Building", SqlDbType.NVarChar);

                MAction.Value = 2;
                //MRepCondition.Value = RepCondition;
                MBookingId.Value = BookingId;
                //MShedule.Value = schedule;
                //MPCDId.Value = pcid;
                //MBuilding.Value = building;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MBookingId };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_QtrySrvcTaxDue", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetBookingId(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 1;
                MRepCondition.Value = RepCondition;

                Open(Setting.CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_QtrySrvcTaxDue", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }


        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 3;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_QtrySrvcTaxDue", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }


        public DataSet GetBuilding(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 4;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_QtrySrvcTaxDue", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetCustTowerWise(int ID,string build, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pbuild = new SqlParameter("@Building", SqlDbType.NVarChar);

                pAction.Value = 5;
                pId.Value = ID;
                pbuild.Value = build;

                Open(CONNECTION_STRING);
                SqlParameter[] param = new SqlParameter[] { pAction, pId,pbuild };
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "MIS_QtrySrvcTaxDue",param );

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DMMISQtrySrvcTaxDue()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}