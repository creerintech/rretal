using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using System.Drawing;
//using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using Build.Utility;
using Build.DALSQLHelper;
using Build.DB;
using System.Net.Mime;
#region Pdf
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
#endregion


/// <summary>
/// Summary description for CommanFunction
/// </summary>
namespace Build.Utility
{

 #region [Comman Function]
    public class CommanFunctionPDF : Build.Utility.Setting
    {     
        /*/////
        public void GeneratePDF(string Imagepath, string fileName,  string HeaderName, GridView GridReport, Page oPage)
        {
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            document.SetMargins(3, 3, 3, 3);
            try
            {
                oPage.Response.Clear();  
                PdfWriter.GetInstance(document, oPage.Response.OutputStream);
                // generates the grid first
                StringBuilder strB = new StringBuilder();
                StringBuilder strB1 = new StringBuilder();
                string str = string.Empty;
                str = " <table width='100%' ><tr><td align='center'><b>" + HeaderName + "</b></td></tr></table><br><br>";
                strB.Append(str);               
                document.Open();
                using (StringWriter sWriter = new StringWriter(strB))
                {
                using (HtmlTextWriter htWriter = new HtmlTextWriter(sWriter))
                      {
                      GridReport.RenderControl(htWriter);                            
                      }
                }                
                // now read the Grid html one by one and add into the document object
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Imagepath);
                    document.Add(gif);
                    List<IElement> list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    foreach (IElement elm in list)
                    {
                        document.Add(elm);                        
                    }
                }
               oPage.Response.ContentType = "application/pdf";
               oPage.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
               oPage.Response.Flush();
               oPage.Response.End();
            }
            catch (Exception ee)
            {
            }
            finally
            {
                document.Close();
            }
        }
        */
        public void GeneratePDFNew(string Imagepath, string fileName, string HeaderName, GridView GridReport, Page oPage)
        {
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            document.SetMargins(20, 20, 20, 20);
            
            try
            {
               // oPage.Response.Clear();
                PdfWriter.GetInstance(document, oPage.Response.OutputStream);
                // generates the grid first
                StringBuilder strB = new StringBuilder();
                StringBuilder strB1 = new StringBuilder();
                string str = string.Empty;
                str = "<table width='100%' ><tr><td align='center'><b>" + HeaderName + "</b></td></tr></table><br><br>";
                strB.Append(str);
                document.Open();
                using (StringWriter sWriter = new StringWriter(strB))
                {
                    using (HtmlTextWriter htWriter = new HtmlTextWriter(sWriter))
                    {
                        GridReport.RenderControl(htWriter);
                    }
                }
               
                // now read the Grid html one by one and add into the document object
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Imagepath);
                    document.Add(gif);
                    List<IElement> list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    foreach (IElement elm in list)
                    {
                        document.Add(elm);
                    }
                }
               // oPage.Response.ContentType = "application/pdf";
               // oPage.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
              //  oPage.Response.Flush();
              //  oPage.Response.End();
            }
            catch (Exception ee)
            {
            }
            finally
            {
                document.Close();
            }
        }
       
        public void GeneratePDFNewA2(string Imagepath, string fileName, string HeaderName, GridView GridReport, Page oPage)
        {
            var document = new Document(PageSize.A2, 50, 50, 25, 25);
            document.SetMargins(20, 20, 20, 20);

            try
            {
                // oPage.Response.Clear();
                PdfWriter.GetInstance(document, oPage.Response.OutputStream);
                // generates the grid first
                StringBuilder strB = new StringBuilder();
                StringBuilder strB1 = new StringBuilder();
                string str = string.Empty;
                str = "<table width='100%' ><tr><td align='center'><b>" + HeaderName + "</b></td></tr></table><br><br>";
                strB.Append(str);
                document.Open();
                using (StringWriter sWriter = new StringWriter(strB))
                {
                    using (HtmlTextWriter htWriter = new HtmlTextWriter(sWriter))
                    {
                        GridReport.RenderControl(htWriter);
                    }
                }

                // now read the Grid html one by one and add into the document object
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Imagepath);
                    document.Add(gif);
                    List<IElement> list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    foreach (IElement elm in list)
                    {
                        document.Add(elm);
                    }
                }
                // oPage.Response.ContentType = "application/pdf";
                // oPage.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                //  oPage.Response.Flush();
                //  oPage.Response.End();
            }
            catch (Exception ee)
            {
            }
            finally
            {
                document.Close();
            }
        }
       
        public CommanFunctionPDF()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
#endregion
}