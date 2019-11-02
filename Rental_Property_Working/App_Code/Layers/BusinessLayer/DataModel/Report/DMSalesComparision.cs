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
    public class DMSalesComparision : Utility.Setting
    {
        public DataSet GetSalescompReport(string Fromdate, string Todate, string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter Mstart = new SqlParameter("@start", SqlDbType.DateTime);
                SqlParameter Mend = new SqlParameter("@end", SqlDbType.DateTime);

                MAction.Value = 1;
                MRepCondition.Value = RepCondition;
                Mstart.Value = Fromdate;
                Mend.Value=Todate;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, Mstart, Mend };

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SaleCompareReport", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetAverageSaleReport(string Fromdate, string Todate, string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter Mstart = new SqlParameter("@start", SqlDbType.DateTime);
                SqlParameter Mend = new SqlParameter("@end", SqlDbType.DateTime);

                MAction.Value = 2;
                MRepCondition.Value = RepCondition;
                Mstart.Value = Fromdate;
                Mend.Value = Todate;

                SqlParameter[] param = new SqlParameter[] { MAction, MRepCondition, Mstart, Mend };

                Open(Setting.CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SaleCompareReport", param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }
    }
}
