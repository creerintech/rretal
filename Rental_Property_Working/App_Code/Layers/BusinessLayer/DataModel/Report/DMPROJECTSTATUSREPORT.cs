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
/// Summary description for DMPROJECTSTATUSREPORT
/// </summary>
/// 
namespace Build.DataModel
{
    public class DMPROJECTSTATUSREPORT : Utility.Setting
    {

        public DataSet FillCombo(out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 1;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
        public DataSet FillComboTOWERStage(int PID, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pProjectID = new SqlParameter("@PCId", SqlDbType.BigInt);
                pAction.Value = 2;
                pProjectID .Value = PID;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction, pProjectID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet FillComboCustomerUNIT(string Tname,int TID, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pTOWERID = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter pTOWER = new SqlParameter("@TowerName", SqlDbType.VarChar);
                pAction.Value = 3;
                pTOWERID.Value = TID;
                pTOWER.Value=Tname;
                SqlParameter[] param = new SqlParameter[] { pAction, pTOWERID, pTOWER };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetEnquiryReport(string RepCondition, string PCID,int Id ,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PPCID = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter MPCID = new SqlParameter("@StrCondition2", SqlDbType.NVarChar);
                SqlParameter MRepCondition = new SqlParameter("@StrCondition", SqlDbType.NVarChar);
                MAction.Value = 4;
                MPCID.Value =  PCID;
                PPCID.Value = Id;
                MRepCondition.Value = RepCondition;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, MPCID, PPCID };
                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

            }
            catch (Exception ex)
             {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        /// <summary>
        /// For Dash Board Collection Report
        /// </summary>
        /// <param name="RepCondition"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        /// 
        public DataSet GetDashboardsalesReport(string RepCondition, string PCID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PPCID = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter MPCID = new SqlParameter("@StrCondition2", SqlDbType.NVarChar);
                SqlParameter MRepCondition = new SqlParameter("@StrCondition", SqlDbType.NVarChar);
                MAction.Value = 4;
                MPCID.Value = PCID;
                PPCID.Value = 1;
                MRepCondition.Value = RepCondition;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, MPCID, PPCID };
                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }


        public DataSet GetEnquiryReportGraph(string RepCondition,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@StrCondition", SqlDbType.NVarChar);

                MAction.Value = 5;
                MRepCondition.Value = RepCondition;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet PROJECTWISEGraph(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@StrCondition", SqlDbType.NVarChar);

                MAction.Value = 8;
                MRepCondition.Value = RepCondition;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition };
                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        /// <summary>
        /// Month Wise project sales Report
        /// </summary>
        /// <param name="strError"></param>
        /// <returns></returns>
        /// 


         public DataSet MonthWiseSaleGrid(out string strError)
        {
            DataSet DS = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 15;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;

        }

         public DataSet MonthWiseSaleGridDUEUNIT(out string strError)
         {
             DataSet DS = new DataSet();
             strError = string.Empty;
             try
             {
                 SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                 pAction.Value = 10;

                 Open(CONNECTION_STRING);
                 DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction);

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
             return DS;

         }





        public DataSet FillComboProject(out string strError)
        {
            DataSet DS = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 6;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetProjectType(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@PCId", SqlDbType.BigInt);

                pAction.Value = 7;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet TestReport(int PCID, string Tname, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {

                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
                SqlParameter PTowerName = new SqlParameter("@TowerName", SqlDbType.NVarChar);
                pAction.Value = 12;
                pPCId.Value = PCID;
                PTowerName.Value = Tname;

                Open(CONNECTION_STRING);
                SqlParameter[] oparam = new SqlParameter[] { pAction, pPCId, PTowerName };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", oparam);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet BINDTowerReport(int id ,out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {

                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PPCID = new SqlParameter("@PCId", SqlDbType.BigInt);
                pAction.Value = 13;
                PPCID.Value = id;


                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction, PPCID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet HeaderTitleReport(string Tname, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {

                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PTowerName = new SqlParameter("@TowerName", SqlDbType.NVarChar);
                pAction.Value = 14;
                PTowerName.Value = Tname;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", pAction, PTowerName);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

         


        //public DataSet GetSalescompReport(string Fromdate, string Todate, string RepCondition, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
        //        SqlParameter Mstart = new SqlParameter("@start", SqlDbType.DateTime);
        //        SqlParameter Mend = new SqlParameter("@end", SqlDbType.DateTime);

        //        MAction.Value = 1;
        //        MRepCondition.Value = RepCondition;
        //        Mstart.Value = Fromdate;
        //        Mend.Value = Todate;

        //        SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, Mstart, Mend };

        //        Open(Setting.CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet GetAverageSaleReport(string Fromdate, string Todate, string RepCondition, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
        //        SqlParameter Mstart = new SqlParameter("@start", SqlDbType.DateTime);
        //        SqlParameter Mend = new SqlParameter("@end", SqlDbType.DateTime);

        //        MAction.Value = 2;
        //        MRepCondition.Value = RepCondition;
        //        Mstart.Value = Fromdate;
        //        Mend.Value = Todate;

        //        SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, Mstart, Mend };

        //        Open(Setting.CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectStatusReport", param);

        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        public DMPROJECTSTATUSREPORT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
