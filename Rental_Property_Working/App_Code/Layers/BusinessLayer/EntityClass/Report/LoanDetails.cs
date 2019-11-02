using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoanDetails
/// </summary>
public class LoanDetails
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
    public static string _BankLoanDate = "@BankLoanDate";
    public static string _ActualBankLoanDate = "@ActualBankLoanDate";
    public static string _Comments = "@Comments";
    public static string _AmountReq = "@AmountReq";
    public static string _Institute = "@Institute";
    public static string _Project = "@Project";
   

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


    private DateTime m_BankLoanDate;
    public DateTime BankLoanDate
    {
        get { return m_BankLoanDate; }
        set { m_BankLoanDate = value; }
    }
    private DateTime m_ActualBankLoanDate;
    public DateTime ActualBankLoanDate
    {
        get { return m_ActualBankLoanDate; }
        set { m_ActualBankLoanDate = value; }
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

    private string m_Project;
    public string Project
    {
        get { return m_Project; }
        set { m_Project = value; }
    }

    private Int32 m_PCDetailId;
    public Int32 PCDetailId
    {
        get { return m_PCDetailId; }
        set { m_PCDetailId = value; }
    }

    private Int32 m_Institute;
    public Int32 Institute
    {
        get { return m_Institute; }
        set { m_Institute = value; }
    }
    private string m_Comments;
    public string Comments
    {
        get { return m_Comments; }
        set { m_Comments = value; }
    }

    private decimal m_AmountReq;
    public decimal AmountReq
    {
        get { return m_AmountReq; }
        set { m_AmountReq = value; }
    }
    #endregion

    #region[StoredProcedure]
    public static string MIS_LoanDetails = "MIS_LoanDetails";
    #endregion


	public LoanDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}