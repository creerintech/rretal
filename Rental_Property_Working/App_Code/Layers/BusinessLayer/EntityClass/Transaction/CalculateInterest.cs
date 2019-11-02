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
/// Summary description for CalculateInterest
/// </summary>
namespace Build.EntityClass
{
    public class CalculateInterest
    {
        public long BookingId { get; set; }
        public long PCId { get; set; }
        public string AsOnDate { get; set; }
        public string BuildingName { get; set; }
        public int CalCulateFromStart { get; set; }

        public CalculateInterest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
