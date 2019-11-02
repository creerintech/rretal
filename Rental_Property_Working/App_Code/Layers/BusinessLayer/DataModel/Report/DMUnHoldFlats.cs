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
using Build.DALSQLHelper;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Build.DataModel
{

    public class DMUnHoldFlats:Utility.Setting
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
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_UnHoldFlats", pAction);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet HoldFlatList(long pcid,out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter("@PCId", SqlDbType.BigInt);
               

                pAction.Value = 2;
                pPCId.Value = pcid;
                
                SqlParameter[] param = new SqlParameter[] { pAction, pPCId };
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_UnHoldFlats", param);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }
       

        public int UnholdFlats(long pcdetailid, out string StrError)
        {
            int iUpdate = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter("@PCDetilId", SqlDbType.BigInt);

                pAction.Value = 3;
                pPCDetailId.Value = pcdetailid;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                BeginTransaction();

                iUpdate = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_UnHoldFlats", param);

                if (iUpdate > 0)
                {
                    CommitTransaction();
                }
                else {
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
            return iUpdate;
           
 
        }
            public DMUnHoldFlats()
            {
                //
                // TODO: Add constructor logic here
                //
            }
     }

    
}
