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
/// Summary description for StageMaster
/// </summary>
public class StageMaster
{
    #region[Constants]
    public static string _Action = "@Action";
    public static string _StageId = "@StageId";
    public static string _StageDesc = "@StageDesc";
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _IsSlab = "@IsSlab";
    public static string _SlabOrder = "@SlabOrder";
    public static string _mode = "@mode";
    public static string _searchCondition = "@searchCondition";
    public static string _NoOfSlabsToGenerate = "@GenerateNoOfSlabs";
    #endregion

    #region[Definations]
    private Int32 m_Action;

    public Int32 Action
    {
        get { return m_Action; }
        set { m_Action = value; }
    }
    public long NoOfSlabsToGenerate { get; set; }

    private Int32 m_StageId;
    public Int32 StageId
    {
        get { return m_StageId; }
        set { m_StageId = value; }
    }
    private string m_StageDesc;
    public string StageDesc
    {
        get { return m_StageDesc; }
        set { m_StageDesc = value; }
    }
    private Int32 m_UserId;
    public Int32 UserId
    {
        get { return m_UserId; }
        set { m_UserId = value; }
    }
    private DateTime m_LoginDate;
    public DateTime LoginDate
    {
        get { return m_LoginDate; }
        set { m_LoginDate = value; }
    }
    private Int32 m_IsDeleted;
    public Int32 IsDeleted
    {
        get { return m_IsDeleted; }
        set { m_IsDeleted = value; }
    }
    private Int32 m_IsSlab;
    public Int32 IsSlab
    {
        get { return m_IsSlab; }
        set { m_IsSlab = value; }
    }
    private Int32 m_SlabOrder;
    public Int32 SlabOrder
    {
        get { return m_SlabOrder; }
        set { m_SlabOrder = value; }
    }
    private Int32 m_mode;
    public Int32 Mode
    {
        get { return m_mode; }
        set { m_mode = value; }
    }
    private string m_searchCondition;
    public string SearchCondition
    {
        get { return m_searchCondition; }
        set { m_searchCondition = value; }
    }
    #endregion

    #region[Store Procedure]
    public static string Est_PRO_StageMaster = "SP_ProjectStage";
    #endregion

	public StageMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
