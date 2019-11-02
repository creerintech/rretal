using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Build.EntityClass
{
    public class BrokerWise
    {


        #region[constants]
        public static string _Action = "@Action";
        public static string _BookingId = "@BookingId";
        public static string _PCId = "@PCId";
        public static string _EmpID = "@EmpID";
        public static string _Building = "@Building";
        public static string _PCDetailId = "@PCDetailId";
        public static string _BookingDate = "@BookingDate";
        public static string _BrokerId = "@BrokerId";
        #endregion
       

        #region[Defination]


        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_Booking_TaxDtlsId;

        public Int32 Booking_TaxDtlsId
        {
            get { return m_Booking_TaxDtlsId; }
            set { m_Booking_TaxDtlsId = value; }
        }

        private Int32 m_BookingId;
        public Int32 BookingId
        {
            get { return m_BookingId; }
            set { m_BookingId = value; }
        }

        
        private DateTime m_BookingDate;
        public DateTime BookingDate
        {
            get { return m_BookingDate; }
            set { m_BookingDate = value; }
        }
        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }
        private Int32 m_PCId;
        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }

        private string m_Building;
        public string Building
        {
            get { return m_Building; }
            set { m_Building = value; }
        }

        private Int32 m_PCDetailId;
        public Int32 PCDetailId
        {
            get { return m_PCDetailId; }
            set { m_PCDetailId = value; }
        }

        private Int32 m_BrokerId;
        public Int32 BrokerId
        {
            get { return m_BrokerId; }
            set { m_BrokerId = value; }
        }
        #endregion

        #region[StoredProcedure]
        public static string MIS_BrokerWiseDetails = "MIS_BrokerWiseDetails";
        #endregion


        public BrokerWise()
        {

        }
    }
}