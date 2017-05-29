﻿using CrystalDecisions.CrystalReports.Engine;
using MWeb.App_Code.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MWeb
{
    public partial class ReportHolderPDF : System.Web.UI.Page
    {
        ReportDocument ObjReportClientDocument = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GetReportDocument();
            }

            ShowPDF();
        }

        private void ShowPDF()
        {
            System.IO.Stream oStream = null;
            byte[] byteArray = null;
            oStream = ObjReportClientDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(byteArray);
            Response.Flush();
            Response.Close();
            ObjReportClientDocument.Close();
            ObjReportClientDocument.Dispose();
        }

        private void GetReportDocument()
        {
            ReportBase objReportBase = new ReportBase();
            string sRptFolder = string.Empty;
            string sRptName = string.Empty;

            ArrayList ParameterArrayList = new ArrayList();
            ParameterArrayList = (ArrayList)Session["parameterArrayList"];
            sRptName = Request.QueryString["sRptName"];

            sRptFolder = Server.MapPath("~/Reports");


            ObjReportClientDocument = objReportBase.PFSubReportConnectionMainParameter(sRptName, ParameterArrayList, sRptFolder);
            foreach (Section oSection in ObjReportClientDocument.ReportDefinition.Sections)
            {
                foreach (ReportObject obj in oSection.ReportObjects)
                {
                    FieldObject field;
                    field = ObjReportClientDocument.ReportDefinition.ReportObjects[obj.Name] as FieldObject;

                    if (field != null)
                    {
                        Font oFon1 = new Font("Arial Narrow", field.Font.Size - 1F);
                        Font oFon2 = new Font("Arial", field.Font.Size - 1F);

                        if (oFon1 != null)
                        {
                            field.ApplyFont(oFon1);
                        }
                        else if (oFon2 != null)
                        {
                            field.ApplyFont(oFon2);
                        }
                    }
                }
            }
        }
    }
}