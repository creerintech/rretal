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
/// Summary description for CompletionCertificateUpdate
/// </summary>
public class CompletionCertificateUpdate
{
    #region[Constants]
        public static string _Action = "@Action";
        public static string _ProjectId = "@ProjectId";
        public static string _FloorsNo = "@FloorNo";
        public static string _TowerName = "@TowerName";
        public static string _FlatNo = "@FlatNo";
        public static string _CompletionDate = "@CompletionDate";
        public static string _StrCondition = "@StrCond";
    #endregion

    #region[Definations]
        public int ProjectId { get; set; }
        public string TowerName { get; set; }
        public int FloorsNo { get; set; }
        public string FlatNo { get; set; }
        public DateTime CompletionDate { get; set; }
        private string m_StrCondition;
        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }
    #endregion

    #region[StoreProcedure]
        public const string Est_PRO_CompletionCertificateUpdate = "Est_PRO_CompletionCertificateUpdate";
    #endregion

    public CompletionCertificateUpdate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
